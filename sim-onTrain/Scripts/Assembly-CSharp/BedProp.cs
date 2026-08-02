using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.Localization;

public class BedProp : NetworkBehaviour, IInteractable
{
	private bool isActive = true;

	private bool isInteracting;

	private TSPlayerController player;

	private TrainGameManager gameManager;

	[SerializeField]
	private Transform sleepPoint;

	[SerializeField]
	private float sleepCameraOffsetY;

	[SerializeField]
	private Transform interactionParent;

	[SyncVar]
	public bool isFull;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString bedFullLocalized;

	[SerializeField]
	private LocalizedString onlyNightLocalized;

	[SerializeField]
	private LocalizedString sleepLocalized;

	[SerializeField]
	private LocalizedString wakeUpLocalized;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public bool NetworkisFull
	{
		get
		{
			return isFull;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isFull, 1uL, null);
		}
	}

	private void Start()
	{
		gameManager = TrainGameManager.Instance;
	}

	private void Update()
	{
		if (isFull && gameManager != null && !TrainGameManager.isSkippingToMorning && !Singleton<GameSettings>.Instance.IsNightTime(gameManager.currentTime) && player != null)
		{
			player.WakeUp();
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (isFull)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(bedFullLocalized, "Bed is Full"));
		}
		else if (!Singleton<GameSettings>.Instance.IsNightTime(gameManager.currentTime))
		{
			InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(onlyNightLocalized, "You can only sleep at night"));
		}
		else if (isInteracting)
		{
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				Sleep(playerInventory.GetComponent<TSPlayerController>());
			}
		}
		else
		{
			player = playerInventory.GetComponent<TSPlayerController>();
			isInteracting = true;
			InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(sleepLocalized, "Sleep"));
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		InteractionPanel.Instance.HidePanels();
		if (player != null)
		{
			player.GetComponent<Interactor>().lastInteractable = null;
		}
	}

	public void Sleep(TSPlayerController tsPlayer)
	{
		NetworkisFull = true;
		player = tsPlayer;
		tsPlayer.transform.SetPositionAndRotation(sleepPoint.position, sleepPoint.rotation);
		tsPlayer.Sleep(sleepCameraOffsetY, this, base.netId);
		InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, tsPlayer.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(wakeUpLocalized, "Wake Up"));
	}

	public void WakeUp()
	{
		NetworkisFull = false;
		player = null;
	}

	[Server]
	public void ServerSetFull(bool full)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BedProp::ServerSetFull(System.Boolean)' called when server was not active");
		}
		else
		{
			NetworkisFull = full;
		}
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isFull);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isFull);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isFull, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isFull, null, reader.ReadBool());
		}
	}
}
