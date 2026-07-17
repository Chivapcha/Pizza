using UnityEngine;

public class Spinner_Collector : MonoBehaviour
{
    public int points; // is set in the inspector window
    [SerializeField] float speed = 40.0f;
    [SerializeField] float volume = 0.5f;
    [SerializeField] AudioClip pickupSound;
    [SerializeField] ParticleSystem collectEffect;
    [SerializeField] AudioSource playerAudio;

    private GameManager gameManager;
    private PizzaController pizzaController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pizzaController = GameObject.Find("Pizza").GetComponent<PizzaController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAudio = other.GetComponent<AudioSource>(); // we set the audio source so that the collect sound comes from the player
            playerAudio.PlayOneShot(pickupSound, volume);
            Instantiate(collectEffect, transform.position, transform.rotation);
            // Debug.Log("Object collected : rank " + points);
            gameManager.AddPoints(points); // GameManager.cs
            pizzaController.ShowIngredient(name); // enables the ingredient collected on the pizza at the finish line in PizzaController.cs

            Destroy(gameObject);
        }
    }
}
