#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class DestroyHolderAfterDuration : GameSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.StructuralChangeRuntime runtime_holder;

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.StructuralChangeRuntime runtime_duration;

					public LambdaParameterValueProvider_IComponentData_Tag<CDestroyHolderAfterDuration>.StructuralChangeRuntime runtime_empty;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CDestroyHolderAfterDuration> forParameter_empty;

				public void ScheduleTimeInitialize(DestroyHolderAfterDuration componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_empty.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_holder = forParameter_holder.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_duration = forParameter_duration.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_empty = forParameter_empty.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public DestroyHolderAfterDuration hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, ref CItemHolder holder, [In] ref CTakesDuration duration, [In] ref CDestroyHolderAfterDuration empty)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref holder, in duration, in empty);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CItemHolder originalComponent;
				CItemHolder holder = reference.runtime_holder.For(entity, out originalComponent);
				CTakesDuration originalComponent2;
				CTakesDuration duration = reference.runtime_duration.For(entity, out originalComponent2);
				CDestroyHolderAfterDuration originalComponent3;
				CDestroyHolderAfterDuration empty = reference.runtime_empty.For(entity, out originalComponent3);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref holder, ref duration, ref empty);
				reference.runtime_holder.WriteBack(entity, ref holder, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(DestroyHolderAfterDuration componentSystem)
			{
				hostInstance = componentSystem;
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.Execute(this, query);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemHolder holder, in CTakesDuration duration, in CDestroyHolderAfterDuration empty)
		{
			if (duration.Active && duration.Remaining <= 0f)
			{
				base.EntityManager.DestroyEntity(holder);
				holder.HeldItem = default(Entity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<CItemHolder>(),
				ComponentType.ReadOnly<CTakesDuration>(),
				ComponentType.ReadOnly<CDestroyHolderAfterDuration>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
