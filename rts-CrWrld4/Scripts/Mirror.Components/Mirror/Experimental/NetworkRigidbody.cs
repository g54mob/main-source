using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Experimental
{
	public class NetworkRigidbody : NetworkBehaviour
	{
		public class ClientSyncState
		{
			public float nextSyncTime;

			public Vector3 velocity;

			public Vector3 angularVelocity;

			public bool isKinematic;

			public bool useGravity;

			public float drag;

			public float angularDrag;
		}

		[SerializeField]
		internal Rigidbody target;

		[SerializeField]
		private bool clientAuthority;

		[SerializeField]
		private bool syncVelocity;

		[SerializeField]
		private bool clearVelocity;

		[SerializeField]
		private float velocitySensitivity;

		[SerializeField]
		private bool syncAngularVelocity;

		[SerializeField]
		private bool clearAngularVelocity;

		[SerializeField]
		private float angularVelocitySensitivity;

		private readonly ClientSyncState previousValue;

		[SyncVar]
		private Vector3 velocity;

		[SyncVar]
		private Vector3 angularVelocity;

		[SyncVar]
		private bool isKinematic;

		[SyncVar]
		private bool useGravity;

		[SyncVar]
		private float drag;

		[SyncVar]
		private float angularDrag;

		private bool IgnoreSync => false;

		private bool ClientWithAuthority => false;

		public Vector3 Networkvelocity
		{
			get
			{
				return default(Vector3);
			}
			[param: In]
			set
			{
			}
		}

		public Vector3 NetworkangularVelocity
		{
			get
			{
				return default(Vector3);
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisKinematic
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkuseGravity
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public float Networkdrag
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkangularDrag
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		private void OnValidate()
		{
		}

		private void OnVelocityChanged(Vector3 _, Vector3 newValue)
		{
		}

		private void OnAngularVelocityChanged(Vector3 _, Vector3 newValue)
		{
		}

		private void OnIsKinematicChanged(bool _, bool newValue)
		{
		}

		private void OnUseGravityChanged(bool _, bool newValue)
		{
		}

		private void OnuDragChanged(float _, float newValue)
		{
		}

		private void OnAngularDragChanged(float _, float newValue)
		{
		}

		internal void Update()
		{
		}

		internal void FixedUpdate()
		{
		}

		[Server]
		private void SyncToClients()
		{
		}

		[Client]
		private void SendToServer()
		{
		}

		[Client]
		private void SendVelocity()
		{
		}

		[Client]
		private void SendRigidBodySettings()
		{
		}

		[Command]
		private void CmdSendVelocity(Vector3 velocity)
		{
		}

		[Command]
		private void CmdSendVelocityAndAngular(Vector3 velocity, Vector3 angularVelocity)
		{
		}

		[Command]
		private void CmdSendIsKinematic(bool isKinematic)
		{
		}

		[Command]
		private void CmdSendUseGravity(bool useGravity)
		{
		}

		[Command]
		private void CmdSendDrag(float drag)
		{
		}

		[Command]
		private void CmdSendAngularDrag(float angularDrag)
		{
		}

		private void MirrorProcessed()
		{
		}

		private void UserCode_CmdSendVelocity(Vector3 velocity)
		{
		}

		protected static void InvokeUserCode_CmdSendVelocity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendVelocityAndAngular(Vector3 velocity, Vector3 angularVelocity)
		{
		}

		protected static void InvokeUserCode_CmdSendVelocityAndAngular(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendIsKinematic(bool isKinematic)
		{
		}

		protected static void InvokeUserCode_CmdSendIsKinematic(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendUseGravity(bool useGravity)
		{
		}

		protected static void InvokeUserCode_CmdSendUseGravity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendDrag(float drag)
		{
		}

		protected static void InvokeUserCode_CmdSendDrag(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendAngularDrag(float angularDrag)
		{
		}

		protected static void InvokeUserCode_CmdSendAngularDrag(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NetworkRigidbody()
		{
		}

		public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			return false;
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
