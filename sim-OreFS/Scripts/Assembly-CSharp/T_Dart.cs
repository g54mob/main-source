using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_Dart : NetworkBehaviour
{
	[Header("References")]
	[SerializeField]
	private Collider dartCollider;

	[SerializeField]
	private PredictedRigidbody predictedRigidbody;

	[Header("Throw Settings")]
	[SerializeField]
	private float throwForce = 15f;

	[SerializeField]
	private float angularForce = 2f;

	[Header("Stick Settings")]
	[SerializeField]
	private LayerMask stickLayers;

	[Header("SFX")]
	[SerializeField]
	private AudioClip hitSFX;

	[SerializeField]
	private AudioSource audioSource;

	[SyncVar]
	private bool isStuck;

	[SyncVar]
	private uint ownerPlayerNetId;

	[SyncVar]
	private string ownerPlayerName = "";

	private bool hasBeenThrown;

	private T_Dartboard assignedDartboard;

	public bool IsStuck => isStuck;

	public uint OwnerPlayerNetId => ownerPlayerNetId;

	public string OwnerPlayerName => ownerPlayerName;

	private Rigidbody Rb
	{
		get
		{
			if (!(predictedRigidbody != null))
			{
				return null;
			}
			return predictedRigidbody.predictedRigidbody;
		}
	}

	public bool NetworkisStuck
	{
		get
		{
			return isStuck;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isStuck, 1uL, null);
		}
	}

	public uint NetworkownerPlayerNetId
	{
		get
		{
			return ownerPlayerNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref ownerPlayerNetId, 2uL, null);
		}
	}

	public string NetworkownerPlayerName
	{
		get
		{
			return ownerPlayerName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref ownerPlayerName, 4uL, null);
		}
	}

	private void Awake()
	{
		EnsureRefs();
	}

	private void EnsureRefs()
	{
		if (!dartCollider)
		{
			dartCollider = GetComponent<Collider>();
		}
		if (!predictedRigidbody)
		{
			predictedRigidbody = GetComponent<PredictedRigidbody>();
		}
		if (!audioSource)
		{
			audioSource = GetComponent<AudioSource>();
		}
		if (!audioSource)
		{
			audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.spatialBlend = 1f;
			audioSource.playOnAwake = false;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		EnsureRefs();
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component)
		{
			component.isKinematic = true;
			component.useGravity = false;
			component.linearDamping = 0.5f;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		EnsureRefs();
	}

	[Server]
	public void ServerSetOwnerPlayer(uint playerNetId, string playerName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dart::ServerSetOwnerPlayer(System.UInt32,System.String)' called when server was not active");
			return;
		}
		NetworkownerPlayerNetId = playerNetId;
		NetworkownerPlayerName = playerName;
	}

	[Server]
	public void ServerSetDartboard(T_Dartboard dartboard)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dart::ServerSetDartboard(T_Dartboard)' called when server was not active");
		}
		else
		{
			assignedDartboard = dartboard;
		}
	}

	public void ClientThrow(Vector3 direction, float chargeForce = -1f)
	{
		if (!hasBeenThrown)
		{
			hasBeenThrown = true;
			float num = ((chargeForce >= 0f) ? chargeForce : throwForce);
			Vector3 force = direction.normalized * num;
			Vector3 torque = Random.insideUnitSphere * angularForce;
			if (Rb != null)
			{
				Rb.isKinematic = false;
				Rb.useGravity = true;
				Rb.linearVelocity = Vector3.zero;
				Rb.angularVelocity = Vector3.zero;
				Rb.AddForce(force, ForceMode.VelocityChange);
				Rb.AddTorque(torque, ForceMode.VelocityChange);
			}
			CmdApplyThrowForce(force, torque);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdApplyThrowForce(Vector3 force, Vector3 torque)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdApplyThrowForce__Vector3__Vector3(force, torque);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(force);
		writer.WriteVector3(torque);
		SendCommandInternal("System.Void T_Dart::CmdApplyThrowForce(UnityEngine.Vector3,UnityEngine.Vector3)", 88515898, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!base.isServer || isStuck)
		{
			return;
		}
		int layer = collision.gameObject.layer;
		Debug.Log($"[T_Dart] OnCollisionEnter - obj: {collision.gameObject.name}, layer: {layer}, stickLayers: {stickLayers.value}, match: {((1 << layer) & (int)stickLayers) != 0}");
		if (((1 << layer) & (int)stickLayers) != 0)
		{
			ServerStick();
			Debug.Log($"[T_Dart] Stuck! assignedDartboard: {assignedDartboard != null}, contactCount: {collision.contactCount}");
			if (assignedDartboard != null && collision.contactCount > 0)
			{
				Vector3 point = collision.GetContact(0).point;
				assignedDartboard.ServerRegisterDartHit(this, point);
				Debug.Log($"[T_Dart] ServerRegisterDartHit called - hitPoint: {point}");
			}
			ServerNotifyDartStuck();
		}
	}

	[Server]
	private void ServerStick()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dart::ServerStick()' called when server was not active");
			return;
		}
		NetworkisStuck = true;
		if (predictedRigidbody != null)
		{
			predictedRigidbody.enabled = false;
		}
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component)
		{
			Vector3 position = component.position;
			Quaternion rotation = component.rotation;
			component.linearVelocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
			component.isKinematic = true;
			component.useGravity = false;
			component.constraints = RigidbodyConstraints.FreezeAll;
			base.transform.SetPositionAndRotation(position, rotation);
		}
		RpcOnStuck(base.transform.position, base.transform.rotation);
	}

	[ClientRpc]
	private void RpcOnStuck(Vector3 stuckPos, Quaternion stuckRot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(stuckPos);
		writer.WriteQuaternion(stuckRot);
		SendRPCInternal("System.Void T_Dart::RpcOnStuck(UnityEngine.Vector3,UnityEngine.Quaternion)", -68911667, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerNotifyDartStuck()
	{
		NetworkIdentity value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dart::ServerNotifyDartStuck()' called when server was not active");
		}
		else if (ownerPlayerNetId != 0 && NetworkServer.spawned.TryGetValue(ownerPlayerNetId, out value))
		{
			T_DartManager component = value.GetComponent<T_DartManager>();
			if (component != null)
			{
				component.ServerOnDartStuck();
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdApplyThrowForce__Vector3__Vector3(Vector3 force, Vector3 torque)
	{
		Rigidbody component = GetComponent<Rigidbody>();
		if (component != null && !hasBeenThrown)
		{
			hasBeenThrown = true;
			component.isKinematic = false;
			component.useGravity = true;
			component.linearVelocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
			component.AddForce(force, ForceMode.VelocityChange);
			component.AddTorque(torque, ForceMode.VelocityChange);
		}
	}

	protected static void InvokeUserCode_CmdApplyThrowForce__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdApplyThrowForce called on client.");
		}
		else
		{
			((T_Dart)obj).UserCode_CmdApplyThrowForce__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcOnStuck__Vector3__Quaternion(Vector3 stuckPos, Quaternion stuckRot)
	{
		if (!base.isServer)
		{
			if (predictedRigidbody != null)
			{
				predictedRigidbody.enabled = false;
			}
			Rigidbody component = GetComponent<Rigidbody>();
			if (component != null)
			{
				component.linearVelocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
				component.isKinematic = true;
				component.useGravity = false;
				component.constraints = RigidbodyConstraints.FreezeAll;
			}
			base.transform.SetPositionAndRotation(stuckPos, stuckRot);
			if (hitSFX != null && audioSource != null)
			{
				audioSource.pitch = Random.Range(0.9f, 1.1f);
				audioSource.PlayOneShot(hitSFX);
			}
		}
	}

	protected static void InvokeUserCode_RpcOnStuck__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnStuck called on server.");
		}
		else
		{
			((T_Dart)obj).UserCode_RpcOnStuck__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	static T_Dart()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Dart), "System.Void T_Dart::CmdApplyThrowForce(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CmdApplyThrowForce__Vector3__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Dart), "System.Void T_Dart::RpcOnStuck(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcOnStuck__Vector3__Quaternion);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isStuck);
			writer.WriteVarUInt(ownerPlayerNetId);
			writer.WriteString(ownerPlayerName);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isStuck);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarUInt(ownerPlayerNetId);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteString(ownerPlayerName);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isStuck, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref ownerPlayerNetId, null, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref ownerPlayerName, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isStuck, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref ownerPlayerNetId, null, reader.ReadVarUInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref ownerPlayerName, null, reader.ReadString());
		}
	}
}
