using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public bool gameGoingOn;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        gameGoingOn = true;
        StartCoroutine(EnemySpawning());
    }

  
    IEnumerator EnemySpawning()
    {
        while (gameGoingOn)
        {
            
            float randomYPos = Random.Range(5.42f, -6f);
            Instantiate(enemy, new Vector3(25f, randomYPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
