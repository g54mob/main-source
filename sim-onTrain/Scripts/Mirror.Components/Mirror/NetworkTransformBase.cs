using System;
using System.Collections.Generic;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Mirror
{
	public abstract class NetworkTransformBase : NetworkBehaviour
	{
		[Header("Target")]
		[Tooltip("The Transform component to sync. May be on on this GameObject, or on a child.")]
		public Transform target;

		[Obsolete("NetworkTransform clientAuthority was replaced with syncDirection. To enable client authority, set SyncDirection to ClientToServer in the Inspector.")]
		[Header("[Obsolete]")]
		[Tooltip("Obsolete: NetworkTransform clientAuthority was replaced with syncDirection. To enable client authority, set SyncDirection to ClientToServer in the Inspector.")]
		public bool clientAuthority;

		public readonly SortedList<double, TransformSnapshot> clientSnapshots = new SortedList<double, TransformSnapshot>(16);

		public readonly SortedList<double, TransformSnapshot> serverSnapshots = new SortedList<double, TransformSnapshot>(16);

		[Header("Selective Sync\nDon't change these at Runtime")]
		public bool syncPosition = true;

		public bool syncRotation = true;

		public bool syncScale;

		[Header("Interpolation")]
		[Tooltip("Set to false to have a snap-like effect on position movement.")]
		public bool interpolatePosition = true;

		[Tooltip("Set to false to have a snap-like effect on rotations.")]
		public bool interpolateRotation = true;

		[Tooltip("Set to false to remove scale smoothing. Example use-case: Instant flipping of sprites that use -X and +X for direction.")]
		public bool interpolateScale = true;

		[Header("Coordinate Space")]
		[Tooltip("Local by default. World may be better when changing hierarchy, or non-NetworkTransforms root position/rotation/scale values.")]
		public CoordinateSpace coordinateSpace;

		[Header("Send Interval Multiplier")]
		[Tooltip("Check/Sync every multiple of Network Manager send interval (= 1 / NM Send Rate), instead of every send interval.\n(30 NM send rate, and 3 interval, is a send every 0.1 seconds)\nA larger interval means less network sends, which has a variety of upsides. The drawbacks are delays and lower accuracy, you should find a nice balance between not sending too much, but the results looking good for your particular scenario.")]
		[Range(1f, 120f)]
		public uint sendIntervalMultiplier = 1u;

		[Header("Timeline Offset")]
		[Tooltip("Add a small timeline offset to account for decoupled arrival of NetworkTime and NetworkTransform snapshots.\nfixes: https://github.com/MirrorNetworking/Mirror/issues/3427")]
		public bool timelineOffset;

		[Header("Debug")]
		public bool showGizmos;

		public bool showOverlay;

		public Color overlayColor = new Color(0f, 0f, 0f, 0.5f);

		protected bool IsClientWithAuthority
		{
			get
			{
				if (base.isClient)
				{
					return base.authority;
				}
				return false;
			}
		}

		protected double timeStampAdjustment => NetworkServer.sendInterval * (float)(sendIntervalMultiplier - 1);

		protected double offset => timelineOffset ? (NetworkServer.sendInterval * (float)sendIntervalMultiplier) : 0f;

		protected virtual void Awake()
		{
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			if (target == null)
			{
				target = base.transform;
			}
			syncInterval = 0f;
			if (coordinateSpace == CoordinateSpace.World)
			{
				syncScale = false;
			}
			if (clientAuthority)
			{
				syncDirection = SyncDirection.ClientToServer;
				Debug.LogWarning(base.name + "'s NetworkTransform component has obsolete .clientAuthority enabled. Please disable it and set SyncDirection to ClientToServer instead.");
			}
		}

		protected Vector3 GetPosition()
		{
			if (coordinateSpace != CoordinateSpace.Local)
			{
				return target.position;
			}
			return target.localPosition;
		}

		protected Quaternion GetRotation()
		{
			if (coordinateSpace != CoordinateSpace.Local)
			{
				return target.rotation;
			}
			return target.localRotation;
		}

		protected Vector3 GetScale()
		{
			if (coordinateSpace != CoordinateSpace.Local)
			{
				return target.lossyScale;
			}
			return target.localScale;
		}

		protected void SetPosition(Vector3 position)
		{
			if (coordinateSpace == CoordinateSpace.Local)
			{
				target.localPosition = position;
			}
			else
			{
				target.position = position;
			}
		}

		protected void SetRotation(Quaternion rotation)
		{
			if (coordinateSpace == CoordinateSpace.Local)
			{
				target.localRotation = rotation;
			}
			else
			{
				target.rotation = rotation;
			}
		}

		protected void SetScale(Vector3 scale)
		{
			if (coordinateSpace == CoordinateSpace.Local)
			{
				target.localScale = scale;
			}
		}

		protected virtual TransformSnapshot Construct()
		{
			return new TransformSnapshot(NetworkTime.localTime, 0.0, GetPosition(), GetRotation(), GetScale());
		}

		protected void AddSnapshot(SortedList<double, TransformSnapshot> snapshots, double timeStamp, Vector3? position, Quaternion? rotation, Vector3? scale)
		{
			if (!position.HasValue)
			{
				position = ((snapshots.Count > 0) ? snapshots.Values[snapshots.Count - 1].position : GetPosition());
			}
			if (!rotation.HasValue)
			{
				rotation = ((snapshots.Count > 0) ? snapshots.Values[snapshots.Count - 1].rotation : GetRotation());
			}
			if (!scale.HasValue)
			{
				scale = ((snapshots.Count > 0) ? snapshots.Values[snapshots.Count - 1].scale : GetScale());
			}
			SnapshotInterpolation.InsertIfNotExists(snapshots, NetworkClient.snapshotSettings.bufferLimit, new TransformSnapshot(timeStamp, NetworkTime.localTime, position.Value, rotation.Value, scale.Value));
		}

		protected virtual void Apply(TransformSnapshot interpolated, TransformSnapshot endGoal)
		{
			if (syncPosition)
			{
				SetPosition(interpolatePosition ? interpolated.position : endGoal.position);
			}
			if (syncRotation)
			{
				SetRotation(interpolateRotation ? interpolated.rotation : endGoal.rotation);
			}
			if (syncScale)
			{
				SetScale(interpolateScale ? interpolated.scale : endGoal.scale);
			}
		}

		[Command]
		public void CmdTeleport(Vector3 destination)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(destination);
			SendCommandInternal("System.Void Mirror.NetworkTransformBase::CmdTeleport(UnityEngine.Vector3)", -788685907, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		[Command]
		public void CmdTeleport(Vector3 destination, Quaternion rotation)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(destination);
			writer.WriteQuaternion(rotation);
			SendCommandInternal("System.Void Mirror.NetworkTransformBase::CmdTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", -840469116, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		public void RpcTeleport(Vector3 destination)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(destination);
			SendRPCInternal("System.Void Mirror.NetworkTransformBase::RpcTeleport(UnityEngine.Vector3)", 165611234, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		public void RpcTeleport(Vector3 destination, Quaternion rotation)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(destination);
			writer.WriteQuaternion(rotation);
			SendRPCInternal("System.Void Mirror.NetworkTransformBase::RpcTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", -84918609, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcReset()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void Mirror.NetworkTransformBase::RpcReset()", 165401669, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		protected virtual void OnTeleport(Vector3 destination)
		{
			Reset();
			target.position = destination;
		}

		protected virtual void OnTeleport(Vector3 destination, Quaternion rotation)
		{
			Reset();
			target.position = destination;
			target.rotation = rotation;
		}

		public virtual void Reset()
		{
			serverSnapshots.Clear();
			clientSnapshots.Clear();
		}

		protected virtual void OnEnable()
		{
			Reset();
			if (NetworkServer.active)
			{
				NetworkIdentity.clientAuthorityCallback += OnClientAuthorityChanged;
			}
		}

		protected virtual void OnDisable()
		{
			Reset();
			if (NetworkServer.active)
			{
				NetworkIdentity.clientAuthorityCallback -= OnClientAuthorityChanged;
			}
		}

		[ServerCallback]
		private void OnClientAuthorityChanged(NetworkConnectionToClient conn, NetworkIdentity identity, bool authorityState)
		{
			if (NetworkServer.active && !(identity != base.netIdentity) && syncDirection == SyncDirection.ClientToServer)
			{
				Reset();
				RpcReset();
			}
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdTeleport__Vector3(Vector3 destination)
		{
			if (syncDirection == SyncDirection.ClientToServer)
			{
				OnTeleport(destination);
				RpcTeleport(destination);
			}
		}

		protected static void InvokeUserCode_CmdTeleport__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdTeleport called on client.");
			}
			else
			{
				((NetworkTransformBase)obj).UserCode_CmdTeleport__Vector3(reader.ReadVector3());
			}
		}

		protected void UserCode_CmdTeleport__Vector3__Quaternion(Vector3 destination, Quaternion rotation)
		{
			if (syncDirection == SyncDirection.ClientToServer)
			{
				OnTeleport(destination, rotation);
				RpcTeleport(destination, rotation);
			}
		}

		protected static void InvokeUserCode_CmdTeleport__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdTeleport called on client.");
			}
			else
			{
				((NetworkTransformBase)obj).UserCode_CmdTeleport__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
			}
		}

		protected void UserCode_RpcTeleport__Vector3(Vector3 destination)
		{
			OnTeleport(destination);
		}

		protected static void InvokeUserCode_RpcTeleport__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcTeleport called on server.");
			}
			else
			{
				((NetworkTransformBase)obj).UserCode_RpcTeleport__Vector3(reader.ReadVector3());
			}
		}

		protected void UserCode_RpcTeleport__Vector3__Quaternion(Vector3 destination, Quaternion rotation)
		{
			OnTeleport(destination, rotation);
		}

		protected static void InvokeUserCode_RpcTeleport__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcTeleport called on server.");
			}
			else
			{
				((NetworkTransformBase)obj).UserCode_RpcTeleport__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
			}
		}

		protected void UserCode_RpcReset()
		{
			Reset();
		}

		protected static void InvokeUserCode_RpcReset(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcReset called on server.");
			}
			else
			{
				((NetworkTransformBase)obj).UserCode_RpcReset();
			}
		}

		static NetworkTransformBase()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(NetworkTransformBase), "System.Void Mirror.NetworkTransformBase::CmdTeleport(UnityEngine.Vector3)", InvokeUserCode_CmdTeleport__Vector3, requiresAuthority: true);
			RemoteProcedureCalls.RegisterCommand(typeof(NetworkTransformBase), "System.Void Mirror.NetworkTransformBase::CmdTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdTeleport__Vector3__Quaternion, requiresAuthority: true);
			RemoteProcedureCalls.RegisterRpc(typeof(NetworkTransformBase), "System.Void Mirror.NetworkTransformBase::RpcTeleport(UnityEngine.Vector3)", InvokeUserCode_RpcTeleport__Vector3);
			RemoteProcedureCalls.RegisterRpc(typeof(NetworkTransformBase), "System.Void Mirror.NetworkTransformBase::RpcTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleport__Vector3__Quaternion);
			RemoteProcedureCalls.RegisterRpc(typeof(NetworkTransformBase), "System.Void Mirror.NetworkTransformBase::RpcReset()", InvokeUserCode_RpcReset);
		}
	}
}
