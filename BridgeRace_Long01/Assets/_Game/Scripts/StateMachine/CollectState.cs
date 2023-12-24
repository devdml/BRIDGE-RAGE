using UnityEngine;

public class CollectState : IState<Bot>
{
    private int targetBrick;

    public void OnEnter(Bot t)
    {

        targetBrick = Random.Range(1, 4);
        SeekTarget(t);
    }

    public void OnExcute(Bot t)
    {  
            if (t.BrickCount >= targetBrick)
            {
                t.ChangeState(new FinishState());
            } else
            {
                SeekTarget(t);
            }
    }

    public void OnExit(Bot t)
    {
        
    }

    private void SeekTarget(Bot t)
    {
        Debug.Log(t.stage);
        if (t.stage != null)
        {
            Brick brick = t.stage.SeekBrickPoint(t.colorType);

            if (brick == null)
            {
                t.ChangeState(new FinishState());
            }
            else
            {
                t.SetDestination(brick.transform.position);
            }
        }
        else
        {
            t.SetDestination(t.transform.position);
        }
    }
}
