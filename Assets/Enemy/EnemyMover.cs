using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

// WayPoint�� Enemy�� �̵�
public class EnemyMover : MonoBehaviour
{
    [Tooltip("���� �̵� ���")]
    //����Ʈ ����� ��� ����Ǳ� ������ (flexible) array��� List���
    [SerializeField]
    List<Tile> path = new List<Tile>();
    
    [Tooltip("���� �̵� �ӵ�")]
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
