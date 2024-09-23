using UnityEngine;

public class PlayerPaddle : Paddle
{
    public ControlKeySet controlKeySet = ControlKeySet.Combined;
    private Vector2 direction;

    private void Update()
    {
        bool moveUp = false;
        bool moveDown = false;

        // Check which keys to use based on controlKeySet
        if (controlKeySet == ControlKeySet.WAndS || controlKeySet == ControlKeySet.Combined)
        {
            moveUp |= Input.GetKey(KeyCode.W);      // Check for W
            moveDown |= Input.GetKey(KeyCode.S);    // Check for S
        }

        if (controlKeySet == ControlKeySet.UpAndDown || controlKeySet == ControlKeySet.Combined)
        {
            moveUp |= Input.GetKey(KeyCode.UpArrow);    // Check for UpArrow
            moveDown |= Input.GetKey(KeyCode.DownArrow); // Check for DownArrow
        }

        // Set the direction based on input
        if (moveUp)
        {
            direction = Vector2.up;
        }
        else if (moveDown)
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }

    }

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rigidbody_.AddForce(direction * speed);
        }
        else
        {
            // Stop the paddle when no key is pressed by resetting the velocity
            rigidbody_.velocity = Vector2.zero;
        }
    }

}

public enum ControlKeySet
{
    WAndS,
    UpAndDown,
    Combined
}

public static class ControlKeySetExtensions
{
    public static KeyCode Up(this ControlKeySet controlKeySet)
    {
        return controlKeySet switch
        {
            ControlKeySet.WAndS => KeyCode.W,
            ControlKeySet.UpAndDown => KeyCode.UpArrow,
            ControlKeySet.Combined => KeyCode.W,
            _ => KeyCode.W
        };
    }

    public static KeyCode Down(this ControlKeySet controlKeySet)
    {
        return controlKeySet switch
        {
            ControlKeySet.WAndS => KeyCode.S,
            ControlKeySet.UpAndDown => KeyCode.DownArrow,
            ControlKeySet.Combined => KeyCode.S,
            _ => KeyCode.S
        };
    }
}