#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateAfter(typeof(DeterminePlayerSpeed))]
	public class SlowPlayersNearCustomers : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public SlowPlayersNearCustomers _003C_003E4__this;

			public NativeArray<Entity> customers;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPlayer player, in CPosition position, in CItemHolder holding)
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
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holding;

				public void ScheduleTimeInitialize(SlowPlayersNearCustomers componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holding.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holding = forParameter_holding.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public SlowPlayersNearCustomers _003C_003E4__this;

			public NativeArray<Entity> customers;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPlayer player, in CPosition position, in CItemHolder holding)
			{
				CLayoutRoomTile tile = _003C_003E4__this.TileManager.GetTile(position);
				foreach (Entity customer in customers)
				{
					CPosition cPosition = _ComponentDataFromEntity_CPosition_0[customer];
					if ((cPosition.Position - position).sqrMagnitude < 16f && _003C_003E4__this.TileManager.GetRoom(cPosition) == tile.RoomID)
					{
						player.Speed *= 0.5f;
						break;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				customers = displayClass.customers;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.customers = customers;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_player.For(i), in runtimes.runtime_position.For(i), in runtimes.runtime_holding.For(i));
				}
			}

			public void ScheduleTimeInitialize(SlowPlayersNearCustomers componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Customers;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Customers = GetEntityQuery(typeof(CPosition), typeof(CCustomer));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this
			};
			if (HasStatus(RestaurantStatus.CustomersSlowPlayers))
			{
				displayClass.customers = Customers.ToEntityArray(Allocator.TempJob);
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
				displayClass.customers.Dispose();
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<CPlayer>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CItemHolder>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
