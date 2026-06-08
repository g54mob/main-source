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
	public class Tray : GameSystemBase
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

					public LambdaParameterValueProvider_IComponentData<CToolStorage>.StructuralChangeRuntime runtime_storage_tool;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CToolStorage> forParameter_storage_tool;

				public void ScheduleTimeInitialize(Tray componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_storage_tool.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_storage_tool = forParameter_storage_tool.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public Tray hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, [In] ref CToolStorage storage_tool)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, in storage_tool);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CToolStorage originalComponent;
				CToolStorage storage_tool = reference.runtime_storage_tool.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref storage_tool);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(Tray componentSystem)
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
		private void _003COnUpdate_003Eb__0_0(Entity e, in CToolStorage storage_tool)
		{
			base.EntityManager.AddComponentData(e, new CItemStorage
			{
				Capacity = storage_tool.Capacity
			});
			base.EntityManager.AddBuffer<CItemStored>(e);
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CToolStorage>() };
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CItemStorage>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
