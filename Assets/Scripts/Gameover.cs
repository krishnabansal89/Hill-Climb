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
    public AudioSource song;

    // Update is called once per frame
    private void Awake() {
        gocanvas.SetActive(false);
        Time.timeScale = 1f;
        song.volume = 0.4f;
        song.Play();
    }
    public void GameOver() {
        song.volume = 0f;
        gocanvas.SetActive(true);
        
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

