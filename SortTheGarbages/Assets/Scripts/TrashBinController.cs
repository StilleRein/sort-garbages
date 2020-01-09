using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashBinController : MonoBehaviour
{
    public AudioClip audioCorrect, audioWrong;
    private AudioSource audio;
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(this.gameObject.tag))
        {
            Data.score += 25;
            audio.PlayOneShot(audioCorrect);
        }

        else
        {
            Data.score -= 5;
            audio.PlayOneShot(audioWrong);
        }

        textScore.text = Data.score.ToString();
        Destroy(collision.gameObject);
    }
}
