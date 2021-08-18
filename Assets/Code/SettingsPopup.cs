using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true); //Активируйте этот объект, чтобы открыть окно
    }

    public void Close()
    {
        gameObject.SetActive(false); //Деактивируйте объект, чтобы закрыть окно
    }
}
