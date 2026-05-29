using System;
using Photon.Pun;
using UnityEngine;

public class GlassInteraction : Interaction
{
	[SerializeField]
	private Camera m_ToolCamera;

	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_SqueegeeInteractionLayer;

	[SerializeField]
	private float m_HoldingInteractionTime;

	private Dust m_Dust;

	private Camera m_MainCamera;

	private bool m_HoldingUse;

	public Sponge sponge;

	public Action<float> onCleaning;

	public Action<bool> onCleaningStateChange;

	private PlayerInstance m_PlayerInstance;

	private NetworkGlassInteraction _networkGlassInteraction;

	private PhotonView m_PhotonView;

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private PlayerInstance PlayerInstance => null;

	private PhotonView PhotonView => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void Awake()
	{
	}

	public void SwitchSqueegee(bool isOpen, bool willAnimate)
	{
	}

	public void FakeSwitchSqueegee(bool isOpen, bool willAnimate)
	{
	}

	public void CheckForInteraction()
	{
	}

	private void CheckHoldingInteraction()
	{
	}

	[PunRPC]
	public void Cleaning_RPC(int dustID)
	{
	}

	[PunRPC]
	public void StopCleaningEffect_RPC(int dustID)
	{
	}

	private void SetCurrentDust(Dust dust)
	{
	}

	private void DustHint(bool show)
	{
	}

	private void DefaultHints(bool show)
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnBack()
	{
	}
}
