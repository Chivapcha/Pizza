using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float border = 2.3f;
    public GameObject finishLine;
    public bool gameOver;
    public GameManager gameManager;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is not at the finish line they can move
        if (transform.position.z < finishLine.transform.position.z)
        {

            // if we wanna move left/right AND we're not at the border then we move left/right
            if (Keyboard.current.aKey.isPressed && transform.position.x >= -border)
            {
                transform.Translate(Vector3.forward * speed * 0.7f * Time.deltaTime); // going forward a bit slower to compensate the speed of going left
                transform.Translate(Vector3.left * Time.deltaTime); // going left
            }
            else if (Keyboard.current.dKey.isPressed && transform.position.x <= border)
            {
                transform.Translate(Vector3.forward * speed * 0.7f * Time.deltaTime); // going forward a bit slower to compensate the speed of going right
                transform.Translate(Vector3.right * Time.deltaTime); // going left
            }
            else transform.Translate(Vector3.forward * speed * Time.deltaTime); // moving forward at times 1 speed
        }
        else
        {
            gameOver = true;
            gameManager.gameOver();
            animator.SetBool("isGameOver", true);
        }
    }
}
