using UnityEngine;

public enum SWIPE_DIRECTION
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8
}

public class InputManager : Singelton<InputManager>
{
    public SWIPE_DIRECTION SWIPE_DIRECTION { get; private set; }

    public bool MouseButtonDown { get { return Input.GetMouseButtonDown(0); } }
    public bool MouseButton { get { return Input.GetMouseButton(0); } }
    public bool MouseButtonUp { get { return Input.GetMouseButtonUp(0); } }

    public float HORIZONTAL_AXIS { get{ return Input.GetAxis("Horizontal"); } }
    public float VERTICAL_AXIS { get { return Input.GetAxis("Vertical"); } }

    private Vector3 touchPosition;
    private readonly float swipeResistanceX = 200.0f;
    private readonly float swipeResistanceY = 100.0f;

    public bool IsSwiping(SWIPE_DIRECTION swipeDirection)
    {
        return (SWIPE_DIRECTION & swipeDirection) == swipeDirection;
    }

    private void Update()
    {
        SWIPE_DIRECTION = SWIPE_DIRECTION.NONE;

        if (MouseButtonDown)
        {
            touchPosition = Input.mousePosition;
        }

        if (MouseButtonUp)
        {
            var deltaSwipe = touchPosition - Input.mousePosition;

            if (Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                SWIPE_DIRECTION |= (deltaSwipe.x < 0 ? SWIPE_DIRECTION.RIGHT : SWIPE_DIRECTION.LEFT);
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
            {
                SWIPE_DIRECTION |= (deltaSwipe.y < 0 ? SWIPE_DIRECTION.UP : SWIPE_DIRECTION.DOWN);
            }
        }
    }
}
