using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    private RectTransform rect_BackGround;
    private RectTransform rect_Joystick;

    private float radius;
    private bool isDown = false;

    Vector2 joyStickMoveVector;

    float joysticSpeed;

    // Use this for initialization
    void Start ()
    {
        rect_BackGround = transform.parent.GetComponent<RectTransform>();
        rect_Joystick = GetComponent<RectTransform>();

        radius = rect_BackGround.rect.width * 0.5f;
        joysticSpeed = 0.0f;
    }

    public void JoystickDrag()
    {
        Vector2 mousePos = Input.mousePosition;
        joyStickMoveVector = mousePos - (Vector2)rect_BackGround.position; //BackGroundImage이미지에서 마우스 현재 좌표로 가는 벡터를 구함 

        joyStickMoveVector = Vector2.ClampMagnitude(joyStickMoveVector, radius); // 조이스틱 이동 최대범위 설정

        joysticSpeed = Vector2.Distance(rect_BackGround.position, rect_Joystick.position) / radius; // 조이스틱과 백그라운드 이미지 거리 ( 조이스틱 거리에 따라 이동속도 다르게 구현)

        rect_Joystick.localPosition = joyStickMoveVector;

        joyStickMoveVector = joyStickMoveVector.normalized;

    }

    private void Update()
    {
        //if(isDown)
        //{
        //    CameraController.instance.CameraMove(joyStickMoveVector, joysticSpeed);
        //}
    }
    public void JoystickEndDrag()
    {
        rect_Joystick.localPosition = Vector3.zero;
        joyStickMoveVector = Vector2.zero;
        isDown = false;
    }

    public void JoystickPointerDown()
    {
        isDown = true;
    }
   
}
