using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class DoorBase : NetworkBehaviour, IDoor
{
	public DoorMovementType movementType;

	public float openingTime = 1f;

	[SyncVar(hook = "OnDoorStateChanged")]
	protected bool isOpened;

	protected bool isNetworkReady;

	protected string saveKey;

	public bool IsOpened => isOpened;

	public bool NetworkisOpened
	{
		get
		{
			return isOpened;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isOpened, 1uL, OnDoorStateChanged);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		CheckNetworkReady();
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		CheckNetworkReady();
	}

	protected virtual void Start()
	{
		saveKey = ComputeSaveKey();
		StartCoroutine(WaitForNetworkReady());
	}

	protected string ComputeSaveKey()
	{
		return "Door_" + GetStableDoorKey(this);
	}

	private IEnumerator WaitForNetworkReady()
	{
		while (!isNetworkReady)
		{
			CheckNetworkReady();
			if (!isNetworkReady)
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
		LoadDoorState();
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveDoorState);
		Singleton<ES3SaveManager>.Instance.OnPreLoad.AddListener(LoadDoorState);
		Debug.Log($"[DOORSAVE] Listeners registered '{base.name}' | saveKey={saveKey} | serverActive={NetworkServer.active}");
	}

	private void CheckNetworkReady()
	{
		NetworkIdentity componentInParent = GetComponentInParent<NetworkIdentity>();
		isNetworkReady = componentInParent == null || componentInParent.netId != 0 || NetworkServer.active;
	}

	protected virtual void LoadDoorState()
	{
		if (NetworkServer.active)
		{
			saveKey = ComputeSaveKey();
			bool flag = Singleton<ES3SaveManager>.Instance.LoadData(saveKey, defaultValue: false);
			Debug.Log($"[DOORSAVE] LOAD '{base.name}' key={saveKey} savedState={flag} current={isOpened}");
			if (flag != isOpened)
			{
				NetworkisOpened = flag;
				OnDoorStateChanged(isOpened, flag);
			}
		}
	}

	protected virtual void SaveDoorState()
	{
		if (NetworkServer.active)
		{
			saveKey = ComputeSaveKey();
			Singleton<ES3SaveManager>.Instance.SaveData(saveKey, isOpened);
			Debug.Log($"[DOORSAVE] SAVE '{base.name}' key={saveKey} isOpened={isOpened}");
		}
	}

	public virtual void OpenDoor()
	{
		Debug.LogWarning("OpenDoor method should be overridden in derived class");
	}

	public virtual void CloseDoor()
	{
		Debug.LogWarning("CloseDoor method should be overridden in derived class");
	}

	public static string GetStableDoorKey(DoorBase door)
	{
		if (door == null)
		{
			return "";
		}
		PropBase component = door.GetComponent<PropBase>();
		if (component != null && !string.IsNullOrEmpty(component.uniqueID))
		{
			return component.uniqueID;
		}
		Transform obj = door.transform;
		string text = obj.name;
		Transform parent = obj.parent;
		while (parent != null)
		{
			PropBase component2 = parent.GetComponent<PropBase>();
			if (component2 != null && !string.IsNullOrEmpty(component2.uniqueID))
			{
				return "owner:" + component2.uniqueID + ":" + text;
			}
			WagonController component3 = parent.GetComponent<WagonController>();
			if (component3 != null)
			{
				return $"scene:{component3.wagonID}:{text}";
			}
			text = parent.name + "/" + text;
			parent = parent.parent;
		}
		return "scene:-1:" + text;
	}

	public virtual int GetClosestLeafIndex(Vector3 worldPos)
	{
		return -1;
	}

	public virtual Transform GetMovingPart(int index)
	{
		return null;
	}

	public virtual void Interact()
	{
		if (base.isServer)
		{
			OnDoorStateChanged(newValue: NetworkisOpened = !isOpened, oldValue: isOpened);
			return;
		}
		CmdToggleDoor();
	}

	[Command(requiresAuthority = false)]
	protected void CmdToggleDoor()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DoorBase::CmdToggleDoor()", -1159670502, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	protected virtual void OnDoorStateChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			OpenDoor();
			PlayDoorSound(GameAudios.WoodenDoorOpen);
		}
		else
		{
			CloseDoor();
			PlayDoorSound(GameAudios.WoodenDoorClose);
		}
	}

	protected void PlayDoorSound(GameAudios audio)
	{
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound(audio, base.transform.position);
		}
	}

	protected virtual void OnDestroy()
	{
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveDoorState);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.RemoveListener(LoadDoorState);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdToggleDoor()
	{
		OnDoorStateChanged(newValue: NetworkisOpened = !isOpened, oldValue: isOpened);
	}

	protected static void InvokeUserCode_CmdToggleDoor(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdToggleDoor called on client.");
		}
		else
		{
			((DoorBase)obj).UserCode_CmdToggleDoor();
		}
	}

	static DoorBase()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DoorBase), "System.Void DoorBase::CmdToggleDoor()", InvokeUserCode_CmdToggleDoor, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isOpened);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isOpened);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isOpened, OnDoorStateChanged, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isOpened, OnDoorStateChanged, reader.ReadBool());
		}
	}
}
