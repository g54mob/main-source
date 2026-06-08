using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(GroupReceiveBonus))]
	[UpdateAfter(typeof(PushItems))]
	[UpdateBefore(typeof(InteractionGroup))]
	[UpdateAfter(typeof(GroupReceiveDrink))]
	[UpdateAfter(typeof(ApplyItemProcesses))]
	public class GrabItems : GameSystemBase
	{
		private EntityQuery Grabbers;

		private List<IntVector3> _UsedTiles = new List<IntVector3>();

		private List<(int, CPosition)> Positions = new List<(int, CPosition)>();

		protected override void Initialise()
		{
			base.Initialise();
			Grabbers = GetEntityQuery(new QueryHelper().All(typeof(CConveyCooldown), typeof(CConveyPushItems), typeof(CItemHolder), typeof(CPosition)).None(typeof(CDisableAutomation)));
			QueryHelper queryHelper = new QueryHelper().All(typeof(CConveyPushItems)).None(typeof(CDisableAutomation));
			RequireForUpdate(GetEntityQuery(queryHelper));
		}

		protected override void OnUpdate()
		{
			using EntityContext ctx = EntityContext.WithTemporaryBuffer(base.EntityManager);
			using NativeArray<Entity> entities = Grabbers.ToEntityArray(Allocator.Temp);
			float num = (HasStatus(RestaurantStatus.HalloweenTrickSlowConveyors) ? 0.5f : 1f);
			float deltaTime = base.Time.DeltaTime;
			_UsedTiles.Clear();
			HashSet<Entity> pushedEntities = base.World.GetExistingSystem<PushItems>().PushedEntities;
			foreach (Entity item in ByPosition(entities))
			{
				if (!Require<CConveyCooldown>(item, out CConveyCooldown comp) || !Require<CConveyPushItems>(item, out CConveyPushItems grab) || !Require<CItemHolder>(item, out CItemHolder comp2) || !Require<CPosition>(item, out CPosition comp3) || !grab.Grab || grab.State == CConveyPushItems.ConveyState.Push || comp.Remaining > 0f)
				{
					continue;
				}
				try
				{
					if (Require<CItem>(comp2.HeldItem, out CItem _))
					{
						if (grab.State != CConveyPushItems.ConveyState.Grab)
						{
							continue;
						}
						if (grab.Progress < grab.Delay)
						{
							grab.Progress += num * deltaTime;
							if (Has<CItemUndergoingProcess>(comp2.HeldItem))
							{
								ctx.Remove<CItemUndergoingProcess>(comp2.HeldItem);
							}
						}
						else
						{
							grab.Progress = 0f;
							grab.State = CConveyPushItems.ConveyState.None;
							comp.Remaining = comp.Total;
							ctx.Set(item, comp);
						}
						continue;
					}
					grab.State = CConveyPushItems.ConveyState.None;
					Vector3 vector = comp3.Forward(-1f) + comp3;
					if (!_UsedTiles.Contains(vector) && base.TileManager.CanReach(comp3, vector))
					{
						Entity occupant = base.TileManager.GetOccupant(vector);
						if (!HasComponent<CPreventItemTransfer>(occupant) && (!Require<CConveyPushItems>(occupant, out CConveyPushItems comp5) || comp5.State == CConveyPushItems.ConveyState.None) && (AttemptGrabHolder(occupant, ctx, item, pushedEntities, ref grab) || AttemptGrabFromProvider(occupant, ctx, item, ref grab)))
						{
							pushedEntities.Add(comp2.HeldItem);
							_UsedTiles.Add(vector);
						}
					}
				}
				finally
				{
					ctx.Set(item, grab);
				}
			}
		}

		private bool AttemptGrabHolder(Entity target, EntityContext ctx, Entity e, HashSet<Entity> blocked_entities, ref CConveyPushItems grab)
		{
			if (!Require<CItemHolder>(target, out CItemHolder comp))
			{
				return false;
			}
			if (comp.HeldItem == default(Entity))
			{
				return false;
			}
			if (!grab.GrabSpecificType && blocked_entities.Contains(comp.HeldItem))
			{
				return false;
			}
			if (Has<CPreventItemTransfer>(target))
			{
				return false;
			}
			if (grab.IgnoreProcessingItems && base.EntityManager.RequireComponent<CItemUndergoingProcess>(comp.HeldItem, out var component) && !component.IsBad)
			{
				return false;
			}
			if (Has<CChangeItemType>(comp))
			{
				return false;
			}
			if (grab.GrabSpecificType && grab.SpecificType != 0 && base.EntityManager.RequireComponent<CItem>(comp.HeldItem, out var component2) && (component2.ID != grab.SpecificType || !component2.Items.IsEquivalent(grab.SpecificComponents)))
			{
				return false;
			}
			ctx.UpdateHolder(comp.HeldItem, e);
			ctx.Remove<CItemUndergoingProcess>(comp.HeldItem);
			grab.Progress = 0f;
			grab.State = CConveyPushItems.ConveyState.Grab;
			return true;
		}

		private bool AttemptGrabFromProvider(Entity target, EntityContext ctx, Entity e, ref CConveyPushItems grab)
		{
			if (!Require<CItemProvider>(target, out CItemProvider comp))
			{
				return false;
			}
			if (comp.DirectInsertionOnly)
			{
				return false;
			}
			if (comp.Available == 0 && comp.Maximum != 0)
			{
				return false;
			}
			if (grab.GrabSpecificType && grab.SpecificType != 0 && (comp.ProvidedItem != grab.SpecificType || !comp.ProvidedComponents.IsEquivalent(grab.SpecificComponents)))
			{
				return false;
			}
			if (comp.Maximum > 0)
			{
				comp.Available--;
				ctx.Set(target, comp);
			}
			Entity held_item = ctx.CreateItemGroup(comp.ProvidedItem, comp.ProvidedComponents);
			ctx.UpdateHolder(held_item, e);
			grab.Progress = 0f;
			grab.State = CConveyPushItems.ConveyState.Grab;
			return true;
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
