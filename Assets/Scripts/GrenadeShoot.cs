using UnityEngine;

public class GrenadeShoot : MonoBehaviour
{

    [SerializeField] GameObject bullet;    
    [SerializeField] ParticleSystem muzzelFlash;

    Recoil recoil;

    public float blastPower;
    public GameObject shootPoint;

    private void Start()
    {
        recoil = transform.GetComponentInParent(typeof(Recoil)) as Recoil;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        recoil.RecoilFire();
        muzzelFlash.Play();
        GameObject createBullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = shootPoint.transform.up * blastPower;
    }
}
