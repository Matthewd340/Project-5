using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    float minSpeed = 10;
    float maxSpeed = 15;
    float maxTorque = 10;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    public ParticleSystem movementParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector2.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-maxTorque,maxTorque), Random.Range(-maxTorque,maxTorque), Random.Range(-maxTorque,maxTorque), ForceMode.Impulse);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.lives -= 1;
                if (gameManager.lives < 1)
                {
                    gameManager.GameOver();
                }
                
            }
        }
    }

    private void OnMouseEnter()
    {
        if (gameManager.isGameActive && gameManager.isPaused == false)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
