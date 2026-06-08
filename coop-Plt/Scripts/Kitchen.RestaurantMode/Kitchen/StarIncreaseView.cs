#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using JetBrains.Annotations;
using Kitchen.Components;
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
	public class StarIncreaseView : BaseDismissableView<StarIncreaseView.ViewData, StarIncreaseView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_IComponentData<CStarIncreasePopup>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CPopup>.Runtime runtime_dismiss;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					private LambdaParameterValueProvider_IComponentData<CStarIncreasePopup> forParameter_info;

					private LambdaParameterValueProvider_IComponentData<CPopup> forParameter_dismiss;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_dismiss.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_input_users.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_dismiss = forParameter_dismiss.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, ref CStarIncreasePopup info, ref CPopup dismiss, [In] ref CLinkedView linked_view, [In] ref DynamicBuffer<CCapturedUserInput> input_users)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, ref info, ref dismiss, in linked_view, in input_users);
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
						Entity entity = runtimes.runtime_entity.For(i);
						ref CStarIncreasePopup info = ref runtimes.runtime_info.For(i);
						ref CPopup dismiss = ref runtimes.runtime_dismiss.For(i);
						ref CLinkedView linked_view = ref runtimes.runtime_linked_view.For(i);
						DynamicBuffer<CCapturedUserInput> input_users = runtimes.runtime_input_users.For(i);
						OriginalLambdaBody(entity, ref info, ref dismiss, ref linked_view, ref input_users);
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, ref CStarIncreasePopup info, ref CPopup dismiss, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
			{
				List<PlayerInputData> inputs = base.EntityManager.GatherInputs(input_users);
				SendUpdate(linked_view, new ViewData
				{
					Inputs = inputs,
					StarCount = info.StarCount
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true))
				{
					dismiss.Dismiss = result.IsComplete;
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadWrite<CStarIncreasePopup>(),
					ComponentType.ReadWrite<CPopup>(),
					ComponentType.ReadOnly<CCapturedUserInput>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public List<PlayerInputData> Inputs;

			[Key(1)]
			public int StarCount;

			public bool IsChangedFrom(ViewData check)
			{
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData, IDismissableResponse
		{
			[Key(0)]
			public bool IsComplete { get; set; }
		}

		[Header("Configuration")]
		[SerializeField]
		public float PopupGracePeriod = 3f;

		[SerializeField]
		[Header("References")]
		private TextMeshPro OldStars;

		[SerializeField]
		private TextMeshPro NewStar;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private SoundSource Sound;

		[Header("State")]
		private int StarCount;

		[UsedImplicitly]
		private void PlaySparkle()
		{
			if (Sound != null)
			{
				Sound.Play();
			}
		}

		public override void Initialise()
		{
			base.Initialise();
			GracePeriod = PopupGracePeriod;
			Animator.Update(0f);
		}

		private void Start()
		{
			ViewStateCommunicator.Main.AddPopup(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ViewStateCommunicator.Main.RemovePopup(this);
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (view_data.StarCount != StarCount)
			{
				CreationTime = Time.realtimeSinceStartup;
				StarCount = view_data.StarCount;
				StringBuilder stringBuilder = new StringBuilder(7);
				for (int i = 0; i < 5; i++)
				{
					if (i == StarCount - 1)
					{
						stringBuilder.Append("<color=black>");
					}
					stringBuilder.Append('V');
				}
				stringBuilder.Append("</color>");
				OldStars.text = stringBuilder.ToString();
				Vector3 localPosition = NewStar.rectTransform.localPosition;
				localPosition.x = (float)(StarCount - 3) * 1.125f;
				NewStar.rectTransform.localPosition = localPosition;
				Animator.Play("Entry");
			}
			CheckForDismissal(view_data.Inputs);
		}
	}
}
