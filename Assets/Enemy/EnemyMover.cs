using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

// WayPoint로 Enemy를 이동
public class EnemyMover : MonoBehaviour
{
    [Tooltip("적의 이동 경로")]
    //리스트 사이즈가 계속 변경되기 때문에 (flexible) array대신 List사용
    [SerializeField]
    List<Tile> path = new List<Tile>();
    
    [Tooltip("적의 이동 속도")]
    [SerializeField]
    [Range(0, 5)] float speed = 2f; 
    float waitTime = 1f;
    Enemy enemy;

    PathFinder pathFinder;
    GridManager gridManager;

    void OnEnable()
    {
        FindPath();

        ReturnToStart();

        //InvokeRepeating("PrintWaypointName", 0, 1);
        StartCoroutine(FollowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        pathFinder = FindObjectOfType<PathFinder>();
        gridManager = FindObjectOfType<GridManager>();
    }
    
    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    void FindPath()
    {
        path.Clear();

        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in pathParent.transform)
        {
            path.Add(child.GetComponent<Tile>()); ;
        }
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetPositionFromCoordinates(pathFinder.DestinationCoordinates);
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while (travelPercent < waitTime)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                //transform.position = waypoint.transform.position;

                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
        
    }

    private void FinishPath()
    {
        enemy.StealMoney();
        gameObject.SetActive(false);
    }
}
