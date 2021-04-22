using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManger _instance;
    private Vector3 origionPos;//初始的位置

    public GameObject win;
    public GameObject lose;
    public GameObject[] starts;
    private int starsNum = 0;
    private int totalNum = 10;
    private void Awake(){
        _instance = this;
        if(birds.Count >0)
        {
            origionPos = birds[0].transform.position;
        }
    }

    private void Start() {
        Initialized();
    }
    /// <summary>
    /// 初始化小鸟
    /// <summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if(i == 0)
            {
                birds[i].transform.position = origionPos;
                birds[i].enabled = true;
                birds[i].sp.enabled =true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;

            }
        }
    }

    ///<summary>
    ///判定游戏逻辑
    ///</summary>
    public void NextBird()
    {
        if(pigs.Count > 0)
        {
            if(birds.Count > 0)
            {
                Initialized();
            }else{
                //输了
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }

    public void ShowStar()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if(starts.Length<=starsNum){
                break;
            }
            yield return new WaitForSeconds(0.2f);
            starts[starsNum].SetActive(true);
            
        }
    }

    public void Replay()
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void Home(){
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        
        if(starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"),starsNum);
        }
        //存储所有的星星个数
        int sum = 0;
        for(int i=1 ;i <=totalNum; i++)
        {
            sum += PlayerPrefs.GetInt("level"+i.ToString());
        }
        print(sum);
        PlayerPrefs.SetInt("totalNum",sum);

    }

}
