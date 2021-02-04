
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{


    [SerializeField] float _speed = 5f;

    Animator _anim;



    void Awake()
    {
        _anim = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement *= Time.deltaTime * _speed;

        transform.Translate(movement, Space.World);

        _anim.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
        _anim.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);










    }
}
