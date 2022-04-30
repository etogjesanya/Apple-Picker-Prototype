using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания яблок
    public GameObject applePrefab;

    //Скорость движения яблони
    public float speed = 10f;

    //Расстояние, на котором должно изменятся направление яблони
    public float leftAndRightEdge = 25f;

    //Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.02f;

    //Частота выпадения яблок
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        //Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        //Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        // Случайная смена направления привязана ко времени
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
