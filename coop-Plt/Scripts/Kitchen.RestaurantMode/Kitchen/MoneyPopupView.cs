#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public class MoneyPopupView : UpdatableObjectView<MoneyPopupView.ViewData>
	{
		public class UpdateMoneyPopupView : IncrementalViewSystemBase<ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CMoneyPopup>.Runtime runtime_change;

						public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

						public LambdaParameterValueProvider_IComponentData<CRequiresView>.Runtime runtime_req;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CMoneyPopup> forParameter_change;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CRequiresView> forParameter_req;

					public void ScheduleTimeInitialize(UpdateMoneyPopupView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_change.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_req.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_change = forParameter_change.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_req = forParameter_req.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateMoneyPopupView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref CMoneyPopup change, [In] ref CPosition pos, [In] ref CRequiresView req)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in change, in pos, in req);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_change.For(i), ref runtimes.runtime_pos.For(i), ref runtimes.runtime_req.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateMoneyPopupView componentSystem)
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CMoneyPopup change, in CPosition pos, in CRequiresView req)
			{
				SendUpdate(linked_view, new ViewData
				{
					Amount = change.Change,
					TwitchBits = change.TwitchBits
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CMoneyPopup>(),
					ComponentType.ReadOnly<CPosition>(),
					ComponentType.ReadOnly<CRequiresView>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int Amount;

			[Key(1)]
			public int TwitchBits;

			public bool IsChangedFrom(ViewData check)
			{
				if (Amount == check.Amount)
				{
					return TwitchBits != check.TwitchBits;
				}
				return true;
			}
		}

		[Serializable]
		public struct BitIcon
		{
			public int Min;

			public Texture2D Texture;

			public Color Color;
		}

		[Header("References")]
		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private TextMeshPro Value;

		[SerializeField]
		private GameObject Coins;

		[SerializeField]
		private GameObject Bits;

		[SerializeField]
		private TextMeshPro ValueBits;

		[SerializeField]
		private Renderer Renderer;

		[SerializeField]
		[Header("Configuration")]
		public List<BitIcon> Icons;

		[Header("State")]
		private ViewData Data;

		private static readonly int Image = Shader.PropertyToID("_Image");

		public override void Initialise()
		{
			base.Initialise();
			Animator.Update(0f);
			Animator.enabled = false;
		}

		private void Update()
		{
			if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public override void Remove()
		{
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (view_data.Amount == 0)
			{
				return;
			}
			Animator.enabled = true;
			if (Bits != null)
			{
				Bits.SetActive(view_data.TwitchBits > 0);
				Coins.SetActive(view_data.TwitchBits <= 0);
				if (view_data.TwitchBits > 0)
				{
					Texture2D value = null;
					Color color = default(Color);
					foreach (BitIcon icon in Icons)
					{
						if (icon.Min > view_data.TwitchBits)
						{
							break;
						}
						value = icon.Texture;
						color = icon.Color;
					}
					ValueBits.text = $"{view_data.TwitchBits}";
					ValueBits.color = color;
					RegisterDisposable(Renderer.material).SetTexture(Image, value);
				}
			}
			string arg = ((view_data.Amount >= 0) ? "+" : "-");
			Value.text = $"{arg}{view_data.Amount}";
		}
	}
}
