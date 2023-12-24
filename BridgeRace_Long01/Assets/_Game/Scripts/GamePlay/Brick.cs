using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorData
{
    [HideInInspector] public Stage Stage;

    public void OnDespawn()
    {
        Stage.RemoveBrick(this);
    }
}
