using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageMovement : MonoBehaviour
{
    //public float speed = 3f;
    public Sprite[] sprites; 
    GameObject health;
    public AudioClip audioHit;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];

        audio = gameObject.AddComponent<AudioSource>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (GameSceneController.isGamePlaying)
        {
            float move = (Data.speed * Time.deltaTime * -1f) + transform.position.x;
            transform.position = new Vector3(move, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Destroy Garbages"))
        {
            audio.PlayOneShot(audioHit);

            Destroy(this.gameObject, audioHit.length);

            Data.countHit++;
            health = GameObject.Find("Health_" + Data.countHit);

            Destroy(health);
        }
    }

private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;

    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (GameSceneController.isGamePlaying)
        {
            Vector3 currScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currPosition = Camera.main.ScreenToWorldPoint(currScreenPoint) + offset;
            transform.position = currPosition;
        }
    }

    private void OnMouseUp()
    { 
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);  
    }
}
