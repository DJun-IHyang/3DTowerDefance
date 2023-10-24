using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Tooltip("������ Ÿ�� ������ �� Tower ������Ʈ")]
    [SerializeField]
    GameObject towerPrefab;

    [Tooltip("Ÿ�Ͽ� Ÿ�� ���� ���� ���θ� ��Ÿ���� ����")]
    [SerializeField]
    bool isPlaceable;

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    public bool GetIsPlaceable()
    {
        return isPlaceable;
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
           
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
