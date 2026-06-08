#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using Platforms;
using TMPro;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class SeededRunIndicatorView : ResponsiveObjectView<SeededRunIndicatorView.ViewData, SeededRunIndicatorView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public UpdateView _003C_003E4__this;

				public Seed seed;

				public bool is_forced;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in ManageSeededRunInfoIndicators.CSeedInfoBubble info, in CLinkedView view, in CIndicator indicator)
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
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						public LambdaParameterValueProvider_IComponentData<ManageSeededRunInfoIndicators.CSeedInfoBubble>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;

						public LambdaParameterValueProvider_IComponentData<CIndicator>.Runtime runtime_indicator;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<ManageSeededRunInfoIndicators.CSeedInfoBubble> forParameter_info;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CIndicator> forParameter_indicator;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public Seed seed;

				public bool is_forced;

				[NoAlias]
				private ComponentDataFromEntity<CSeededRunInfo> _ComponentDataFromEntity_CSeededRunInfo_0;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in ManageSeededRunInfoIndicators.CSeedInfoBubble info, in CLinkedView view, in CIndicator indicator)
				{
					int openPromptFor = 0;
					if (!_003C_003E4__this.Require<CSeededRunInfo>(indicator.Source, out CSeededRunInfo comp))
					{
						return;
					}
					if (_003C_003E4__this.RequireBuffer(indicator.Source, out DynamicBuffer<CBeingActedOnBy> comp2) && comp2.Length > 0)
					{
						foreach (CBeingActedOnBy item in comp2)
						{
							if (_003C_003E4__this.Require<CInputData>(item.Interactor, out CInputData comp3) && comp3.State.InteractAction == ButtonState.Pressed && _003C_003E4__this.Require<CPlayer>(item.Interactor, out CPlayer comp4))
							{
								if (!comp.IsSeedOverride)
								{
									openPromptFor = comp4.ID;
									break;
								}
								comp.IsSeedOverride = false;
								comp.FixedSeed = default(Seed);
								_ComponentDataFromEntity_CSeededRunInfo_0[indicator.Source] = comp;
								break;
							}
						}
					}
					_003C_003E4__this.SendUpdate(view.Identifier, new ViewData
					{
						FixedSeed = (seed.IsSet ? seed : info.Seed),
						IsForcedSeed = is_forced,
						OpenPromptFor = openPromptFor
					});
					ResponseData result = default(ResponseData);
					if (_003C_003E4__this.ApplyUpdates(view.Identifier, delegate(ResponseData data)
					{
						result = data;
					}, only_final_update: true) && !string.IsNullOrEmpty(result.RequestSeed))
					{
						comp.FixedSeed = new Seed(result.RequestSeed);
						comp.IsSeedOverride = true;
						_003C_003E4__this.EntityManager.SetComponentData(indicator.Source, comp);
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					seed = displayClass.seed;
					is_forced = displayClass.is_forced;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.seed = seed;
					displayClass.is_forced = is_forced;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_info.For(i), in runtimes.runtime_view.For(i), in runtimes.runtime_indicator.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
					_ComponentDataFromEntity_CSeededRunInfo_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CSeededRunInfo>(false);
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
				RequireForUpdate(GetEntityQuery(typeof(ManageSeededRunInfoIndicators.CSeedInfoBubble)));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
				{
					_003C_003E4__this = this
				};
				if (RequireEntity<SLayoutPedestal>(out var comp))
				{
					displayClass.seed = default(Seed);
					displayClass.is_forced = false;
					if (GetComponentOfHeld<CSetting>(comp, out var result))
					{
						displayClass.seed = result.FixedSeed;
						displayClass.is_forced = HasComponentOfHeld<CShowSeed>(comp) && result.FixedSeed.IsSet;
					}
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
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<ManageSeededRunInfoIndicators.CSeedInfoBubble>(),
					ComponentType.ReadOnly<CIndicator>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public Seed FixedSeed;

			[Key(1)]
			public bool IsForcedSeed;

			[Key(2)]
			public int OpenPromptFor;

			public bool IsChangedFrom(ViewData check)
			{
				if (FixedSeed.IntValue == check.FixedSeed.IntValue && IsForcedSeed == check.IsForcedSeed)
				{
					return OpenPromptFor != check.OpenPromptFor;
				}
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData
		{
			[Key(0)]
			public string RequestSeed;
		}

		[Header("References")]
		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private GameObject SeedActive;

		[SerializeField]
		private GameObject SeedActiveSeedTextDisplay;

		[SerializeField]
		private GameObject SeedInactive;

		[SerializeField]
		private GameObject SeedForced;

		[SerializeField]
		private TextMeshPro ActiveText;

		[SerializeField]
		private TextMeshPro ActiveSeed;

		[SerializeField]
		private InputPromptElement ActivePrompt;

		[SerializeField]
		private GameObject LoadingSymbol;

		[SerializeField]
		private TextMeshPro InactiveText;

		[SerializeField]
		private InputPromptElement InactivePrompt;

		[SerializeField]
		private TextMeshPro ForcedText;

		[SerializeField]
		private TextMeshPro ForcedSeed;

		private string RequestSeed;

		protected override void UpdateData(ViewData data)
		{
			if (Session.NetworkedPlayState == NetworkedPlayState.Client && !PlatformSettings.AllowUGC)
			{
				SeedInactive.SetActive(value: false);
				SeedActive.SetActive(value: false);
				SeedForced.SetActive(value: false);
				return;
			}
			SeedInactive.SetActive(!data.FixedSeed.IsSet);
			SeedActive.SetActive(data.FixedSeed.IsSet && !data.IsForcedSeed);
			SeedForced.SetActive(data.FixedSeed.IsSet && data.IsForcedSeed);
			SeedActiveSeedTextDisplay.SetActive(value: true);
			if (data.OpenPromptFor != 0 && Players.Main.Get(data.OpenPromptFor).IsLocalUser)
			{
				TextInputView.RequestSeedInput(GameData.Main.GlobalLocalisation["SET_SEED_TITLE"], "", delegate(TextInputView.TextInputState state, string s)
				{
					if (state == TextInputView.TextInputState.TextEntryComplete)
					{
						RequestSeed = s;
					}
					else
					{
						RequestSeed = null;
					}
				});
			}
			if (data.FixedSeed.IsSet)
			{
				if (data.IsForcedSeed)
				{
					ForcedText.text = base.Localisation["SEED_FORCED_BY_MAP"];
					ForcedSeed.text = data.FixedSeed.StrValue;
				}
				else
				{
					ActiveText.text = base.Localisation["FIXED_SEED_SET"];
					ActivePrompt.SetButtonForAll(Controls.Interact2);
					ActiveSeed.text = data.FixedSeed.StrValue;
					LoadingSymbol.SetActive(value: false);
				}
			}
			else
			{
				InactiveText.text = base.Localisation["SET_SEED"];
				InactivePrompt.SetButtonForAll(Controls.Interact2);
			}
			if (Animator != null)
			{
				Animator.Update(0f);
			}
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (RequestSeed == null)
			{
				return false;
			}
			state = new ResponseData
			{
				RequestSeed = RequestSeed
			};
			RequestSeed = null;
			return true;
		}
	}
}
