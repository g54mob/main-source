using UnityEngine;
using UnityEngine.AI;

public class CustomerHelperAnimationController : MonoBehaviour
{
	private static readonly int SpeedHash;

	private static readonly int InteractHash;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Animator m_Animator;

	private float m_AnimationWalkingSpeed;

	private OffMeshLinkNavigator m_OffMeshLinkNavigator;

	private void Awake()
	{
	}

	public void ManualUpdate()
	{
	}

	public void PlayInteraction()
	{
	}

	public void SetAnimationSpeed(float speed)
	{
	}
}
