using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] TMP_Text  _scoreText;
    [SerializeField] TMP_Text _highScoreText;
    [SerializeField] TMP_Text _MultiplierText;

    int _score;
    int _highScore;
    private float _scoreMultiplierExpiration;
    private int _killMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        enemymovement.Died += Enemy_Died;
        _highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreText.SetText("High Score:  " + _highScore);

        
    }

    // Update is called once per frame
    void Enemy_Died ()
    {
        UpdateKillMultiplier();
        
        _score += _killMultiplier;


        if (_score > _highScore)
        {
            _highScore = _score;
            _highScoreText.SetText("High Score: " + _highScore);
            PlayerPrefs.SetInt("HighScore", _highScore);


        }
        _scoreText.SetText(_score.ToString());



    }

    void UpdateKillMultiplier()
    {
        if (Time.time <= _scoreMultiplierExpiration)
        {
            _killMultiplier++;
        }
        else
        {
            _killMultiplier = 1;
        }

        _scoreMultiplierExpiration = Time.time + 1f;


        _MultiplierText.SetText("x " + _killMultiplier);


        if (_killMultiplier < 3)
            _MultiplierText.color = Color.white;
        else if (_killMultiplier < 10)
            _MultiplierText.color = Color.green;
        else if (_killMultiplier < 20)
            _MultiplierText.color = Color.yellow;
        else if (_killMultiplier < 30)
            _MultiplierText.color = Color.red;






    }





}
