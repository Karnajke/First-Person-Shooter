using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ �������������� ��� ������ � ����� UI

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    void Start()
    {
        settingsPopup.Close(); //��������� ����������� ���� � ������ ������ ����
    }



    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();//������ ����� Reference Text, ��������������� ��� ������� �������� text.
    }

    public void OnOpenSettings() //�����, ���������� ������� ��������.
    {
        settingsPopup.Open();
        Debug.Log("open settings");
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
