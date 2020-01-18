using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed;

    Animator anim;
    static public PlayerController instance;
    // Start is called before the first frame update

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
        transform.position += new Vector3(_moveVector.x, 0.0f, _moveVector.y) * Time.deltaTime * speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
        anim.SetFloat("speed", _speed);
    }
}
