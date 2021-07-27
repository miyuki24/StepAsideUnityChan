using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.z > this.transform.position.z){
            Debug.Log("アイテムが見えなくなった");
            Destroy(this.gameObject);
        }
    }
}
