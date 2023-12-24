public class FinishState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.SetDestination(t.target.position);
    }

    public void OnExcute(Bot t)
    {
        if (t.BrickCount == 0)
        {
            t.ChangeState(new CollectState());
        }
    }

    public void OnExit(Bot t)
    {
       
    }
}
