using UnityEngine;

public class ScanAnimationHandler : StateMachineBehaviour
{
	private float m_ScanSpeed;

	private Cashier m_Cashier;

	private float m_CachedScanSpeed;

	public float ScanSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
	{
	}
}
