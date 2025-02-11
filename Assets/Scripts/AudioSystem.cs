using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    private static AudioSystem _instance;

    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);

        _instance = this;
    }

    public static void PlayOneShot(AudioClip audioClip)
    {
        _instance._audioSource.PlayOneShot(audioClip);
    }
}
