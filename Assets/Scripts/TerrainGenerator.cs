using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int gridWidth, gridHeight;
    [SerializeField] private Vector2 gridOrigin;
    [SerializeField] private GameObject mineral;
    private float furthestGenerated; // furthest point generated, used to check if generation is needed again

    void Start()
    {
        Generation(gridOrigin);
    }

    private void Generation(Vector2 origin)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 spawnPos = new Vector2(x + origin.x, y + origin.y); // add origin to coordinates
                Instantiate(mineral, spawnPos, Quaternion.identity); // Quanternion.identity == default angle
            }
        }
    }

    void Update()
    {
        // get player x coordinate, compare to fursthestGenerated and generate terrain if needed
        GameObject player = GameObject.Find("Player");
        // check if player has progressed
    }
}
