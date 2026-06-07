using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Experimental
{
	public class NetworkRigidbody2D : NetworkBehaviour
	{
		public class ClientSyncState
		{
			public float nextSyncTime;

			public Vector2 velocity;

			public float angularVelocity;

			public bool isKinematic;

			public float gravityScale;

			public float drag;

			public float angularDrag;
		}

		[SerializeField]
		internal Rigidbody2D target;

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
		private Vector2 velocity;

		[SyncVar]
		private float angularVelocity;

		[SyncVar]
		private bool isKinematic;

		[SyncVar]
		private float gravityScale;

		[SyncVar]
		private float drag;

		[SyncVar]
		private float angularDrag;

		private bool IgnoreSync => false;

		private bool ClientWithAuthority => false;

		public Vector2 Networkvelocity
		{
			get
			{
				return default(Vector2);
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkangularVelocity
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

		public float NetworkgravityScale
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

		private void OnVelocityChanged(Vector2 _, Vector2 newValue)
		{
		}

		private void OnAngularVelocityChanged(float _, float newValue)
		{
		}

		private void OnIsKinematicChanged(bool _, bool newValue)
		{
		}

		private void OnGravityScaleChanged(float _, float newValue)
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
		private void CmdSendVelocity(Vector2 velocity)
		{
		}

		[Command]
		private void CmdSendVelocityAndAngular(Vector2 velocity, float angularVelocity)
		{
		}

		[Command]
		private void CmdSendIsKinematic(bool isKinematic)
		{
		}

		[Command]
		private void CmdChangeGravityScale(float gravityScale)
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

		private void UserCode_CmdSendVelocity(Vector2 velocity)
		{
		}

		protected static void InvokeUserCode_CmdSendVelocity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdSendVelocityAndAngular(Vector2 velocity, float angularVelocity)
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

		private void UserCode_CmdChangeGravityScale(float gravityScale)
		{
		}

		protected static void InvokeUserCode_CmdChangeGravityScale(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
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

		static NetworkRigidbody2D()
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
