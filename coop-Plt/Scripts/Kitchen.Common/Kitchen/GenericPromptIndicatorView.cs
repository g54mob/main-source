#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using TMPro;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class GenericPromptIndicatorView : UpdatableObjectView<GenericPromptIndicatorView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CGenericInputIndicator>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;

						public LambdaParameterValueProvider_IComponentData<CIndicator>.Runtime runtime_indicator;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CGenericInputIndicator> forParameter_info;

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

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CGenericInputIndicator info, [In] ref CLinkedView view, [In] ref CIndicator indicator)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in info, in view, in indicator);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_info.For(i), ref runtimes.runtime_view.For(i), ref runtimes.runtime_indicator.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CGenericInputIndicator info, in CLinkedView view, in CIndicator indicator)
			{
				FixedString64 additionalInfo = "";
				if (info.Message == InputIndicatorMessage.ReloadSave && Require<CLocationChoice>(indicator.Source, out CLocationChoice comp))
				{
					additionalInfo = ((!GameData.Main.IsUserGeneratedContentAllowed) ? comp.RestaurantSafeName : comp.RestaurantName);
				}
				SendUpdate(view.Identifier, new ViewData
				{
					Message = info.Message,
					OpenPromptFor = info.CreateForPlayer,
					AdditionalInfo = additionalInfo
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CGenericInputIndicator>(),
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
			public InputIndicatorMessage Message;

			[Key(1)]
			public int OpenPromptFor;

			[Key(2)]
			public FixedString64 AdditionalInfo;

			public bool IsChangedFrom(ViewData check)
			{
				if (Message == check.Message && OpenPromptFor == check.OpenPromptFor)
				{
					return AdditionalInfo != check.AdditionalInfo;
				}
				return true;
			}
		}

		[SerializeField]
		[Header("References")]
		private Animator Animator;

		[SerializeField]
		private TextMeshPro ActiveText;

		[SerializeField]
		private TextMeshPro AdditionalText;

		[SerializeField]
		private InputPromptElement ActivePrompt;

		protected override void UpdateData(ViewData data)
		{
			if (data.Message != InputIndicatorMessage.None && data.OpenPromptFor != 0)
			{
				TextMeshPro activeText = ActiveText;
				GlobalLocalisation localisation = base.Localisation;
				activeText.text = localisation[data.Message switch
				{
					InputIndicatorMessage.None => "", 
					InputIndicatorMessage.Tutorial => "LABEL_TUTORIAL", 
					InputIndicatorMessage.Reroll => "LABEL_REROLL", 
					InputIndicatorMessage.ExpGrant => "LABEL_EXP_GRANT", 
					InputIndicatorMessage.PracticeMode => "LABEL_PRACTICE", 
					InputIndicatorMessage.RenameRestaurant => "INPUT_TITLE_RENAME_RESTAURANT", 
					InputIndicatorMessage.ReloadSave => "LABEL_RECOVER_SAVE", 
					InputIndicatorMessage.AbandonSave => "MAP_ABANDON", 
					InputIndicatorMessage.HowToActivateAdvancedBuildMode => "TIP_ADVANCED_BUILD", 
					InputIndicatorMessage.HowToActivateAdvancedBuildModeIngame => "TIP_ADVANCED_BUILD_INGAME", 
					_ => "", 
				}];
				AdditionalText.enabled = data.AdditionalInfo != ILSpyHelper_AsRefReadOnly((FixedString32)"");
				AdditionalText.text = data.AdditionalInfo.ToString();
				string action = data.Message switch
				{
					InputIndicatorMessage.HowToActivateAdvancedBuildModeIngame => Controls.Interact4, 
					InputIndicatorMessage.HowToActivateAdvancedBuildMode => Controls.Interact4, 
					_ => Controls.Interact2, 
				};
				if (data.Message == InputIndicatorMessage.HowToActivateAdvancedBuildMode)
				{
					ActivePrompt.Hide();
				}
				else if (Players.Main.Get(data.OpenPromptFor).IsLocalUser)
				{
					ActivePrompt.Show();
					ActivePrompt.SetButtonForUser(action, data.OpenPromptFor);
				}
				else
				{
					ActivePrompt.Hide();
				}
				if (Animator != null)
				{
					Animator.Update(0f);
				}
			}
			static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
			{
				//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
				return ref temp;
			}
		}
	}
}
