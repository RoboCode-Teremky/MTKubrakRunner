using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private int platformLimit = 25;
    private float generatorCooldown = 1.49f;
    float initialGeneratorCooldown;
    void Start()
    {
        Random.InitState(LevelSeed.seed);
        ScoreCounter.allBonuses = 0;
        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length - 1)],transform.position, Quaternion.identity);
        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length - 1)], new Vector3(transform.position.x,transform.position.y,transform.position.z + 15), Quaternion.identity);
        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length - 1)], new Vector3(transform.position.x,transform.position.y,transform.position.z + 30), Quaternion.identity);
        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length - 1)], new Vector3(transform.position.x,transform.position.y,transform.position.z + 45), Quaternion.identity);
        StartCoroutine(GeneratePlatform());
        initialGeneratorCooldown = generatorCooldown;
    }

    private IEnumerator GeneratePlatform()
    {
        for (int i = 0; i < platformLimit; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length - 1)], new Vector3(transform.position.x,transform.position.y,transform.position.z + 60), Quaternion.identity);
            platform.AddComponent<PlatformData>();
            ScoreCounter.allBonuses += platform.GetComponent<PlatformData>().CountBonuses();
            yield return new WaitForSeconds(generatorCooldown);
        }
        Instantiate(platformPrefabs[platformPrefabs.Length - 1], new Vector3(transform.position.x,transform.position.y,transform.position.z + 60), Quaternion.identity); // Фінішна пряма
    }
}
