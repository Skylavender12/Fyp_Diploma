using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    Player player;
    Text distanceText;

    GameObject results;
    Text finalDistanceText;
    public AudioSource deathSound;
    //change to private
    public void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();

        results.SetActive(false);
    }


    void Start()
    {
        
    }

    
    public void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " ";

        if (player.isDead)
        {
            results.SetActive(true);
            finalDistanceText.text = distance + " ";
            deathSound.Play();
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
