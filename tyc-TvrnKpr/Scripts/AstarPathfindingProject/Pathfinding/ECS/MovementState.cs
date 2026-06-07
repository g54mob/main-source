using Pathfinding.PID;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.ECS
{
	public struct MovementState : IComponentData, IQueryTypeParameter
	{
		public PIDMovement.PersistentState followerState;

		public float3 nextCorner;

		public float3 endOfPath;

		public float3 closestOnNavmesh;

		public float3 positionOffset;

		public int hierarchicalNodeIndex;

		public float remainingDistanceToEndOfPart;

		public float rotationOffset;

		public float rotationOffset2;

		public ushort pathTracerVersion;

		private ushort flags;

		private const int ReachedDestinationFlag = 1;

		private const int reachedDestinationAndOrientationFlag = 2;

		private const int ReachedEndOfPathFlag = 4;

		private const int reachedEndOfPathAndOrientationFlag = 8;

		private const int ReachedEndOfPartFlag = 16;

		private const int TraversingLastPartFlag = 32;

		private const int HasValidEndPointFlag = 64;

		private const int GraphIndexOffsetInFlags = 8;

		private const ushort GraphIndexMaskInFlags = 65280;

		public bool reachedDestination
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool reachedDestinationAndOrientation
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool reachedEndOfPath
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool reachedEndOfPathAndOrientation
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool reachedEndOfPart
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool traversingLastPart
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public bool hasValidEndPoint
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public uint graphIndex
		{
			[IgnoredByDeepProfiler]
			get
			{
				return 0u;
			}
			[IgnoredByDeepProfiler]
			internal set
			{
			}
		}

		public bool isOnValidNode => false;

		public MovementState(Vector3 agentPosition)
		{
			followerState = default(PIDMovement.PersistentState);
			nextCorner = default(float3);
			endOfPath = default(float3);
			closestOnNavmesh = default(float3);
			positionOffset = default(float3);
			hierarchicalNodeIndex = 0;
			remainingDistanceToEndOfPart = 0f;
			rotationOffset = 0f;
			rotationOffset2 = 0f;
			pathTracerVersion = 0;
			flags = 0;
		}

		public void SetPathIsEmpty(Vector3 agentPosition)
		{
		}
	}
}
