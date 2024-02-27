using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject bombBody;
    [SerializeField] private ParticleSystem particle;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        bombBody.SetActive(false);
        col.enabled = false;
        particle.Play();
        AudioController.Instance.ExplodeSFX();
        FindObjectOfType<GameManager>().TakeDamage();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}