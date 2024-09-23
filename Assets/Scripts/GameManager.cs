using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _player1Score = 0;
    private int _player2Score = 0;
    public Ball ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;


    public void Player1Scored()
    {
        _player1Score++;
        player1ScoreText.text = _player1Score.ToString();
        Debug.Log("Player 1 Scored! Score: " + _player1Score);
        ball.ResetPosition();
        ball.InitForce();
    }

    public void Player2Scored()
    {
        _player2Score++;
        player2ScoreText.text = _player2Score.ToString();
        Debug.Log("Player 2 Scored! Score: " + _player2Score);
        ball.ResetPosition();
        ball.InitForce();
    }

    public void NewMatch()
    {
        _player1Score = 0;
        _player2Score = 0;
    }

}
