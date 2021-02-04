using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField] float _duration = 10f;            // for powerup time which 10seconds

    [SerializeField] float _delayMultiplier = 0.1f;    // gap between shots which is 0.1seconds
    [SerializeField] float _Cooldown = 10f;             // after powerup 10seconds ,gun can be repowerup after 10 seconds  

    [SerializeField] Transform[] _spawnPoints;


    public float DelayMultiplier => _delayMultiplier;

    void OnTriggerEnter(Collider other)
    {
        var playerWeapon = other.GetComponent<PlayerWeapon>();
        if(playerWeapon)
        {
            playerWeapon.AddPowerup(this);
            StartCoroutine(DisableAfterDelay(playerWeapon));
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
            
    }


    IEnumerator DisableAfterDelay(PlayerWeapon playerWeapon)
    {
        yield return new WaitForSeconds(_duration);
        playerWeapon.RemovePowerup(this);

        yield return new WaitForSeconds(_Cooldown);

        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        transform.position = _spawnPoints[randomIndex].position;

        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
    }


}
