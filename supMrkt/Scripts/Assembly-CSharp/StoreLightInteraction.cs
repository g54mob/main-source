using UnityEngine;
using __Project__.Scripts.Multiplayer;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class StoreLightInteraction : Interaction
{
	[SerializeField]
	private string storeTag;

	[SerializeField]
	private NetworkStoreLight networkStoreLight;

	private NetworkStoreLightInteraction m_NetworkStoreLightInteraction;

	private StoreLight m_StoreLight;

	private PlayerInstance m_PlayerInstance;

	private bool m_PlacingMode;

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

	public bool IsOccupied
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public NetworkStoreLightInteraction NetworkStoreLightInteraction => null;

	public StoreLight CurrentStoreLight => null;

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

	private void OnEnable()
	{
	}

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	public void OnCancel()
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnUse(bool down)
	{
	}

	private void TryPlaceFurniture()
	{
	}

	private bool CheckFloorIsStore()
	{
		return false;
	}

	public void PlaceStoreLight()
	{
	}

	public void PlaceStoreLight_LeftRoom()
	{
	}

	public void SetStoreLight(StoreLight storeLight)
	{
	}

	private void DefaultHint(bool show)
	{
	}
}
