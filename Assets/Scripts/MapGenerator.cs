using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Vector2 _size = new Vector2(3, 3);
    [Header("Prefabs")]
    [SerializeField] GameObject _startTile;
    [SerializeField] GameObject _mazeTile;
    [SerializeField] GameObject _endTile;
    [SerializeField] GameObject _scoreGiver;

    private Vector2 _tileSize = new Vector2(16, 16);

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        if (GameObject.Find("Generated Maze"))
            Destroy(GameObject.Find("Generated Maze"));

        GameObject map = new GameObject("Generated Maze");

        // Row
        for (int row = 0; row < _size.x; row++)
        {
            // Column
            for (int col = 0; col < _size.y; col++)
            {
                GameObject tile;
                Vector3 tilePosition = new Vector3(_tileSize.x * row, 0, _tileSize.y * col);

                // Start Tile
                if (row == 0 && col == 0)
                    tile = Instantiate(_startTile, tilePosition, Quaternion.identity, map.transform);
                // End Tile
                else if (row == _size.x - 1 && col == _size.y - 1)
                    tile = Instantiate(_endTile, tilePosition, Quaternion.identity, map.transform);
                // Regular Maze Tile
                else
                {
                    tile = Instantiate(_mazeTile, tilePosition, Quaternion.identity, map.transform);
                    tile.transform.rotation = Quaternion.Euler(-90, 0, Random.Range(0, 4) * 90);

                    // Score Givers (4 on each tile; Random locations)
                    List<int> randomLocations = GetRandomScoreLocations();
                    Transform pickupLocations = tile.transform.Find("Pickup Locations");

                    for (int i = 0; i < 4; i++)
                    {
                        Transform spawnPoint = pickupLocations.GetChild(randomLocations[i]);
                        Vector3 scorePosition = spawnPoint.position;
                        Instantiate(_scoreGiver, scorePosition, Quaternion.identity, map.transform);
                    }
                }
            }
        }

        Debug.Log("<color=green> Generated Maze Successfuly.</color>");
    }

    private List<int> GetRandomScoreLocations()
    {
        List<int> totalLocations = new List<int>();

        for (int i = 1; i <= 12; i++)
            totalLocations.Add(i);

        // Shuffle
        for (int i = 0; i < totalLocations.Count; i++)
        {
            int randomIndex = Random.Range(i, totalLocations.Count);
            (totalLocations[i], totalLocations[randomIndex]) = (totalLocations[i], totalLocations[randomIndex]); // Tuple Swap
        }

        List<int> result = new List<int>();

        for (int i = 0; i < 4; i++)
            result.Add(totalLocations[i]);

        return result;
    }

    private void OnValidate()
    {
        _size.x = Mathf.FloorToInt(_size.x);
        _size.y = Mathf.FloorToInt(_size.y);

        _size.x = _size.x < 3 ? 3 : _size.x;
        _size.y = _size.y < 3 ? 3 : _size.y;
    }
}
