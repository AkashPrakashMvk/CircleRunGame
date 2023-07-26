using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading : MonoBehaviour
{
    float time,seconds;
    // Start is called before the first frame update
    void Start()
    {
     seconds = 5;
     Invoke("LoadGame",5f);
    }
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }
}
