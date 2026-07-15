using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float border = 2.3f;
    public bool gameOver;
    public GameObject finishLine;
    public GameManager gameManager;
    public Animator animator;
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
            // if we wanna move left/right AND we're not at the border then we move left/right
            transform.Translate(Vector3.forward * speed * speedCoeff() * Time.deltaTime); // going forward a bit slower to normalize the speed
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime); // going left or right
        }
        else // if the player is at the finish line the game is over
        {
            gameOver = true;
            gameManager.gameOver();
            animator.SetBool("isGameOver", true);
        }
    }

    float speedCoeff()
    {
        if (horizontalInput == 0) return 1;
        else return 0.7f; // if the player is going sidewards the horizontal input is normalized
    }
}
