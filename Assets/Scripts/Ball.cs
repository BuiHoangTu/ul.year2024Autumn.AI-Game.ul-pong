using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 150f;
    private Rigidbody2D rigidbody_;
    private bool isStationary = true;

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
        rigidbody_.velocity = Vector2.zero;
        isStationary = true;
    }
    
    
    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetPosition();
    }

    public void InitForce()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? Random.Range(-1, 0.5f) : Random.Range(-0.5f, 1);

        Vector2 direction = new(x, y);
        rigidbody_.AddForce(direction * speed);

        isStationary = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStationary)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InitForce();
            }
        }
    }
}
