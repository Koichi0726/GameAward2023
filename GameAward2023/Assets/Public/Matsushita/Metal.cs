using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : JunkBase
{
    /// <summary>
    /// 蓄電器に当たったとき
    /// </summary>
    public override void HitCapacitor()
    {
        JunkBase JunkBase = GetComponent<JunkBase>();

        if (JunkBase != null)
        {
            JunkBase.Explosion();
        }
    }
}