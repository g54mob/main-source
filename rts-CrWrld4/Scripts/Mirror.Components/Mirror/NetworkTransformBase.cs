using System;
using UnityEngine;

namespace Mirror
{
	public abstract class NetworkTransformBase : NetworkBehaviour
	{
		public class DataPoint
		{
			public float timeStamp;

			public Vector3 localPosition;

			public Quaternion localRotation;

			public Vector3 localScale;

			public float movementSpeed;
		}

		public bool clientAuthority;

		private bool clientAuthorityBeforeTeleport;

		public float localPositionSensitivity;

		public float localRotationSensitivity;

		public float localScaleSensitivity;

		public bool compressRotation;

		public bool interpolateScale;

		public bool syncScale;

		private Vector3 lastPosition;

		private Quaternion lastRotation;

		private Vector3 lastScale;

		private DataPoint start;

		private DataPoint goal;

		private float lastClientSendTime;

		private bool IsClientWithAuthority => false;

		protected abstract Transform targetComponent { get; }

		public static void SerializeIntoWriter(NetworkWriter writer, Vector3 position, Quaternion rotation, Vector3 scale, bool compressRotation, bool syncScale)
		{
		}

		public override bool OnSerialize(NetworkWriter writer, bool initialState)
		{
			return false;
		}

		private static float EstimateMovementSpeed(DataPoint from, DataPoint to, Transform transform, float sendInterval)
		{
			return 0f;
		}

		private void DeserializeFromReader(NetworkReader reader)
		{
		}

		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
		}

		[Command]
		private void CmdClientToServerSync(ArraySegment<byte> payload)
		{
		}

		private static float CurrentInterpolationFactor(DataPoint start, DataPoint goal)
		{
			return 0f;
		}

		private static Vector3 InterpolatePosition(DataPoint start, DataPoint goal, Vector3 currentPosition)
		{
			return default(Vector3);
		}

		private static Quaternion InterpolateRotation(DataPoint start, DataPoint goal, Quaternion defaultRotation)
		{
			return default(Quaternion);
		}

		private Vector3 InterpolateScale(DataPoint start, DataPoint goal, Vector3 currentScale)
		{
			return default(Vector3);
		}

		private bool NeedsTeleport()
		{
			return false;
		}

		private bool HasEitherMovedRotatedScaled()
		{
			return false;
		}

		private void ApplyPositionRotationScale(Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		private void Update()
		{
		}

		[Server]
		public void ServerTeleport(Vector3 position)
		{
		}

		[Server]
		public void ServerTeleport(Vector3 position, Quaternion rotation)
		{
		}

		private void DoTeleport(Vector3 newPosition, Quaternion newRotation)
		{
		}

		[ClientRpc]
		private void RpcTeleport(Vector3 newPosition, Quaternion newRotation, bool isClientAuthority)
		{
		}

		[Command]
		private void CmdTeleportFinished()
		{
		}

		private static void DrawDataPointGizmo(DataPoint data, Color color)
		{
		}

		private static void DrawLineBetweenDataPoints(DataPoint data1, DataPoint data2, Color color)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void MirrorProcessed()
		{
		}

		private void UserCode_CmdClientToServerSync(ArraySegment<byte> payload)
		{
		}

		protected static void InvokeUserCode_CmdClientToServerSync(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcTeleport(Vector3 newPosition, Quaternion newRotation, bool isClientAuthority)
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
	}
}
