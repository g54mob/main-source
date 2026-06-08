using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateBefore(typeof(InteractionGroup))]
	[UpdateAfter(typeof(ApplyItemProcesses))]
	public class PushItems : GameSystemBase
	{
		private EntityQuery Pushers;

		private List<IntVector3> _UsedTiles = new List<IntVector3>();

		public HashSet<Entity> PushedEntities = new HashSet<Entity>();

		private List<(int, CPosition)> Positions = new List<(int, CPosition)>();

		protected override void Initialise()
		{
			base.Initialise();
			Pushers = GetEntityQuery(new QueryHelper().All(typeof(CConveyCooldown), typeof(CConveyPushItems), typeof(CItemHolder), typeof(CPosition)).None(typeof(CDisableAutomation)));
			QueryHelper queryHelper = new QueryHelper().All(typeof(CConveyPushItems)).None(typeof(CDisableAutomation));
			RequireForUpdate(GetEntityQuery(queryHelper));
		}

		protected override void OnUpdate()
		{
			using EntityContext ctx = EntityContext.WithTemporaryBuffer(base.EntityManager);
			float deltaTime = base.Time.DeltaTime;
			float num = (HasStatus(RestaurantStatus.HalloweenTrickSlowConveyors) ? 0.5f : 1f);
			_UsedTiles.Clear();
			PushedEntities.Clear();
			using NativeArray<Entity> entities = Pushers.ToEntityArray(Allocator.Temp);
			foreach (Entity item in ByPosition(entities))
			{
				if (!Require<CConveyCooldown>(item, out CConveyCooldown comp) || !Require<CConveyPushItems>(item, out CConveyPushItems comp2) || !Require<CItemHolder>(item, out CItemHolder comp3) || (comp3.HeldItem != default(Entity) && PushedEntities.Contains(comp3.HeldItem)) || !Require<CPosition>(item, out CPosition comp4) || !comp2.Push || comp2.State == CConveyPushItems.ConveyState.Grab)
				{
					continue;
				}
				try
				{
					if (comp.Remaining > 0f || !HasComponent<CItem>(comp3.HeldItem))
					{
						comp2.State = CConveyPushItems.ConveyState.None;
						comp2.Progress = 0f;
						continue;
					}
					bool flag = false;
					bool flag2 = false;
					Orientation o = Orientation.Up;
					if (Require<CConveyPushRotatable>(item, out CConveyPushRotatable comp5) && comp5.Target != Orientation.Null)
					{
						o = comp5.Target;
					}
					Vector3 vector = comp4.Rotation.RotateOrientation(o).ToOffset() * ((!comp2.Reversed) ? 1 : (-1));
					Vector3 vector2 = vector + comp4;
					Entity occupant = base.TileManager.GetOccupant(vector2);
					if (_UsedTiles.Contains(vector + comp4))
					{
						continue;
					}
					Entity heldItem = comp3.HeldItem;
					if (comp2.IgnoreProcessingItems && base.EntityManager.RequireComponent<CItemUndergoingProcess>(comp3.HeldItem, out var component) && !component.IsBad)
					{
						flag2 = false;
						goto IL_070f;
					}
					if (!base.TileManager.CanReach(comp4, vector + comp4) || HasComponent<CPreventItemTransfer>(occupant))
					{
						goto IL_070f;
					}
					if (!flag && ctx.Require<CItemProvider>(occupant, out var comp6) && comp6.AllowRefreshes && comp6.Available == 0 && ctx.Has<CRefreshesProviderQuantity>(comp3.HeldItem) && (!ctx.Require<CRefreshesSpecificProvider>(comp3.HeldItem, out var comp7) || comp7.Item == comp6.ProvidedItem))
					{
						flag = true;
						if (comp2.Progress < comp2.Delay)
						{
							comp2.Progress += num * deltaTime;
							flag2 = true;
						}
						else
						{
							_UsedTiles.Add(vector2);
							comp2.Progress = 0f;
							comp6.Available = comp6.Maximum;
							ctx.Set(occupant, comp6);
							ctx.Destroy(comp3.HeldItem);
							comp3.HeldItem = default(Entity);
							comp.Remaining = comp.Total;
							comp2.State = CConveyPushItems.ConveyState.None;
						}
					}
					if (!flag && ctx.Require<CItemHolder>(occupant, out var comp8))
					{
						CItem component2 = GetComponent<CItem>(comp3.HeldItem);
						bool flag3 = false;
						if (HasComponent<CItemHolderFilter>(occupant))
						{
							CItemHolderFilter component3 = GetComponent<CItemHolderFilter>(occupant);
							flag3 = !component3.NoDirectInsertion && component3.AllowCategory(component2.Category);
						}
						else
						{
							flag3 = component2.Category == ItemCategory.Generic;
						}
						if (Require<CItemHolderOnlySpecificItem>(occupant, out CItemHolderOnlySpecificItem comp9))
						{
							flag3 &= component2.ID == comp9.ItemID;
						}
						if (comp8.HeldItem == default(Entity) && !HasComponent<CPreventItemTransfer>(occupant) && flag3)
						{
							flag = true;
							if (comp2.Progress < comp2.Delay)
							{
								comp2.Progress += num * deltaTime;
								flag2 = true;
							}
							else
							{
								_UsedTiles.Add(vector2);
								comp2.Progress = 0f;
								ctx.UpdateHolder(comp3.HeldItem, occupant);
								comp.Remaining = comp.Total;
								comp2.State = CConveyPushItems.ConveyState.None;
								comp3.HeldItem = default(Entity);
							}
						}
					}
					if (flag || !HasComponent<CItemProvider>(occupant))
					{
						goto IL_060e;
					}
					CItem component4 = GetComponent<CItem>(comp3.HeldItem);
					if (!base.Data.TryGet<Item>(component4, out var output, warn_if_fail: true))
					{
						continue;
					}
					CItemProvider component5 = GetComponent<CItemProvider>(occupant);
					bool flag4 = HasComponent<CDynamicItemProvider>(occupant);
					bool num2 = !component5.PreventReturns;
					bool flag5 = (component5.ProvidedItem == component4.ID && component5.ProvidedComponents.IsEquivalent(component4.Items)) || (flag4 && component5.Available == 0);
					bool flag6 = component5.Maximum <= 0 || component5.Available != component5.Maximum;
					if (num2 && flag5 && flag6)
					{
						bool flag7 = true;
						if (component5.Available == 0 && flag4)
						{
							ItemStorage itemStorageFlags = output.ItemStorageFlags;
							ItemStorage storageFlags = GetComponent<CDynamicItemProvider>(occupant).StorageFlags;
							if (!itemStorageFlags.HasFlag(storageFlags))
							{
								flag7 = false;
							}
						}
						if (flag7)
						{
							flag = true;
							if (comp2.Progress < comp2.Delay)
							{
								comp2.Progress += num * deltaTime;
								flag2 = true;
							}
							else
							{
								_UsedTiles.Add(vector2);
								comp2.Progress = 0f;
								component5.Available++;
								component5.ProvidedItem = component4.ID;
								component5.ProvidedComponents = component4.Items;
								ctx.Set(occupant, component5);
								ctx.Destroy(comp3.HeldItem);
								comp3.HeldItem = default(Entity);
								comp.Remaining = comp.Total;
								comp2.State = CConveyPushItems.ConveyState.None;
							}
						}
					}
					goto IL_060e;
					IL_070f:
					if (flag)
					{
						PushedEntities.Add(heldItem);
					}
					if (flag2)
					{
						comp2.State = CConveyPushItems.ConveyState.Push;
						if (HasComponent<CItemUndergoingProcess>(heldItem))
						{
							ctx.Remove<CItemUndergoingProcess>(heldItem);
						}
					}
					else
					{
						comp2.State = CConveyPushItems.ConveyState.None;
						comp2.Progress = 0f;
					}
					goto end_IL_00f6;
					IL_060e:
					if (flag || !HasComponent<CApplianceBin>(occupant))
					{
						goto IL_070f;
					}
					CApplianceBin component6 = GetComponent<CApplianceBin>(occupant);
					if (component6.CurrentAmount >= component6.Capacity)
					{
						goto IL_070f;
					}
					if (!GameData.Main.TryGet<Item>(GetComponent<CItem>(comp3.HeldItem), out var output2, warn_if_fail: true))
					{
						continue;
					}
					if (!output2.IsIndisposable && output2.DisposesTo == null)
					{
						flag = true;
						if (comp2.Progress < comp2.Delay)
						{
							comp2.Progress += num * deltaTime;
							flag2 = true;
						}
						else
						{
							_UsedTiles.Add(vector2);
							comp2.Progress = 0f;
							ctx.Destroy(comp3.HeldItem);
							comp3.HeldItem = default(Entity);
							component6.CurrentAmount++;
							ctx.Set(occupant, component6);
							comp.Remaining = comp.Total;
							comp2.State = CConveyPushItems.ConveyState.None;
						}
					}
					goto IL_070f;
					end_IL_00f6:;
				}
				finally
				{
					ctx.Set(item, comp);
					ctx.Set(item, comp2);
					ctx.Set(item, comp3);
				}
			}
		}

		private IEnumerable<Entity> ByPosition(NativeArray<Entity> entities)
		{
			Positions.Clear();
			for (int i = 0; i < entities.Length; i++)
			{
				if (Require<CPosition>(entities[i], out CPosition comp))
				{
					Positions.Add((i, comp));
				}
			}
			Positions.Sort(delegate((int, CPosition) a, (int, CPosition) b)
			{
				int num = b.Item2.Position.x.CompareTo(a.Item2.Position.x);
				if (num != 0)
				{
					return num;
				}
				num = b.Item2.Position.y.CompareTo(a.Item2.Position.y);
				return (num != 0) ? num : b.Item2.Position.z.CompareTo(a.Item2.Position.z);
			});
			foreach (var position in Positions)
			{
				yield return entities[position.Item1];
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
