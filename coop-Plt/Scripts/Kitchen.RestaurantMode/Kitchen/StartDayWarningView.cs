#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using JetBrains.Annotations;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kitchen
{
	[Serializable]
	public class StartDayWarningView : BaseDismissableView<StartDayWarningView.ViewData, StartDayWarningView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass3_0
			{
				public UpdateView _003C_003E4__this;

				public bool is_paused;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, ref CPlayersReadyToStart ready, in CLinkedView linked_view, in SStartDayWarnings warning, in DynamicBuffer<CCapturedUserInput> input_users)
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

						public LambdaParameterValueProvider_IComponentData<CPlayersReadyToStart>.Runtime runtime_ready;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<SStartDayWarnings>.Runtime runtime_warning;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CPlayersReadyToStart> forParameter_ready;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<SStartDayWarnings> forParameter_warning;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_ready.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_warning.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_input_users.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_ready = forParameter_ready.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_warning = forParameter_warning.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public bool is_paused;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPlayersReadyToStart ready, in CLinkedView linked_view, in SStartDayWarnings warning, in DynamicBuffer<CCapturedUserInput> input_users)
				{
					List<PlayerInputData> inputs = _003C_003E4__this.EntityManager.GatherInputs(input_users);
					(StartDayWarning, WarningLevel) primary = warning.Primary;
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						Warning = primary.Item1,
						WarningLevel = primary.Item2,
						Inputs = inputs,
						Paused = is_paused,
						IsNight = _003C_003E4__this.HasSingleton<SIsNightTime>(),
						ClearReadyState = _003C_003E4__this.ClearPlayerReady
					});
					ResponseData result = default(ResponseData);
					if (_003C_003E4__this.ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
					{
						result = data;
					}, only_final_update: true))
					{
						ready.Ready = result.IsComplete;
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					is_paused = displayClass.is_paused;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.is_paused = is_paused;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_ready.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_warning.For(i), runtimes.runtime_input_users.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery HoldingSomething;

			private HashSet<int> ClearPlayerReady = new HashSet<int>();

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void Initialise()
			{
				base.Initialise();
				HoldingSomething = GetEntityQuery(typeof(CHeldAppliance), typeof(CHeldBy));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
				{
					_003C_003E4__this = this,
					is_paused = base.Time.IsPaused
				};
				ClearPlayerReady.Clear();
				using NativeArray<CHeldBy> nativeArray = HoldingSomething.ToComponentDataArray<CHeldBy>(Allocator.Temp);
				foreach (CHeldBy item in nativeArray)
				{
					if (Require<CPlayer>(item.Holder, out CPlayer comp))
					{
						ClearPlayerReady.Add(comp.ID);
					}
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
					ComponentType.ReadWrite<CPlayersReadyToStart>(),
					ComponentType.ReadOnly<SStartDayWarnings>(),
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
			public StartDayWarning Warning;

			[Key(1)]
			public WarningLevel WarningLevel;

			[Key(2)]
			public List<PlayerInputData> Inputs;

			[Key(3)]
			public HashSet<int> ClearReadyState;

			[Key(4)]
			public bool Paused;

			[Key(5)]
			public bool IsNight;

			public bool IsChangedFrom(ViewData check)
			{
				if (Paused != check.Paused || Warning != check.Warning || WarningLevel != check.WarningLevel || IsNight != check.IsNight)
				{
					return true;
				}
				if (!ClearReadyState.SetEquals(check.ClearReadyState))
				{
					return true;
				}
				if (Inputs.Count != check.Inputs.Count)
				{
					return true;
				}
				int num = 0;
				foreach (PlayerInputData input2 in Inputs)
				{
					foreach (PlayerInputData input3 in check.Inputs)
					{
						if (input3.PlayerID == input2.PlayerID)
						{
							CInputData input = input3.Input;
							if (input.IsChangedFrom(input2.Input))
							{
								return true;
							}
							num++;
						}
					}
				}
				if (num != Inputs.Count)
				{
					return true;
				}
				return false;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData, IDismissableResponse
		{
			[Key(0)]
			public bool IsComplete { get; set; }
		}

		[Serializable]
		private struct WarningPairs
		{
			public WarningLevel Level;

			public Color Colour;
		}

		[SerializeField]
		[Header("Configuration")]
		private List<WarningPairs> WarningColours = new List<WarningPairs>();

		[SerializeField]
		[Header("References")]
		private Animator Animator;

		[SerializeField]
		private InputPromptElement PromptElement;

		[FormerlySerializedAs("ConsentModule")]
		[SerializeField]
		private ConsentElement ConsentElement;

		[SerializeField]
		private AutoLocal NameLocalisation;

		[SerializeField]
		private AutoLocal DescriptionLocalisation;

		[Header("State")]
		private ViewData Data;

		private bool IsUpdated;

		private bool ReportedState;

		private static readonly int Transition = Animator.StringToHash("Transition");

		private static readonly int Ready = Animator.StringToHash("Ready");

		private static readonly int Hide = Animator.StringToHash("Hide");

		public override bool IsComplete
		{
			get
			{
				if (Data.Inputs != null)
				{
					if (Data.Inputs.Count > 0)
					{
						return ConsentElement.IsCompleted;
					}
					return false;
				}
				return false;
			}
		}

		[UsedImplicitly]
		private void SetNextWarning()
		{
			Animator.SetBool(Transition, value: false);
			Animator.SetBool(Hide, value: false);
			SetWarningColour(Data.WarningLevel);
			GenericLocalisationStruct value;
			if (Data.Warning == StartDayWarning.Ready || Data.Warning == StartDayWarning.PlayersNotReady)
			{
				Animator.SetBool(Ready, value: true);
			}
			else if (base.Localisation.StartDayWarningLocalisation.Text.TryGetValue(Data.Warning, out value))
			{
				Animator.SetBool(Ready, value: false);
				SetLocalisation(value);
			}
			else
			{
				Animator.SetBool(Hide, value: true);
			}
		}

		private void SetWarningColour(WarningLevel level)
		{
			foreach (WarningPairs warningColour in WarningColours)
			{
				if (level == warningColour.Level)
				{
					NameLocalisation.SetColour(warningColour.Colour);
				}
			}
		}

		private void SetLocalisation(GenericLocalisationStruct text)
		{
			NameLocalisation.Set(text);
			DescriptionLocalisation.Set(text);
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (Data.Warning != view_data.Warning)
			{
				Animator.SetBool(Transition, value: true);
			}
			ConsentElement.SetPlayers(view_data.Inputs);
			Data = view_data;
			base.gameObject.SetActive(view_data.IsNight);
			bool flag = false;
			if ((view_data.Warning != StartDayWarning.PlayersNotReady && view_data.Warning != StartDayWarning.Ready) || !IsUpdated)
			{
				ConsentElement.ClearConsents();
				flag = true;
				IsUpdated = true;
			}
			if (!view_data.Paused && !flag)
			{
				for (int i = 0; i < view_data.Inputs.Count; i++)
				{
					PlayerInputData playerInputData = view_data.Inputs[i];
					if (playerInputData.Input.State.SecondaryAction1 == ButtonState.Pressed)
					{
						ConsentElement.SetConsent(playerInputData.PlayerID, !ConsentElement.GetConsent(playerInputData.PlayerID));
					}
					else if (playerInputData.Input.State.IsUnconsenting || playerInputData.Input.IsCaptured || playerInputData.Input.State.Request == GameStateRequest.InLocalMenu)
					{
						ConsentElement.SetConsent(playerInputData.PlayerID, value: false);
					}
				}
			}
			foreach (int item in view_data.ClearReadyState)
			{
				ConsentElement.SetConsent(item, value: false);
			}
			PromptElement.SetButtonForAll(Controls.Interact3);
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (IsComplete || IsComplete != ReportedState)
			{
				ReportedState = IsComplete;
				state = new ResponseData
				{
					IsComplete = IsComplete
				};
				return true;
			}
			return false;
		}
	}
}
