using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Импорт инфраструктуры для работы с кодом UI

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    void Start()
    {
        settingsPopup.Close(); //Закрываем всплывающее окно в момент начала игры
    }



    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();//Объект сцены Reference Text, предназначенный для задания свойства text.
    }

    public void OnOpenSettings() //Метод, вызываемый кнопкой настроек.
    {
        settingsPopup.Open();
        Debug.Log("open settings");
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
