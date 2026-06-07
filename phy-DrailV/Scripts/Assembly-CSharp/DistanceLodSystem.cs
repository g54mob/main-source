#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV;
using DV.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;

public class DistanceLodSystem : SystemBase
{
	[UpdateInGroup(typeof(LateSimulationSystemGroup))]
	public class LateUpdateSystem : SystemBase
	{
		private DistanceLodSystem system;

		protected override void OnCreate()
		{
			system = base.World.GetOrCreateSystem<DistanceLodSystem>();
		}

		protected override void OnUpdate()
		{
			system.Dependency.Complete();
			LodLevelChangedEvent item;
			while (system.lodLevelChangedEvents.TryDequeue(out item))
			{
				base.EntityManager.GetComponentObject<DistanceLod>(item.Entity).SetLod(item.Lod);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}

	private struct ThresholdIndexData : IComponentData
	{
		public int thresholdsIndex;
	}

	public struct CurrentLodData : IComponentData
	{
		public byte lod;
	}

	private readonly struct LodThresholds : IComponentData, IEquatable<LodThresholds>
	{
		public readonly UnsafeList<ushort> thresholds;

		public LodThresholds(ushort[] lods)
		{
			thresholds = new UnsafeList<ushort>(lods.Length, Allocator.Persistent);
			for (int i = 0; i < lods.Length; i++)
			{
				thresholds.AddNoResize(lods[i]);
			}
		}

		public static bool operator ==(LodThresholds left, LodThresholds right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(LodThresholds left, LodThresholds right)
		{
			return !left.Equals(right);
		}

		public unsafe bool Equals(LodThresholds other)
		{
			return thresholds.Ptr == other.thresholds.Ptr;
		}

		public override bool Equals(object obj)
		{
			if (obj is LodThresholds other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = thresholds[0].GetHashCode();
			for (int i = 1; i < thresholds.Length; i++)
			{
				num = (num * 397) ^ thresholds[i].GetHashCode();
			}
			return num;
		}
	}

	private readonly struct LodLevelChangedEvent
	{
		public readonly Entity Entity;

		public readonly byte Lod;

		public LodLevelChangedEvent(Entity entity, byte lod)
		{
			Entity = entity;
			Lod = lod;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass6_0
	{
		public DistanceLodSystem _003C_003E4__this;

		public EntityCommandBuffer endSimulationEcb;

		public NativeList<float3> worldPositions;

		public NativeList<LodThresholds> lodThresholds;

		public NativeQueue<LodLevelChangedEvent>.ParallelWriter lodLevelChangedQueue;

		internal void _003COnUpdate_003Eb__0(DistanceLod distanceLod, in Entity entity)
		{
			LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
		}

		internal void _003COnUpdate_003Eb__1(ref CurrentLodData data, in Entity entity, in ThresholdIndexData indexData, in LocalToWorld transform)
		{
			LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
		}
	}

	[Unity.Entities.DOTSCompilerGenerated]
	private struct _003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities : IJobChunk
	{
		private struct LambdaParameterValueProviders
		{
			public struct Runtimes
			{
				public LambdaParameterValueProvider_ManagedComponentData<DistanceLod>.Runtime runtime_distanceLod;

				public LambdaParameterValueProvider_Entity.Runtime runtime_entity;
			}

			private LambdaParameterValueProvider_ManagedComponentData<DistanceLod> forParameter_distanceLod;

			[ReadOnly]
			private LambdaParameterValueProvider_Entity forParameter_entity;

			public void ScheduleTimeInitialize(DistanceLodSystem componentSystem)
			{
				forParameter_distanceLod.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
			}

			public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
			{
				return new Runtimes
				{
					runtime_distanceLod = forParameter_distanceLod.PrepareToExecuteOnEntitiesIn(ref p0),
					runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0)
				};
			}
		}

		public DistanceLodSystem _003C_003E4__this;

		public EntityCommandBuffer endSimulationEcb;

		private LambdaParameterValueProviders _lambdaParameterValueProviders;

		[NativeDisableUnsafePtrRestriction]
		private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

		private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

		internal void OriginalLambdaBody(DistanceLod distanceLod, in Entity entity)
		{
			LodThresholds value = new LodThresholds(distanceLod.GetLodThresholds());
			distanceLod.GetLodThresholds = null;
			int num = _003C_003E4__this.globalLodThresholds.IndexOf(value);
			if (num == -1)
			{
				_003C_003E4__this.globalLodThresholds.Add(value);
				num = _003C_003E4__this.globalLodThresholds.Length - 1;
			}
			endSimulationEcb.AddComponent(entity, new ThresholdIndexData
			{
				thresholdsIndex = num
			});
			endSimulationEcb.AddComponent(entity, new CurrentLodData
			{
				lod = byte.MaxValue
			});
		}

		public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass6_0 displayClass)
		{
			_003C_003E4__this = displayClass._003C_003E4__this;
			endSimulationEcb = displayClass.endSimulationEcb;
		}

		public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass6_0 displayClass)
		{
			displayClass._003C_003E4__this = _003C_003E4__this;
			displayClass.endSimulationEcb = endSimulationEcb;
		}

		public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
		{
			LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
			_runtimes = &runtimes;
			IterateEntities(ref chunk, ref *_runtimes);
		}

		public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
		{
			int count = chunk.Count;
			for (int i = 0; i < count; i++)
			{
				OriginalLambdaBody(runtimes.runtime_distanceLod.For(i), in runtimes.runtime_entity.For(i));
			}
		}

		public void ScheduleTimeInitialize(DistanceLodSystem componentSystem, ref _003C_003Ec__DisplayClass6_0 displayClass)
		{
			_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			ReadFromDisplayClass(ref displayClass);
		}

		public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
		{
			JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities>(jobData), ref *archetypeChunkIterator);
		}
	}

	[NoAlias]
	[BurstCompile]
	[Unity.Entities.DOTSCompilerGenerated]
	private struct _003C_003Ec__DisplayClass_Calculate_DistanceLods : IJobChunk
	{
		private struct LambdaParameterValueProviders
		{
			[NoAlias]
			public struct Runtimes
			{
				[NoAlias]
				public LambdaParameterValueProvider_IComponentData<CurrentLodData>.Runtime runtime_data;

				[NoAlias]
				public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

				[NoAlias]
				public LambdaParameterValueProvider_IComponentData<ThresholdIndexData>.Runtime runtime_indexData;

				[NoAlias]
				public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_transform;
			}

			[NoAlias]
			private LambdaParameterValueProvider_IComponentData<CurrentLodData> forParameter_data;

			[ReadOnly]
			[NoAlias]
			private LambdaParameterValueProvider_Entity forParameter_entity;

			[ReadOnly]
			[NoAlias]
			private LambdaParameterValueProvider_IComponentData<ThresholdIndexData> forParameter_indexData;

			[NoAlias]
			[ReadOnly]
			private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_transform;

			public void ScheduleTimeInitialize(DistanceLodSystem componentSystem)
			{
				forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				forParameter_indexData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				forParameter_transform.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
			}

			public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
			{
				return new Runtimes
				{
					runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0),
					runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
					runtime_indexData = forParameter_indexData.PrepareToExecuteOnEntitiesIn(ref p0),
					runtime_transform = forParameter_transform.PrepareToExecuteOnEntitiesIn(ref p0)
				};
			}
		}

		[ReadOnly]
		public NativeList<float3> worldPositions;

		[ReadOnly]
		public NativeList<LodThresholds> lodThresholds;

		public NativeQueue<LodLevelChangedEvent>.ParallelWriter lodLevelChangedQueue;

		private LambdaParameterValueProviders _lambdaParameterValueProviders;

		[NativeDisableUnsafePtrRestriction]
		private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

		internal void OriginalLambdaBody(ref CurrentLodData data, in Entity entity, in ThresholdIndexData indexData, in LocalToWorld transform)
		{
			float num = float.PositiveInfinity;
			float3 position = transform.Position;
			for (int i = 0; i < worldPositions.Length; i++)
			{
				float num2 = math.lengthsq(position - worldPositions[i]);
				num = math.select(num, num2, num2 < num);
			}
			UnsafeList<ushort> thresholds = lodThresholds[indexData.thresholdsIndex].thresholds;
			int num3 = 0;
			for (int j = 0; j < thresholds.Length; j++)
			{
				num3 = math.select(num3, j, num >= (float)(thresholds[j] * thresholds[j]));
			}
			if (num3 != data.lod)
			{
				data.lod = (byte)num3;
				lodLevelChangedQueue.Enqueue(new LodLevelChangedEvent(entity, (byte)num3));
			}
		}

		public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass6_0 displayClass)
		{
			worldPositions = displayClass.worldPositions;
			lodThresholds = displayClass.lodThresholds;
			lodLevelChangedQueue = displayClass.lodLevelChangedQueue;
		}

		public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
		{
			LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
			_runtimes = &runtimes;
			IterateEntities(ref chunk, ref *_runtimes);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
		{
			int count = chunk.Count;
			for (int i = 0; i < count; i++)
			{
				OriginalLambdaBody(ref runtimes.runtime_data.For(i), in runtimes.runtime_entity.For(i), in runtimes.runtime_indexData.For(i), in runtimes.runtime_transform.For(i));
			}
		}

		public void ScheduleTimeInitialize(DistanceLodSystem componentSystem, ref _003C_003Ec__DisplayClass6_0 displayClass)
		{
			_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			ReadFromDisplayClass(ref displayClass);
		}
	}

	private NativeList<float3> referenceWorldPositions;

	private NativeList<LodThresholds> globalLodThresholds;

	private NativeQueue<LodLevelChangedEvent> lodLevelChangedEvents;

	private EndSimulationEntityCommandBufferSystem endSimulationEcbSystem;

	private EntityQuery _003C_003EInitialize_DistanceLod_Entities_entityQuery;

	private ProfilerMarker _003C_003EInitialize_DistanceLod_Entities_profilerMarker;

	private EntityQuery _003C_003ECalculate_DistanceLods_entityQuery;

	protected override void OnCreate()
	{
		referenceWorldPositions = new NativeList<float3>(2, Allocator.Persistent);
		globalLodThresholds = new NativeList<LodThresholds>(Allocator.Persistent);
		lodLevelChangedEvents = new NativeQueue<LodLevelChangedEvent>(Allocator.Persistent);
		endSimulationEcbSystem = base.World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
	}

	protected override void OnDestroy()
	{
		if (referenceWorldPositions.IsCreated)
		{
			referenceWorldPositions.Dispose();
		}
		if (globalLodThresholds.IsCreated)
		{
			for (int i = 0; i < globalLodThresholds.Length; i++)
			{
				globalLodThresholds[i].thresholds.Dispose();
			}
			globalLodThresholds.Dispose();
		}
		if (lodLevelChangedEvents.IsCreated)
		{
			lodLevelChangedEvents.Dispose();
		}
	}

	protected override void OnUpdate()
	{
		_003C_003Ec__DisplayClass6_0 displayClass = new _003C_003Ec__DisplayClass6_0
		{
			_003C_003E4__this = this
		};
		if (TimeUtil.IsFlowing && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
		{
			displayClass.endSimulationEcb = endSimulationEcbSystem.CreateCommandBuffer();
			_ = base.Entities;
			_003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities jobData = default(_003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EInitialize_DistanceLod_Entities_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EInitialize_DistanceLod_Entities_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EInitialize_DistanceLod_Entities_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			referenceWorldPositions.Clear();
			if ((bool)PlayerManager.PlayerTransform)
			{
				referenceWorldPositions.Add(PlayerManager.PlayerTransform.position);
			}
			ExternalCamera externalCamera = SingletonBehaviour<PlayerCameraSwitcher>.Instance?.externalCamera;
			if ((object)externalCamera != null && externalCamera.IsOn)
			{
				referenceWorldPositions.Add(externalCamera.transform.position);
			}
			displayClass.worldPositions = referenceWorldPositions;
			displayClass.lodThresholds = globalLodThresholds;
			displayClass.lodLevelChangedQueue = lodLevelChangedEvents.AsParallelWriter();
			_ = base.Entities;
			JobHandle dependency = base.Dependency;
			_003C_003Ec__DisplayClass_Calculate_DistanceLods jobData2 = default(_003C_003Ec__DisplayClass_Calculate_DistanceLods);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			dependency = JobChunkExtensions.ScheduleParallel(jobData2, _003C_003ECalculate_DistanceLods_entityQuery, dependency);
			base.Dependency = dependency;
		}
	}

	protected internal unsafe override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		_003C_003EInitialize_DistanceLod_Entities_entityQuery = _003C_003EGetEntityQuery_ForInitialize_DistanceLod_Entities_From(this);
		_003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Initialize_DistanceLod_Entities.RunWithoutJobSystem;
		_003C_003EInitialize_DistanceLod_Entities_profilerMarker = new ProfilerMarker("Initialize_DistanceLod_Entities");
		_003C_003ECalculate_DistanceLods_entityQuery = _003C_003EGetEntityQuery_ForCalculate_DistanceLods_From(this);
	}

	public static EntityQuery _003C_003EGetEntityQuery_ForInitialize_DistanceLod_Entities_From(ComponentSystemBase componentSystem)
	{
		EntityQueryDesc[] array = new EntityQueryDesc[1];
		EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
		entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadWrite<DistanceLod>() };
		entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CurrentLodData>() };
		return componentSystem.GetEntityQuery(array);
	}

	public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_DistanceLods_From(ComponentSystemBase componentSystem)
	{
		EntityQueryDesc[] array = new EntityQueryDesc[1];
		(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
		{
			ComponentType.ReadWrite<CurrentLodData>(),
			ComponentType.ReadOnly<ThresholdIndexData>(),
			ComponentType.ReadOnly<LocalToWorld>()
		};
		return componentSystem.GetEntityQuery(array);
	}
}
