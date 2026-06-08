#define ENABLE_PROFILER
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
using Platforms;
using TMPro;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class DayDisplayView : UpdatableObjectView<DayDisplayView.ViewData>
	{
		[Obsolete]
		public struct CLiveSplitTime : IComponentData
		{
			public long ElapsedMS;

			public bool IsRunning;
		}

		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public BurstContext bctx;

				public SDay day;

				public bool is_practice;

				public bool is_night;

				public int tier;

				public SFixedSeed fixed_seed;

				public bool show_seed;

				public int setting;

				public bool show_run_timer;

				public bool is_speedrun;

				public SpeedrunScore speedrun_score;

				public long livesplit_time;

				public bool send_seed_affects_everything;

				public bool is_speedrun_mode;

				public bool livesplit_running;

				public bool always_show_run_timer;

				public bool livesplit_mode;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CDayDisplay time_display)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[NoAlias]
			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						[NoAlias]
						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData_Tag<CDayDisplay>.Runtime runtime_time_display;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData_Tag<CDayDisplay> forParameter_time_display;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_time_display.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_time_display = forParameter_time_display.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000C89_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000C89_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000C89_0024PostfixBurstDelegate).TypeHandle);
						}
						P_0 = Pointer;
					}

					private static IntPtr GetFunctionPointer()
					{
						IntPtr result = (IntPtr)0;
						GetFunctionPointerDiscard(ref result);
						return result;
					}

					public static void Constructor()
					{
						DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
					}

					public static void Initialize()
					{
					}

					static RunWithoutJobSystem_00000C89_0024BurstDirectCall()
					{
						Constructor();
					}

					public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
					{
						if (BurstCompiler.IsEnabled)
						{
							IntPtr functionPointer = GetFunctionPointer();
							if (functionPointer != (IntPtr)0)
							{
								((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
								return;
							}
						}
						RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
					}
				}

				public BurstContext bctx;

				public SDay day;

				public bool is_practice;

				public bool is_night;

				public int tier;

				public SFixedSeed fixed_seed;

				public bool show_seed;

				public int setting;

				public bool show_run_timer;

				public bool is_speedrun;

				public SpeedrunScore speedrun_score;

				public long livesplit_time;

				public bool send_seed_affects_everything;

				public bool is_speedrun_mode;

				public bool livesplit_running;

				public bool always_show_run_timer;

				public bool livesplit_mode;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CDayDisplay time_display)
				{
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						Day = day.Day,
						IsPractice = is_practice,
						IsNight = is_night,
						Tier = tier,
						Seed = fixed_seed.Seed,
						ShowSeed = show_seed,
						CurrentSetting = setting,
						HasRunTimer = show_run_timer,
						IsSpeedrun = is_speedrun,
						SpeedrunScore = speedrun_score,
						LivesplitScore = livesplit_time,
						SeedAffectsEverything = send_seed_affects_everything,
						IsSpeedrunMode = is_speedrun_mode,
						LivesplitIsRunning = livesplit_running,
						AlwaysShowRunTimerEnabled = always_show_run_timer,
						LiveSplitOptionEnabled = livesplit_mode
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					bctx = displayClass.bctx;
					day = displayClass.day;
					is_practice = displayClass.is_practice;
					is_night = displayClass.is_night;
					tier = displayClass.tier;
					fixed_seed = displayClass.fixed_seed;
					show_seed = displayClass.show_seed;
					setting = displayClass.setting;
					show_run_timer = displayClass.show_run_timer;
					is_speedrun = displayClass.is_speedrun;
					speedrun_score = displayClass.speedrun_score;
					livesplit_time = displayClass.livesplit_time;
					send_seed_affects_everything = displayClass.send_seed_affects_everything;
					is_speedrun_mode = displayClass.is_speedrun_mode;
					livesplit_running = displayClass.livesplit_running;
					always_show_run_timer = displayClass.always_show_run_timer;
					livesplit_mode = displayClass.livesplit_mode;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass.bctx = bctx;
					displayClass.day = day;
					displayClass.is_practice = is_practice;
					displayClass.is_night = is_night;
					displayClass.tier = tier;
					displayClass.fixed_seed = fixed_seed;
					displayClass.show_seed = show_seed;
					displayClass.setting = setting;
					displayClass.show_run_timer = show_run_timer;
					displayClass.is_speedrun = is_speedrun;
					displayClass.speedrun_score = speedrun_score;
					displayClass.livesplit_time = livesplit_time;
					displayClass.send_seed_affects_everything = send_seed_affects_everything;
					displayClass.is_speedrun_mode = is_speedrun_mode;
					displayClass.livesplit_running = livesplit_running;
					displayClass.always_show_run_timer = always_show_run_timer;
					displayClass.livesplit_mode = livesplit_mode;
				}

				public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
				{
					LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
					_runtimes = &runtimes;
					IterateEntities(ref chunk, ref *_runtimes);
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
				{
					int count = chunk.Count;
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), runtimes.runtime_time_display.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000C89_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SDay_16;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SLayout_17;

			protected override void Initialise()
			{
				base.Initialise();
				RequireSingletonForUpdate<SKitchenStatus>();
			}

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
				{
					bctx = bctx,
					day = _SingletonEntityQuery_SDay_16.GetSingleton<SDay>(),
					is_practice = Has<SPracticeMode>(),
					is_night = Has<SIsNightTime>(),
					tier = 0
				};
				Entity singletonEntity = _SingletonEntityQuery_SLayout_17.GetSingletonEntity();
				if (HasComponent<CFranchiseTier>(singletonEntity))
				{
					displayClass.tier = GetComponent<CFranchiseTier>(singletonEntity).Tier;
				}
				displayClass.setting = (Require<CSetting>(singletonEntity, out CSetting comp) ? comp.RestaurantSetting : 0);
				displayClass.show_seed = Has<CShowSeed>(singletonEntity);
				Require<SFixedSeed>(out displayClass.fixed_seed);
				displayClass.show_run_timer = Require<SSpeedrunDuration>(out var comp2);
				displayClass.speedrun_score = (displayClass.show_run_timer ? SpeedrunScore.FromSeconds(Mathf.Round(comp2.Seconds)) : default(SpeedrunScore));
				SLiveSplitStartTime comp3;
				bool flag = Require<SLiveSplitStartTime>(out comp3);
				displayClass.livesplit_time = ((!flag || comp3.StartTime <= 0) ? (-10000) : ((comp3.FinishTime > 0) ? (comp3.FinishTime - comp3.StartTime) : (DateTime.UtcNow.Ticks - comp3.StartTime)));
				displayClass.livesplit_running = comp3.FinishTime <= 0;
				displayClass.send_seed_affects_everything = Preferences.TryGet<bool>(Pref.SeedsAffectEverything, out var value) && value;
				Preferences.TryGet<bool>(Pref.SpeedrunMode, out displayClass.is_speedrun_mode);
				Preferences.TryGet<bool>(Pref.AlwaysShowRunTimer, out displayClass.always_show_run_timer);
				Preferences.TryGet<bool>(Pref.LiveSplitEnabled, out displayClass.livesplit_mode);
				displayClass.is_speedrun = Has<CSpeedrun>();
				_ = base.Entities;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
				}
				finally
				{
					_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
				}
				jobData.WriteToDisplayClass(ref displayClass);
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
				_SingletonEntityQuery_SDay_16 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
				_SingletonEntityQuery_SLayout_17 = GetEntityQuery(ComponentType.ReadOnly<SLayout>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CDayDisplay>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000C89_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000C89_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int Day;

			[Key(1)]
			public bool IsPractice;

			[Key(2)]
			public bool IsNight;

			[Key(3)]
			public int Tier;

			[Key(4)]
			public Seed Seed;

			[Key(5)]
			public int CurrentSetting;

			[Key(6)]
			public bool HasRunTimer;

			[Key(7)]
			public bool IsSpeedrun;

			[Key(8)]
			public SpeedrunScore SpeedrunScore;

			[Key(9)]
			public bool ShowSeed;

			[Key(10)]
			public bool SeedAffectsEverything;

			[Key(11)]
			public bool IsSpeedrunMode;

			[Key(12)]
			public long LivesplitScore;

			[Key(13)]
			public bool LivesplitIsRunning;

			[Key(14)]
			public int Heat;

			[Key(15)]
			public bool AlwaysShowRunTimerEnabled;

			[Key(16)]
			public bool LiveSplitOptionEnabled;

			public bool IsChangedFrom(ViewData check)
			{
				if (Day == check.Day && IsPractice == check.IsPractice && IsNight == check.IsNight && Tier == check.Tier && Heat == check.Heat && Seed.IntValue == check.Seed.IntValue && CurrentSetting == check.CurrentSetting && HasRunTimer == check.HasRunTimer && IsSpeedrun == check.IsSpeedrun && SpeedrunScore.Equals(check.SpeedrunScore) && ShowSeed == check.ShowSeed && SeedAffectsEverything == check.SeedAffectsEverything && IsSpeedrunMode == check.IsSpeedrunMode && !((float)Math.Abs(LivesplitScore - check.LivesplitScore) > 5000f) && LivesplitIsRunning == check.LivesplitIsRunning && AlwaysShowRunTimerEnabled == check.AlwaysShowRunTimerEnabled)
				{
					return LiveSplitOptionEnabled != check.LiveSplitOptionEnabled;
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro Day;

		[SerializeField]
		private TextMeshPro Preparation;

		[SerializeField]
		private TextMeshPro Tier;

		[SerializeField]
		private TextMeshPro Seed;

		[SerializeField]
		private GameObject SeedLoading;

		[SerializeField]
		private TextMeshPro RunTimer;

		[SerializeField]
		[Header("State")]
		private Seed CurrentSeed;

		[SerializeField]
		private bool SeedIsDisplayed;

		[SerializeField]
		private bool CurrentSeedAffectsEverything;

		[SerializeField]
		private bool CurrentIsSpeedrunMode;

		[SerializeField]
		private Stopwatch Stopwatch = new Stopwatch();

		[SerializeField]
		private long StopwatchOffset;

		[SerializeField]
		private bool ShowTimer;

		[SerializeField]
		private ViewData Data;

		private void Update()
		{
			RunTimer.gameObject.SetActive(ShowTimer);
			if (!ShowTimer)
			{
				return;
			}
			if (Data.AlwaysShowRunTimerEnabled)
			{
				long num = Stopwatch.ElapsedMilliseconds + StopwatchOffset;
				if (num < 0)
				{
					num = 0L;
				}
				TimeSpan timeSpan = TimeSpan.FromMilliseconds(num);
				RunTimer.text = $"<mspace=0.8em>{Data.SpeedrunScore.ToMonospacedString()}\n<size=60%><mspace=0.8em><sprite name=\"moon\"> <size=80%><mspace=0.8em>{Math.Floor(timeSpan.TotalHours):00}</mspace>:<mspace=0.8em>{timeSpan.Minutes:00}</mspace>:<mspace=0.8em>{timeSpan.Seconds:00}</mspace>.<mspace=0.8em>{timeSpan.Milliseconds:000}</mspace>";
			}
			else
			{
				RunTimer.text = Data.SpeedrunScore.ToMonospacedString() ?? "";
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			Data = view_data;
			if (view_data.LivesplitIsRunning && view_data.LivesplitScore > 0)
			{
				Stopwatch.Start();
			}
			else
			{
				Stopwatch.Stop();
			}
			StopwatchOffset = view_data.LivesplitScore / 10000 - Stopwatch.ElapsedMilliseconds;
			ShowTimer = view_data.HasRunTimer && (view_data.IsSpeedrun || view_data.AlwaysShowRunTimerEnabled || view_data.IsSpeedrunMode);
			if ((GameInfo.CurrentSetting == null || GameInfo.CurrentSetting.ID != view_data.CurrentSetting) && GameData.Main.TryGet<RestaurantSetting>(view_data.CurrentSetting, out var output))
			{
				GameInfo.CurrentSetting = output;
			}
			GameInfo.CurrentDay = view_data.Day;
			GameInfo.IsPreparationTime = view_data.IsNight;
			if (view_data.IsPractice)
			{
				Day.text = GameData.Main.GlobalLocalisation["PRACTICE"];
				Preparation.text = "";
			}
			else
			{
				int num = (view_data.IsNight ? (view_data.Day + 1) : view_data.Day);
				string arg = ((num > 15) ? GameData.Main.GlobalLocalisation["OVERTIME"] : GameData.Main.GlobalLocalisation["DAY"]);
				if (num > 15)
				{
					num -= 15;
				}
				Day.text = $"{arg} {num}";
				Preparation.text = (view_data.IsNight ? GameData.Main.GlobalLocalisation["PREPARATION"] : "");
			}
			if (view_data.Tier > 0)
			{
				Tier.text = string.Format("{0} {1}", GameData.Main.GlobalLocalisation["TIER"], view_data.Tier);
			}
			else
			{
				Tier.text = "";
			}
			bool flag = (Session.NetworkedPlayState != NetworkedPlayState.Client || PlatformSettings.AllowUGC) && view_data.ShowSeed;
			if (Seed != null && (view_data.Seed != CurrentSeed || flag != SeedIsDisplayed || view_data.SeedAffectsEverything != CurrentSeedAffectsEverything || view_data.IsSpeedrunMode != CurrentIsSpeedrunMode))
			{
				CurrentSeed = view_data.Seed;
				SeedIsDisplayed = flag;
				CurrentSeedAffectsEverything = view_data.SeedAffectsEverything;
				CurrentIsSpeedrunMode = view_data.IsSpeedrunMode;
				bool flag2 = flag && view_data.Seed.IsSet;
				Seed.gameObject.SetActive(flag2 || view_data.SeedAffectsEverything);
				SeedLoading.SetActive(value: false);
				Seed.text = (flag2 ? (GameData.Main.Parse("$seed$") + view_data.Seed.StrValue) : "");
				if (!view_data.SeedAffectsEverything)
				{
					Seed.text += " <size=80%><sprite name=\"map\"></size>";
				}
			}
		}
	}
}
