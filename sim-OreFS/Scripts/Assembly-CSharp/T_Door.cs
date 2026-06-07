using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_Door : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class DoorSaveData
	{
		public bool isOpen;
	}

	[Header("Save")]
	[SerializeField]
	private string saveId;

	[Header("Mode")]
	[SerializeField]
	private bool rotate = true;

	[SerializeField]
	private bool move;

	[Header("Targets")]
	[SerializeField]
	private Transform doorTransform;

	[SerializeField]
	private Vector3 closePosition;

	[SerializeField]
	private Vector3 openPosition;

	[SerializeField]
	private Vector3 closeRotation;

	[SerializeField]
	private Vector3 openRotation;

	[Header("Motion")]
	[SerializeField]
	private float speed = 6f;

	[SerializeField]
	private bool useLerp = true;

	[Header("Audio")]
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip openSfx;

	[SerializeField]
	private AudioClip closeSfx;

	[Header("State")]
	[SyncVar(hook = "OnStateChanged")]
	[SerializeField]
	private bool isOpen;

	private Coroutine routine;

	private bool _loadedOpen;

	private bool _hasLoadData;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isOpen;

	public bool IsOpen => isOpen;

	public string SaveID => "door-" + saveId;

	public bool IsShared => false;

	public Type SaveType => typeof(DoorSaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	public bool NetworkisOpen
	{
		get
		{
			return isOpen;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isOpen, 1uL, _Mirror_SyncVarHookDelegate_isOpen);
		}
	}

	private void Awake()
	{
		if (!doorTransform)
		{
			doorTransform = base.transform;
		}
	}

	public override void OnStartClient()
	{
		SnapSilent(isOpen);
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (_hasLoadData)
		{
			_hasLoadData = false;
			NetworkisOpen = _loadedOpen;
			SnapSilent(isOpen);
		}
	}

	public void Toggle()
	{
		if (base.isServer)
		{
			ServerSet(!isOpen);
		}
		else
		{
			CmdToggle();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdToggle()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdToggle();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Door::CmdToggle()", 113046428, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdSet(bool open)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSet__Boolean(open);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(open);
		SendCommandInternal("System.Void T_Door::CmdSet(System.Boolean)", -994809605, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSet(bool open)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Door::ServerSet(System.Boolean)' called when server was not active");
		}
		else if (isOpen != open)
		{
			NetworkisOpen = open;
		}
	}

	private void OnStateChanged(bool oldState, bool newState)
	{
		PlaySfx(newState);
		if (routine != null)
		{
			StopCoroutine(routine);
		}
		routine = StartCoroutine(Animate(newState));
	}

	private IEnumerator Animate(bool open)
	{
		Vector3 targetPos = (open ? openPosition : closePosition);
		Quaternion targetRot = Quaternion.Euler(open ? openRotation : closeRotation);
		while (true)
		{
			bool flag = true;
			if (move)
			{
				doorTransform.localPosition = (useLerp ? Vector3.Lerp(doorTransform.localPosition, targetPos, speed * Time.deltaTime) : Vector3.MoveTowards(doorTransform.localPosition, targetPos, speed * Time.deltaTime));
				if (Vector3.Distance(doorTransform.localPosition, targetPos) > 0.01f)
				{
					flag = false;
				}
			}
			if (rotate)
			{
				doorTransform.localRotation = (useLerp ? Quaternion.Lerp(doorTransform.localRotation, targetRot, speed * Time.deltaTime) : Quaternion.RotateTowards(doorTransform.localRotation, targetRot, speed * Time.deltaTime));
				if (Quaternion.Angle(doorTransform.localRotation, targetRot) > 0.1f)
				{
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
			yield return null;
		}
		if (move)
		{
			doorTransform.localPosition = targetPos;
		}
		if (rotate)
		{
			doorTransform.localRotation = targetRot;
		}
		routine = null;
	}

	private void SnapSilent(bool open)
	{
		if (routine != null)
		{
			StopCoroutine(routine);
			routine = null;
		}
		if (move)
		{
			doorTransform.localPosition = (open ? openPosition : closePosition);
		}
		if (rotate)
		{
			doorTransform.localRotation = Quaternion.Euler(open ? openRotation : closeRotation);
		}
	}

	private void PlaySfx(bool open)
	{
		if ((bool)audioSource)
		{
			AudioClip audioClip = (open ? openSfx : closeSfx);
			if ((bool)audioClip)
			{
				audioSource.PlayOneShot(audioClip);
			}
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		return new DoorSaveData
		{
			isOpen = isOpen
		};
	}

	public Task OnLoad(object value)
	{
		if (!(value is DoorSaveData doorSaveData))
		{
			return Task.CompletedTask;
		}
		if (!SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			return Task.CompletedTask;
		}
		if (base.isServer)
		{
			NetworkisOpen = doorSaveData.isOpen;
			SnapSilent(isOpen);
		}
		else
		{
			_loadedOpen = doorSaveData.isOpen;
			_hasLoadData = true;
		}
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		if (!string.IsNullOrEmpty(saveId))
		{
			SaveLoadManager.Subscribe(this, 50);
		}
	}

	private void OnDisable()
	{
		if (!string.IsNullOrEmpty(saveId))
		{
			SaveLoadManager.Unsubscribe(this);
		}
	}

	public T_Door()
	{
		_Mirror_SyncVarHookDelegate_isOpen = OnStateChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdToggle()
	{
		ServerSet(!isOpen);
	}

	protected static void InvokeUserCode_CmdToggle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdToggle called on client.");
		}
		else
		{
			((T_Door)obj).UserCode_CmdToggle();
		}
	}

	protected void UserCode_CmdSet__Boolean(bool open)
	{
		ServerSet(open);
	}

	protected static void InvokeUserCode_CmdSet__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSet called on client.");
		}
		else
		{
			((T_Door)obj).UserCode_CmdSet__Boolean(reader.ReadBool());
		}
	}

	static T_Door()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Door), "System.Void T_Door::CmdToggle()", InvokeUserCode_CmdToggle, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Door), "System.Void T_Door::CmdSet(System.Boolean)", InvokeUserCode_CmdSet__Boolean, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isOpen);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isOpen);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isOpen, _Mirror_SyncVarHookDelegate_isOpen, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isOpen, _Mirror_SyncVarHookDelegate_isOpen, reader.ReadBool());
		}
	}
}
