using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bottleText;
    public GameObject lossText;
    public GameObject winText;
    public TextMeshProUGUI ammoText;
    int bottles;
    public int ammo; 

    public bool canShoot;

    AudioSource audioSource;
    public AudioClip hitSound;

    void Start(){
        bottles = GameObject.FindGameObjectsWithTag("bottle").Length;
        Debug.Log(bottles);
        audioSource = gameObject.GetComponent<AudioSource>();
        if(lossText != null){
            lossText.SetActive(false); 
            winText.SetActive(false);
            bottleText.text = "Bottles: " + bottles.ToString(); 
            ammoText.text = "Ammo: " + ammo.ToString();
            canShoot = true;
        }
    }

    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(0);
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
    }

    public void destroyedBottle() {
        bottles--;
        Debug.Log(bottles);
        audioSource.PlayOneShot(hitSound, 1.0f);
        bottleText.text = "Bottles: " + bottles.ToString();
        if(bottles == 0) {
            Debug.Log("no more bottles left");
            StartCoroutine(WinState()); 

        }
    }

    public void destroyedLossItem() {
        Debug.Log ("Destroyed loss item");
        StartCoroutine(LossState());

    }

    public void SetAmmo() {
        ammo--; 
        ammoText.text = "Ammo: " + ammo.ToString();
        if (ammo <= 0) {
            StartCoroutine(LossState());
        }
    }

    IEnumerator LossState() {
        canShoot = false;
        lossText.SetActive(true);

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    IEnumerator WinState() {
        canShoot = false;
        winText.SetActive(true);
        yield return new WaitForSeconds(3);
        LoadNextLevel();
    }
}
