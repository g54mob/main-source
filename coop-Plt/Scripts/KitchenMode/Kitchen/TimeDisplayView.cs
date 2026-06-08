#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using KitchenData;
using MessagePack;
using Shapes;
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
	public class TimeDisplayView : UpdatableObjectView<TimeDisplayView.ViewData>
	{
		public class UpdateTimeDisplayView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public BurstContext bctx;

				public STime time;

				public bool is_day;

				public SDay day;

				public bool is_practice;

				public bool morning_rush;

				public bool lunch_rush;

				public bool dinner_rush;

				public bool prep_time;

				public CSetting setting;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CTimeDisplay time_display)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
			[NoAlias]
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
						public LambdaParameterValueProvider_IComponentData_Tag<CTimeDisplay>.Runtime runtime_time_display;
					}

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<CTimeDisplay> forParameter_time_display;

					public void ScheduleTimeInitialize(UpdateTimeDisplayView componentSystem)
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

				public unsafe delegate void RunWithoutJobSystem_00000D15_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000D15_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000D15_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000D15_0024BurstDirectCall()
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

				public STime time;

				public bool is_day;

				public SDay day;

				public bool is_practice;

				public bool morning_rush;

				public bool lunch_rush;

				public bool dinner_rush;

				public bool prep_time;

				public CSetting setting;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CTimeDisplay time_display)
				{
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						TimeOfDay = time.TimeOfDay,
						IsNight = !is_day,
						Day = day.Day,
						IsPractice = is_practice,
						MorningRush = morning_rush,
						LunchRush = lunch_rush,
						DinnerRush = dinner_rush,
						HasPrepTime = prep_time,
						Setting = setting.RestaurantSetting
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					bctx = displayClass.bctx;
					time = displayClass.time;
					is_day = displayClass.is_day;
					day = displayClass.day;
					is_practice = displayClass.is_practice;
					morning_rush = displayClass.morning_rush;
					lunch_rush = displayClass.lunch_rush;
					dinner_rush = displayClass.dinner_rush;
					prep_time = displayClass.prep_time;
					setting = displayClass.setting;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass.bctx = bctx;
					displayClass.time = time;
					displayClass.is_day = is_day;
					displayClass.day = day;
					displayClass.is_practice = is_practice;
					displayClass.morning_rush = morning_rush;
					displayClass.lunch_rush = lunch_rush;
					displayClass.dinner_rush = dinner_rush;
					displayClass.prep_time = prep_time;
					displayClass.setting = setting;
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

				public void ScheduleTimeInitialize(UpdateTimeDisplayView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000D15_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
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
			private EntityQuery _SingletonEntityQuery_STime_18;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SDay_19;

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
					time = _SingletonEntityQuery_STime_18.GetSingleton<STime>(),
					day = _SingletonEntityQuery_SDay_19.GetSingleton<SDay>(),
					is_day = HasSingleton<SIsDayTime>(),
					is_practice = Has<SPracticeMode>()
				};
				SGlobalStatusList orCreate = GetOrCreate<SGlobalStatusList>();
				displayClass.morning_rush = orCreate.Has(RestaurantStatus.MorningRush);
				displayClass.lunch_rush = orCreate.Has(RestaurantStatus.LunchRush);
				displayClass.dinner_rush = orCreate.Has(RestaurantStatus.DinnerRush);
				displayClass.prep_time = orCreate.Has(RestaurantStatus.PreparationTime);
				Require<CSetting>(GetEntity<SLayout>(), out displayClass.setting);
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
				_SingletonEntityQuery_STime_18 = GetEntityQuery(ComponentType.ReadOnly<STime>());
				_SingletonEntityQuery_SDay_19 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CTimeDisplay>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000D15_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000D15_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public float TimeOfDay;

			[Key(1)]
			public bool IsNight;

			[Key(2)]
			public int Day;

			[Key(3)]
			public bool IsPractice;

			[Key(4)]
			public bool MorningRush;

			[Key(5)]
			public bool LunchRush;

			[Key(6)]
			public bool DinnerRush;

			[Key(7)]
			public bool HasPrepTime;

			[Key(8)]
			public int Setting;

			public bool IsChangedFrom(ViewData check)
			{
				if (TimeOfDay == check.TimeOfDay && IsNight == check.IsNight && Day == check.Day && IsPractice == check.IsPractice && MorningRush == check.MorningRush && LunchRush == check.LunchRush && DinnerRush == check.DinnerRush && HasPrepTime == check.HasPrepTime)
				{
					return Setting != check.Setting;
				}
				return true;
			}
		}

		[SerializeField]
		[Header("Configuration")]
		private float LineWidth = 3.9f;

		[SerializeField]
		private float Brightness = 1.1f;

		[SerializeField]
		[Header("References")]
		private GameObject TimeDisplay;

		[SerializeField]
		private GameObject DayDisplay;

		[SerializeField]
		private List<Animator> RushMarkers = new List<Animator>();

		[SerializeField]
		private Rectangle ProgressBar;

		[SerializeField]
		private TextMeshPro Icons;

		[SerializeField]
		private GameObject PrepTimeIcon;

		[SerializeField]
		private TextMeshPro Ticks;

		[SerializeField]
		private Line LineBefore;

		[SerializeField]
		private Line LineAfter;

		[Header("State")]
		private ViewData Data;

		private float BarFullX;

		private float BarFullWidth;

		private static readonly int NightFade = Shader.PropertyToID("_NightFade");

		private static readonly int IsTriggered = Animator.StringToHash("IsTriggered");

		private static readonly int IsGameplay = Shader.PropertyToID("_IsGameplay");

		private int CurrentSetting;

		private void SetBar(float fraction)
		{
			float num = fraction * BarFullWidth;
			Transform obj = ProgressBar.transform;
			Vector3 localPosition = obj.localPosition;
			localPosition.x = BarFullX - (BarFullWidth - num) / 2f;
			obj.localPosition = localPosition;
			ProgressBar.Width = num;
		}

		private void SetTicks(int day)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < day; i++)
			{
				stringBuilder.Append("<sprite name=\"tick_overlay\" tint=1>");
			}
			for (int j = day; j < 15; j++)
			{
				stringBuilder.Append("<sprite name=\"tick_overlay\" tint=1 color=#00000000>");
			}
			Ticks.text = stringBuilder.ToString();
		}

		private void SetLine(int day)
		{
			float x = Mathf.Clamp01(((float)day - 0.5f) / 14f) * (2f * LineWidth) - LineWidth;
			LineBefore.End = new Vector3(x, 0f, 0f);
			LineAfter.Start = new Vector3(x, 0f, 0f);
		}

		private void SetupLine(int setting)
		{
			if (CurrentSetting == setting)
			{
				return;
			}
			CurrentSetting = setting;
			if (GameData.Main.TryGet<RestaurantSetting>(setting, out var output))
			{
				UnlockPack unlockPack = output.UnlockPack;
				if ((object)unlockPack == null)
				{
					unlockPack = GameData.Main.Get<UnlockPack>(AssetReference.DefaultUnlockPack);
				}
				StringBuilder stringBuilder = new StringBuilder();
				HashSet<int> current_cards = new HashSet<int>();
				for (int i = 1; i <= 15; i++)
				{
					UnlockLabel label = unlockPack.GetLabel(current_cards, new UnlockRequest(i, 0));
					string text = ((i != 10) ? (label switch
					{
						UnlockLabel.Standard => "<sprite name=\"star_small\">", 
						UnlockLabel.Franchise => "<sprite name=\"franchise_tier\">", 
						UnlockLabel.Theme => "<sprite name=\"franchise\">", 
						_ => "<sprite name=\"circle\" tint=1>", 
					}) : "<sprite name=\"decoration\">");
					string value = text;
					stringBuilder.Append(value);
				}
				Icons.text = stringBuilder.ToString();
			}
		}

		public override void Initialise()
		{
			base.Initialise();
			BarFullX = ProgressBar.transform.localPosition.x;
			BarFullWidth = ProgressBar.Width;
		}

		protected override void UpdateData(ViewData view_data)
		{
			_ = Data;
			Data = view_data;
			SetupLine(Data.Setting);
			bool flag = !Preferences.Get<bool>(Pref.AccessibilityEnableNightFade);
			if (GameData.Main.TryGet<RestaurantSetting>(view_data.Setting, out var output))
			{
				flag |= output.AlwaysLight;
			}
			if (view_data.IsNight)
			{
				TimeDisplay.SetActive(value: false);
				DayDisplay.SetActive(value: true);
				int num = Mathf.Clamp(view_data.Day, 0, 15);
				SetLine(num);
				SetTicks(num);
				Shader.SetGlobalFloat(NightFade, 0f);
				Shader.SetGlobalFloat(IsGameplay, 0f);
				return;
			}
			Shader.SetGlobalFloat(IsGameplay, 1f);
			TimeDisplay.SetActive(value: true);
			DayDisplay.SetActive(value: false);
			if (view_data.IsPractice)
			{
				SetBar(1f);
				ProgressBar.Color = new Color(0.62f, 1f, 0.34f);
				float value = SmoothStep(0.4f, 0.9f, 0f);
				Shader.SetGlobalFloat(NightFade, flag ? 0f : Mathf.Clamp01(value));
			}
			else
			{
				SetBar(Data.IsNight ? 1f : Data.TimeOfDay);
				ProgressBar.Color = (Data.IsNight ? new Color(0.3372549f, 0.29411766f, 39f / 85f) : (new Color(1f, 0.8901961f, 39f / 85f) * Mathf.Pow(Brightness, 2f)));
				float value2 = SmoothStep(0.4f, 0.9f, view_data.TimeOfDay);
				Shader.SetGlobalFloat(NightFade, flag ? 0f : Mathf.Clamp01(value2));
			}
			SetRushMarkerActive(0, view_data.TimeOfDay, view_data.MorningRush);
			SetRushMarkerActive(1, view_data.TimeOfDay, view_data.LunchRush);
			SetRushMarkerActive(2, view_data.TimeOfDay, view_data.DinnerRush);
			if (PrepTimeIcon != null)
			{
				PrepTimeIcon.SetActive(view_data.HasPrepTime);
			}
		}

		private void SetRushMarkerActive(int rush_index, float current_time, bool has_rush)
		{
			float num = rush_index switch
			{
				0 => 0.2f, 
				1 => 0.5f, 
				2 => 0.8f, 
				_ => -1f, 
			};
			if (!(num < 0f) && RushMarkers.Count >= rush_index)
			{
				RushMarkers[rush_index].gameObject.SetActive(has_rush);
				RushMarkers[rush_index].SetBool(IsTriggered, current_time > num - 0.05f && current_time < num + 0.1f);
			}
		}

		public override void Remove()
		{
			Shader.SetGlobalFloat(NightFade, Mathf.Clamp01(0f));
			base.Remove();
		}

		private float SmoothStep(float a, float b, float t)
		{
			t = Mathf.Clamp01((t - a) / (b - a));
			return t * t * (3f - 2f * t);
		}
	}
}
