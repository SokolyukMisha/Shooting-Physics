using UnityEngine;

public class Recoil : MonoBehaviour
{
    WeaponZoom weaponZoom;
    bool isAiming;

    Vector3 currentRotation;
    Vector3 targetRotation;

    [SerializeField] float recoilX, recoilY, recoilZ;

    [SerializeField] float zoomRecoilX, zoomRecoilY, zoomRecoilZ;

    [SerializeField] float snappines, returnSpeed;

    void Start()
    {
        weaponZoom = GetComponentInChildren<WeaponZoom>();
    }

    void Update()
    {
        if (weaponZoom != null)
        {
            isAiming = weaponZoom.ZoomInToggle();
        }
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappines * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        if (isAiming)
        {
            targetRotation += new Vector3(zoomRecoilX, Random.Range(-zoomRecoilY, zoomRecoilY), Random.Range(-zoomRecoilZ, zoomRecoilZ));
        }
        else
        {
            targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        }
    }
}
