using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] float _delay = 0.25f;
    [SerializeField] BlasterShot _blasterShotPrefab;

    [SerializeField] LayerMask _aimLayerMask;
    [SerializeField] Transform _firePoint;

    float _nextFireTime;


    List<Powerup> _powerups = new List<Powerup>(); 

    public void AddPowerup(Powerup powerup) => _powerups.Add(powerup);


    public void RemovePowerup(Powerup powerup) => _powerups.Remove(powerup);








    void Update()
    {
        AimTowordMouse();      // for direction of weapon 


        if (ReadToFire())
            Fire();
    }


    void AimTowordMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _aimLayerMask))
        {
            var destination = hitInfo.point;
            destination.y = transform.position.y;


            Vector3 direction = destination - transform.position;
            direction.Normalize();
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);


        }





    }



    bool ReadToFire() => Time.time >= _nextFireTime;


    void Fire()
    {

        float delay = _delay;
        foreach (var powerup in _powerups)
            delay *= powerup.DelayMultiplier;


         
        _nextFireTime = Time.time + delay;     // delay can also works as reload

        BlasterShot shot = Instantiate(_blasterShotPrefab, _firePoint.position, transform.rotation);
        shot.Launch(transform.forward);

    }




    








}
