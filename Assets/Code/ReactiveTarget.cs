using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() // Метод, вызванный сценарием стрельбы.
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null) //Проверяем, присоединен ли к персонажу сценарий WanderingAI
        {
            behavior.SetAlive(false);
        }
            StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}