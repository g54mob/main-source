#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class AssignMenuRequests : GameSystemBase
	{
		private struct Encourager
		{
			public float Probability;

			public int Room;

			public Entity Item;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass12_0
		{
			public EntityCommandBuffer ecb;

			public AssignMenuRequests _003C_003E4__this;

			public NativeArray<CTwitchOrderOption> twitch_order_options;

			public EntityContext ctx;

			public NativeArray<CItem> twitch_order_options_items;

			public NativeArray<Entity> menu_entities;

			public NativeArray<CMenuItem> menu_items;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPatience patience, in CPosition position, in CCustomerSettings settings, in DynamicBuffer<CRequestWaitingForItem> requests, in DynamicBuffer<CGroupMember> members)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_DynamicBuffer<CRequestWaitingForItem>.Runtime runtime_requests;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CRequestWaitingForItem> forParameter_requests;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				public void ScheduleTimeInitialize(AssignMenuRequests componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_requests.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_requests = forParameter_requests.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			public AssignMenuRequests _003C_003E4__this;

			public NativeArray<CTwitchOrderOption> twitch_order_options;

			public EntityContext ctx;

			public NativeArray<CItem> twitch_order_options_items;

			public NativeArray<Entity> menu_entities;

			public NativeArray<CMenuItem> menu_items;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPatience patience, in CPosition position, in CCustomerSettings settings, in DynamicBuffer<CRequestWaitingForItem> requests, in DynamicBuffer<CGroupMember> members)
			{
				float bonus_time = 0f;
				ecb.AddBuffer<CWaitingForItem>(e);
				ecb.AddComponent<CWaitingForItem.Marker>(e);
				int room = _003C_003E4__this.TileManager.GetRoom(position);
				UnityEngine.Random.State state = UnityEngine.Random.state;
				foreach (CRequestWaitingForItem request in requests)
				{
					if (settings.Ordering.GroupOrdersSame)
					{
						UnityEngine.Random.state = state;
					}
					bool flag = false;
					CGroupMember cGroupMember = members[request.MemberIndex];
					if (_003C_003E4__this.Require<CManualOrder>((Entity)cGroupMember, out CManualOrder comp))
					{
						for (int i = 0; i < twitch_order_options.Length; i++)
						{
							if (twitch_order_options[i].Index == comp.Index && _003C_003E4__this.AttemptOrderSpecific(ctx, twitch_order_options_items[i], menu_entities, menu_items, request.Phase, e, ref bonus_time, request.MemberIndex))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						continue;
					}
					for (int j = 0; j < _003C_003E4__this.EncouragerList.Count; j++)
					{
						Encourager encourager = _003C_003E4__this.EncouragerList[j];
						if (!(UnityEngine.Random.value > encourager.Probability) && room == encourager.Room)
						{
							Entity item = encourager.Item;
							if (ctx.Require<CItem>(item, out var comp2) && _003C_003E4__this.AttemptOrderSpecific(ctx, comp2, menu_entities, menu_items, request.Phase, e, ref bonus_time, request.MemberIndex))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						_003C_003E4__this.AddItemToGroupMember(ctx, e, request.MemberIndex, menu_entities, menu_items, request.Phase, ref bonus_time);
					}
				}
				settings.AddPatience(ref patience, bonus_time, allow_over: true);
				ecb.RemoveComponent<CRequestWaitingForItem>(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass12_0 displayClass)
			{
				ecb = displayClass.ecb;
				_003C_003E4__this = displayClass._003C_003E4__this;
				twitch_order_options = displayClass.twitch_order_options;
				ctx = displayClass.ctx;
				twitch_order_options_items = displayClass.twitch_order_options_items;
				menu_entities = displayClass.menu_entities;
				menu_items = displayClass.menu_items;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass12_0 displayClass)
			{
				displayClass.ecb = ecb;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.twitch_order_options = twitch_order_options;
				displayClass.ctx = ctx;
				displayClass.twitch_order_options_items = twitch_order_options_items;
				displayClass.menu_entities = menu_entities;
				displayClass.menu_items = menu_items;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_patience.For(i), in runtimes.runtime_position.For(i), in runtimes.runtime_settings.For(i), runtimes.runtime_requests.For(i), runtimes.runtime_members.For(i));
				}
			}

			public void ScheduleTimeInitialize(AssignMenuRequests componentSystem, ref _003C_003Ec__DisplayClass12_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery MenuItems;

		private EntityQuery Requests;

		private EntityQuery Encouragers;

		private EntityQuery TwitchOrders;

		private EntityQuery Ingredients;

		private EntityQuery Extras;

		private NativeArray<CAvailableIngredient> UnlockList;

		private NativeArray<CPossibleExtra> ExtraList;

		private HashSet<int> TempIngredients = new HashSet<int>();

		private List<Encourager> EncouragerList = new List<Encourager>();

		private List<int> ExtraTemp = new List<int>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Requests = GetEntityQuery(typeof(CRequestWaitingForItem));
			Encouragers = GetEntityQuery(typeof(COrderEncourager), typeof(CPosition), typeof(CItemHolder));
			MenuItems = GetEntityQuery(new QueryHelper().All(typeof(CMenuItem)).None(typeof(CDisabledMenuItem)));
			Ingredients = GetEntityQuery(typeof(CAvailableIngredient));
			Extras = GetEntityQuery(typeof(CPossibleExtra));
			TwitchOrders = GetEntityQuery(typeof(CTwitchOrderOption), typeof(CItem));
			RequireForUpdate(Requests);
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass12_0 displayClass = default(_003C_003Ec__DisplayClass12_0);
			displayClass._003C_003E4__this = this;
			displayClass.ecb = GetCommandBuffer(ECB.End);
			displayClass.ctx = new EntityContext(base.EntityManager, displayClass.ecb);
			displayClass.menu_entities = MenuItems.ToEntityArray(Allocator.TempJob);
			try
			{
				displayClass.menu_items = MenuItems.ToComponentDataArray<CMenuItem>(Allocator.TempJob);
				try
				{
					displayClass.twitch_order_options = TwitchOrders.ToComponentDataArray<CTwitchOrderOption>(Allocator.TempJob);
					try
					{
						displayClass.twitch_order_options_items = TwitchOrders.ToComponentDataArray<CItem>(Allocator.TempJob);
						try
						{
							using NativeArray<COrderEncourager> nativeArray = Encouragers.ToComponentDataArray<COrderEncourager>(Allocator.TempJob);
							using NativeArray<CPosition> nativeArray2 = Encouragers.ToComponentDataArray<CPosition>(Allocator.TempJob);
							using NativeArray<CItemHolder> nativeArray3 = Encouragers.ToComponentDataArray<CItemHolder>(Allocator.TempJob);
							EncouragerList.Clear();
							for (int i = 0; i < nativeArray2.Length; i++)
							{
								EncouragerList.Add(new Encourager
								{
									Probability = nativeArray[i].Probability,
									Room = base.TileManager.GetRoom(nativeArray2[i]),
									Item = nativeArray3[i].HeldItem
								});
							}
							UnlockList = Ingredients.ToComponentDataArray<CAvailableIngredient>(Allocator.TempJob);
							ExtraList = Extras.ToComponentDataArray<CPossibleExtra>(Allocator.TempJob);
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
							UnlockList.Dispose();
							ExtraList.Dispose();
						}
						finally
						{
							((IDisposable)displayClass.twitch_order_options_items/*cast due to .constrained prefix*/).Dispose();
						}
					}
					finally
					{
						((IDisposable)displayClass.twitch_order_options/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)displayClass.menu_items/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.menu_entities/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private bool AttemptOrderSpecific(EntityContext ctx, CItem data, NativeArray<Entity> menu_entities, NativeArray<CMenuItem> menu_items, MenuPhase phase, Entity group, ref float bonus_time, int member_index)
		{
			if (menu_entities.Length == 0)
			{
				return false;
			}
			if (data.IsPartial)
			{
				return false;
			}
			for (int i = 0; i < menu_entities.Length; i++)
			{
				CMenuItem cMenuItem = menu_items[i];
				if (cMenuItem.Phase != phase)
				{
					continue;
				}
				if (cMenuItem.Item != data.ID)
				{
					if (base.Data.TryGet<Item>(cMenuItem.Item, out var output) && data.Satisfies(output))
					{
						OrderItem(output, ctx, new ItemList(output.ID), group, ref bonus_time, member_index, phase, cMenuItem.SourceDish);
						return true;
					}
					continue;
				}
				if (!base.Data.TryGet<Item>(data.ID, out var output2, warn_if_fail: true))
				{
					return false;
				}
				ItemList item_components = default(ItemList);
				foreach (int item in data.Items)
				{
					if (!base.Data.TryGet<Item>(item, out var output3) || !output3.IsMergeableSide)
					{
						item_components.Add(item);
					}
				}
				OrderItem(output2, ctx, item_components, group, ref bonus_time, member_index, phase, cMenuItem.SourceDish);
				if (output2.AlwaysOrderAdditionalItem != 0 && base.Data.TryGet<Item>(output2.AlwaysOrderAdditionalItem, out var output4, warn_if_fail: true))
				{
					OrderItem(output4, ctx, (output4 is ItemGroup) ? base.Data.ItemSetView.GetRandomConfiguration(output2.AlwaysOrderAdditionalItem, TempIngredients) : new ItemList(output2.AlwaysOrderAdditionalItem), group, ref bonus_time, member_index, phase, cMenuItem.SourceDish);
				}
				return true;
			}
			return false;
		}

		public void OrderItem(Item item_data, EntityContext ctx, ItemList item_components, Entity group, ref float bonus_time, int member_index, MenuPhase phase, int source_menu_item)
		{
			int num = 1 + item_data.RepeatOrderMin;
			if (item_data.RepeatOrderMax > item_data.RepeatOrderMin)
			{
				num += UnityEngine.Random.Range(0, 1 + item_data.RepeatOrderMax - item_data.RepeatOrderMin);
			}
			for (int i = 0; i < num; i++)
			{
				int iD = item_data.ID;
				Entity entity = default(Entity);
				entity = ((!(item_data is ItemGroup)) ? ctx.CreateItem(iD) : ctx.CreateItemGroup(item_data.ID, item_components));
				ctx.Set(entity, new CRequestItemOf
				{
					Group = group
				});
				ExtraTemp.Clear();
				if (!item_data.MayRequestExtraItems.IsNullOrEmpty())
				{
					foreach (Item mayRequestExtraItem in item_data.MayRequestExtraItems)
					{
						ExtraTemp.Add(mayRequestExtraItem.ID);
					}
				}
				for (int j = 0; j < ExtraList.Length; j++)
				{
					CPossibleExtra cPossibleExtra = ExtraList[j];
					if (cPossibleExtra.MenuItem == iD)
					{
						ExtraTemp.Add(cPossibleExtra.Ingredient);
					}
				}
				float num2 = 1f - Mathf.Pow(0.5f, ExtraTemp.Count);
				bool flag = UnityEngine.Random.value < num2;
				bonus_time += item_data.ExtraTimeGranted;
				ctx.AppendToBuffer(group, new CWaitingForItem
				{
					ItemID = iD,
					Item = entity,
					Reward = item_data.Reward,
					MemberIndex = member_index,
					IsSide = (phase == MenuPhase.Side),
					DirtItem = ((item_data.DirtiesTo != null) ? item_data.DirtiesTo.ID : 0),
					Extra = ((flag && !ExtraTemp.IsNullOrEmpty()) ? ExtraTemp.Random() : 0),
					SourceMenuItem = source_menu_item,
					Satisfied = item_data.AutoSatisfied
				});
			}
			ctx.Add<CWaitingForItem.Marker>(group);
		}

		public void AddItemToGroupMember(EntityContext ctx, Entity group, int member_index, NativeArray<Entity> menu_entities, NativeArray<CMenuItem> menu_items, MenuPhase phase, ref float bonus_time)
		{
			if (menu_entities.Length == 0)
			{
				return;
			}
			int num = PickRandomMenuItem(menu_items, phase);
			if (num < 0)
			{
				return;
			}
			NativeArray<CAvailableIngredient> unlockList = UnlockList;
			TempIngredients.Clear();
			for (int i = 0; i < unlockList.Length; i++)
			{
				CAvailableIngredient cAvailableIngredient = unlockList[i];
				if (cAvailableIngredient.MenuItem == menu_items[num].Item)
				{
					TempIngredients.Add(cAvailableIngredient.Ingredient);
				}
			}
			int item = menu_items[num].Item;
			if (base.Data.TryGet<Item>(item, out var output, warn_if_fail: true))
			{
				ItemList item_components = ((output is ItemGroup) ? base.Data.ItemSetView.GetRandomConfiguration(item, TempIngredients) : new ItemList(item));
				OrderItem(output, ctx, item_components, group, ref bonus_time, member_index, phase, menu_items[num].SourceDish);
				if (output.AlwaysOrderAdditionalItem != 0 && base.Data.TryGet<Item>(output.AlwaysOrderAdditionalItem, out var output2, warn_if_fail: true))
				{
					OrderItem(output2, ctx, (output2 is ItemGroup) ? base.Data.ItemSetView.GetRandomConfiguration(output.AlwaysOrderAdditionalItem, TempIngredients) : new ItemList(output.AlwaysOrderAdditionalItem), group, ref bonus_time, member_index, phase, menu_items[num].SourceDish);
				}
			}
		}

		public int PickRandomMenuItem(NativeArray<CMenuItem> items, MenuPhase phase)
		{
			float num = 0f;
			foreach (CMenuItem item in items)
			{
				if (item.Phase == phase)
				{
					num += item.Weight;
				}
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].Phase == phase)
				{
					num2 -= items[i].Weight;
					if (num2 <= 0f)
					{
						return i;
					}
				}
			}
			return -1;
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[5]
			{
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CRequestWaitingForItem>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
