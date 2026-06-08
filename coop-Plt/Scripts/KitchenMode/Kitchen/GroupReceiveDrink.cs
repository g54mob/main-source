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
	public class GroupReceiveDrink : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public bool has_found_item;

			public GroupReceiveDrink _003C_003E4__this;

			public GameData data;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CGroupReward reward, ref CPatience patience, ref CWantsDrink drink, in CCustomerSettings settings, in CAssignedTable table_set)
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

					public LambdaParameterValueProvider_IComponentData<CGroupReward>.Runtime runtime_reward;

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CWantsDrink>.Runtime runtime_drink;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_IComponentData<CAssignedTable>.Runtime runtime_table_set;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CGroupReward> forParameter_reward;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				private LambdaParameterValueProvider_IComponentData<CWantsDrink> forParameter_drink;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAssignedTable> forParameter_table_set;

				public void ScheduleTimeInitialize(GroupReceiveDrink componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_reward.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_drink.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_table_set.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_reward = forParameter_reward.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_drink = forParameter_drink.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table_set = forParameter_table_set.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool has_found_item;

			public GameData data;

			public EntityCommandBuffer ecb;

			[NoAlias]
			private BufferFromEntity<CTableSetGrabPoints> _BufferFromEntity_CTableSetGrabPoints_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CItemHolder> _ComponentDataFromEntity_CItemHolder_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CItem> _ComponentDataFromEntity_CItem_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CDrink> _ComponentDataFromEntity_CDrink_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CGroupReward reward, ref CPatience patience, ref CWantsDrink drink, in CCustomerSettings settings, in CAssignedTable table_set)
			{
				if (has_found_item)
				{
					return;
				}
				DynamicBuffer<CTableSetGrabPoints> dynamicBuffer = _BufferFromEntity_CTableSetGrabPoints_0[table_set];
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					CTableSetGrabPoints cTableSetGrabPoints = dynamicBuffer[i];
					CItemHolder cItemHolder = _ComponentDataFromEntity_CItemHolder_1[cTableSetGrabPoints];
					if (!(cItemHolder.HeldItem == default(Entity)) && _ComponentDataFromEntity_CItem_2.HasComponent(cItemHolder.HeldItem))
					{
						CItem cItem = _ComponentDataFromEntity_CItem_2[cItemHolder.HeldItem];
						if (_ComponentDataFromEntity_CDrink_3.HasComponent(cItemHolder.HeldItem) && !(drink.TimeToNextDrink > 0f))
						{
							CDrink cDrink = _ComponentDataFromEntity_CDrink_3[cItemHolder.HeldItem];
							int num = drink.Drink.Score(cDrink);
							drink.TimeToNextDrink = 120f;
							settings.AddPatience(ref patience, settings.Patience.DrinkDeliverBonus + (float)(10 * num));
							reward.Amount += data.Get<Item>(cItem).Reward;
							ecb.SetComponent(cTableSetGrabPoints, default(CItemHolder));
							ecb.DestroyEntity(cItemHolder.HeldItem);
							has_found_item = true;
						}
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				has_found_item = displayClass.has_found_item;
				data = displayClass.data;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.has_found_item = has_found_item;
				displayClass.data = data;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_reward.For(i), ref runtimes.runtime_patience.For(i), ref runtimes.runtime_drink.For(i), in runtimes.runtime_settings.For(i), in runtimes.runtime_table_set.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupReceiveDrink componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_BufferFromEntity_CTableSetGrabPoints_0 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CTableSetGrabPoints>(false);
				_ComponentDataFromEntity_CItemHolder_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItemHolder>(true);
				_ComponentDataFromEntity_CItem_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItem>(true);
				_ComponentDataFromEntity_CDrink_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CDrink>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			RequireForUpdate(GetEntityQuery(typeof(CWantsDrink)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
			};
			_ = base.EntityManager;
			_ = base.Time;
			displayClass.data = base.Data;
			displayClass.has_found_item = false;
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[5]
			{
				ComponentType.ReadWrite<CGroupReward>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadWrite<CWantsDrink>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CAssignedTable>()
			};
			entityQueryDesc.Any = new ComponentType[1] { ComponentType.ReadWrite<CAtTable>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
