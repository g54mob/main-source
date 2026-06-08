#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MessagePack;
using Platforms;
using Shapes;
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
	public class PlayerColourView : UpdatableObjectView<PlayerColourView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<COwnedByPlayer>.Runtime runtime_player;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<COwnedByPlayer> forParameter_player;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, [In] ref CLinkedView linked_view, [In] ref COwnedByPlayer player)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, in linked_view, in player);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_player.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, in CLinkedView linked_view, in COwnedByPlayer player)
			{
				int playerID = 0;
				if (HasComponent<CPlayer>(player.Player))
				{
					playerID = GetComponent<CPlayer>(player.Player).ID;
				}
				SendUpdate(linked_view, new ViewData
				{
					PlayerID = playerID
				}, MessageType.SpecificViewUpdate);
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
					ComponentType.ReadOnly<CColourByOwner>(),
					ComponentType.ReadOnly<COwnedByPlayer>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int PlayerID;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<PlayerColourView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				return PlayerID != check.PlayerID;
			}
		}

		[Header("Configuration")]
		[SerializeField]
		private bool ShowAlways = true;

		[SerializeField]
		private bool ShowOnInactive;

		[Header("References")]
		[SerializeField]
		private Renderer Renderer;

		[SerializeField]
		private TextMeshPro ProfileLabel;

		[SerializeField]
		private GameObject Container;

		[SerializeField]
		private Rectangle JoinBar;

		[SerializeField]
		private TextMeshPro JoinMessage;

		[SerializeField]
		private SwapOutDefaultButtonPrompt PromptSwapper;

		[SerializeField]
		private Mirror Mirror;

		[Header("State")]
		private int Player;

		private static readonly int Color0 = Shader.PropertyToID("_Color0");

		protected override void UpdateData(ViewData view_data)
		{
			Player = view_data.PlayerID;
			if (PromptSwapper != null)
			{
				PromptSwapper.TargetPlayerIndex = Player;
			}
			if (Mirror != null)
			{
				Mirror.SetActive(active: true);
			}
		}

		public void Update()
		{
			PlayerInfo playerInfo = Players.Main.Get(Player);
			bool flag = Player != 0 && !playerInfo.IsJoining;
			if (!ShowAlways && Container != null)
			{
				Container.SetActive(flag != ShowOnInactive);
			}
			if (Renderer != null)
			{
				RegisterDisposable(Renderer.material).SetColor(Color0, playerInfo.Profile.Colour);
			}
			if (JoinBar != null)
			{
				JoinBar.enabled = playerInfo.JoinProgress > 0f;
				JoinBar.Width = Mathf.Clamp01(playerInfo.JoinProgress);
			}
			if (JoinMessage != null)
			{
				JoinMessage.text = base.Localisation["JOIN_PROMPT"];
			}
			if (ProfileLabel != null)
			{
				ProfileLabel.text = base.Localisation["SELECT_PROFILE_PROMPT"];
				ProfileLabel.gameObject.SetActive(PlatformSettings.UseAdvancedProfilesMode);
			}
		}
	}
}
