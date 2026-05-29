using UnityEngine;
using __Project__.Scripts.Multiplayer;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class StorageLightInteraction : Interaction
{
	[SerializeField]
	private string storageTag;

	[SerializeField]
	private NetworkStorageLight networkStorageLight;

	private NetworkStorageLightInteraction m_NetworkStorageLightInteraction;

	private StorageLight m_StorageLight;

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

	public NetworkStorageLightInteraction NetworkStorageLightInteraction => null;

	public StorageLight CurrentStorageLight => null;

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

	private bool CheckFloorIsStorage()
	{
		return false;
	}

	public void PlaceStorageLight()
	{
	}

	public void PlaceStorageLight_LeftRoom()
	{
	}

	public void SetStorageLight(StorageLight storageLight)
	{
	}

	private void DefaultHint(bool show)
	{
	}
}
