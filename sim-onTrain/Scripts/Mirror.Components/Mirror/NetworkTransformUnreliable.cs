using Mirror.RemoteCalls;
using UnityEngine;

namespace Mirror
{
	[AddComponentMenu("Network/Network Transform (Unreliable)")]
	public class NetworkTransformUnreliable : NetworkTransformBase
	{
		[Header("Sync Only If Changed")]
		[Tooltip("When true, changes are not sent unless greater than sensitivity values below.")]
		public bool onlySyncOnChange = true;

		private uint sendIntervalCounter;

		private double lastSendIntervalTime = double.MinValue;

		[Tooltip("How much time, as a multiple of send interval, has passed before clearing buffers.\nA larger buffer means more delay, but results in smoother movement.\nExample: 1 for faster responses minimal smoothing, 5 covers bad pings but has noticable delay, 3 is recommended for balanced results,.")]
		public float bufferResetMultiplier = 3f;

		[Header("Sensitivity")]
		[Tooltip("Sensitivity of changes needed before an updated state is sent over the network")]
		public float positionSensitivity = 0.01f;

		public float rotationSensitivity = 0.01f;

		public float scaleSensitivity = 0.01f;

		protected bool positionChanged;

		protected bool rotationChanged;

		protected bool scaleChanged;

		protected TransformSnapshot lastSnapshot;

		protected bool cachedSnapshotComparison;

		protected bool hasSentUnchangedPosition;

		private void Update()
		{
			if (base.isServer)
			{
				UpdateServerInterpolation();
			}
			else if (base.isClient && !base.IsClientWithAuthority)
			{
				UpdateClientInterpolation();
			}
		}

		private void LateUpdate()
		{
			if (base.isServer)
			{
				UpdateServerBroadcast();
			}
			else if (base.isClient && base.IsClientWithAuthority)
			{
				UpdateClientBroadcast();
			}
		}

		protected virtual void CheckLastSendTime()
		{
			if (sendIntervalCounter == sendIntervalMultiplier)
			{
				sendIntervalCounter = 0u;
			}
			if (AccurateInterval.Elapsed(NetworkTime.localTime, NetworkServer.sendInterval, ref lastSendIntervalTime))
			{
				sendIntervalCounter++;
			}
		}

		private void UpdateServerBroadcast()
		{
			CheckLastSendTime();
			if (sendIntervalCounter != sendIntervalMultiplier || (syncDirection != SyncDirection.ServerToClient && !base.IsClientWithAuthority))
			{
				return;
			}
			TransformSnapshot currentSnapshot = Construct();
			cachedSnapshotComparison = CompareSnapshots(currentSnapshot);
			if (!cachedSnapshotComparison || !hasSentUnchangedPosition || !onlySyncOnChange)
			{
				RpcServerToClientSync((syncPosition && positionChanged) ? new Vector3?(currentSnapshot.position) : ((Vector3?)null), (syncRotation && rotationChanged) ? new Quaternion?(currentSnapshot.rotation) : ((Quaternion?)null), (syncScale && scaleChanged) ? new Vector3?(currentSnapshot.scale) : ((Vector3?)null));
				if (cachedSnapshotComparison)
				{
					hasSentUnchangedPosition = true;
					return;
				}
				hasSentUnchangedPosition = false;
				lastSnapshot = currentSnapshot;
			}
		}

		private void UpdateServerInterpolation()
		{
			if (syncDirection == SyncDirection.ClientToServer && base.connectionToClient != null && !base.isOwned && serverSnapshots.Count != 0)
			{
				SnapshotInterpolation.StepInterpolation(serverSnapshots, base.connectionToClient.remoteTimeline, out var fromSnapshot, out var toSnapshot, out var t);
				TransformSnapshot interpolated = TransformSnapshot.Interpolate(fromSnapshot, toSnapshot, t);
				Apply(interpolated, toSnapshot);
			}
		}

		private void UpdateClientBroadcast()
		{
			if (!NetworkClient.ready)
			{
				return;
			}
			CheckLastSendTime();
			if (sendIntervalCounter != sendIntervalMultiplier)
			{
				return;
			}
			TransformSnapshot currentSnapshot = Construct();
			cachedSnapshotComparison = CompareSnapshots(currentSnapshot);
			if (!cachedSnapshotComparison || !hasSentUnchangedPosition || !onlySyncOnChange)
			{
				CmdClientToServerSync((syncPosition && positionChanged) ? new Vector3?(currentSnapshot.position) : ((Vector3?)null), (syncRotation && rotationChanged) ? new Quaternion?(currentSnapshot.rotation) : ((Quaternion?)null), (syncScale && scaleChanged) ? new Vector3?(currentSnapshot.scale) : ((Vector3?)null));
				if (cachedSnapshotComparison)
				{
					hasSentUnchangedPosition = true;
					return;
				}
				hasSentUnchangedPosition = false;
				lastSnapshot = currentSnapshot;
			}
		}

		private void UpdateClientInterpolation()
		{
			if (clientSnapshots.Count != 0)
			{
				SnapshotInterpolation.StepInterpolation(clientSnapshots, NetworkTime.time, out var fromSnapshot, out var toSnapshot, out var t);
				TransformSnapshot interpolated = TransformSnapshot.Interpolate(fromSnapshot, toSnapshot, t);
				Apply(interpolated, toSnapshot);
			}
		}

		public override void OnSerialize(NetworkWriter writer, bool initialState)
		{
			if (initialState)
			{
				if (syncPosition)
				{
					writer.WriteVector3(GetPosition());
				}
				if (syncRotation)
				{
					writer.WriteQuaternion(GetRotation());
				}
				if (syncScale)
				{
					writer.WriteVector3(GetScale());
				}
			}
		}

		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
			if (initialState)
			{
				if (syncPosition)
				{
					SetPosition(reader.ReadVector3());
				}
				if (syncRotation)
				{
					SetRotation(reader.ReadQuaternion());
				}
				if (syncScale)
				{
					SetScale(reader.ReadVector3());
				}
			}
		}

		protected virtual bool CompareSnapshots(TransformSnapshot currentSnapshot)
		{
			positionChanged = Vector3.SqrMagnitude(lastSnapshot.position - currentSnapshot.position) > positionSensitivity * positionSensitivity;
			rotationChanged = Quaternion.Angle(lastSnapshot.rotation, currentSnapshot.rotation) > rotationSensitivity;
			scaleChanged = Vector3.SqrMagnitude(lastSnapshot.scale - currentSnapshot.scale) > scaleSensitivity * scaleSensitivity;
			if (!positionChanged && !rotationChanged)
			{
				return !scaleChanged;
			}
			return false;
		}

		[Command(channel = 1)]
		private void CmdClientToServerSync(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3Nullable(position);
			writer.WriteQuaternionNullable(rotation);
			writer.WriteVector3Nullable(scale);
			SendCommandInternal("System.Void Mirror.NetworkTransformUnreliable::CmdClientToServerSync(System.Nullable`1<UnityEngine.Vector3>,System.Nullable`1<UnityEngine.Quaternion>,System.Nullable`1<UnityEngine.Vector3>)", -1263136411, writer, 1);
			NetworkWriterPool.Return(writer);
		}

		protected virtual void OnClientToServerSync(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			if (syncDirection != SyncDirection.ClientToServer || serverSnapshots.Count >= base.connectionToClient.snapshotBufferSizeLimit)
			{
				return;
			}
			double remoteTimeStamp = base.connectionToClient.remoteTimeStamp;
			if (onlySyncOnChange)
			{
				double num = bufferResetMultiplier * (float)sendIntervalMultiplier * NetworkClient.sendInterval;
				if (serverSnapshots.Count > 0 && serverSnapshots.Values[serverSnapshots.Count - 1].remoteTime + num < remoteTimeStamp)
				{
					Reset();
				}
			}
			AddSnapshot(serverSnapshots, base.connectionToClient.remoteTimeStamp + base.timeStampAdjustment + base.offset, position, rotation, scale);
		}

		[ClientRpc(channel = 1)]
		private void RpcServerToClientSync(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3Nullable(position);
			writer.WriteQuaternionNullable(rotation);
			writer.WriteVector3Nullable(scale);
			SendRPCInternal("System.Void Mirror.NetworkTransformUnreliable::RpcServerToClientSync(System.Nullable`1<UnityEngine.Vector3>,System.Nullable`1<UnityEngine.Quaternion>,System.Nullable`1<UnityEngine.Vector3>)", -1968965670, writer, 1, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		protected virtual void OnServerToClientSync(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			if (base.isServer || base.IsClientWithAuthority)
			{
				return;
			}
			double remoteTimeStamp = NetworkClient.connection.remoteTimeStamp;
			if (onlySyncOnChange)
			{
				double num = bufferResetMultiplier * (float)sendIntervalMultiplier * NetworkServer.sendInterval;
				if (clientSnapshots.Count > 0 && clientSnapshots.Values[clientSnapshots.Count - 1].remoteTime + num < remoteTimeStamp)
				{
					Reset();
				}
			}
			AddSnapshot(clientSnapshots, NetworkClient.connection.remoteTimeStamp + base.timeStampAdjustment + base.offset, position, rotation, scale);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdClientToServerSync__Nullable_00601__Nullable_00601__Nullable_00601(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			OnClientToServerSync(position, rotation, scale);
			if (syncDirection == SyncDirection.ClientToServer)
			{
				RpcServerToClientSync(position, rotation, scale);
			}
		}

		protected static void InvokeUserCode_CmdClientToServerSync__Nullable_00601__Nullable_00601__Nullable_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdClientToServerSync called on client.");
			}
			else
			{
				((NetworkTransformUnreliable)obj).UserCode_CmdClientToServerSync__Nullable_00601__Nullable_00601__Nullable_00601(reader.ReadVector3Nullable(), reader.ReadQuaternionNullable(), reader.ReadVector3Nullable());
			}
		}

		protected void UserCode_RpcServerToClientSync__Nullable_00601__Nullable_00601__Nullable_00601(Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			OnServerToClientSync(position, rotation, scale);
		}

		protected static void InvokeUserCode_RpcServerToClientSync__Nullable_00601__Nullable_00601__Nullable_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcServerToClientSync called on server.");
			}
			else
			{
				((NetworkTransformUnreliable)obj).UserCode_RpcServerToClientSync__Nullable_00601__Nullable_00601__Nullable_00601(reader.ReadVector3Nullable(), reader.ReadQuaternionNullable(), reader.ReadVector3Nullable());
			}
		}

		static NetworkTransformUnreliable()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(NetworkTransformUnreliable), "System.Void Mirror.NetworkTransformUnreliable::CmdClientToServerSync(System.Nullable`1<UnityEngine.Vector3>,System.Nullable`1<UnityEngine.Quaternion>,System.Nullable`1<UnityEngine.Vector3>)", InvokeUserCode_CmdClientToServerSync__Nullable_00601__Nullable_00601__Nullable_00601, requiresAuthority: true);
			RemoteProcedureCalls.RegisterRpc(typeof(NetworkTransformUnreliable), "System.Void Mirror.NetworkTransformUnreliable::RpcServerToClientSync(System.Nullable`1<UnityEngine.Vector3>,System.Nullable`1<UnityEngine.Quaternion>,System.Nullable`1<UnityEngine.Vector3>)", InvokeUserCode_RpcServerToClientSync__Nullable_00601__Nullable_00601__Nullable_00601);
		}
	}
}
