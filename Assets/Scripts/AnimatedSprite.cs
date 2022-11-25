using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class NewBehaviourScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite[] sprites;

    public float animationTime = 0.25f;
    public int animationFrame { get; private set; }
    public bool loop = true

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
