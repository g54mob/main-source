#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
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
	public class ItemCollectionView : UpdatableObjectView<ItemCollectionView.ViewData>
	{
		public class UpdateView : GameViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass2_0
			{
				public UpdateView _003C_003E4__this;

				public EntityCommandBuffer ecb;

				public bool hide_when_not_close;

				public NativeArray<CPosition> player_positions;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CInterfaceOf relates, in DynamicBuffer<CDisplayedItem> items, in CPosition pos)
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<CInterfaceOf>.Runtime runtime_relates;

						public LambdaParameterValueProvider_DynamicBuffer<CDisplayedItem>.Runtime runtime_items;

						public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CInterfaceOf> forParameter_relates;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CDisplayedItem> forParameter_items;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_relates.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_items.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_relates = forParameter_relates.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_items = forParameter_items.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public EntityCommandBuffer ecb;

				public bool hide_when_not_close;

				public NativeArray<CPosition> player_positions;

				public UpdateView _003C_003E4__this;

				[ReadOnly]
				[NoAlias]
				private ComponentDataFromEntity<CHasItemCollectionIndicator> _ComponentDataFromEntity_CHasItemCollectionIndicator_0;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CInterfaceOf relates, in DynamicBuffer<CDisplayedItem> items, in CPosition pos)
				{
					if (!_ComponentDataFromEntity_CHasItemCollectionIndicator_0.HasComponent(relates))
					{
						ecb.DestroyEntity(entity);
						return;
					}
					bool isHidden = false;
					if (hide_when_not_close)
					{
						bool flag = false;
						foreach (CPosition player_position in player_positions)
						{
							if ((player_position.Position - pos).Chebyshev() < 2f)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							isHidden = true;
						}
					}
					List<ItemData> list = new List<ItemData>();
					for (int i = 0; i < items.Length; i++)
					{
						if (!_003C_003E4__this.Require<CItem>(items[i].Item, out CItem comp))
						{
							return;
						}
						list.Add(new ItemData
						{
							IsComplete = items[i].IsComplete,
							IsSide = items[i].IsSide,
							ItemID = items[i].ItemID,
							SeatPosition = items[i].SeatPosition,
							TablePosition = items[i].TablePosition,
							Components = comp.Items,
							IsSatisfiedBySharer = items[i].IsSatisfiedBySharer
						});
						if (items[i].ShowExtra)
						{
							list.Add(new ItemData
							{
								IsComplete = false,
								ItemID = items[i].ExtraID,
								SeatPosition = items[i].SeatPosition,
								TablePosition = items[i].TablePosition,
								Components = new ItemList(items[i].ExtraID)
							});
						}
					}
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						IsHidden = isHidden,
						Items = list
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					ecb = displayClass.ecb;
					hide_when_not_close = displayClass.hide_when_not_close;
					player_positions = displayClass.player_positions;
					_003C_003E4__this = displayClass._003C_003E4__this;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					displayClass.ecb = ecb;
					displayClass.hide_when_not_close = hide_when_not_close;
					displayClass.player_positions = player_positions;
					displayClass._003C_003E4__this = _003C_003E4__this;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_relates.For(i), runtimes.runtime_items.For(i), in runtimes.runtime_pos.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
					_ComponentDataFromEntity_CHasItemCollectionIndicator_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CHasItemCollectionIndicator>(true);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery Players;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void Initialise()
			{
				base.Initialise();
				RequireSingletonForUpdate<SAssetDirectory>();
				Players = GetEntityQuery(typeof(CPlayer), typeof(CPosition));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
				{
					_003C_003E4__this = this,
					ecb = GetCommandBuffer(ECB.End),
					hide_when_not_close = HasStatus(RestaurantStatus.OrdersOnlyWhenClose),
					player_positions = Players.ToComponentDataArray<CPosition>(Allocator.TempJob)
				};
				try
				{
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
				finally
				{
					((IDisposable)displayClass.player_positions/*cast due to .constrained prefix*/).Dispose();
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
					ComponentType.ReadOnly<CInterfaceOf>(),
					ComponentType.ReadOnly<CDisplayedItem>(),
					ComponentType.ReadOnly<CPosition>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public List<ItemData> Items;

			[Key(1)]
			public bool IsHidden;

			public bool IsChangedFrom(ViewData check)
			{
				if (IsHidden != check.IsHidden)
				{
					return true;
				}
				if (Items.Count != check.Items.Count)
				{
					return true;
				}
				for (int i = 0; i < Items.Count; i++)
				{
					if (Items[i].IsChangedFrom(check.Items[i]))
					{
						return true;
					}
				}
				return false;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ItemData : IViewData.ICheckForChanges<ItemData>
		{
			[Key(0)]
			public bool IsComplete;

			[Key(1)]
			public Vector3 SeatPosition;

			[Key(2)]
			public int ItemID;

			[Key(3)]
			public bool IsSide;

			[Key(4)]
			public ItemList Components;

			[Key(5)]
			public Vector3 TablePosition;

			[Key(6)]
			public bool ShowExtra;

			[Key(7)]
			public int ExtraID;

			[Key(8)]
			public bool IsSatisfiedBySharer;

			public bool IsChangedFrom(ItemData check)
			{
				if (IsComplete != check.IsComplete || (SeatPosition - check.SeatPosition).sqrMagnitude > 0.01f || (TablePosition - check.TablePosition).sqrMagnitude > 0.01f || ItemID != check.ItemID || IsSide != check.IsSide || ShowExtra != check.ShowExtra || ExtraID != check.ExtraID || IsSatisfiedBySharer != check.IsSatisfiedBySharer)
				{
					return true;
				}
				if (Components.Count != check.Components.Count)
				{
					return true;
				}
				for (int i = 0; i < Components.Count; i++)
				{
					if (Components[i] != check.Components[i])
					{
						return true;
					}
				}
				return false;
			}
		}

		public struct DrawnItem
		{
			public GameObject Item;

			public GameObject Object;

			public ItemRequestHolder Holder;

			public int ID;

			public int Count;

			public bool IsComplete;

			public bool IsSatisfiedBySharer;

			public ItemList Components;

			public bool Matches(ItemData data)
			{
				if (ID != data.ItemID)
				{
					return false;
				}
				if (!Components.IsEquivalent(data.Components))
				{
					return false;
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private GameObject Container;

		[SerializeField]
		private GameObject Template;

		[Header("State")]
		private DrawnItem[] DrawnItems;

		private ViewData Data;

		[Header("Configuration")]
		[SerializeField]
		private Vector3 OnTableScale = new Vector3(0.8f, 0.8f, 0.8f);

		[SerializeField]
		private Vector3 WhileOrderingScale = new Vector3(1.1f, 1.1f, 1.1f);

		private static readonly int IsEating = Animator.StringToHash("IsEating");

		private static readonly int IsHidden = Animator.StringToHash("IsHidden");

		public override void Initialise()
		{
			base.Initialise();
			Template.SetActive(value: false);
			DrawnItems = Array.Empty<DrawnItem>();
		}

		protected override void UpdatePosition()
		{
		}

		protected override void UpdateData(ViewData view_data)
		{
			_ = Data;
			Data = view_data;
			if (DrawnItems.Length != Data.Items.Count)
			{
				for (int i = 0; i < DrawnItems.Length; i++)
				{
					GameObject gameObject = DrawnItems[i].Object;
					if (gameObject != null)
					{
						UnityEngine.Object.Destroy(gameObject);
					}
				}
				DrawnItems = new DrawnItem[Data.Items.Count];
			}
			for (int j = 0; j < DrawnItems.Length; j++)
			{
				if (Data.Items[j].ItemID == 0)
				{
					GameObject gameObject2 = DrawnItems[j].Object;
					if (gameObject2 != null)
					{
						UnityEngine.Object.Destroy(gameObject2);
					}
					continue;
				}
				if (!DrawnItems[j].Matches(Data.Items[j]))
				{
					UpdateDrawnItem(j, Data.Items[j]);
				}
				int num = 0;
				int num2 = 0;
				int num3 = -1;
				for (int k = 0; k < DrawnItems.Length; k++)
				{
					if (j == k)
					{
						num2 = num;
					}
					else if (Data.Items[k].IsComplete == Data.Items[j].IsComplete && Data.Items[k].SeatPosition == Data.Items[j].SeatPosition)
					{
						if (j > k)
						{
							num3 = k;
						}
						num++;
					}
				}
				ItemRequestHolder component = DrawnItems[j].Object.GetComponent<ItemRequestHolder>();
				if (!Data.Items[j].IsComplete && num3 >= 0 && Data.Items[j].Components.IsEquivalent(Data.Items[num3].Components))
				{
					ColourBlindMode[] componentsInChildren = component.Container.GetComponentsInChildren<ColourBlindMode>();
					foreach (ColourBlindMode obj in componentsInChildren)
					{
						obj.ShowInColourblindMode = false;
						obj.ShowInNonColourblindMode = false;
					}
				}
				float num4 = 0.4f;
				float num5 = ((float)num2 - 0.5f * (float)num) * 0.3f;
				Vector3 forward = Data.Items[j].SeatPosition - Data.Items[j].TablePosition;
				Vector3 vector = (Data.Items[j].IsComplete ? new Vector3(forward.z, 0f, 0f - forward.x) : new Vector3(1f, 0f, 0f));
				Vector3 vector2 = (Data.Items[j].IsComplete ? (Data.Items[j].SeatPosition * num4 + Data.Items[j].TablePosition * (1f - num4)) : Data.Items[j].SeatPosition);
				vector2.y = (Data.Items[j].IsComplete ? 0.5f : 1.5f);
				DrawnItems[j].Object.transform.position = vector2 + num5 * vector;
				if (Data.Items[j].IsComplete)
				{
					DrawnItems[j].Item.transform.localRotation = Quaternion.LookRotation(forward, Vector3.up);
				}
				if (DrawnItems[j].IsComplete != Data.Items[j].IsComplete)
				{
					DrawnItems[j].IsComplete = Data.Items[j].IsComplete;
					DrawnItems[j].Holder.Effect.enabled = !Data.Items[j].IsComplete;
					DrawnItems[j].Holder.Animator.SetBool(IsEating, Data.Items[j].IsComplete);
					DrawnItems[j].Item.transform.localScale = (DrawnItems[j].IsComplete ? OnTableScale : WhileOrderingScale);
				}
				DrawnItems[j].IsSatisfiedBySharer = Data.Items[j].IsSatisfiedBySharer;
			}
			DrawnItem[] drawnItems = DrawnItems;
			for (int l = 0; l < drawnItems.Length; l++)
			{
				DrawnItem drawnItem = drawnItems[l];
				drawnItem.Object.GetComponent<ItemRequestHolder>().Container.SetActive(!drawnItem.IsSatisfiedBySharer && (!view_data.IsHidden || drawnItem.IsComplete));
			}
		}

		protected void UpdateDrawnItem(int index, ItemData item_info)
		{
			if (DrawnItems[index].Object != null)
			{
				UnityEngine.Object.Destroy(DrawnItems[index].Object);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(Template, Container.transform, worldPositionStays: true);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.SetActive(value: true);
			ItemRequestHolder component = gameObject.GetComponent<ItemRequestHolder>();
			component.SideHighlighter.SetActive(item_info.IsSide);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(GameData.Main.GetPrefab(item_info.ItemID), component.Container.transform, worldPositionStays: true);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localRotation = Quaternion.identity;
			gameObject2.transform.localScale = (item_info.IsComplete ? OnTableScale : WhileOrderingScale);
			gameObject2.GetComponent<IItemSpecificView>()?.PerformUpdate(item_info.ItemID, item_info.Components, !item_info.IsComplete);
			component.Animator.Update(UnityEngine.Random.value);
			DrawnItems[index].Item = gameObject2;
			DrawnItems[index].Holder = component;
			DrawnItems[index].Object = gameObject;
			DrawnItems[index].ID = item_info.ItemID;
			DrawnItems[index].Components = item_info.Components;
		}
	}
}
