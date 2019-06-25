using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{
    private Animator anim;

    public GameObject[] obstaculos;
    public GameObject plataforma;
    public GameObject chao;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        iniciarObstaculos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Aberto", true);
            criarProxima();
        }
    }

    private void iniciarObstaculos()
    {
        foreach (GameObject obs in obstaculos)
        {
            int qtdeFilhos = obs.transform.childCount;
            int posRemover = Random.Range(0, qtdeFilhos - 1);

            for (int i = 0; i < qtdeFilhos; i++)
            {
                GameObject child = obs.transform.GetChild(i).gameObject;
                child.SetActive(true);
            }

            obs.transform.GetChild(posRemover).gameObject.SetActive(false);
        }
    }

    private void criarProxima()
    {
        Renderer rend = chao.GetComponent<Renderer>();
        float maxZ = rend.bounds.max.z;

        Instantiate(plataforma, new Vector3(0, 0, maxZ + 15), Quaternion.identity);
    }

}
