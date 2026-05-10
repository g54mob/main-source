using UnityEngine;
using UnityEngine.AI;

public class CashierAnimationController : MonoBehaviour
{
	private static readonly int SpeedHash;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Animator m_Animator;

	public bool Carrying
	{
		set
		{
		}
	}

	public void ManualUpdate()
	{
	}

	public void SetAnimationSpeed(float speed)
	{
	}
}
