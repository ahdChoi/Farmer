using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //To do : Input.mousePostion -> touch_fingerID
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);

                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (touch.phase == TouchPhase.Began)
                    {
                        PlayerController.instance.PickingMove(hit.point);
                    }


                    if (touch.phase == TouchPhase.Moved)
                    {
                        PlayerController.instance.PickingMove(hit.point);

                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                    }
                }
            }
        }
    }
}
