using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public GameObject menuScreen;

    public Button startButton;

    public Text scoreText;

    private int score = 0;

    public bool IsStarted { get; private set;  } = false; // запущена ли игра

    public static GameControllerScript Instance { get; private set; }

    public void IncreaseScore(int increment)
        => this.scoreText.text = $"Score: {this.score += increment}";

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        this.startButton.onClick.AddListener(() =>
        {
            this.menuScreen.SetActive(false);
            this.IsStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}