using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;
    public bool isPig = false;
    public AudioClip hurtClip;
    public AudioClip dead;
    public AudioClip birdCollision;
    public bool isDead = false;
    private void Awake() {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioPlya(birdCollision);
            collision.transform.GetComponent<Bird>().Hurt();
        }
        print(collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude > maxSpeed)
        {//直接死亡
            Dead();
        }
        else if(collision.relativeVelocity.magnitude > minSpeed
        && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
            AudioPlya(hurtClip);
        }
    }

    public void Dead(){
        isDead = true;
        if(isPig)
        {
            GameManger._instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go,1.5f);
        AudioPlya(dead);
    }
    public void AudioPlya(AudioClip clip){
        AudioSource.PlayClipAtPoint(clip,transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
