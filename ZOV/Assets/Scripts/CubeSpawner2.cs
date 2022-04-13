using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner2 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> GameObjectList;
    public float scalingFactor = 0.95f;
    public int numCubes = 0;

    void Start()
    {
        GameObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        numCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);

        gObj.name = "Cube " + numCubes;
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color=c;
        gObj.transform.position = Random.insideUnitSphere;

        GameObjectList.Add(gObj);

        List<GameObject> removeList = new List<GameObject>();

        foreach(GameObject goTemp in GameObjectList) {
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;

            if (scale <= 0.1f) {
                removeList.Add(goTemp);
            }
        }

        foreach(GameObject goTemp in removeList) {
            GameObjectList.Remove(goTemp);
            Destroy(goTemp);
        }
    }
}
