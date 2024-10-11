using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public float minSpawnDistance = 1f;
    public float maxSpawnDistance = 10f;
    public float moveSpeed = 1f;
    public float spawnTime = 2f;
    public float spawnAreaWidth = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monster = Instantiate(monsterPrefabs[randomIndex]);

            float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
            Vector3 randomSpawnPosition = mainCamera.transform.position + mainCamera.transform.forward * randomDistance;
            randomSpawnPosition.x += Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            randomSpawnPosition.z += Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            monster.transform.position = randomSpawnPosition;

            MonsterMovement movement = monster.AddComponent<MonsterMovement>();
            movement.speed = moveSpeed;

            Destroy(monster, 5f);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
