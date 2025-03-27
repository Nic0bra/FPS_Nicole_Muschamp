using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //Event for ammo change
    public UnityEvent<int> OnAmmoChanged = new UnityEvent<int>();

    //Event for fire gun camera shake
    public UnityEvent OnFire = new UnityEvent();

    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    // stats
    [SerializeField] int maxAmmo = 10;
    [SerializeField] float timeBetweenShots = 0.1f;

    // private variables
    int ammo;
    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        OnAmmoChanged?.Invoke(ammo);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if(elapsed < timeBetweenShots)
        {
            return false;
        }

        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;
        OnAmmoChanged.Invoke(ammo);
        OnFire.Invoke();


        return true;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);
        OnAmmoChanged?.Invoke(ammo);
    }
}
