#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Components;
using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.VFX;

namespace Kitchen
{
	[Serializable]
	public class WeatherView : UpdatableObjectView<WeatherView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<SWeatherPrecipitation>.Runtime runtime_type;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<SWeatherPrecipitation> forParameter_type;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_type.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_type = forParameter_type.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref SWeatherPrecipitation type)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in type);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_type.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					hostInstance = componentSystem;
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void OnUpdate()
			{
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

			[CompilerGenerated]
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in SWeatherPrecipitation type)
			{
				SendUpdate(linked_view.Identifier, new ViewData
				{
					Weather = type.Mode,
					IsWeatherActive = type.IsActive
				});
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<SWeatherPrecipitation>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public WeatherMode Weather;

			[Key(1)]
			public bool IsWeatherActive;

			public bool IsChangedFrom(ViewData check)
			{
				if (Weather == check.Weather)
				{
					return IsWeatherActive != check.IsWeatherActive;
				}
				return true;
			}
		}

		[Serializable]
		public struct WeatherLookup
		{
			public WeatherMode Mode;

			public VisualEffect Effect;

			public SoundSource Sound;
		}

		[SerializeField]
		[Header("References")]
		private List<WeatherLookup> WeatherLookups = new List<WeatherLookup>();

		[Header("State")]
		private VisualEffect ActiveEffect;

		private bool HasLayoutTexture;

		private static readonly int RoomLayout = Shader.PropertyToID("_RoomLayout");

		private static readonly int NightFade = Shader.PropertyToID("_NightFade");

		protected override void UpdateData(ViewData data)
		{
			ActiveEffect = null;
			Texture globalTexture = Shader.GetGlobalTexture(RoomLayout);
			HasLayoutTexture = globalTexture != null;
			foreach (WeatherLookup weatherLookup in WeatherLookups)
			{
				bool flag = weatherLookup.Mode == data.Weather;
				if (weatherLookup.Effect != null)
				{
					weatherLookup.Effect.gameObject.SetActive(flag && HasLayoutTexture);
				}
				if (weatherLookup.Sound != null)
				{
					weatherLookup.Sound.gameObject.SetActive(flag);
				}
				if (!flag || !HasLayoutTexture)
				{
					continue;
				}
				if (weatherLookup.Sound != null)
				{
					weatherLookup.Sound.TargetVolume = (data.IsWeatherActive ? 1 : 0);
				}
				if (weatherLookup.Effect != null)
				{
					ActiveEffect = weatherLookup.Effect;
					weatherLookup.Effect.SetBool("Active", data.IsWeatherActive);
					try
					{
						weatherLookup.Effect.SetTexture("_RoomLayout", globalTexture);
					}
					catch (ArgumentNullException)
					{
						Debug.LogError("Failed to set layout texture");
					}
				}
			}
		}

		private void Update()
		{
			if (!ActiveEffect)
			{
				return;
			}
			float globalFloat = Shader.GetGlobalFloat(NightFade);
			try
			{
				bool flag = Preferences.Get<bool>(Pref.AccessibilityWeatherVisible);
				ActiveEffect.gameObject.SetActive(HasLayoutTexture && flag);
				if (ActiveEffect.HasFloat(NightFade))
				{
					ActiveEffect.SetFloat(NightFade, globalFloat);
				}
			}
			catch (ArgumentNullException)
			{
			}
		}
	}
}
