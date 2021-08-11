using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>(); //Доступ к другим компонентам, присоединенным к этому же объекту.

        Cursor.lockState = CursorLockMode.Locked; //Скрываем указатель мыши...
        Cursor.visible = false;                   //...в центре экрана.
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); //Команда GUI.Label() отображает на экране символ.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Реакция на нажатие кнопки мыши.
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);//Середина экрана — это половина его ширины и высоты
            Ray ray = _camera.ScreenPointToRay(point); //Создание в этой точке луча методом ScreenPointToRay().
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //Испущенный луч заполняет информацией переменную, на которую имеется ссылка
            { 
                GameObject hitObject = hit.transform.gameObject; //Получаем объект, в который попал луч.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) // Проверяем наличие у этого объекта компонента ReactiveTarget
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

    private IEnumerator SphereIndicator(Vector3 pos) //Сопрограммы пользуются функциями IEnumerator.
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1); //Ключевое слово yield указывает сопрограмме, когда следует остановиться.

        Destroy(sphere); //Удаляем этот GameObject и очищаем память
    }
}

 