using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header ("SPEED :")]
    [Space]
    public float speed = 8.0f;
    [Range (0, 3)]
    public float speedMultiplier = 1.0f;
    
    [Header ("PHYSICS :")]
    [Space]
    public LayerMask obstacleLayer;
    public new Rigidbody2D rigidbody;

    [Header ("VECTOR :")]
    [Space]
    public Vector2 initialDirection;
    public Vector2 direction;
    public Vector2 nextDirection;
    public Vector3 startingPosition;
    public Vector2 position = new Vector2 (0.0f, -8.5f);

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }


    private void FixedUpdate()
    {
        position = this.rigidbody.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
            return hit.collider != null;
    }
}
