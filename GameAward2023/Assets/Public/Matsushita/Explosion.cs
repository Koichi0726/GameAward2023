using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionForce = 1000f; // 爆発力
    [SerializeField] private float explosionRadius = 15f; // 爆発半径


    /// <summary>
    /// fixjointをなくして爆発する
    /// </summary>
    public void Blast()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            // FixedJointを削除する
            FixedJoint[] allJoints = FindObjectsOfType<FixedJoint>();
            foreach (FixedJoint joint in allJoints)
            {
                Destroy(joint);
            }

            if (rb == null) continue;
            
            rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 3.0F);
            
        }
    }
}