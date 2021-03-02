using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehaviour : MonoBehaviour
{
    //projectille
    [SerializeField] GameObject projectille;

    //projectile forces
    [SerializeField] float shootForce;
    //slingshoot stats
    [SerializeField] float timebetweenshooting, reloadTime;

    //shooting flags
    [SerializeField] bool shootting, readyToShoot, allowInvoke;

    //externals
    [SerializeField] Transform slingshoot;
    [SerializeField] Camera fpsCam;

    private void Awake()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    void Update() {
        ShootInput();
    }

    void ShootInput() {
        if(Input.GetMouseButtonDown(0) && readyToShoot) {
            shoot();
        }
    }

    void shoot() {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // um raycast que passsa pelo meio da minha atual visão
        RaycastHit hit;

        //checa se o raycast atingio algo
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(2);

        //calcula a direção do estilingue para o alvo
        Vector3 projectilleDirection = targetPoint - slingshoot.position;

        //geração do projétil
        GameObject currentProjectile = Instantiate(projectille, slingshoot.position, Quaternion.identity);


        //adição de força para o projétil
        currentProjectile.GetComponent<Rigidbody>().AddForce(shootForce * projectilleDirection.normalized, ForceMode.Impulse);

        if(allowInvoke)
        {
            Invoke("ResetShot", timebetweenshooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}
