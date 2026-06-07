using UnityEngine;
using UnityEngine.AI;

public class JanitorAnimationController : MonoBehaviour
{
	private static readonly int SpeedHash;

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

	public void SetAnimationSpeed(float speed)
	{
	}
}
