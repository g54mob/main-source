#define ENABLE_PROFILER
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen.ShopBuilder
{
	[UpdateInGroup(typeof(ShopOptionGroup), OrderFirst = true)]
	public class CreateShopOptions : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SRequestRebuild : IComponentData
		{
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CShopBuilderOption>.Runtime runtime_option;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CShopBuilderOption> forParameter_option;

				public void ScheduleTimeInitialize(CreateShopOptions componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_option.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_option = forParameter_option.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CShopBuilderOption option)
			{
				option.Staple = ShopStapleType.NonStaple;
				option.IsRemoved = false;
				option.FilteredBy = default(SystemReference);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_option.For(i));
				}
			}

			public void ScheduleTimeInitialize(CreateShopOptions componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery ShopBuilderOptions;

		public NativeHashMap<int, ShopBuilderApplianceInfo> CachedApplianceInfo = new NativeHashMap<int, ShopBuilderApplianceInfo>(512, Allocator.Persistent);

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			ShopBuilderOptions = GetEntityQuery(typeof(CShopBuilderOption));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			CachedApplianceInfo.Dispose();
		}

		protected override void OnUpdate()
		{
			if (ShopBuilderOptions.IsEmpty || Has<SRequestRebuild>())
			{
				base.EntityManager.DestroyEntity(ShopBuilderOptions);
				Clear<SRequestRebuild>();
				CreateOptions();
				CreateCache();
			}
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
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
		}

		private void CreateCache()
		{
			CachedApplianceInfo.Clear();
			foreach (Appliance item in base.Data.Get<Appliance>())
			{
				CachedApplianceInfo[item.ID] = new ShopBuilderApplianceInfo
				{
					ID = item.ID,
					ShoppingTags = item.ShoppingTags,
					SellOnlyAsDuplicate = item.SellOnlyAsDuplicate,
					SellOnlyAsUnique = item.SellOnlyAsUnique,
					RequiresForShop = DataObjectList.FromList(item.RequiresForShop, (Appliance a) => a.ID),
					RequiresPhaseForShop = DataObjectList.FromList(item.RequiresPhaseForShop, (MenuPhase a) => (int)a),
					RequiresProcessForShop = DataObjectList.FromList(item.RequiresProcessForShop, (Process a) => a.ID),
					RequiresIngredientForShop = DataObjectList.FromList(item.RequiresIngredientForShop, (Item a) => a.ID)
				};
			}
		}

		private void CreateOptions()
		{
			Season season = Seasons.GetSeason();
			foreach (Appliance item in base.Data.Get<Appliance>())
			{
				if ((item.IsPurchasable || item.IsPurchasableAsUpgrade) && (item.RestrictedToSeason == Season.Normal || item.RestrictedToSeason == season))
				{
					AddOption(item);
				}
			}
		}

		private void AddOption(Appliance app)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CShopBuilderOption));
			base.EntityManager.SetComponentData(entity, new CShopBuilderOption(app));
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			Set<SRequestRebuild>();
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CShopBuilderOption>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
