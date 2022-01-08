using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] monsterReferences;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnMonster;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReferences.Length);
            randomSide = Random.Range(0, 2);
            spawnMonster = Instantiate(monsterReferences[randomIndex]);

            if (randomSide == 0)
            {
                // left side
                spawnMonster.transform.position = leftPos.position;
                spawnMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                // right side
                spawnMonster.transform.position = rightPos.position;
                spawnMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
            
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} // class
