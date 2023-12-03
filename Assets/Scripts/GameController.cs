
using System.Collections;
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public Transform gameOverText;

    private const int EXTRA_LIFE_SCORE = 10000;

    private const int STARTING_WAVE = 1;

    public const int LEFT_TORPEDO_SHIP_POINTS = 200;
    public const int CENTRE_TORPEDO_SHIP_POINTS = 100;
    public const int RIGHT_TORPEDO_SHIP_POINTS = 150;

    private const float START_DELAY = 1f;
    private const float RESTART_DELAY = 5f;

    private int player1Score;
    [HideInInspector] public int player1ExtraLives;
    private int player1ExtraLifePoints;

    private int player2Score; 

    private int highScore;

    private int waveNumber;
    [HideInInspector] public int enemiesInWave;
    [HideInInspector] public int numberOfEnemiesDestroyed;
    private int enemyWaveCountIncrease;

    [HideInInspector] public bool canPlay;
    [HideInInspector] public bool gameOver;

    [HideInInspector] public bool twoPlayer;



    private void Awake()
    {
        gameController = this;
    }


    void Start()
    {
        StartUp();
    }


    void Update()
    {
        KeyboardController();
    }


    private void StartUp()
    {
        canPlay = false;
        gameOver = true;

        twoPlayer = false;

        AtlantisController.atlantisController.baseActive = new bool[AtlantisController.atlantisController.atlantisBase.Length];

        EnemyController.enemyController.DisableEnemyShips();

        ResetPlayerScore();

        highScore = 0;

        ScoreController.scoreController.InitialiseHighScore();

        gameOverText.gameObject.SetActive(true);
    }


    private void Initialise()
    {
        EnemyController.enemyController.DisableEnemyShips();

        ResetPlayerScore();

        Player1Controller.player1Controller.Initialise();

        if (twoPlayer)
        {
            Player2Controller.player2.Initialise();
        }

        AtlantisController.atlantisController.numberOfBases = 6;

        AtlantisController.atlantisController.BuildAtlantis();

        waveNumber = STARTING_WAVE;
        enemiesInWave = EnemyController.WAVE_START_ENEMY_COUNT;

        numberOfEnemiesDestroyed = 0;

        StartCoroutine(ReadyPlayerOne(START_DELAY));
    }


    private IEnumerator ReadyPlayerOne(float startDelay)
    {
        gameOverText.gameObject.SetActive(false);

        yield return new WaitForSeconds(startDelay);

        gameOver = false;
        canPlay = true;
    }


    private int WaveEnemyIncrease()
    {
        enemyWaveCountIncrease = Random.Range(EnemyController.MINIMUM_WAVE_ENEMY_INCREASE, EnemyController.MAXIMUM_WAVE_ENEMY_INCREASE);

        return enemyWaveCountIncrease;
    }


    private void ResetPlayerScore()
    {
        player1Score = 0;

        player1ExtraLives = 0;
        player1ExtraLifePoints = EXTRA_LIFE_SCORE;

        player2Score = 0;

        ScoreController.scoreController.InitialiseScores();
    }


    private void KeyboardController()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartOnePlayer();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartTwoPlayer();
            }
        }
    }


    private void StartOnePlayer()
    {
        Initialise();
    }


    private void StartTwoPlayer()
    {
        twoPlayer = true;

        Initialise();
    }


    public void GameOver()
    {
        canPlay = false;

        EnemyController.enemyController.DisableEnemyShips();

        AtlantisController.atlantisController.EscapeAtlantis();
    }


    public void NextWave()
    {
        canPlay = false;

        EnemyController.enemyController.DisableEnemyShips();

        TallyBonusPoints();

        AtlantisController.atlantisController.RebuildAtlantis();

        waveNumber += 1;

        enemiesInWave = EnemyController.WAVE_START_ENEMY_COUNT + WaveEnemyIncrease();

        if (enemiesInWave > EnemyController.MAXIMUM_ENEMIES)
        {
            enemiesInWave = EnemyController.MAXIMUM_ENEMIES;
        }

        numberOfEnemiesDestroyed = 0;

        Player1Controller.player1Controller.Initialise();

        StartCoroutine(ReadyPlayerOne(RESTART_DELAY));
    }


    private void TallyBonusPoints()
    {
        if (!AtlantisController.atlantisController.shieldControllerDestroyed)
        {
            UpdatePlayer1Score(AtlantisController.SHIELD_CONTROLLER_BONUS_POINTS);
        }

        UpdatePlayer1Score(AtlantisController.atlantisController.numberOfBases * AtlantisController.BASE_BONUS_POINTS);
    }


    public void UpdatePlayer1Score(int points)
    {
        player1Score += points;
        
        ScoreController.scoreController.UpdateScoreDisplay(player1Score, ScoreController.PLAYER_1);

        if (player1Score >= player1ExtraLifePoints)
        {
            player1ExtraLives += 1;
            
            player1ExtraLifePoints += EXTRA_LIFE_SCORE;
        }
    }


    public void UpdatePlayer2Score(int points)
    {
        player2Score += points;

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, ScoreController.PLAYER_2);
    }


    public void UpdateHighScore()
    {
        if (player1Score > highScore)
        {
            highScore = player1Score;
        }

        if (player2Score > highScore)
        {
            highScore = player2Score;
        }

        ScoreController.scoreController.UpdateScoreDisplay(highScore, ScoreController.HIGH_SCORE);
    }


} // end of class
