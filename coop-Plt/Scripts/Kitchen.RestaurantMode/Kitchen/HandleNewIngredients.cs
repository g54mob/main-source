#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(HandleNewDish))]
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class HandleNewIngredients : RestaurantSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public int used_slots;

			public NativeArray<Entity> slots;

			public HandleNewIngredients _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public List<Vector3> floor_tiles;

			public int placed_tile;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, in CNeedsNewIngredient ingredient)
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

					public LambdaParameterValueProvider_IComponentData<CNeedsNewIngredient>.Runtime runtime_ingredient;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CNeedsNewIngredient> forParameter_ingredient;

				public void ScheduleTimeInitialize(HandleNewIngredients componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_ingredient.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ingredient = forParameter_ingredient.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public int used_slots;

			public NativeArray<Entity> slots;

			public HandleNewIngredients _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public List<Vector3> floor_tiles;

			public int placed_tile;

			public EntityContext ctx;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CNeedsNewIngredient ingredient)
			{
				if (used_slots < slots.Length)
				{
					if (!_003C_003E4__this.Data.TryGet<Item>(ingredient.Item, out var output, warn_if_fail: true))
					{
						return;
					}
					Appliance dedicatedProvider = output.DedicatedProvider;
					int iD = ((dedicatedProvider == null) ? _003C_003E4__this.Data.ReferableObjects.DefaultProvider.ID : dedicatedProvider.ID);
					Entity entity = slots[used_slots];
					CPosition component = _ComponentDataFromEntity_CPosition_0[entity];
					Entity e2 = ecb.CreateEntity();
					ecb.AddComponent(e2, new CCreateAppliance
					{
						ID = iD
					});
					bool flag = false;
					if (dedicatedProvider != null && dedicatedProvider.Properties != null)
					{
						foreach (IApplianceProperty property in dedicatedProvider.Properties)
						{
							if (property is CItemProvider)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						ecb.AddComponent(e2, CItemProvider.InfiniteItemProvider(ingredient.Item));
					}
					ecb.AddComponent(e2, component);
					used_slots++;
					return;
				}
				Vector3 vector = Vector3.zero;
				bool flag2 = false;
				while (!flag2 && placed_tile < floor_tiles.Count)
				{
					vector = floor_tiles[placed_tile++];
					if (!_003C_003E4__this.UsedTiles.Contains(vector) && _003C_003E4__this.TileManager.GetOccupant(vector) == default(Entity) && !_003C_003E4__this.TileManager.GetTile(vector).HasFeature)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					vector = _003C_003E4__this.GetFallbackTile();
				}
				_003C_003E4__this.UsedTiles.Add(vector);
				PostHelpers.CreateIngredientParcel(ctx, vector, ingredient.Item);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				used_slots = displayClass.used_slots;
				slots = displayClass.slots;
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
				floor_tiles = displayClass.floor_tiles;
				placed_tile = displayClass.placed_tile;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass.used_slots = used_slots;
				displayClass.slots = slots;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ecb = ecb;
				displayClass.floor_tiles = floor_tiles;
				displayClass.placed_tile = placed_tile;
				displayClass.ctx = ctx;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_ingredient.For(i));
				}
			}

			public void ScheduleTimeInitialize(HandleNewIngredients componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
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

		private EntityQuery Query;

		private EntityQuery Slots;

		private HashSet<Vector3> UsedTiles = new HashSet<Vector3>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Query = GetEntityQuery(typeof(CNeedsNewIngredient));
			Slots = GetEntityQuery(new QueryHelper().All(typeof(CApplianceIngredientSlot)).None(typeof(CForSale)));
			RequireForUpdate(Query);
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = default(_003C_003Ec__DisplayClass4_0);
			displayClass._003C_003E4__this = this;
			displayClass.ecb = new EntityCommandBuffer(Allocator.TempJob);
			displayClass.ctx = new EntityContext(base.EntityManager, displayClass.ecb);
			displayClass.slots = Slots.ToEntityArray(Allocator.TempJob);
			displayClass.floor_tiles = GetPostTiles();
			displayClass.placed_tile = 0;
			displayClass.used_slots = 0;
			UsedTiles.Clear();
			UsedTiles.Add(GetFrontDoor());
			UsedTiles.Add(GetNameplateTile());
			UsedTiles.Add(GetRerollTile());
			UsedTiles.Add(GetPracticeTile());
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
			base.EntityManager.DestroyEntity(Query);
			base.EntityManager.DestroyEntity(Slots);
			displayClass.slots.Dispose();
			displayClass.ecb.Playback(base.EntityManager);
			displayClass.ecb.Dispose();
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CNeedsNewIngredient>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
