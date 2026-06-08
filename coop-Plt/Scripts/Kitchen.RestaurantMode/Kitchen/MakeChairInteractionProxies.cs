#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class MakeChairInteractionProxies : RestaurantSystem
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

					public LambdaParameterValueProvider_IComponentData<CApplianceChair>.StructuralChangeRuntime runtime_chair;

					public LambdaParameterValueProvider_IComponentData<CInteractionProxy>.StructuralChangeRuntime runtime_proxy;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CApplianceChair> forParameter_chair;

				private LambdaParameterValueProvider_IComponentData<CInteractionProxy> forParameter_proxy;

				public void ScheduleTimeInitialize(MakeChairInteractionProxies componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_chair.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_proxy.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_chair = forParameter_chair.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_proxy = forParameter_proxy.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public MakeChairInteractionProxies hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, ref CApplianceChair chair, ref CInteractionProxy proxy)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref chair, ref proxy);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CApplianceChair originalComponent;
				CApplianceChair chair = reference.runtime_chair.For(entity, out originalComponent);
				CInteractionProxy originalComponent2;
				CInteractionProxy proxy = reference.runtime_proxy.For(entity, out originalComponent2);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref chair, ref proxy);
				reference.runtime_chair.WriteBack(entity, ref chair, ref originalComponent);
				reference.runtime_proxy.WriteBack(entity, ref proxy, ref originalComponent2);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(MakeChairInteractionProxies componentSystem)
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
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CApplianceChair chair, ref CInteractionProxy proxy)
		{
			proxy.IsActive = chair.IsInUse;
			if (!chair.IsInUse)
			{
				if (Has<CIsInteractive>(e))
				{
					base.EntityManager.RemoveComponent<CIsInteractive>(e);
				}
				if (!Has<CFireImmune>(e))
				{
					base.EntityManager.AddComponent<CFireImmune>(e);
				}
			}
			if (chair.IsInUse)
			{
				if (Has<CFireImmune>(e))
				{
					base.EntityManager.RemoveComponent<CFireImmune>(e);
				}
				if (!Has<CIsInteractive>(e))
				{
					base.EntityManager.AddComponent<CIsInteractive>(e);
				}
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CApplianceChair>(),
				ComponentType.ReadWrite<CInteractionProxy>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
