using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting;

namespace Pug.ECS.Hybrid
{
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(TransformSystemGroup), OrderLast = true)]
	public class UpdateGraphicalObjectTransformSystem : SystemBase
	{
		[BurstCompile]
		private struct TransformUpdateJob : IJobParallelForTransform
		{
			[ReadOnly]
			public NativeList<Entity> Entities;

			[ReadOnly]
			public ComponentLookup<LocalToWorld> TransformFromEntity;

			public float3 Offset;

			public void Execute(int index, TransformAccess transform)
			{
				Entity entity = Entities[index];
				if (TransformFromEntity.TryGetComponent(entity, out var componentData) && transform.isValid)
				{
					transform.position = math.round((componentData.Position + Offset) * 16f) / 16f;
				}
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentLookup<LocalToWorld> __Unity_Transforms_LocalToWorld_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Transforms_LocalToWorld_RO_ComponentLookup = state.GetComponentLookup<LocalToWorld>(isReadOnly: true);
			}
		}

		private CreateGraphicalObjectSystem _createGraphicalObjectSystem;

		private Dictionary<Transform, int> _entityOverrideIndex;

		private NativeList<Entity> _entityOverrides;

		private TransformAccessArray _transformOverrides;

		private TypeHandle __TypeHandle;

		public JobHandle GetOutputDependency()
		{
			return base.Dependency;
		}

		[Preserve]
		protected override void OnCreate()
		{
			_createGraphicalObjectSystem = base.World.GetExistingSystemManaged<CreateGraphicalObjectSystem>();
			_entityOverrideIndex = new Dictionary<Transform, int>(16);
			_entityOverrides = new NativeList<Entity>(16, Allocator.Persistent);
			_transformOverrides = new TransformAccessArray(16, 1);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			_entityOverrides.Dispose();
			_transformOverrides.Dispose();
			base.OnDestroy();
		}

		public void SetTransformOverride(Transform transform, Entity entity)
		{
			if (!_entityOverrideIndex.TryGetValue(transform, out var value))
			{
				_entityOverrideIndex.Add(transform, _entityOverrides.Length);
				_entityOverrides.Add(in entity);
				_transformOverrides.Add(transform);
			}
			else
			{
				_entityOverrides[value] = entity;
			}
		}

		public void RemoveTransformOverride(Transform transform)
		{
			if (_entityOverrideIndex.Remove(transform, out var value))
			{
				Transform key = _transformOverrides[_transformOverrides.length - 1];
				_transformOverrides.RemoveAtSwapBack(value);
				_entityOverrides.RemoveAtSwapBack(value);
				_entityOverrideIndex[key] = value;
				_entityOverrideIndex.Remove(transform);
			}
		}

		[Preserve]
		protected override void OnUpdate()
		{
			Manager.camera.UpdateRenderOrigo();
			TransformUpdateJob jobData = new TransformUpdateJob
			{
				Entities = _createGraphicalObjectSystem.m_GraphicalEntities,
				TransformFromEntity = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalToWorld_RO_ComponentLookup, ref base.CheckedStateRef),
				Offset = (-Manager.camera.RenderOrigo).ToFloat3()
			};
			base.Dependency = jobData.Schedule(_createGraphicalObjectSystem.m_Transforms, base.Dependency);
			TransformUpdateJob jobData2 = new TransformUpdateJob
			{
				Entities = _entityOverrides,
				TransformFromEntity = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalToWorld_RO_ComponentLookup, ref base.CheckedStateRef),
				Offset = (-Manager.camera.RenderOrigo).ToFloat3()
			};
			base.Dependency = jobData2.Schedule(_transformOverrides, base.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
		}

		protected override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			__AssignQueries(ref base.CheckedStateRef);
			__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
		}

		[Preserve]
		public UpdateGraphicalObjectTransformSystem()
		{
		}
	}
}
