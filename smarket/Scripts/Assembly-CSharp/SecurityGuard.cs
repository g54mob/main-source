using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class SecurityGuard : MonoBehaviour
{
	public int ID;

	public Crate GuardCrate;

	[HideInInspector]
	public Restocker FakeRestocker;

	[SerializeField]
	private SecurityGuardBehaviourData m_BehaviourData;

	[SerializeField]
	private GameObject m_BaseballBat;

	private SecurityGuardStateController m_StateController;

	private SecurityGuardAnimationController m_AnimController;

	private Vector3 m_IdlePosition;

	public List<Product> ProductsToCollect;

	private NetworkSecurityGuard m_NetworkSecurityGuard;

	public GameObject BaseballBat => null;

	public bool ShouldChase => false;

	public SecurityGuardAnimationController Controller => null;

	public SecurityGuardBehaviourData BehaviourData => null;

	public Vector3 IdlePosition
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public NetworkSecurityGuard NetworkSecurityGuard => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void SubscribeEvents()
	{
	}

	private void UnSubscribeEvents()
	{
	}

	public void Setup()
	{
	}

	private void OnDayFinished()
	{
	}

	private void OnSecurityGuardFired(int ID)
	{
	}

	private void OnSectionPositionChanged(Vector3 vector)
	{
	}

	public void OnShoplifterDetected(Shoplifter shoplifter, bool OnAlert)
	{
	}

	private void Awake()
	{
	}

	public void ToggleBaseballBat(bool isEnable)
	{
	}

	public void StateChase()
	{
	}

	public void StateIdle()
	{
	}

	public void StateCollecting()
	{
	}

	public void StateRestocking()
	{
	}

	public void StatePatroling()
	{
	}

	public void StateFired()
	{
	}

	public void AddProductIntoCrate(Product product)
	{
	}
}
