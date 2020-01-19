using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    static public CameraController instance;

    Vector3 offSet;

    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        offSet = transform.position;
        DontDestroyOnLoad(gameObject);

        target = PlayerController.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = offSet + target.transform.position;
    }

}
