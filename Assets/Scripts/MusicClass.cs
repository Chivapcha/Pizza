using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
