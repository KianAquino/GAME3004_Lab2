using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;

    [SerializeField] Text _scoreText;

    private int _score = 0;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);

        _instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        _scoreText.text = $"SCORE {_score}";
    }

    public static void AddScore(int score)
    {
        _instance._score += score;

        _instance.RefreshUI();
    }
}
