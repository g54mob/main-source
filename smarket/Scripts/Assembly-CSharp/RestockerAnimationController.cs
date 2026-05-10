using UnityEngine;
using UnityEngine.AI;

public class RestockerAnimationController : MonoBehaviour
{
	private static readonly int SpeedHash;

	private static readonly int CarryBoxHash;

	private static readonly int RemoveLabelHash;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Animator m_Animator;

	private OffMeshLinkNavigator m_OffMeshNavigator;

	private float m_AnimationWalkingSpeed;

	public bool Carrying
	{
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void ManualUpdate()
	{
	}

	public void RemoveLabelAnim()
	{
	}
}
