using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    [SerializeField] int _amount = 1;
    [SerializeField] AudioClip _audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreSystem.AddScore(_amount);
        AudioSystem.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        _amount = _amount < 1 ? 1 : _amount;
    }
}
