using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class RackInteraction : Interaction
{
	private Rack m_Rack;

	private PlayerInstance m_ownedPlayerInstance;

	public NetworkRackInteraction NetworkRackInteraction;

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

	public Rack CurrentRack => null;

	public PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpRack()
	{
	}

	public void BoxUpRackNetwork()
	{
	}

	public void CancelInteractionForMultiplayer()
	{
	}

	private void TryPlaceFurniture()
	{
	}

	public void PlaceFurniture(Vector3 playSoundPosition)
	{
	}

	public void SetRack(Rack rack)
	{
	}

	private void DefaultHint(bool show)
	{
	}
}
