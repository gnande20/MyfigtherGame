using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Text titleText;
    [SerializeField] private Text authorText;

    void Start()
    {
        // Animation simple du titre
        titleText.text = "MY FIGHTER GAME";
        authorText.text = "Créé par Camille Prospère © 2025";

        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Charge la scène du jeu (ex: "ArenaScene")
        SceneManager.LoadScene("ArenaScene");
    }
}
