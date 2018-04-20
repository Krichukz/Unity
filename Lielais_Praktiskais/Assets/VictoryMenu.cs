using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
    }
    public void Restart()
    {

        SceneManager.LoadScene("Jauna_update", LoadSceneMode.Single);
        gameObject.SetActive(false);
    }
}