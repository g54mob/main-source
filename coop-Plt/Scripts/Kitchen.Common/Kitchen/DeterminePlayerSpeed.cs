#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class DeterminePlayerSpeed : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public DeterminePlayerSpeed _003C_003E4__this;

			public NativeArray<Entity> slower_tools;

			public NativeArray<Entity> slowers;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPlayer player, in CPosition position, in CItemHolder holding, in CShoeEffect shoes)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.Runtime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holding;

					public LambdaParameterValueProvider_IComponentData<CShoeEffect>.Runtime runtime_shoes;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holding;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CShoeEffect> forParameter_shoes;

				public void ScheduleTimeInitialize(DeterminePlayerSpeed componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holding.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_shoes.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holding = forParameter_holding.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_shoes = forParameter_shoes.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public DeterminePlayerSpeed _003C_003E4__this;

			public NativeArray<Entity> slower_tools;

			public NativeArray<Entity> slowers;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CHeldAppliance> _ComponentDataFromEntity_CHeldAppliance_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CToolInUse> _ComponentDataFromEntity_CToolInUse_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CSlowPlayer> _ComponentDataFromEntity_CSlowPlayer_2;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPlayer player, in CPosition position, in CItemHolder holding, in CShoeEffect shoes)
			{
				CLayoutRoomTile tile = _003C_003E4__this.TileManager.GetTile(position);
				bool flag = _ComponentDataFromEntity_CHeldAppliance_0.HasComponent(holding.HeldItem);
				CSlowPlayer comp;
				float num = (_003C_003E4__this.Require<CSlowPlayer>(holding.HeldItem, out comp) ? comp.Factor : 1f);
				player.Speed = num * ((flag && LayoutHelpers.IsInside(tile.Type)) ? 0.75f : 1f);
				player.Speed *= 1f + shoes.SpeedModifier;
				foreach (Entity slower_tool in slower_tools)
				{
					if (_ComponentDataFromEntity_CToolInUse_1[slower_tool].User == e)
					{
						CSlowPlayer cSlowPlayer = _ComponentDataFromEntity_CSlowPlayer_2[slower_tool];
						player.Speed *= cSlowPlayer.Factor;
					}
				}
				foreach (Entity slower in slowers)
				{
					CPosition cPosition = _ComponentDataFromEntity_CPosition_3[slower];
					CSlowPlayer cSlowPlayer2 = _ComponentDataFromEntity_CSlowPlayer_2[slower];
					if ((!shoes.IgnoreMess || !(cSlowPlayer2.Factor < 1f)) && (cPosition.Position - position).sqrMagnitude < cSlowPlayer2.Radius * cSlowPlayer2.Radius && (cSlowPlayer2.Radius > 100f || _003C_003E4__this.TileManager.GetRoom(cPosition) == tile.RoomID))
					{
						player.Speed *= cSlowPlayer2.Factor;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				slower_tools = displayClass.slower_tools;
				slowers = displayClass.slowers;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.slower_tools = slower_tools;
				displayClass.slowers = slowers;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_player.For(i), in runtimes.runtime_position.For(i), in runtimes.runtime_holding.For(i), in runtimes.runtime_shoes.For(i));
				}
			}

			public void ScheduleTimeInitialize(DeterminePlayerSpeed componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CHeldAppliance_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CHeldAppliance>(true);
				_ComponentDataFromEntity_CToolInUse_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CToolInUse>(true);
				_ComponentDataFromEntity_CSlowPlayer_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CSlowPlayer>(true);
				_ComponentDataFromEntity_CPosition_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery SlowPlayer;

		private EntityQuery SlowPlayerTools;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			SlowPlayer = GetEntityQuery(new QueryHelper().All(typeof(CPosition), typeof(CSlowPlayer)).None(typeof(CToolInUse)));
			SlowPlayerTools = GetEntityQuery(typeof(CToolInUse), typeof(CSlowPlayer));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				_003C_003E4__this = this
			};
			if (!Has<SLayout>())
			{
				return;
			}
			displayClass.slowers = SlowPlayer.ToEntityArray(Allocator.TempJob);
			try
			{
				displayClass.slower_tools = SlowPlayerTools.ToEntityArray(Allocator.TempJob);
				try
				{
					_ = base.Entities;
					_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
					jobData.ScheduleTimeInitialize(this, ref displayClass);
					CompleteDependency();
					EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
					InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
					_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
					try
					{
						InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
					}
					finally
					{
						_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
					}
					jobData.WriteToDisplayClass(ref displayClass);
				}
				finally
				{
					((IDisposable)displayClass.slower_tools/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.slowers/*cast due to .constrained prefix*/).Dispose();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadWrite<CPlayer>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CItemHolder>(),
				ComponentType.ReadOnly<CShoeEffect>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
