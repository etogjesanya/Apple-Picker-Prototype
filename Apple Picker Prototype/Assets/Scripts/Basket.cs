using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Denamically")]
    public Text scoreGT;

    void Start()
    {
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получаить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        //Установить начальное значение на 0
        scoreGT.text = "0";
    }
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        //Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        //Пробразовать точку на двумерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переместить корзину вдоль ости X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }

        //Преобразовать текст в scoreGO в целое число
        int score = int.Parse(scoreGT.text);
        //Добавить очки за пойманное яблоко
        score += 100;
        //Преобразовать число обратно в строку и вывести на экран
        scoreGT.text = score.ToString();

        // Запомнить высшее достижение
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
