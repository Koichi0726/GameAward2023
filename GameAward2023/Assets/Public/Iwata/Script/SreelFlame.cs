using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreelFlame : JankBase_iwata
{
    public int value = 5;   //攻撃したときの壁に掛ける倍率
    FixedJoint joint;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 鉄骨の動き
    /// </summary>
    public override void work()
    {

    }

    public override List<float> GetParam()
    {
        List<float> list = new List<float>();

        return list;
    }
    
    public override void SetParam(List<float> paramList)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Cage"))
        {
            Debug.Log("速度:" + rb.velocity);
            Vector3 force = rb.velocity * 150f; // 適宜調整
            Debug.Log("force:" + force);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
