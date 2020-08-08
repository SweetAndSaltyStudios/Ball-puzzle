using UnityEngine;

public class SaveState
{
    public string currentScene;
    public int currentPage;
    public int gold = 1000;
    public int completedLevel = 0;
}

public class SaveManager : Singelton<SaveManager>
{
    public SaveState saveState;

    public void Save()
    {
        PlayerPrefs.SetString("Save",ConvertHelper.Serialize<SaveState>(saveState));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            saveState = ConvertHelper.Deserialize<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            saveState = new SaveState();
            Save();
            Debug.Log("There was no Savestate ... Creating new one");
        }
    }

    public void CompleteLevel(int index)
    {
        if (saveState.completedLevel == index)
        {
            saveState.completedLevel++;
            Save();
        }
    }
}
