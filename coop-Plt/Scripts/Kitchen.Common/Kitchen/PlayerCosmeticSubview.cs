#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class PlayerCosmeticSubview : UpdatableObjectView<PlayerCosmeticSubview.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CPlayerCosmetics>.Runtime runtime_cosmetics;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CPlayerCosmetics> forParameter_cosmetics;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_cosmetics.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_cosmetics = forParameter_cosmetics.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPlayerCosmetics cosmetics, [In] ref CLinkedView linked_view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, ref cosmetics, in linked_view);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_cosmetics.For(i), ref runtimes.runtime_linked_view.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, ref CPlayerCosmetics cosmetics, in CLinkedView linked_view)
			{
				SendUpdate(linked_view, new ViewData
				{
					Cosmetics = cosmetics.Cosmetics
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
					ComponentType.ReadWrite<CPlayerCosmetics>(),
					ComponentType.ReadOnly<CLinkedView>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public DataObjectList Cosmetics;

			public bool IsChangedFrom(ViewData check)
			{
				return !Cosmetics.IsEquivalent(check.Cosmetics);
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<PlayerCosmeticSubview>();
			}
		}

		[Serializable]
		private struct AttachmentPoint
		{
			public CosmeticType Type;

			public Transform Transform;
		}

		[Serializable]
		private struct AttachedCosmetic
		{
			public PlayerCosmetic Cosmetic;

			public GameObject GameObject;
		}

		[SerializeField]
		[Header("References")]
		private List<PlayerCosmetic> Defaults = new List<PlayerCosmetic>();

		[SerializeField]
		public SkinnedMeshRenderer BoneSource;

		[SerializeField]
		private List<AttachmentPoint> AttachmentPoints = new List<AttachmentPoint>();

		[SerializeField]
		private List<AttachedCosmetic> AttachedCosmetics = new List<AttachedCosmetic>();

		[SerializeField]
		private List<Transform> HideHeadBones = new List<Transform>();

		private void Start()
		{
			if (Defaults.Count != 0)
			{
				UpdateData(new ViewData
				{
					Cosmetics = DataObjectList.FromList(Defaults, (PlayerCosmetic c) => c.ID)
				});
			}
		}

		public void SetCosmetic(PlayerCosmetic cosmetic)
		{
			UpdateData(new ViewData
			{
				Cosmetics = new DataObjectList(cosmetic.ID)
			});
		}

		protected override void UpdateData(ViewData view_data)
		{
			CleanAttachments(view_data);
			AddMissingAttachments(view_data);
			SetHatVisibility(view_data);
		}

		private void SetHatVisibility(ViewData view_data)
		{
			bool flag = false;
			float num = 1f;
			bool flag2 = false;
			foreach (int cosmetic in view_data.Cosmetics)
			{
				if (GameData.Main.TryGet<PlayerCosmetic>(cosmetic, out var output))
				{
					if (output.BlockHats)
					{
						flag = true;
					}
					if (Math.Abs(output.HeadSize - 1f) > 0.01f)
					{
						num = output.HeadSize;
					}
					flag2 |= output.HideBody;
				}
			}
			foreach (AttachedCosmetic attachedCosmetic in AttachedCosmetics)
			{
				PlayerOutfitComponent component = attachedCosmetic.GameObject.GetComponent<PlayerOutfitComponent>();
				if ((bool)component && attachedCosmetic.Cosmetic.CosmeticType == CosmeticType.Outfit)
				{
					component.SetHatVisibility(!flag);
				}
			}
			BoneSource.renderingLayerMask = ((!flag2) ? uint.MaxValue : 0u);
			foreach (Transform hideHeadBone in HideHeadBones)
			{
				hideHeadBone.localScale = Vector3.one * num;
			}
		}

		private void CleanAttachments(ViewData view_data)
		{
			for (int num = AttachedCosmetics.Count - 1; num >= 0; num--)
			{
				AttachedCosmetic attachment = AttachedCosmetics[num];
				bool flag = false;
				foreach (int cosmetic in view_data.Cosmetics)
				{
					if (cosmetic == attachment.Cosmetic.ID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					RemoveAttachment(attachment);
					AttachedCosmetics.RemoveAt(num);
				}
			}
		}

		private void AddMissingAttachments(ViewData view_data)
		{
			foreach (int cosmetic in view_data.Cosmetics)
			{
				if (!GameData.Main.TryGet<PlayerCosmetic>(cosmetic, out var output))
				{
					continue;
				}
				bool flag = false;
				foreach (AttachedCosmetic attachedCosmetic in AttachedCosmetics)
				{
					if (!(attachedCosmetic.Cosmetic != output))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					AddAttachment(output);
				}
			}
		}

		private void RemoveAttachment(AttachedCosmetic attachment)
		{
			GameObject gameObject = attachment.GameObject;
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}

		private void AddAttachment(PlayerCosmetic cosmetic)
		{
			foreach (AttachmentPoint attachmentPoint in AttachmentPoints)
			{
				if (cosmetic.CosmeticType == attachmentPoint.Type)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(cosmetic.Visual, attachmentPoint.Transform, worldPositionStays: false);
					PlayerOutfitComponent component = gameObject.GetComponent<PlayerOutfitComponent>();
					if ((bool)component)
					{
						component.SetupBones(BoneSource);
					}
					AttachedCosmetics.Add(new AttachedCosmetic
					{
						Cosmetic = cosmetic,
						GameObject = gameObject
					});
				}
			}
		}
	}
}
