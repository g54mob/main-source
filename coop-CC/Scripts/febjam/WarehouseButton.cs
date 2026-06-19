using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class WarehouseButton : NetworkEntityBehaviourBase
{
	public Transform buttonObject;

	[Min(0f)]
	public float pressDistanceThreshold = 0.1f;

	[Min(0f)]
	public float minimumPressDuration = 1f;

	[Space]
	public bool destroyOnPressed;

	public Transform destroyLocation;

	public float destroyRadius = 3f;

	public GameObject[] destroyedPrefabs;

	public GameObject[] destroyedVFX;

	[SyncVar]
	private WarehouseButtonState _syncState;

	private bool _pressed;

	private bool _receivedResponse;

	private Vector3 _originalPosition;

	private Timer _serverTimer;

	public EventReference buttonClick;

	private EventInstance _clickInstance;

	public Color blankColor = Color.white;

	public Color activatedColor = Color.white;

	public Renderer buttonRenderer;

	public static readonly int FLASHING_PROPERTY_ID;

	public EventReference pushSfx;

	public WarehouseButtonState buttonState => _syncState;

	public WarehouseButtonState Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_clickInstance = RuntimeManager.CreateInstance(buttonClick);
		_clickInstance.set3DAttributes(base.transform.To3DAttributes());
		_originalPosition = buttonObject.transform.position;
	}

	protected override void OnEntityDestroyed()
	{
		_clickInstance.release();
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				IWarehouseButton obj;
				if (_syncState == WarehouseButtonState.Destroying)
				{
					if (destroyedVFX.Length != 0)
					{
						GameObject[] array = destroyedVFX;
						foreach (GameObject prefab in array)
						{
							NetworkAggroManagerBase<VFXManager>.instance.Play(prefab, destroyLocation.transform.position);
						}
					}
					Unity.Mathematics.Random random = GetRandom();
					Vector3 position = destroyLocation.transform.position;
					for (int j = 0; j < destroyedPrefabs.Length; j++)
					{
						GameObject gameObject = destroyedPrefabs[j];
						if (gameObject != null)
						{
							EntityUtil.Instantiate(gameObject, position + (Vector3)random.NextFloat3Direction() * destroyRadius, random.NextQuaternionRotation());
						}
					}
					EntityUtil.Destroy(base.entity);
				}
				else if (base.entity.TryGetObject<IWarehouseButton>(out obj))
				{
					Network_syncState = obj.ServerGetButtonState();
				}
				else
				{
					Network_syncState = WarehouseButtonState.Pressed;
				}
			}
		}
		if (_syncState == WarehouseButtonState.Pressed)
		{
			return;
		}
		if ((buttonObject.transform.position - _originalPosition).sqrMagnitude >= pressDistanceThreshold * pressDistanceThreshold)
		{
			if (!_pressed)
			{
				_pressed = true;
				_receivedResponse = false;
				CmdRequestPress();
			}
		}
		else if (_receivedResponse)
		{
			_pressed = false;
		}
	}

	protected override void OnUpdatePresentation()
	{
		switch (buttonState)
		{
		case WarehouseButtonState.Pressed:
		case WarehouseButtonState.Destroying:
			buttonRenderer.SetPropertyBlockColor(MaterialUtil.MAIN_COLOR_ID, activatedColor);
			buttonRenderer.SetPropertyBlockFloat(FLASHING_PROPERTY_ID, 0f);
			break;
		case WarehouseButtonState.Unpressed:
			buttonRenderer.SetPropertyBlockColor(MaterialUtil.MAIN_COLOR_ID, blankColor);
			buttonRenderer.SetPropertyBlockFloat(FLASHING_PROPERTY_ID, 1f);
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestPress(NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void WarehouseButton::CmdRequestPress(Mirror.NetworkConnectionToClient)", 1297899869, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcRequestProcessed(NetworkConnectionToClient target, bool accepted)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(accepted);
		SendTargetRPCInternal(target, "System.Void WarehouseButton::RpcRequestProcessed(Mirror.NetworkConnectionToClient,System.Boolean)", -283232684, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcButtonPressed()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void WarehouseButton::RpcButtonPressed()", 1566319239, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmos()
	{
		if (destroyOnPressed && destroyLocation != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(destroyLocation.transform.position, destroyRadius);
		}
	}

	static WarehouseButton()
	{
		FLASHING_PROPERTY_ID = Shader.PropertyToID("_flashing");
		RemoteProcedureCalls.RegisterCommand(typeof(WarehouseButton), "System.Void WarehouseButton::CmdRequestPress(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestPress__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(WarehouseButton), "System.Void WarehouseButton::RpcButtonPressed()", InvokeUserCode_RpcButtonPressed);
		RemoteProcedureCalls.RegisterRpc(typeof(WarehouseButton), "System.Void WarehouseButton::RpcRequestProcessed(Mirror.NetworkConnectionToClient,System.Boolean)", InvokeUserCode_RpcRequestProcessed__NetworkConnectionToClient__Boolean);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestPress__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		if (_syncState == WarehouseButtonState.Unpressed)
		{
			if (destroyOnPressed)
			{
				Network_syncState = WarehouseButtonState.Destroying;
				if (base.entity.TryGetObject<Station>(out var obj))
				{
					obj.ServerSetUnpickable();
				}
			}
			else
			{
				Network_syncState = WarehouseButtonState.Pressed;
			}
			_serverTimer.SetTimer(minimumPressDuration);
			base.entity.GetObject<IWarehouseButton>().ServerButtonPressed(conn);
			RpcRequestProcessed(conn, accepted: true);
			RpcButtonPressed();
		}
		else
		{
			RpcRequestProcessed(conn, accepted: false);
		}
	}

	protected static void InvokeUserCode_CmdRequestPress__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestPress called on client.");
		}
		else
		{
			((WarehouseButton)obj).UserCode_CmdRequestPress__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcRequestProcessed__NetworkConnectionToClient__Boolean(NetworkConnectionToClient target, bool accepted)
	{
		_receivedResponse = true;
		if (accepted)
		{
			base.entity.GetObject<IWarehouseButton>().ClientButtonPressed();
		}
	}

	protected static void InvokeUserCode_RpcRequestProcessed__NetworkConnectionToClient__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcRequestProcessed called on server.");
		}
		else
		{
			((WarehouseButton)obj).UserCode_RpcRequestProcessed__NetworkConnectionToClient__Boolean(null, reader.ReadBool());
		}
	}

	protected void UserCode_RpcButtonPressed()
	{
		_clickInstance.start();
		if (!pushSfx.IsNull)
		{
			AudioManager.PlaySfx(pushSfx, base.transform.position);
		}
	}

	protected static void InvokeUserCode_RpcButtonPressed(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcButtonPressed called on server.");
		}
		else
		{
			((WarehouseButton)obj).UserCode_RpcButtonPressed();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_WarehouseButtonState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_WarehouseButtonState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_WarehouseButtonState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_WarehouseButtonState(reader));
		}
	}
}
