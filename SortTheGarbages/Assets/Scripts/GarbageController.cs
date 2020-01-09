using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageController : MonoBehaviour
{
    public float delay;
    public float timer;
    public GameObject[] garbages;

    // Start is called before the first frame update
    void Start()
    {
        delay = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSceneController.isGamePlaying)
        {
            timer += Time.deltaTime;

            if (timer > delay)
            {
                int index = Random.Range(0, garbages.Length);
                Instantiate(garbages[index], transform.position, transform.rotation);
                timer = 0;
            }

            if (Data.gameTimer >= 60f)
            {
                if(delay > 0.8f)
                {
                    delay -= 0.1f;
                    Data.gameTimer = 0f;
                }
            }
        }
    }
}
