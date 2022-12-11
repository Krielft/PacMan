using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] ghosts;
    public GameObject pacman;
    public Transform pellets;

    public GameObject StartPosition;



    public int ghostMultiplier = 1;
    public int score;
    public int lives;

    private void Start()
    {
        NewGame();
    }
    private void Update()
    {
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Return)){
            NewGame();
        }
        
    }
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }
    private void NewRound()
    {
        foreach (Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState()
    {
        ResetGhostMultiplier();

        for (int i = 0; i < this.ghosts.Length; i++)

        {
            this.ghosts[i].gameObject.SetActive(true);
        }
        this.pacman.gameObject.SetActive(true);
        FindObjectOfType<Pacman>().transform.position = new Vector2(0, -8.5f);

        FindObjectOfType<Pacman>().transform.position = new Vector2(0, -8.5f);
        FindObjectOfType<Pacman>().transform.position = new Vector2(0, -8.5f);
        FindObjectOfType<Pacman>().transform.position = new Vector2(0, -8.5f);
        FindObjectOfType<Pacman>().transform.position = new Vector2(0, -8.5f);


        Debug.Log("Rejouer");
    }
    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }
    private void SetLives(int lives)
    {
        this.lives = lives;
        Debug.Log("Set Lives");
    }
    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * this.ghostMultiplier;
        SetScore(this.score + points);
        this.ghostMultiplier++;
    }
    public void PacmanEaten()
    {
       
        this.pacman.gameObject.SetActive(false);

        SetLives(lives - 1);
        Debug.Log("Mort");

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

        public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }
    
    public void PowerPelletEaten(PowerPellet pellet)
    {
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);

        //TODO: changing ghost state
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return (true);
            }
        }
        return false;
    }

    private void ResetGhostMultiplier()
    {
        
    }

}
