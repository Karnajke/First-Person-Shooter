using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;              //Значения для скорости движения и расстояния, с которого
    public float obstacleRange = 5.0f;                            //начинается реакция на препятствие

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;

    void Start()
    {
        _alive = true;
    }
    void Update()
    {

        if (_alive) 
        { 
            transform.Translate(0, 0, speed * Time.deltaTime);//Непрерывно движемся вперед в каждом кадре, несмотря на повороты.
            Ray ray = new Ray(transform.position, transform.forward); //Луч находится в том же положении и нацеливается в том же направлении, что и персонаж
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) //Бросаем луч с описанной вокруг него окружностью
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110); //Поворот с наполовину случайным выбором нового направления.
                    transform.Rotate(0, angle, 0);
                }
                if (Physics.SphereCast(ray, 0.75f, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerCharacter>())//Игрок распознается тем же способом, что и мишень в сценарии RayShooter.
                    {
                        if (_fireball == null)
                        { //Та же самая логика с пустым игровым объектом, что и в сценарии SceneController.
                            _fireball = Instantiate(fireballPrefab) as GameObject;
                            _fireball.transform.position = //Поместим огненный шар перед врагом и нацелим в направлении его движения.
                            transform.TransformPoint(Vector3.forward * 1.5f);
                            _fireball.transform.rotation = transform.rotation;
                        }
                    }
                    else if (hit.distance < obstacleRange)
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }
        }
    }

    public void SetAlive(bool alive) //Открытый метод, позволяющий внешнему коду воздействовать на «живое» состояние.
    {
        _alive = alive;
    }
}
