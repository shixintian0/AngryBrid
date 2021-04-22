using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    private List<Pig> blocks = new List<Pig>();

    /// <summary>
    /// 进入触发区
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());
        }
    }

    /// <summary>
    /// 离开触发区域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(collision.GetComponent<Pig>().isDead == false)
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        if(blocks.Count >0 && blocks!= null)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Dead();
            }
        }
        OnClear();
    }

    void OnClear(){
        rg.velocity = Vector3.zero;
        Instantiate(boom,transform.position,Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        myTrail.ClearTrail();
    }

    protected override void Next()
    {
        GameManger._instance.birds.Remove(this);
        Destroy(gameObject);
        GameManger._instance.NextBird();
    }
}
