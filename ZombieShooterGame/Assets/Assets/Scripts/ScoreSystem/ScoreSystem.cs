using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] TMP_Text  _scoreText;
    [SerializeField] TMP_Text _highScoreText;
    
    int _score;
    int _highScore;

    // Start is called before the first frame update
    void Awake()
    {
        enemymovement.Died += Enemy_Died;
        _highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreText.SetText("High Score:  " + _highScore);

        
    }

    // Update is called once per frame
    void Enemy_Died ()
    {
        _score++;

        if(_score > _highScore)
        {
            _highScore = _score;
            _highScoreText.SetText("High Score: " + _highScore);
            PlayerPrefs.SetInt("HighScore", _highScore);

         
        }
        _scoreText.SetText(_score.ToString());
    }
}
