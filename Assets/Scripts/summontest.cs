using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summontest : MonoBehaviour
{
    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            SpawnPoint.GetComponent<SummonFruits>().Summon(Random.Range(1,4),gameObject.transform);
        }
    }
}
