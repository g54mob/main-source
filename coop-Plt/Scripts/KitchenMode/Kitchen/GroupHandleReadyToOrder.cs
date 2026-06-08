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
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	public class GroupHandleReadyToOrder : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public GroupHandleReadyToOrder _003C_003E4__this;

			public bool has_instant_order;

			public EntityCommandBuffer ecb;

			public int starter_count;

			public int side_count;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPatience patience, in CGroupMealPhase phase, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
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

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CGroupMealPhase>.Runtime runtime_phase;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CGroupMealPhase> forParameter_phase;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				public void ScheduleTimeInitialize(GroupHandleReadyToOrder componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_phase.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_phase = forParameter_phase.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool has_instant_order;

			public EntityCommandBuffer ecb;

			public int starter_count;

			public int side_count;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupPromptedForOrder> _ComponentDataFromEntity_CGroupPromptedForOrder_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPatience patience, in CGroupMealPhase phase, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
			{
				if (!_ComponentDataFromEntity_CGroupPromptedForOrder_0.HasComponent(e) && !has_instant_order)
				{
					return;
				}
				DynamicBuffer<CRequestWaitingForItem> dynamicBuffer = ecb.AddBuffer<CRequestWaitingForItem>(e);
				float num = 1f - Mathf.Pow(1f - GameData.Main.Difficulty.CustomerStarterChance * settings.Ordering.StarterModifier, starter_count);
				float num2 = 1f - Mathf.Pow(1f - GameData.Main.Difficulty.CustomerSideChance * settings.Ordering.SidesModifier, side_count);
				bool flag = Random.value < num2;
				for (int i = 0; i < group.Length; i++)
				{
					if (i <= 0 || (MenuPhase)phase != MenuPhase.Starter || Random.value < num || settings.Ordering.GroupOrdersSame)
					{
						dynamicBuffer.Add(new CRequestWaitingForItem
						{
							MemberIndex = i,
							Phase = phase
						});
						bool flag2 = Random.value < num2;
						if (settings.Ordering.GroupOrdersSame)
						{
							flag2 = flag;
						}
						if ((MenuPhase)phase == MenuPhase.Main && flag2)
						{
							dynamicBuffer.Add(new CRequestWaitingForItem
							{
								MemberIndex = i,
								Phase = MenuPhase.Side
							});
						}
					}
				}
				patience = settings.NewPhase(PatienceReason.WaitForFood);
				ecb.RemoveComponent<CGroupReadyToOrder>(e);
				ecb.RemoveComponent<CGroupPromptedForOrder>(e);
				ecb.AddComponent<CGroupAwaitingOrder>(e);
				ecb.AddComponent<CGroupStateChanged>(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				has_instant_order = displayClass.has_instant_order;
				ecb = displayClass.ecb;
				starter_count = displayClass.starter_count;
				side_count = displayClass.side_count;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass.has_instant_order = has_instant_order;
				displayClass.ecb = ecb;
				displayClass.starter_count = starter_count;
				displayClass.side_count = side_count;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_patience.For(i), in runtimes.runtime_phase.For(i), in runtimes.runtime_settings.For(i), runtimes.runtime_group.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupHandleReadyToOrder componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CGroupPromptedForOrder_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupPromptedForOrder>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Sides;

		private EntityQuery Starters;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Sides = GetEntityQuery(typeof(CMenuItemSide));
			Starters = GetEntityQuery(typeof(CMenuItemStarter));
			RequireForUpdate(GetEntityQuery(typeof(CGroupReadyToOrder)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.StateChanges)
			};
			GameData data = base.Data;
			displayClass.side_count = Sides.CalculateEntityCount();
			displayClass.starter_count = Starters.CalculateEntityCount();
			displayClass.has_instant_order = HasStatus(RestaurantStatus.CustomersOrderImmediately);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[5]
			{
				ComponentType.ReadOnly<CGroupReadyToOrder>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadOnly<CGroupMealPhase>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
