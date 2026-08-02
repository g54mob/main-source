using System.Runtime.InteropServices;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.AI;

namespace Mirror.Examples.TanksCoop
{
	public class TankController : NetworkBehaviour
	{
		[Header("Components")]
		public NavMeshAgent agent;

		public Animator animator;

		public Transform turret;

		[Header("Movement")]
		public float rotationSpeed = 100f;

		[Header("Firing")]
		public KeyCode shootKey = KeyCode.Space;

		public GameObject projectilePrefab;

		public Transform projectileMount;

		public PlayerController playerController;

		public Transform seatPosition;

		[SyncVar(hook = "OnOwnerChangedHook")]
		public NetworkIdentity objectOwner;

		protected uint ___objectOwnerNetId;

		public NetworkIdentity NetworkobjectOwner
		{
			get
			{
				return GetSyncVarNetworkIdentity(___objectOwnerNetId, ref objectOwner);
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter_NetworkIdentity(value, ref objectOwner, 1uL, OnOwnerChangedHook, ref ___objectOwnerNetId);
			}
		}

		private void Update()
		{
			if (Application.isFocused && base.isOwned)
			{
				float axis = Input.GetAxis("Horizontal");
				base.transform.Rotate(0f, axis * rotationSpeed * Time.deltaTime, 0f);
				float axis2 = Input.GetAxis("Vertical");
				Vector3 vector = base.transform.TransformDirection(Vector3.forward);
				agent.velocity = vector * Mathf.Max(axis2, 0f) * agent.speed;
				animator.SetBool("Moving", agent.velocity != Vector3.zero);
				if (Input.GetKeyDown(shootKey))
				{
					CmdFire();
				}
				RotateTurret();
			}
		}

		[Command]
		private void CmdFire()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendCommandInternal("System.Void Mirror.Examples.TanksCoop.TankController::CmdFire()", 900491737, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcOnFire()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void Mirror.Examples.TanksCoop.TankController::RpcOnFire()", -488170045, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private void RotateTurret()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hitInfo, 100f))
			{
				Debug.DrawLine(ray.origin, hitInfo.point);
				Vector3 worldPosition = new Vector3(hitInfo.point.x, turret.transform.position.y, hitInfo.point.z);
				turret.transform.LookAt(worldPosition);
			}
		}

		private void OnOwnerChangedHook(NetworkIdentity _old, NetworkIdentity _new)
		{
			if ((bool)NetworkobjectOwner)
			{
				playerController = _new.GetComponent<PlayerController>();
				if ((bool)playerController)
				{
					playerController.canControlPlayer = false;
				}
			}
			else if ((bool)_old)
			{
				playerController = _old.GetComponent<PlayerController>();
				if ((bool)playerController)
				{
					playerController.canControlPlayer = true;
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdFire()
		{
			NetworkServer.Spawn(Object.Instantiate(projectilePrefab, projectileMount.position, projectileMount.rotation));
			RpcOnFire();
		}

		protected static void InvokeUserCode_CmdFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdFire called on client.");
			}
			else
			{
				((TankController)obj).UserCode_CmdFire();
			}
		}

		protected void UserCode_RpcOnFire()
		{
			animator.SetTrigger("Shoot");
		}

		protected static void InvokeUserCode_RpcOnFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcOnFire called on server.");
			}
			else
			{
				((TankController)obj).UserCode_RpcOnFire();
			}
		}

		static TankController()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(TankController), "System.Void Mirror.Examples.TanksCoop.TankController::CmdFire()", InvokeUserCode_CmdFire, requiresAuthority: true);
			RemoteProcedureCalls.RegisterRpc(typeof(TankController), "System.Void Mirror.Examples.TanksCoop.TankController::RpcOnFire()", InvokeUserCode_RpcOnFire);
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			base.SerializeSyncVars(writer, forceAll);
			if (forceAll)
			{
				writer.WriteNetworkIdentity(NetworkobjectOwner);
				return;
			}
			writer.WriteULong(base.syncVarDirtyBits);
			if ((base.syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteNetworkIdentity(NetworkobjectOwner);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize_NetworkIdentity(ref objectOwner, OnOwnerChangedHook, reader, ref ___objectOwnerNetId);
				return;
			}
			long num = (long)reader.ReadULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize_NetworkIdentity(ref objectOwner, OnOwnerChangedHook, reader, ref ___objectOwnerNetId);
			}
		}
	}
}
