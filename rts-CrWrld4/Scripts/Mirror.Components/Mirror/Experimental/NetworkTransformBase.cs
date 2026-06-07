using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Experimental
{
	public abstract class NetworkTransformBase : NetworkBehaviour
	{
		[Serializable]
		public struct DataPoint
		{
			public float timeStamp;

			public Vector3 localPosition;

			public Quaternion localRotation;

			public Vector3 localScale;

			public float movementSpeed;

			public bool isValid => false;
		}

		[SyncVar]
		public bool clientAuthority;

		[SyncVar]
		public bool excludeOwnerUpdate;

		[SyncVar]
		public bool syncPosition;

		[SyncVar]
		public bool syncRotation;

		[SyncVar]
		public bool syncScale;

		[SyncVar]
		public bool interpolatePosition;

		[SyncVar]
		public bool interpolateRotation;

		[SyncVar]
		public bool interpolateScale;

		[SyncVar]
		public float localPositionSensitivity;

		[SyncVar]
		public float localRotationSensitivity;

		[SyncVar]
		public float localScaleSensitivity;

		public Vector3 lastPosition;

		public Quaternion lastRotation;

		public Vector3 lastScale;

		public DataPoint start;

		public DataPoint goal;

		private bool clientAuthorityBeforeTeleport;

		protected abstract Transform targetTransform { get; }

		private bool IsOwnerWithClientAuthority => false;

		private bool HasMoved => false;

		private bool HasRotated => false;

		private bool HasScaled => false;

		public bool NetworkclientAuthority
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

		public bool NetworkexcludeOwnerUpdate
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

		public bool NetworksyncPosition
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

		public bool NetworksyncRotation
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

		public bool NetworksyncScale
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

		public bool NetworkinterpolatePosition
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

		public bool NetworkinterpolateRotation
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

		public bool NetworkinterpolateScale
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

		public float NetworklocalPositionSensitivity
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

		public float NetworklocalRotationSensitivity
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

		public float NetworklocalScaleSensitivity
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

		private void FixedUpdate()
		{
		}

		private void ServerUpdate()
		{
		}

		private void ClientAuthorityUpdate()
		{
		}

		private void ClientRemoteUpdate()
		{
		}

		private bool HasEitherMovedRotatedScaled()
		{
			return false;
		}

		private bool NeedsTeleport()
		{
			return false;
		}

		[Command]
		private void CmdClientToServerSync(Vector3 position, uint packedRotation, Vector3 scale)
		{
		}

		[ClientRpc]
		private void RpcMove(Vector3 position, uint packedRotation, Vector3 scale)
		{
		}

		private void SetGoal(Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		private static float EstimateMovementSpeed(DataPoint from, DataPoint to, Transform transform, float sendInterval)
		{
			return 0f;
		}

		private void ApplyPositionRotationScale(Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		private Vector3 InterpolatePosition(DataPoint start, DataPoint goal, Vector3 currentPosition)
		{
			return default(Vector3);
		}

		private Quaternion InterpolateRotation(DataPoint start, DataPoint goal, Quaternion defaultRotation)
		{
			return default(Quaternion);
		}

		private Vector3 InterpolateScale(DataPoint start, DataPoint goal, Vector3 currentScale)
		{
			return default(Vector3);
		}

		private static float CurrentInterpolationFactor(DataPoint start, DataPoint goal)
		{
			return 0f;
		}

		[Server]
		public void ServerTeleport(Vector3 localPosition)
		{
		}

		[Server]
		public void ServerTeleport(Vector3 localPosition, Quaternion localRotation)
		{
		}

		private void DoTeleport(Vector3 newLocalPosition, Quaternion newLocalRotation)
		{
		}

		[ClientRpc]
		private void RpcTeleport(Vector3 newPosition, uint newPackedRotation, bool isClientAuthority)
		{
		}

		[Command]
		private void CmdTeleportFinished()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private static void DrawDataPointGizmo(DataPoint data, Color color)
		{
		}

		private static void DrawLineBetweenDataPoints(DataPoint data1, DataPoint data2, Color color)
		{
		}

		private void MirrorProcessed()
		{
		}

		private void UserCode_CmdClientToServerSync(Vector3 position, uint packedRotation, Vector3 scale)
		{
		}

		protected static void InvokeUserCode_CmdClientToServerSync(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcMove(Vector3 position, uint packedRotation, Vector3 scale)
		{
		}

		protected static void InvokeUserCode_RpcMove(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcTeleport(Vector3 newPosition, uint newPackedRotation, bool isClientAuthority)
		{
		}

		protected static void InvokeUserCode_RpcTeleport(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdTeleportFinished()
		{
		}

		protected static void InvokeUserCode_CmdTeleportFinished(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NetworkTransformBase()
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
