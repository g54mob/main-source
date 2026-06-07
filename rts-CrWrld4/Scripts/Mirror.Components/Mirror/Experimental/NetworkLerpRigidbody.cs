using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Experimental
{
	public class NetworkLerpRigidbody : NetworkBehaviour
	{
		[SerializeField]
		internal Rigidbody target;

		[SerializeField]
		private float lerpVelocityAmount;

		[SerializeField]
		private float lerpPositionAmount;

		[SerializeField]
		private bool clientAuthority;

		private float nextSyncTime;

		[SyncVar]
		private Vector3 targetVelocity;

		[SyncVar]
		private Vector3 targetPosition;

		private bool IgnoreSync => false;

		private bool ClientWithAuthority => false;

		public Vector3 NetworktargetVelocity
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

		public Vector3 NetworktargetPosition
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

		private void OnValidate()
		{
		}

		private void Update()
		{
		}

		private void SyncToClients()
		{
		}

		private void SendToServer()
		{
		}

		[Command]
		private void CmdSendState(Vector3 velocity, Vector3 position)
		{
		}

		private void FixedUpdate()
		{
		}

		private void MirrorProcessed()
		{
		}

		private void UserCode_CmdSendState(Vector3 velocity, Vector3 position)
		{
		}

		protected static void InvokeUserCode_CmdSendState(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NetworkLerpRigidbody()
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
