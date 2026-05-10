using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoplifter : MonoBehaviour
{
	[HideInInspector]
	public SecurityGuard OccupiedGuard;

	protected RuntimeAnimatorController m_AnimatorController;

	protected Animator m_Animator;

	private Customer m_Customer;

	protected Bounds m_Bounds;

	private bool m_IsDetected;

	private List<string> m_CustomerSpeechType;

	private ShoplifterIndicator m_Indicator;

	protected NavMeshAgent agent;

	public bool isCrateFull;

	public bool IsDetected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Customer Customer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void StopAgent()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected virtual void CheckVisibility()
	{
	}

	public void SpawnIndicator(bool OnAlert)
	{
	}

	public void DespawnIndicator()
	{
	}

	public virtual void Initialize(Animator animator, RuntimeAnimatorController animatorController)
	{
	}

	public void SetAnimator()
	{
	}

	public bool IsOccupied(out SecurityGuard securityGuard)
	{
		securityGuard = null;
		return false;
	}

	public bool OccupiShoplifter(SecurityGuard securityGuard)
	{
		return false;
	}

	public void RelaseShoplifter()
	{
	}

	public virtual void SpawnSpeech()
	{
	}
}
