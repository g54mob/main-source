using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_Dynamite : NetworkBehaviour
{
	[Header("References")]
	[SerializeField]
	private Collider dynamiteCollider;

	[SerializeField]
	private GameObject visual;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private PredictedRigidbody predictedRigidbody;

	[Header("Throw Settings")]
	[SerializeField]
	private float throwForce = 8f;

	[SerializeField]
	private float angularForce = 5f;

	[Header("Stick Settings")]
	[SerializeField]
	private LayerMask stickLayers;

	[Header("Explosion Dig Settings")]
	[Tooltip("Merkez kazı boyutu (fallback değer - UpgradeManager'dan alınır)")]
	[SerializeField]
	private float centerDigSize = 2.5f;

	[Tooltip("Çevredeki kazıların boyutu (merkeze göre oran)")]
	[Range(0.3f, 1f)]
	[SerializeField]
	private float surroundingDigSizeRatio = 0.8f;

	[Tooltip("Kazı opacity değeri")]
	[Range(0f, 1f)]
	[SerializeField]
	private float digOpacity = 1f;

	[Tooltip("Merkez etrafında kaç nokta kazılacak (0 = sadece merkez)")]
	[Range(0f, 20f)]
	[SerializeField]
	private int surroundingDigCount = 6;

	[Tooltip("Çevredeki kazıların merkeze uzaklığı")]
	[SerializeField]
	private float surroundingDigDistance = 2f;

	[Tooltip("Çevredeki kazıların dikey dağılımı (0 = sadece yatay, 1 = tam küresel)")]
	[Range(0f, 1f)]
	[SerializeField]
	private float verticalSpread = 0.5f;

	[Header("SFX")]
	[SerializeField]
	private AudioClip explosionSFX;

	[SyncVar]
	private bool isStuck;

	[SyncVar]
	private uint ownerNetId;

	private bool hasDetonated;

	private bool hasBeenThrown;

	private bool explosionPlayed;

	public bool IsStuck => isStuck;

	public uint OwnerNetId => ownerNetId;

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

	public uint NetworkownerNetId
	{
		get
		{
			return ownerNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref ownerNetId, 2uL, null);
		}
	}

	private void Awake()
	{
		EnsureRefs();
	}

	private void EnsureRefs()
	{
		if (!dynamiteCollider)
		{
			dynamiteCollider = GetComponent<Collider>();
		}
		if (!visual)
		{
			visual = base.gameObject;
		}
		if (!audioSource)
		{
			audioSource = GetComponent<AudioSource>();
		}
		if (!predictedRigidbody)
		{
			predictedRigidbody = GetComponent<PredictedRigidbody>();
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
			component.isKinematic = false;
			component.useGravity = true;
			component.linearDamping = 0.5f;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		EnsureRefs();
	}

	[Server]
	public void ServerSetOwner(uint ownerNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dynamite::ServerSetOwner(System.UInt32)' called when server was not active");
		}
		else
		{
			NetworkownerNetId = ownerNetId;
		}
	}

	public void ClientThrow(Vector3 direction)
	{
		if (!hasBeenThrown)
		{
			hasBeenThrown = true;
			Vector3 force = direction.normalized * throwForce;
			Vector3 torque = UnityEngine.Random.insideUnitSphere * angularForce;
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
		SendCommandInternal("System.Void T_Dynamite::CmdApplyThrowForce(UnityEngine.Vector3,UnityEngine.Vector3)", 1651637036, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (base.isServer && !isStuck)
		{
			int layer = collision.gameObject.layer;
			if (((1 << layer) & (int)stickLayers) != 0)
			{
				ServerStick();
			}
		}
	}

	[Server]
	private void ServerStick()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dynamite::ServerStick()' called when server was not active");
			return;
		}
		NetworkisStuck = true;
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component)
		{
			component.isKinematic = true;
			component.useGravity = false;
			component.linearVelocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
		}
		RpcOnStuck();
	}

	[ClientRpc]
	private void RpcOnStuck()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Dynamite::RpcOnStuck()", 1056813431, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void RequestDetonate()
	{
		float dynamiteSizeFromLevel = GetDynamiteSizeFromLevel();
		CmdRequestDetonate(dynamiteSizeFromLevel);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestDetonate(float requestedSize)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestDetonate__Single(requestedSize);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(requestedSize);
		SendCommandInternal("System.Void T_Dynamite::CmdRequestDetonate(System.Single)", -439729427, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerDetonate(float size = -1f)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dynamite::ServerDetonate(System.Single)' called when server was not active");
		}
		else if (!hasDetonated)
		{
			hasDetonated = true;
			float size2 = ((size > 0f) ? Mathf.Clamp(size, 1f, 6f) : centerDigSize);
			Vector3 position = base.transform.position;
			PerformExplosionDig(position, size2);
			RpcPlayExplosionEffects(position);
			StartCoroutine(DestroyActions());
		}
	}

	private float GetDynamiteSizeFromLevel()
	{
		if (UpgradeManager.Instance == null || PlayerProgressManager.Instance == null)
		{
			return centerDigSize;
		}
		int level = PlayerProgressManager.Instance.GetLevel(ItemType.Dynamite);
		return UpgradeManager.Instance.GetDynamiteStats(level).size;
	}

	private IEnumerator DestroyActions()
	{
		yield return new WaitForSeconds(0.2f);
		NetworkServer.Destroy(base.gameObject);
	}

	[Server]
	private void PerformExplosionDig(Vector3 center, float size)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Dynamite::PerformExplosionDig(UnityEngine.Vector3,System.Single)' called when server was not active");
			return;
		}
		if (DiggerController.Instance == null)
		{
			Debug.LogWarning("T_Dynamite: DiggerController.Instance not found!");
			return;
		}
		DiggerController.Instance.ServerDigAtPosition(center, size, digOpacity, uniformIntensity: true);
		if (surroundingDigCount > 0)
		{
			float size2 = size * surroundingDigSizeRatio;
			float num = MathF.PI * (3f - Mathf.Sqrt(5f));
			for (int i = 0; i < surroundingDigCount; i++)
			{
				float num2 = (float)i / ((float)(surroundingDigCount - 1) + 0.0001f);
				float num3 = (1f - 2f * num2) * verticalSpread;
				float num4 = Mathf.Sqrt(1f - num3 * num3);
				float f = num * (float)i;
				Vector3 vector = new Vector3(Mathf.Cos(f) * num4, num3, Mathf.Sin(f) * num4) * surroundingDigDistance;
				Vector3 worldPos = center + vector;
				DiggerController.Instance.ServerDigAtPosition(worldPos, size2, digOpacity);
			}
		}
	}

	[ClientRpc]
	private void RpcPlayExplosionEffects(Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		SendRPCInternal("System.Void T_Dynamite::RpcPlayExplosionEffects(UnityEngine.Vector3)", -1351568952, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayExplosionEffectsLocal(Vector3 position)
	{
		explosionPlayed = true;
		if (GameManager.Instance != null && GameManager.Instance.poolingManager != null)
		{
			GameObject pooledObjectByType = GameManager.Instance.poolingManager.GetPooledObjectByType(LayerVFX.ExplosionVFX);
			if (pooledObjectByType != null)
			{
				pooledObjectByType.transform.position = position;
				pooledObjectByType.SetActive(value: true);
			}
		}
		if (explosionSFX != null)
		{
			GameObject obj = new GameObject("DynamiteExplosionSFX");
			obj.transform.position = position;
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.spatialBlend = 1f;
			audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
			audioSource.clip = explosionSFX;
			audioSource.Play();
			UnityEngine.Object.Destroy(obj, explosionSFX.length / audioSource.pitch + 0.5f);
		}
		if (visual != null)
		{
			visual.SetActive(value: false);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, surroundingDigDistance);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, centerDigSize);
		if (surroundingDigCount > 0)
		{
			Gizmos.color = new Color(1f, 0.5f, 0f, 0.5f);
			float num = centerDigSize * surroundingDigSizeRatio;
			float num2 = MathF.PI * (3f - Mathf.Sqrt(5f));
			for (int i = 0; i < surroundingDigCount; i++)
			{
				float num3 = (float)i / ((float)(surroundingDigCount - 1) + 0.0001f);
				float num4 = (1f - 2f * num3) * verticalSpread;
				float num5 = Mathf.Sqrt(1f - num4 * num4);
				float f = num2 * (float)i;
				Vector3 vector = new Vector3(Mathf.Cos(f) * num5, num4, Mathf.Sin(f) * num5) * surroundingDigDistance;
				Gizmos.DrawWireSphere(base.transform.position + vector, num * 0.5f);
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
			((T_Dynamite)obj).UserCode_CmdApplyThrowForce__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcOnStuck()
	{
		if (!base.isServer && Rb != null)
		{
			Rb.isKinematic = true;
			Rb.useGravity = false;
		}
	}

	protected static void InvokeUserCode_RpcOnStuck(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnStuck called on server.");
		}
		else
		{
			((T_Dynamite)obj).UserCode_RpcOnStuck();
		}
	}

	protected void UserCode_CmdRequestDetonate__Single(float requestedSize)
	{
		ServerDetonate(requestedSize);
	}

	protected static void InvokeUserCode_CmdRequestDetonate__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestDetonate called on client.");
		}
		else
		{
			((T_Dynamite)obj).UserCode_CmdRequestDetonate__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_RpcPlayExplosionEffects__Vector3(Vector3 position)
	{
		if (!explosionPlayed)
		{
			PlayExplosionEffectsLocal(position);
		}
	}

	protected static void InvokeUserCode_RpcPlayExplosionEffects__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayExplosionEffects called on server.");
		}
		else
		{
			((T_Dynamite)obj).UserCode_RpcPlayExplosionEffects__Vector3(reader.ReadVector3());
		}
	}

	static T_Dynamite()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Dynamite), "System.Void T_Dynamite::CmdApplyThrowForce(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CmdApplyThrowForce__Vector3__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Dynamite), "System.Void T_Dynamite::CmdRequestDetonate(System.Single)", InvokeUserCode_CmdRequestDetonate__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Dynamite), "System.Void T_Dynamite::RpcOnStuck()", InvokeUserCode_RpcOnStuck);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Dynamite), "System.Void T_Dynamite::RpcPlayExplosionEffects(UnityEngine.Vector3)", InvokeUserCode_RpcPlayExplosionEffects__Vector3);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isStuck);
			writer.WriteVarUInt(ownerNetId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isStuck);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarUInt(ownerNetId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isStuck, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref ownerNetId, null, reader.ReadVarUInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isStuck, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref ownerNetId, null, reader.ReadVarUInt());
		}
	}
}
