using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using Workbench.Wolfsbane.Multiplayer;
using __Project__.Scripts.Multiplayer.Customers;

public class CustomerAnimator : MonoBehaviour
{
	private static readonly int SpeedHash;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private float m_MinimumHeightForHighDisplay;

	[SerializeField]
	private float m_MinimumHeightForMediumDisplay;

	[SerializeField]
	private float m_MinimumHeightForMediumLowDisplay;

	private NetworkedAnimation m_NetworkedAnimation;

	private NetworkCustomer m_networkCustomer;

	private bool m_Bending;

	private Customer m_Customer;

	private PhotonView m_PhotonView;

	private ShoplifterTutorialCustomer m_TutorialCustomer;

	private bool m_IsShoplifterTutorial;

	private OffMeshLinkNavigator m_OffMeshNavigator;

	public bool ClientShoplifterRun { get; set; }

	public bool Shopping
	{
		set
		{
		}
	}

	public Animator Animator
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public NetworkedAnimation NetworkedAnimation => null;

	public NetworkCustomer NetworkCustomer => null;

	private void Awake()
	{
	}

	public void SetSpeed(float speed)
	{
	}

	public void SetWalkSpeed(float speed)
	{
	}

	public void StopAnimation()
	{
	}

	public void ForceRun()
	{
	}

	public void ManualUpdate()
	{
	}

	public void StopAnimator()
	{
	}

	public float GetAnimationSpeed()
	{
		return 0f;
	}

	public void PickUpProductFromDisplay(float displayHeight)
	{
	}

	public void HandItem()
	{
	}

	public void FinishAnimation(bool standUp)
	{
	}

	public void ExpensiveProduct()
	{
	}

	public void LookForProduct()
	{
	}

	public void HandPayment(bool play)
	{
	}

	public void ScanProduct()
	{
	}

	public void NeedHelp()
	{
	}

	public void ShoplifterLookForProduct()
	{
	}

	public void ShoplifterGotHit()
	{
	}

	public void ToggleInteraction(bool value)
	{
	}
}
