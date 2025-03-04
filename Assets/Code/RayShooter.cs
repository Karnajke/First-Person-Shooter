using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>(); //������ � ������ �����������, �������������� � ����� �� �������.

       //Cursor.lockState = CursorLockMode.Locked; //�������� ��������� ����...
       //Cursor.visible = false;                   //...� ������ ������.
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); //������� GUI.Label() ���������� �� ������ ������.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //������� �� ������� ������ ����.
        {
            EventSystem.current.IsPointerOverGameObject(); //���������, ��� GUI �� ������������.
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);//�������� ������ � ��� �������� ��� ������ � ������
            Ray ray = _camera.ScreenPointToRay(point); //�������� � ���� ����� ���� ������� ScreenPointToRay().
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //���������� ��� ��������� ����������� ����������, �� ������� ������� ������
            { 
                GameObject hitObject = hit.transform.gameObject; //�������� ������, � ������� ����� ���.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) // ��������� ������� � ����� ������� ���������� ReactiveTarget
                {
                    //Debug.Log("Target hit");
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) //����������� ���������� ��������� IEnumerator.
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1); //�������� ����� yield ��������� �����������, ����� ������� ������������.

        Destroy(sphere); //������� ���� GameObject � ������� ������
    }
}

 