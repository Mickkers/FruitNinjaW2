using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnBox;
    private GameManager gManager;

    [SerializeField] private float lifetime;

    [Header("Spawn Time")]
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [Header("Spawn Angle")]
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    [Header("Spawn Force")]
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [Header("Bomb Chance")]
    [SerializeField] private float bombChance;
    [Header("Prefabs")]
    [SerializeField] private GameObject[] fruits;
    [SerializeField] private GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        gManager = FindObjectOfType<GameManager>();
        spawnBox = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnSequence());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnSequence()
    {
        yield return new WaitForSeconds(1f);

        while (gManager.GameActive)
        {
            GameObject obj = SpawnFruit();

            Destroy(obj, lifetime);

            float force = Random.Range(minForce, maxForce);
            obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

    private GameObject SpawnFruit()
    {
        Vector3 pos = new Vector3
        {
            x = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x),
            y = Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y),
            z = Random.Range(spawnBox.bounds.min.z, spawnBox.bounds.max.z)
        };

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));

        GameObject fruit;

        if(Random.Range(0f, 1f) < bombChance)
        {
            fruit = Instantiate(bomb, pos, rotation);
        }
        else
        {
            fruit = Instantiate(fruits[Random.Range(0, fruits.Length)], pos, rotation);
        }

        return fruit;
    }
}
