
using UnityEngine;
using UnityEngine.AI;

public class enemymovement: MonoBehaviour
{

    [SerializeField] float _attackRange = 0.8f;  // set attack range to enemy for player

    [SerializeField] int _health = 2;       // set health means how many shots take enemy to die  

    int _currentHealth;

    Animator _anim;
    NavMeshAgent _navMeshAgent;

    bool Alive => _currentHealth > 0;

   
    void Awake()                          // 
    {

        _currentHealth = _health;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _navMeshAgent.enabled = false;

    }




    //enemy will died after hiting by blastershot

    void OnCollisionEnter(Collision collision)
    {

        var blasterShot = collision.collider.GetComponent<BlasterShot>();
        if (blasterShot != null)                                            // if blaster shot is hit something then the health will decrese untill its equal to 0  
        {
            _currentHealth--;
            if (_currentHealth <= 0)
                Die();
            else
                TakeHit();

        }
    }

    public void StartWalking()                               // enemy will be in idle(moving) position
    {

        _navMeshAgent.enabled = true;
        _anim.SetBool("Moving", true);


    }





    void TakeHit()
    {
        _navMeshAgent.enabled = false;
        _anim.SetTrigger("Hit");

    }


    



    void Die()
    {
        GetComponent<Collider>().enabled = false;
        _navMeshAgent.enabled = false;
        _anim.SetTrigger("Died");

        //enemy will disapear after die from scene view after 5 seconds
        Destroy(gameObject, 5f);
    }




    // Update is called once per frame
    void Update()
    {
        if (!Alive)
            return;



        var player = FindObjectOfType<PlayerMovements>();

        if(_navMeshAgent.enabled)
           _navMeshAgent.SetDestination(player.transform.position);


        if (Vector3.Distance(transform.position, player.transform.position) < _attackRange)
            Attack();



    }




    void Attack()
    {
        _anim.SetTrigger("Attack");
        _navMeshAgent.enabled = false;
    }



    #region Animation Callback form event

    void AttackComplete()
    {
        if(Alive)
        _navMeshAgent.enabled = true;
        Debug.Log("attackcompelete");
    }



    //Aniamtion callback form event
    void AttackHit()
    {
        Debug.Log("Killed Player");
    }


    void HitComplete()
    {
        if (Alive)
            _navMeshAgent.enabled = true;
    }

    #endregion Animation callback form event

}
