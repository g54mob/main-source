using System.Runtime.InteropServices;
using Pathfinding.Drawing;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	public struct JobDrawFollowerGizmos : IJobChunk
	{
		public CommandBuilder draw;

		public GCHandle entityManagerHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<AgentCylinderShape> AgentCylinderShapeHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<MovementSettings> MovementSettingsHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<AgentMovementPlane> AgentMovementPlaneHandleRO;

		[NativeDisableContainerSafetyRestriction]
		public ComponentTypeHandle<ManagedState> ManagedStateHandleRW;

		[ReadOnly]
		public ComponentTypeHandle<MovementState> MovementStateHandleRO;

		[ReadOnly]
		public ComponentTypeHandle<ResolvedMovement> ResolvedMovementHandleRO;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> scratchBuffer1;

		[NativeDisableContainerSafetyRestriction]
		public NativeArray<int> scratchBuffer2;

		public static readonly Color VisualRotationColor;

		public static readonly Color UnsmoothedRotation;

		public static readonly Color InternalRotation;

		public static readonly Color TargetInternalRotation;

		public static readonly Color TargetInternalRotationHint;

		public static readonly Color Path;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}

		public void Execute(ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref AgentCylinderShape shape, ManagedState managedState, ref MovementSettings settings, ref MovementState movementState, ref ResolvedMovement resolvedMovement)
		{
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}
	}
}
