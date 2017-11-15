using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{


    float counterThresh = 3.0f;
    float counter;
    float rockAttTimerThresh = 0.3f;
    float rockAttTimer = 0f;
    int rocks = 0;
    int maxRocks = 8;

    GameObject[] rocksArray;
    bool dropping = false;
    public Vector3 dropLocLow;
    public Vector3 dropLocHigh;
    public GameObject rockPrefab;
    public GameObject boundaryPrefab;
    public Vector3 boundaryLoc;
    public GameObject currBoundary;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        rocksArray = new GameObject[maxRocks];
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        dropRocks();

    }

    void stupidDropRocks()
    {
        if (counter >= counterThresh) //set up attack.
        {
            if (rocks >= maxRocks)
            {

                rocks = 0;
                dropping = false;
                Debug.Log("Instantiate stuff");
                //currBoundary = Instantiate(boundaryPrefab, boundaryLoc, Quaternion.identity);
            }

            rockAttTimer += Time.deltaTime;
            if (rockAttTimer >= rockAttTimerThresh && !dropping)
            {
                rocksArray[rocks] = Instantiate(rockPrefab, new Vector3(Random.Range(dropLocLow.x, dropLocHigh.x), dropLocLow.y, 0), Quaternion.identity);
                rocksArray[rocks].isStatic = true;
                rocks++;
                rockAttTimer = 0;

            }
            else if (rockAttTimer >= rockAttTimerThresh)
            {
                if (rocks <= maxRocks - 1 && rocks >= 0)
                {
                    rocksArray[rocks].isStatic = false;
                }
                rockAttTimer = 0;
                rocks--;
                if (rocks == 0)
                {
                    counter = 0;
                    dropping = true;
                    return;
                }
            }
        }

    }

    void dropRocks()
    {
        if (counter >= counterThresh) //set up attack.
        {


            rockAttTimer += Time.deltaTime;
            if (rockAttTimer >= rockAttTimerThresh && !dropping)
            {
                rocksArray[rocks] = Instantiate(rockPrefab, new Vector3(Random.Range(dropLocLow.x, dropLocHigh.x), dropLocLow.y, 0), Quaternion.identity);
                rocksArray[rocks].GetComponent<Rigidbody2D>().isKinematic = true;
                rocks++;
                rockAttTimer = 0;
                if(rocks >= maxRocks)
                {
                    rocks--;
                    dropping = true;
                }

            }
            else if (rockAttTimer >= rockAttTimerThresh)
            {
                if (rocks <= maxRocks-1 && rocks >= 0)
                {
                    rocksArray[(maxRocks-1)-rocks].GetComponent<Rigidbody2D>().isKinematic = false;
                }
                rockAttTimer = 0;
                
                if (rocks <= 0)
                {
                    counter = 0;
                    dropping = false;
                    return;
                }
                rocks--;
            }
        }
    }
}
