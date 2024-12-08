using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levels;

    private float level_Distance = 50f;
    private float current_Level_X = 0f;

    private float increment_Spawner_X = 125f;

    private int spawn_Count = 5;



    // Start is called before the first frame update
    void Start()
    {
        SpawnLevels();

    }

    void SpawnLevels()
    {
        int rand = 0;
        for(int i=0; i < spawn_Count; i++)
        {
            rand = Random.Range(0, levels.Length);

            GameObject go = Instantiate(levels[rand]);

            Vector3 levelTemp = Vector3.zero;
            levelTemp.x = current_Level_X;
            go.transform.position= levelTemp;
            current_Level_X += level_Distance;
        }

        Vector3 temp = transform.position;
        temp.x += increment_Spawner_X;
        transform.position = temp;
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Player")
        {
            SpawnLevels();
        }
    }
}
