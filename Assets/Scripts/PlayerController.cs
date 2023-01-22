using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text result;
    public GameObject grid;
    private int moves = 0;
    private int[,] occupied = { {-1, -1, -1}, {-1, -1, -1}, {-1, -1, -1} };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGame();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public int getResult(){
        for(int i = 0; i < 3; i++){
            if(occupied[i, 0] == 0 && occupied[i, 1] == 0 && occupied[i, 2] == 0){
                result.text = "Playe 2 Won";
                return 0;
            }
            if(occupied[i, 0] == 1 && occupied[i, 1] == 1 && occupied[i, 2] == 1){
                result.text = "Playe 1 Won";
                return 1;
            }
            if(occupied[0, i] == 0 && occupied[1, i] == 0 && occupied[2, i] == 0){
                result.text = "Playe 2 Won";
                return 0;
            }
            if(occupied[0, i] == 1 && occupied[1, i] == 1 && occupied[2, i] == 1){
                result.text = "Playe 1 Won";
                return 1;
            }
        }
        if(occupied[0, 0] == 0 && occupied[1, 1] == 0 && occupied[2, 2] == 0){
            result.text = "Playe 2 Won";
            return 0;
        }
        if(occupied[0, 0] == 1 && occupied[1, 1] == 1 && occupied[2, 2] == 1){
            result.text = "Playe 1 Won";
            return 1;
        }
        if(occupied[2, 0] == 0 && occupied[1, 1] == 0 && occupied[0, 2] == 0){
            result.text = "Playe 2 Won";
            return 0;
        }
        if(occupied[2, 0] == 1 && occupied[1, 1] == 1 && occupied[0, 2] == 1){
            result.text = "Playe 1 (X) Won";
            return 1;
        }
        if(moves == 9){
            result.text = "It's a Draw!";
            return 2;  // Draw
        }
        return -1; // No Result
    }

    public void updateButtonText(GameObject btn){
        GameObject moveChar = btn.transform.GetChild(moves % 2).gameObject;
        moveChar.SetActive(true);
        moves++;
        int btnNum = btn.name[0] - '0';
        occupied[((btnNum - 1) / 3), (btnNum - 1) % 3] = moves % 2;
        int result = getResult();
        if(result >= 0){
            grid.SetActive(false);
        }
    }

    public void quitGame(){
        Application.Quit();
    }
}
