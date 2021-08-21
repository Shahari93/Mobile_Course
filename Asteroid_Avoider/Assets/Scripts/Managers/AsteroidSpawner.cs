using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float timeBetweenAsteroidSpawn = 1.5f;
    [SerializeField] private Vector2 randomForce;

    private Camera mainCamera;
    private float timer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // goes down every frame
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnNewAsteroid();

            timer += timeBetweenAsteroidSpawn;
        }
    }

    private void SpawnNewAsteroid()
    {
        // int max random is exclusive
        int side = UnityEngine.Random.Range(0, 4);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 dir = Vector2.zero;

        switch (side)
        {
            case 0:
                // Left
                spawnPoint.x = 0;
                spawnPoint.y = UnityEngine.Random.value;
                dir = new Vector2(1f, UnityEngine.Random.Range(-1f, 1f));
                break;
            case 1:
                // Right
                spawnPoint.x = 1;
                spawnPoint.y = UnityEngine.Random.value;
                dir = new Vector2(-1f, UnityEngine.Random.Range(-1f, 1f));
                break;
            case 2:
                // Bottom
                spawnPoint.x = UnityEngine.Random.value;
                spawnPoint.y = 0;
                dir = new Vector2(UnityEngine.Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                // Up
                spawnPoint.x = UnityEngine.Random.value;
                spawnPoint.y = 1;
                dir = new Vector2(UnityEngine.Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = asteroidPrefabs[UnityEngine.Random.Range(0, asteroidPrefabs.Length)];
        Quaternion zRotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360f));
        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint, zRotation);

        Rigidbody asteroidRB = asteroidInstance.GetComponent<Rigidbody>();
        asteroidRB.velocity = dir.normalized * UnityEngine.Random.Range(randomForce.x, randomForce.y);
    }
}
