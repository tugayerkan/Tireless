using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitForce : MonoBehaviour
{
    public Transform spawnPosition;
    public float speed = 1000;
    public Transform[] bulletTransform;
    private int bulletIndex = 0;
    public GameObject Bullet;
    public ActionController trigger;
    public GameObject Container;

    public IEnumerator Triggered()
    {
        while (bulletIndex < bulletTransform.Length)
        {
            GameObject projectile = Instantiate(Bullet, spawnPosition.position, Quaternion.identity,Container.transform) as GameObject; //Spawns the selected projectile
            projectile.transform.LookAt(bulletTransform[bulletIndex].position); //Sets the projectiles rotation to look at the point clicked
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody
            bulletIndex++;
            yield return new WaitForSeconds(0.25f);


        }
    }

}
