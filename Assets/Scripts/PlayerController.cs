using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject finishLine;
    [SerializeField] Animator animator;
    private GameManager gameManager;
    private InputSystem_Actions controls; // initialize the InputActions script
    private float horizontalInput;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    void OnEnable() // plays everytime the object (here player) is enabled
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = controls.Player.Move.ReadValue<Vector2>().x; // controls.Player.Move.ReadValue<Vector2> takes the x (a/d) and y (w/s) values,
                                                                       // here we only need the x (between -1 and 1)
        // if the player is not at the finish line they can move
        if (transform.position.z < finishLine.transform.position.z)
        {
            transform.Translate(Vector3.forward * speed * SpeedCoeff() * Time.deltaTime); // going forward with the SpeedCoeff calculated
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime); // going left or right
        }
        else // if the player is at the finish line the game is over
        {
            gameOver = true;
            gameManager.GameOver();
            animator.SetBool("isGameOver", true);
        }
    }

    float SpeedCoeff() // returns 1 if going straight or 0.7 if going sidewards in order to normalize the speed
    {
        if (horizontalInput == 0) return 1;
        else return 0.7f;
    }
}
