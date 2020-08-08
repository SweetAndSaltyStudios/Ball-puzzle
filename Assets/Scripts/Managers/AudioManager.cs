using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singelton<AudioManager>
{
    private AudioMixer audioMixer;
    private AudioMixerUpdateMode audioMixerUpdateMode;
    private AudioMixerSnapshot masterOn, masterOff;
    private AudioSource musicSource;

    [SerializeField]
    private AudioClip[] musicTracks;

    public bool isChanging { get; private set; }
    public AudioMixerSnapshot MasterOn { get { return masterOn; } }
    public AudioMixerSnapshot MasterOff { get { return masterOff; } }

    private void Awake()
    {
        audioMixer = GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer;          
        audioMixerUpdateMode = AudioMixerUpdateMode.UnscaledTime;
        audioMixer.updateMode = audioMixerUpdateMode;

        masterOn = audioMixer.FindSnapshot("MasterOn");
        masterOff = audioMixer.FindSnapshot("MasterOff");
        musicSource = GetComponent<AudioSource>();

        musicTracks = Resources.LoadAll<AudioClip>("MusicTracks");       
    }

    public void PlayMusicTrack(string musicTrack)
    {
        for (int i = 0; i < musicTracks.Length; i++)
        {
            if(musicTracks[i].name == musicTrack)
            {
                musicSource.clip = musicTracks[i];

                musicSource.loop = true;
                musicSource.Play();
                return;
            }
        }      
    }

    public void ChangeMusicTrack(AudioClip audioClip, float time = 1f)
    {
        if (isChanging)
            return;

        StartCoroutine(IChangeMusicTrack(audioClip, time));
    }

    private IEnumerator IChangeMusicTrack(AudioClip audioClip, float time = 1f)
    {
        isChanging = true;

        float volume = musicSource.volume;

        masterOff.TransitionTo(time);

        yield return new WaitForSeconds(time);

        musicSource.Stop();
        musicSource.clip = audioClip;
        musicSource.loop = true;
        musicSource.Play();

        masterOn.TransitionTo(time);

        yield return new WaitForSeconds(time);

        isChanging = false;
    }
}
