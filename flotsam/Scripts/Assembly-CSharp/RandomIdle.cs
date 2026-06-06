using UnityEngine;

public class RandomIdle : StateMachineBehaviour
{
	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
	{
		animator.SetInteger("IdleIndex", Random.Range(0, 6));
	}
}
