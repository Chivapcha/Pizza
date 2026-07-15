using Unity.VisualScripting;
using UnityEngine;

public class Spinner_Collector : MonoBehaviour
{
    public int points;
    public float speed = 40.0f;
    public float volume = 0.5f;
    private AudioSource playerAudio;
    public AudioClip pickupSound;
    private GameManager gameManager;

    public ParticleSystem collectEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            gameManager.addPoints(points); // GameManager.cs

            Destroy(gameObject);
        }
    }
}
