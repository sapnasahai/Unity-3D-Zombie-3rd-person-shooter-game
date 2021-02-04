
using UnityEngine;

public class BlasterShot : MonoBehaviour
{

    [SerializeField] float _speed = 15f;




    public void Launch(Vector3 direction)
    {


        direction.Normalize();
        transform.up = direction;
        GetComponent<Rigidbody>().velocity = direction * _speed;


    }



   


    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        
    }



    void Awake()
    {
        Destroy(gameObject, 5f);
        
    }
    










}
