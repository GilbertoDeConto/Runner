using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip somMorte;
    public AudioClip somColetaItem;
    private AudioSource audioSrc;

    private float vel = 200;
    private float velX = 350;

    public GameController gameController;

    private int pontos = 0;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (Input.GetKey("down"))
            vel = 100;
        else
            vel = 200;

        Vector3 velocidade = new Vector3(moveX * velX * Time.deltaTime, 0, vel * Time.deltaTime);
        body.velocity = velocidade;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Placa"))
        {
            audioSrc.PlayOneShot(somMorte);
            SceneManager.LoadScene("GameOver");
        } else if (collision.gameObject.CompareTag("Item"))
        {

            audioSrc.PlayOneShot(somColetaItem);

            Destroy(collision.gameObject);
            pontos += 10;

            gameController.setScore(pontos);
        }
    }

}
