using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private int score;

    [SerializeField] private GameObject wholeFruit;
    [SerializeField] private GameObject sliceFruit;
    private Rigidbody[] slices;

    private Rigidbody rbody;
    private Collider col;
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        particle = GetComponentInChildren<ParticleSystem>();
        slices = sliceFruit.GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchArea player = other.gameObject.GetComponent<TouchArea>();
            Slice(player.direction, other.transform.position, player.GetSlicePower());
        }
    }

    private void Slice(Vector3 dir, Vector3 pos, float force)
    {
        wholeFruit.SetActive(false);
        col.enabled = false;
        sliceFruit.SetActive(true);
        particle.Play();
        AudioController.Instance.SlashSFX();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        sliceFruit.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        FindObjectOfType<GameManager>().AddScore(score);
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = rbody.velocity;
            slice.AddForceAtPosition(dir.normalized * force, pos, ForceMode.Impulse);
        }
    }
}
