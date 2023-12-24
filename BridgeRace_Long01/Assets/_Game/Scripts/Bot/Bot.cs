using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public Transform target;
    public NavMeshAgent agent;
        
    IState<Bot> currentState;

    protected override void Start()
    {
        base.Start();
        ChangeState(new CollectState());
    }


    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);
        }
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
