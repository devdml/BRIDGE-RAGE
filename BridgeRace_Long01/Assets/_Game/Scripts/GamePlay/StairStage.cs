using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairStage : Singleton<StairStage>
{
    public Stage stage;

    private void Start()
    {
        stage = GetComponent<Stage>();
    }
}
