using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController _charController; //���������� ��� ������ �� ��������� CharacterController.
    public float gravity = -9.8f; //����������

    void Start()
    {
        _charController = GetComponent<CharacterController>(); //������ � ������ �����������, �������������� � ����� �� �������.
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed; //"Horizontal" � "Vertical" � ��� �������������� ����� ��� ������������� � �����������.
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime); //����������� ���������� ���������
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//��������� �������� �� ��������� ��� �� ���������, ��� � �������� ����������� ����
        movement.y = gravity; //���������� �������� ���������� gravity ������ ����.
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);//����������� ������ �������� �� ��������� � ���������� �����������.
        _charController.Move(movement); //�������� ���� ������ ���������� ��������� CharacterController.
    }
}
