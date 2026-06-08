#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class SetDefaultSettingSelector : FranchiseSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public int franchise_setting;

			public NativeArray<CSettingUpgrade> upgrades;

			public Season season;

			public bool has_made_changes_again;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CSettingSelector selector)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_1
		{
			public bool has_made_changes;

			public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

			internal void _003COnUpdate_003Eb__1(Entity e, ref CSettingSelector selector)
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

					public LambdaParameterValueProvider_IComponentData<CSettingSelector>.Runtime runtime_selector;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CSettingSelector> forParameter_selector;

				public void ScheduleTimeInitialize(SetDefaultSettingSelector componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_selector.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_selector = forParameter_selector.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public int franchise_setting;

			public bool has_made_changes;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CSettingSelector selector)
			{
				if (franchise_setting != selector.SettingID)
				{
					selector.SettingID = franchise_setting;
					has_made_changes = true;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_1 displayClass)
			{
				franchise_setting = displayClass.CS_0024_003C_003E8__locals1.franchise_setting;
				has_made_changes = displayClass.has_made_changes;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_1 displayClass)
			{
				displayClass.CS_0024_003C_003E8__locals1.franchise_setting = franchise_setting;
				displayClass.has_made_changes = has_made_changes;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_selector.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetDefaultSettingSelector componentSystem, ref _003C_003Ec__DisplayClass2_1 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CSettingSelector>.Runtime runtime_selector;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CSettingSelector> forParameter_selector;

				public void ScheduleTimeInitialize(SetDefaultSettingSelector componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_selector.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_selector = forParameter_selector.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public NativeArray<CSettingUpgrade> upgrades;

			public Season season;

			public bool has_made_changes_again;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CSettingSelector selector)
			{
				foreach (CSettingUpgrade upgrade in upgrades)
				{
					if (upgrade.SettingID == selector.SettingID)
					{
						return;
					}
				}
				if (season == Season.Normal || !GameData.Main.TryGet<RestaurantSetting>(selector.SettingID, out var output) || output.FixedRunSeason != season)
				{
					selector.SettingID = upgrades.Random().SettingID;
					has_made_changes_again = true;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				upgrades = displayClass.upgrades;
				season = displayClass.season;
				has_made_changes_again = displayClass.has_made_changes_again;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.upgrades = upgrades;
				displayClass.season = season;
				displayClass.has_made_changes_again = has_made_changes_again;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_selector.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetDefaultSettingSelector componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery SettingUpgrades;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			SettingUpgrades = GetEntityQuery(typeof(CSettingUpgrade));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = default(_003C_003Ec__DisplayClass2_0);
			if (SelectSetting.TryGetFranchiseSetting(base.EntityManager, out displayClass.franchise_setting))
			{
				_003C_003Ec__DisplayClass2_1 displayClass2 = new _003C_003Ec__DisplayClass2_1
				{
					CS_0024_003C_003E8__locals1 = displayClass,
					has_made_changes = false
				};
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass2);
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
				jobData.WriteToDisplayClass(ref displayClass2);
				if (displayClass2.has_made_changes)
				{
					Set(default(HandleLayoutRequests.SLayoutRequest));
				}
				return;
			}
			displayClass.has_made_changes_again = false;
			if (SettingUpgrades.IsEmpty)
			{
				return;
			}
			displayClass.season = Seasons.GetSeason();
			displayClass.upgrades = SettingUpgrades.ToComponentDataArray<CSettingUpgrade>(Allocator.Temp);
			try
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst2 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst2);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
				}
				jobData2.WriteToDisplayClass(ref displayClass);
				if (displayClass.has_made_changes_again)
				{
					Set(default(HandleLayoutRequests.SLayoutRequest));
				}
			}
			finally
			{
				((IDisposable)displayClass.upgrades/*cast due to .constrained prefix*/).Dispose();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CSettingSelector>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CSettingSelector>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
