#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateBefore(typeof(UpdateTakesDuration))]
	[UpdateInGroup(typeof(HighPriorityInteractionGroup))]
	public class InstantProcessToolCompleteProxyDuration : GameSystemBase
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

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.StructuralChangeRuntime runtime_duration;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				public void ScheduleTimeInitialize(InstantProcessToolCompleteProxyDuration componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_duration = forParameter_duration.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public InstantProcessToolCompleteProxyDuration hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, ref CTakesDuration duration)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref duration);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CTakesDuration originalComponent;
				CTakesDuration duration = reference.runtime_duration.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref duration);
				reference.runtime_duration.WriteBack(entity, ref duration, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(InstantProcessToolCompleteProxyDuration componentSystem)
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
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CTakesDuration duration)
		{
			if (duration.Remaining <= 0f)
			{
				duration.Active = false;
			}
			if (!duration.Active || !duration.Manual || !Require<CDurationInteractionProxy>(e, out CDurationInteractionProxy comp))
			{
				return;
			}
			Entity proxy = comp.Proxy;
			if (!RequireBuffer(proxy, out DynamicBuffer<CBeingActedOnBy> comp2))
			{
				return;
			}
			for (int i = 0; i < comp2.Length; i++)
			{
				CBeingActedOnBy cBeingActedOnBy = comp2[i];
				if (cBeingActedOnBy.IsTransferOnly || !Require<CAttemptingInteraction>(cBeingActedOnBy.Interactor, out CAttemptingInteraction comp3) || comp3.Mode != duration.Mode || comp3.Result != InteractionResult.None)
				{
					continue;
				}
				if (Require<CItemHolder>(cBeingActedOnBy.Interactor, out CItemHolder comp4))
				{
					if (!(comp4.HeldItem == default(Entity)) && duration.ManualNeedsEmptyHands)
					{
						continue;
					}
				}
				else if (duration.ManualNeedsEmptyHands)
				{
					continue;
				}
				if (Require<CToolUser>(cBeingActedOnBy.Interactor, out CToolUser comp5) && Has<CInstantProcessTool>(comp5.CurrentTool) && !Has<CInstantProcessToolOnCooldown>(comp5.CurrentTool))
				{
					Set<CInstantlyCompleteDuration>(e);
					Set<CInstantProcessToolOnCooldown>(comp5.CurrentTool);
					comp3.Result = InteractionResult.Performed;
					Set(cBeingActedOnBy.Interactor, comp3);
					break;
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadWrite<CTakesDuration>() };
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CInstantlyCompleteDuration>(),
				ComponentType.ReadWrite<CPreventUse>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
