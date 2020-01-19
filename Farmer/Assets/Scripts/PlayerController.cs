using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;
    float rotationSpeed = 5.0f;
    Animator anim;
    static public PlayerController instance;
    // Start is called before the first frame update
    Coroutine curMoveCor;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoMove(Vector2 _moveVector)
    {
        transform.position += new Vector3(_moveVector.x, 0.0f, _moveVector.y) * Time.deltaTime * moveSpeed;
    }

    public void SetSpeed(float _speed)
    {
        moveSpeed = _speed;
        anim.SetFloat("speed", _speed);
    }

    public void PickingMove(Vector3 _pos)
    {
        SetSpeed(3.0f);

        if (curMoveCor != null)
            StopCoroutine(curMoveCor);
        curMoveCor = StartCoroutine(corPickingMove(_pos));
    }

    IEnumerator corPickingMove(Vector3 _pos)
    {
        //transform.LookAt(_pos, Vector3.up);
        while (true)
        {
            Vector3 dir = new Vector3(_pos.x, 0.0f, _pos.z) - new Vector3(transform.position.x, 0.0f, transform.position.z);

            Quaternion rotationTarget = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationTarget, rotationSpeed * Time.deltaTime);
            if (Vector3.Magnitude(dir) < 0.1f)
            {
                SetSpeed(0.0f);
                break;
            }

            dir.Normalize();
            transform.position += dir * Time.deltaTime * moveSpeed;

            yield return new WaitForEndOfFrame();
        }
    }
}
