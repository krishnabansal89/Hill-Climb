using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    public CircleCollider2D head;
    public GameObject gocanvas;
    public carcontroller carcontroller;
    public AudioSource play;

    // Update is called once per frame
    private void Awake() {
        gocanvas.SetActive(false);
        Time.timeScale = 1f;
        play.volume = 0.4f;
        play.Play();
    }
    public void GameOver() {
        gocanvas.SetActive(true);
        play.volume = 0f;
        Time.timeScale = 0f;
        
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag !="fuel")
        {
            play.Play();
            GameOver();     
        }
        
    }
    private void FixedUpdate() {
        if(carcontroller.fuel <= 0 ){
            GameOver();
        }
    }
    }

