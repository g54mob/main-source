using System;
using UnityEngine;
using __Project__.Scripts.Computer;
using __Project__.Scripts.Multiplayer.NetworkComputer;

public class ComputerInteraction : Interaction
{
	private Computer m_Computer;

	private bool m_PlacingMode;

	public bool isInDoorCamera;

	private NetworkComputerInteraction m_NetworkComputerInteraction;

	public Action onComputerInteractionStopped;

	public Action onComputerInteractionStart;

	public Action onDestroyed;

	private PlayerInstance m_PlayerInstance;

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

	public Computer CurrentComputer => null;

	public NetworkComputerInteraction NetworkComputerInteraction => null;

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

	public bool PlacingMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnUse(bool down)
	{
	}

	public void OnCancel()
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void PlaceComputer()
	{
	}

	public void PlaceComputerForce()
	{
	}

	private void DefaultHint(bool show)
	{
	}

	public void MovingHints(bool show)
	{
	}

	public void SetComputer(Computer computer)
	{
	}

	public void PlaceComputerOrder(Vector3 playSoundPosition)
	{
	}

	public void CancelInteractionForOnlyMultiplayer()
	{
	}
}
