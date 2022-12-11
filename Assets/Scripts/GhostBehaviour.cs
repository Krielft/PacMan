using UnityEngine;

[RequireComponent(typeof(Ghost))]

public abstract class GhostBehaviour : MonoBehaviour
{
    public Ghost ghosts;
    public float duration;

    private void Awake()
    {
        this.ghosts = GetComponent<Ghost>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(this.duration);
    }
    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }
    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
    }
}
