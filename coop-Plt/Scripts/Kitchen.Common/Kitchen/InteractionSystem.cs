#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup))]
	public abstract class InteractionSystem : GenericSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CAttemptingInteraction>.StructuralChangeRuntime runtime_attempt;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_player;

				private LambdaParameterValueProvider_IComponentData<CAttemptingInteraction> forParameter_attempt;

				public void ScheduleTimeInitialize(InteractionSystem componentSystem)
				{
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_attempt.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_player = forParameter_player.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_attempt = forParameter_attempt.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public InteractionSystem hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity player, ref CAttemptingInteraction attempt)
			{
				hostInstance._003COnUpdate_003Eb__24_0(player, ref attempt);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity player = reference.runtime_player.For(entity);
				CAttemptingInteraction originalComponent;
				CAttemptingInteraction attempt = reference.runtime_attempt.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(player, ref attempt);
				reference.runtime_attempt.WriteBack(entity, ref attempt, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(InteractionSystem componentSystem)
			{
				hostInstance = componentSystem;
			}
		}

		protected EntityContext Context;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected virtual InteractionMode RequiredMode => InteractionMode.Items;

		protected virtual InteractionType RequiredType => InteractionType.Act;

		protected virtual bool AllowActOrGrab => false;

		protected virtual bool AllowAnyMode => false;

		protected virtual bool RequirePress => true;

		protected virtual bool RequireHold => false;

		protected virtual bool AllowTransferOnly => false;

		protected virtual bool UseImmediateContext => false;

		protected abstract bool IsPossible(ref InteractionData data);

		protected abstract void Perform(ref InteractionData data);

		protected virtual bool BeforeRun()
		{
			return true;
		}

		protected virtual void AfterRun()
		{
		}

		protected virtual bool ShouldAct(ref InteractionData interaction_data)
		{
			bool num = RequiredType == interaction_data.Attempt.Type || (AllowActOrGrab && (interaction_data.Attempt.Type == InteractionType.Act || interaction_data.Attempt.Type == InteractionType.Grab));
			bool flag = !RequirePress || !interaction_data.Attempt.IsHeld;
			bool flag2 = !RequireHold || interaction_data.Attempt.IsHeld;
			return num && flag && flag2;
		}

		protected virtual EntityContext CreateContext()
		{
			if (UseImmediateContext)
			{
				return new EntityContext(base.EntityManager, new EntityCommandBuffer(Allocator.TempJob));
			}
			return new EntityContext(base.EntityManager, GetCommandBuffer(ECB.PostInteraction));
		}

		protected virtual void CompleteContext(EntityContext ctx)
		{
			if (UseImmediateContext)
			{
				ctx.Playback();
				ctx.Dispose();
			}
		}

		protected override void OnUpdate()
		{
			if (BeforeRun())
			{
				Context = CreateContext();
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
				CompleteContext(Context);
				AfterRun();
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__24_0(Entity player, ref CAttemptingInteraction attempt)
		{
			if (attempt.Result == InteractionResult.Performed || (attempt.Mode != RequiredMode && !AllowAnyMode) || (attempt.TransferOnly && !AllowTransferOnly))
			{
				return;
			}
			InteractionData interaction_data = new InteractionData
			{
				Interactor = player,
				Attempt = attempt,
				Context = Context
			};
			interaction_data.ShouldAct = ShouldAct(ref interaction_data);
			if (IsPossible(ref interaction_data))
			{
				if (interaction_data.ShouldAct)
				{
					Perform(ref interaction_data);
					attempt = interaction_data.Attempt;
					attempt.PerformedBy = this;
				}
				if (RequiredType != InteractionType.Notify)
				{
					attempt.Result = ((!interaction_data.ShouldAct) ? InteractionResult.Possible : InteractionResult.Performed);
				}
				else if (interaction_data.ShouldAct)
				{
					attempt.Result = InteractionResult.Performed;
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CAttemptingInteraction>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
