using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement;

    public GhostHome home;
    public GhostScatter scatter;
    public GhostChase chase;
    public GhostFrightened frightened;

    public GhostBehaviour initialBehavior;

    public Transform target;

    public int points = 200;


    public void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if(!this.home != this.initialBehavior)
        {
            this.home.Disable();
        }
        if(this.initialBehavior = null)
        {
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
