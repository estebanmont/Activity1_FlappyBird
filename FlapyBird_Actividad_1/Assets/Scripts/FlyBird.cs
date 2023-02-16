using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rb;
    private SpriteRenderer bird;
    [SerializeField] Sprite[] birdColors;
    private Animator anim;
    [SerializeField] private RuntimeAnimatorController[] birdAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bird = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

    }
    void Start()
    {
        bird.sprite = birdColors[Random.Range(0, birdColors.Length)];
        if (bird.sprite == birdColors[0]) anim.runtimeAnimatorController = birdAnim[0];
        else if (bird.sprite == birdColors[1]) anim.runtimeAnimatorController = birdAnim[1];
        else if (bird.sprite == birdColors[2]) anim.runtimeAnimatorController = birdAnim[2];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * velocity;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * velocity;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
