using UnityEngine;

public class RectTransformClamp : MonoBehaviour
{
    public float padding = 10;
    public float elementSize = 640;
    public float viewSize = 1280;

    private RectTransform rt;
    private float contentSize;
    private int amountElements;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        amountElements = rt.childCount;
        contentSize = ((amountElements * (elementSize + padding)) - viewSize) * rt.localScale.x;

        if (rt.localPosition.x > padding)
        {
            rt.localPosition = new Vector3(padding, rt.localPosition.y, rt.localPosition.z);
        }
        else if(rt.localPosition.x < -contentSize)
        {
            rt.localPosition = new Vector3(-contentSize, rt.localPosition.y, rt.localPosition.z);
        }
    }
}
