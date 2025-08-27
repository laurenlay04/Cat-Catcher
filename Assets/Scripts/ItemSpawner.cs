using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject collectiblePrefab; // reference to the collectible prefab, pizzas
    public GameObject badEggPrefab; // Eggs
    public float spawnRate = 1f; //rate of spawn
    public float spawnHeight = 6f; // Height above player to spwn
    public float spawnRangeX = 4f; // Range to spwn x-axis
    [Range(0f, 1f)] public float eggSpawnChance = 0.2f; //20% chance to spawn an egg

    private void Start(){
        //Start spawning items after delay
        InvokeRepeating(nameof(SpawnItem), 1f, spawnRate);

    }

    void SpawnItem(){

        //pick random X position within the spawn range
        float spawnX = Random.Range(- spawnRangeX, spawnRangeX);
        // Egg or pizza
        float randomValue = Random.value;
        Vector2 spawnPosition = new Vector2(spawnX, spawnHeight);
        if(Random.value < eggSpawnChance){
        Instantiate(badEggPrefab, spawnPosition, Quaternion.identity);
        } else {
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        }

    }

}