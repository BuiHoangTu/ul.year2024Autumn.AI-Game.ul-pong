using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D rigidbody_;
    public float speed = 10f;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }
}
