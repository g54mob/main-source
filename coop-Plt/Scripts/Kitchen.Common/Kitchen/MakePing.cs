#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup))]
	public class MakePing : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, in CPlayer player, in CInputData inputs, in CPlayerColour colour, in CAttemptingInteraction attempting_interaction, in CBlockPing ping_block)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.StructuralChangeRuntime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CInputData>.StructuralChangeRuntime runtime_inputs;

					public LambdaParameterValueProvider_IComponentData<CPlayerColour>.StructuralChangeRuntime runtime_colour;

					public LambdaParameterValueProvider_IComponentData<CAttemptingInteraction>.StructuralChangeRuntime runtime_attempting_interaction;

					public LambdaParameterValueProvider_IComponentData<CBlockPing>.StructuralChangeRuntime runtime_ping_block;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInputData> forParameter_inputs;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayerColour> forParameter_colour;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAttemptingInteraction> forParameter_attempting_interaction;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CBlockPing> forParameter_ping_block;

				public void ScheduleTimeInitialize(MakePing componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_inputs.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_colour.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_attempting_interaction.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_ping_block.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_player = forParameter_player.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_inputs = forParameter_inputs.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_colour = forParameter_colour.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_attempting_interaction = forParameter_attempting_interaction.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_ping_block = forParameter_ping_block.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, in CPlayer player, in CInputData inputs, in CPlayerColour colour, in CAttemptingInteraction attempting_interaction, in CBlockPing ping_block)
			{
				if (!ping_block.PreventPing && inputs.State.SecondaryAction2 == ButtonState.Released)
				{
					Entity entity = ctx.CreateEntity();
					ctx.Set(entity, new CRequiresView
					{
						Type = ViewType.Ping
					});
					ctx.Set(entity, new CPosition
					{
						Position = attempting_interaction.Location
					});
					ctx.Set(entity, new CLifetime
					{
						RemainingLife = 1f
					});
					ctx.Set(entity, new CPlayerPing
					{
						Colour = colour.Color
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.ctx = ctx;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CPlayer originalComponent;
				CPlayer player = reference.runtime_player.For(entity, out originalComponent);
				CInputData originalComponent2;
				CInputData inputs = reference.runtime_inputs.For(entity, out originalComponent2);
				CPlayerColour originalComponent3;
				CPlayerColour colour = reference.runtime_colour.For(entity, out originalComponent3);
				CAttemptingInteraction originalComponent4;
				CAttemptingInteraction attempting_interaction = reference.runtime_attempting_interaction.For(entity, out originalComponent4);
				CBlockPing originalComponent5;
				CBlockPing ping_block = reference.runtime_ping_block.For(entity, out originalComponent5);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, in player, in inputs, in colour, in attempting_interaction, in ping_block);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(MakePing componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery PlayersWithoutBlockPing;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			PlayersWithoutBlockPing = GetEntityQuery(new QueryHelper().All(typeof(CPlayer)).None(typeof(CBlockPing)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = default(_003C_003Ec__DisplayClass2_0);
			base.EntityManager.AddComponent<CBlockPing>(PlayersWithoutBlockPing);
			displayClass.ctx = new EntityContext(base.EntityManager, new EntityCommandBuffer(Allocator.Temp));
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this, ref displayClass);
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
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.WriteToDisplayClass(ref displayClass);
			displayClass.ctx.Playback();
			displayClass.ctx.Dispose();
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
			entityQueryDesc.All = new ComponentType[5]
			{
				ComponentType.ReadOnly<CPlayer>(),
				ComponentType.ReadOnly<CInputData>(),
				ComponentType.ReadOnly<CPlayerColour>(),
				ComponentType.ReadOnly<CAttemptingInteraction>(),
				ComponentType.ReadOnly<CBlockPing>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHideView>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
