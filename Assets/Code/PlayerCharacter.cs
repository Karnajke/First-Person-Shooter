using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    private void Start()
    {
        _health = 5; //������������� ���������� health.
    }
    public void Hurt(int damage)
    {
        _health -= damage; //���������� �������� ������
        Debug.Log("Health: " + _health);
    }
}
