#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	public class GroupHandleChoosingOrder : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public EntityCommandBuffer ecb;

			public float dt;

			public NativeArray<CMenuItem> starter_items;

			public NativeArray<CMenuItem> main_items;

			public NativeArray<CMenuItem> dessert_items;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPatience patience, ref CGroupMealPhase phase, ref CGroupChoosingOrder choosing, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
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

					public LambdaParameterValueProvider_IComponentData<CGroupChoosingOrder>.Runtime runtime_choosing;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				private LambdaParameterValueProvider_IComponentData<CGroupMealPhase> forParameter_phase;

				private LambdaParameterValueProvider_IComponentData<CGroupChoosingOrder> forParameter_choosing;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				public void ScheduleTimeInitialize(GroupHandleChoosingOrder componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_phase.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_choosing.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
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
						runtime_choosing = forParameter_choosing.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			public float dt;

			public NativeArray<CMenuItem> starter_items;

			public NativeArray<CMenuItem> main_items;

			public NativeArray<CMenuItem> dessert_items;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPatience patience, ref CGroupMealPhase phase, ref CGroupChoosingOrder choosing, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
			{
				if (choosing.HasSelectedCourse)
				{
					if (choosing.RemainingTime <= 0f)
					{
						patience = settings.NewPhase(PatienceReason.Service);
						ecb.RemoveComponent<CGroupChoosingOrder>(e);
						ecb.AddComponent<CGroupReadyToOrder>(e);
						ecb.AddComponent<CGroupStateChanged>(e);
					}
					else
					{
						choosing.RemainingTime -= dt;
					}
					return;
				}
				NativeArray<CMenuItem> nativeArray = phase.Phase switch
				{
					MenuPhase.Starter => starter_items, 
					MenuPhase.Main => main_items, 
					MenuPhase.Dessert => dessert_items, 
					_ => default(NativeArray<CMenuItem>), 
				};
				float num = Mathf.Clamp01(GameData.Main.Difficulty.GroupDessertChance * settings.Ordering.DessertModifier);
				float f = 1f - num;
				bool flag = (MenuPhase)phase == MenuPhase.Dessert && (main_items.Length > 0 || starter_items.Length > 0) && Random.value < Mathf.Pow(f, dessert_items.Length);
				if (nativeArray == default(NativeArray<CMenuItem>) || nativeArray.Length == 0 || flag)
				{
					phase.Phase = phase.Phase.Next();
					if ((MenuPhase)phase == MenuPhase.Complete)
					{
						ecb.RemoveComponent<CGroupChoosingOrder>(e);
						ecb.AddComponent<CGroupStartLeaving>(e);
						ecb.AddComponent<CGroupStateChanged>(e);
					}
				}
				else
				{
					choosing.HasSelectedCourse = true;
					choosing.RemainingTime = settings.Patience.Thinking;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				ecb = displayClass.ecb;
				dt = displayClass.dt;
				starter_items = displayClass.starter_items;
				main_items = displayClass.main_items;
				dessert_items = displayClass.dessert_items;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass.ecb = ecb;
				displayClass.dt = dt;
				displayClass.starter_items = starter_items;
				displayClass.main_items = main_items;
				displayClass.dessert_items = dessert_items;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_patience.For(i), ref runtimes.runtime_phase.For(i), ref runtimes.runtime_choosing.For(i), in runtimes.runtime_settings.For(i), runtimes.runtime_group.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupHandleChoosingOrder componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private Dictionary<MenuPhase, EntityQuery> MenuItems;

		private EntityQuery RequiresOrder;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			RequiresOrder = GetEntityQuery(typeof(CGroupChoosingOrder));
			RequireForUpdate(RequiresOrder);
			MenuItems = new Dictionary<MenuPhase, EntityQuery>();
			MenuItems.Add(MenuPhase.Starter, GetEntityQuery(typeof(CMenuItem), typeof(CMenuItemStarter)));
			MenuItems.Add(MenuPhase.Main, GetEntityQuery(typeof(CMenuItem), typeof(CMenuItemMain)));
			MenuItems.Add(MenuPhase.Dessert, GetEntityQuery(typeof(CMenuItem), typeof(CMenuItemDessert)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				ecb = GetCommandBuffer(ECB.StateChanges)
			};
			new EntityContext(base.EntityManager, displayClass.ecb);
			GameData data = base.Data;
			displayClass.dt = base.Time.DeltaTime;
			displayClass.starter_items = MenuItems[MenuPhase.Starter].ToComponentDataArray<CMenuItem>(Allocator.TempJob);
			displayClass.main_items = MenuItems[MenuPhase.Main].ToComponentDataArray<CMenuItem>(Allocator.TempJob);
			displayClass.dessert_items = MenuItems[MenuPhase.Dessert].ToComponentDataArray<CMenuItem>(Allocator.TempJob);
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
			displayClass.main_items.Dispose();
			displayClass.starter_items.Dispose();
			displayClass.dessert_items.Dispose();
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
				ComponentType.ReadWrite<CGroupChoosingOrder>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadWrite<CGroupMealPhase>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
