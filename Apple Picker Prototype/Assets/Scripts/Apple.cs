using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -19;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //Получить ссылку на компонент ApplePicker главной камеры
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }
    }
}
