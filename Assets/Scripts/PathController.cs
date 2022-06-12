using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] GameObject lastpath;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPath;
    Vector3 direction;
    void Start()
    {
        direction = new Vector3(0, 0.2f, 0.5f);
    }
    int count;
    void Update()
    {
        if (PlayerController.stair)
        {
            if (Input.GetMouseButton(0))
            {
                lastpath = Instantiate(path, lastpath.transform.position + direction, path.transform.rotation, spawnPath.transform);
                count++;
                if(count >18)
                {
                    PlayerController.stair = false;
                    count = 0;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                lastpath.transform.position = player.transform.position;
                PlayerController.bagStair--;
                Debug.Log(PlayerController.bagStair);
            }
        }
    }
}
