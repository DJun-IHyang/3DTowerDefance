using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ���� �������� Ÿ�� ���� ��ġ�� ǥ��
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [Tooltip("TMPro label�� �⺻ ����")]
    [SerializeField]
    Color defaultColor = Color.white;
    [Tooltip("Tile�� ��ġ �Ұ��� �� ��� TMPro label�� �⺻ ����")]
    [SerializeField]
    Color blockColor = Color.gray;

    
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint waypoint;

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();

        Togglelabels();
    }

    private void Togglelabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }


    //Tile Parent������Ʈ�� �̸��� �� ��ǥ������ �ڵ� ����
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
