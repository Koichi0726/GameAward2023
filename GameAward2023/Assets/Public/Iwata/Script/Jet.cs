using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : JankBase_iwata
{
    [SerializeReference] float m_boostForceRate;        //速度
    [SerializeReference] float m_maxSpeed;          //最高速度

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    /// <summary>
    /// ジェットの動き
    /// </summary>
    public override void work()
    {
       //--- 現在のスピードを取得
       Rigidbody rigidbody = this.transform.GetComponent<Rigidbody>();
       float currentSpeed = rigidbody.velocity.magnitude;

       // ブースト用のベクトルを計算
       Vector3 boostFoce = this.transform.forward.normalized * m_boostForceRate;

        // 最大速度以下の時のみ処理する
        if (currentSpeed < m_maxSpeed)
        {
            rigidbody.AddForce(boostFoce);	// ブースト処理
        }

        Vector3 effectPos = this.transform.position;
        Vector3 direction = transform.forward;

        // 少し後ろに移動する
        Vector3 offset = -direction * 1f;
        effectPos += offset;

        Vector3 size = new Vector3(3f, 3f, 3f);
        float deff = m_boostForceRate - 100f;
        if(deff < 0)
        {
            size *= 0.5f;
        }
        else if(deff > 0)
        {
            size *= 1.5f;
        }

        //ジェットの炎のエフェクト表示
        EffectManager_iwata.PlayEffect(EffectType.E_EFFECT_KIND_JET, effectPos, this.transform.parent, size);
    }

    public override List<float> GetParam()
    {
        List<float> list = new List<float>();

        list.Add(m_boostForceRate);
        list.Add(m_maxSpeed);

        return list;
    }
    
    public override void SetParam(List<float> paramList)
    {
        m_boostForceRate = paramList[0];
        m_maxSpeed = paramList[1];
    }
}
