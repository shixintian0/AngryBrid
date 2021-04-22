using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private void Awake() {
        if(Resources.Load(PlayerPrefs.GetString("nowLevel")) != null)
        {
            Instantiate(Resources.Load(PlayerPrefs.GetString("nowLevel")));
        }else{
            Instantiate(Resources.Load("level2"));
        }
        
    }
}
