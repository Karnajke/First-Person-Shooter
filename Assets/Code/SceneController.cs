using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;//Сериализованная переменная для связи с объектом-шаблоном
    private GameObject _enemy;//Закрытая переменная для слежения за экземпляром врага в сцене
    public float CoordX = 0.0f;
    public float CoordY = 1.0f;
    public float CoordZ = 0.0f;

    private void Update() // Порождаем нового врага, только если враги в сцене отсутствуют.
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //Метод, копирующий объект-шаблон.
            _enemy.transform.position = new Vector3(CoordX, CoordY, CoordZ);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
