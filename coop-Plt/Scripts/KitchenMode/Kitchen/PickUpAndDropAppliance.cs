using System.Collections.Generic;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PickUpAndDropAppliance : ApplianceInteractionSystem
	{
		protected Bounds CachedBounds;

		protected bool MadeChanges;

		protected CPosition Position;

		protected CItemHolder Holder;

		protected List<Vector3> ReservedTiles = new List<Vector3>();

		protected override InteractionType RequiredType => InteractionType.Grab;

		protected override bool UseImmediateContext => true;

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			if (!Has<SLayout>())
			{
				return false;
			}
			CachedBounds = base.Bounds;
			Vector3 frontDoor = GetFrontDoor();
			ReservedTiles.Clear();
			GetReservedTiles(ReservedTiles);
			CachedBounds.Encapsulate(frontDoor + new Vector3(0f, 0f, -2f));
			CachedBounds.Expand(0.5f);
			MadeChanges = false;
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			if (MadeChanges)
			{
				base.EntityManager.CreateEntity(typeof(CRequireStartDayWarningRecalculation));
				if (!HasSingleton<SPerformTableUpdate>())
				{
					base.EntityManager.CreateEntity(typeof(SPerformTableUpdate));
				}
			}
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPosition>(data.Interactor, out Position))
			{
				return false;
			}
			if (!Require<CItemHolder>(data.Interactor, out Holder))
			{
				return false;
			}
			return Perform(ref data, should_act: false);
		}

		protected override void Perform(ref InteractionData data)
		{
			Perform(ref data, data.ShouldAct);
		}

		protected virtual bool Perform(ref InteractionData data, bool should_act)
		{
			CAttemptingInteraction interact = data.Attempt;
			bool flag = false;
			if (Holder.HeldItem != default(Entity))
			{
				bool flag2 = PerformDrop(data.Context, data.Interactor, ref interact, Holder, Position, data.ShouldAct && should_act);
				flag = flag || flag2;
				if (flag2 && should_act)
				{
					CSoundEvent.Create(base.EntityManager, SoundEvent.PlayerItemDrop);
				}
			}
			else
			{
				bool flag3 = PerformPickUp(data.Context, data.Interactor, ref interact, in Position, data.ShouldAct && should_act, OccupancyLayer.Default);
				flag = flag || flag3;
				if (flag3 && should_act)
				{
					CSoundEvent.Create(base.EntityManager, SoundEvent.PlayerItemPickUp);
				}
			}
			if (should_act)
			{
				MadeChanges |= flag;
			}
			return flag;
		}

		protected bool IsHeldItemFloorOccupier(Entity item)
		{
			if (!Require<CAppliance>(item, out CAppliance comp))
			{
				return false;
			}
			return comp.Layer == OccupancyLayer.Floor;
		}

		protected bool PerformDrop(EntityContext ctx, Entity player, ref CAttemptingInteraction interact, CItemHolder player_holder, CPosition pos, bool should_act)
		{
			EntityManager entityManager = base.EntityManager;
			bool result = false;
			if (!base.TileManager.CanReach(pos, interact.Location))
			{
				return false;
			}
			if (GetFrontDoor().IsSameTile(interact.Location))
			{
				return false;
			}
			if (GetFrontDoor(get_external_tile: true).IsSameTile(interact.Location))
			{
				return false;
			}
			if (!CachedBounds.Contains(interact.Location))
			{
				return false;
			}
			CLayoutRoomTile tile = base.TileManager.GetTile(interact.Location);
			Vector3 vector = interact.Location.Rounded();
			foreach (Vector3 reservedTile in ReservedTiles)
			{
				if (reservedTile.IsSameTile(vector))
				{
					return false;
				}
			}
			Quaternion quaternion2 = Quaternion.identity;
			Entity heldItem = player_holder.HeldItem;
			if (!entityManager.RequireComponent<CAppliance>(heldItem, out var component))
			{
				return false;
			}
			OccupancyLayer layer = component.Layer;
			bool flag = false;
			Orientation[] preferredRotations = OrientationHelpers.PreferredRotations;
			foreach (Orientation o in preferredRotations)
			{
				Vector3 vector2 = o.ToOffset();
				if (base.TileManager.GetRoom(vector + vector2) != tile.RoomID)
				{
					flag = !tile.CanReach(o);
					if (!Has<CApplianceBlueprint>(heldItem))
					{
						quaternion2 = o.ToRotation();
					}
					break;
				}
			}
			bool flag2 = tile.RoomID == 0;
			if (flag2 && HasComponent<CUnsellableAppliance>(heldItem))
			{
				return false;
			}
			if (!flag2 && HasComponent<CMustHaveWall>(heldItem) && !flag)
			{
				return result;
			}
			bool flag3 = false;
			Entity occupant = base.TileManager.GetOccupant(vector, layer);
			if (occupant != default(Entity) && !HasComponent<CAllowPlacingOver>(occupant))
			{
				if (!PerformPickUp(ctx, player, ref interact, in pos, should_act: false, layer))
				{
					return false;
				}
				flag3 = true;
			}
			if (layer == OccupancyLayer.Floor && !flag3)
			{
				occupant = base.TileManager.GetOccupant(vector);
				if (occupant != default(Entity) && !HasComponent<CAllowPlacingOver>(occupant) && !PerformPickUp(ctx, player, ref interact, in pos, should_act: false, OccupancyLayer.Default))
				{
					return false;
				}
				flag3 = true;
			}
			result = true;
			if (should_act)
			{
				CPosition data = CPosition.Rounded(vector);
				data.Rotation = quaternion2;
				ctx.Remove<CHeldAppliance>(heldItem);
				ctx.Remove<CHeldBy>(heldItem);
				ctx.Add<CRemoveView>(heldItem);
				ctx.Set(heldItem, new CRequiresView
				{
					Type = ViewType.Appliance
				});
				ctx.Set(heldItem, data);
				if (flag3)
				{
					PerformPickUp(ctx, player, ref interact, in pos, should_act: true, layer);
				}
				else
				{
					ctx.Set(player, default(CItemHolder));
				}
				base.TileManager.SetOccupant(vector, heldItem);
			}
			return result;
		}

		protected bool PerformPickUp(EntityContext ctx, Entity player, ref CAttemptingInteraction interact, in CPosition pos, bool should_act, OccupancyLayer layer)
		{
			EntityManager entityManager = base.EntityManager;
			bool result = false;
			Entity entity = default(Entity);
			if (!base.TileManager.CanReach(pos, interact.Location))
			{
				return result;
			}
			entity = ((layer != OccupancyLayer.Default) ? base.TileManager.GetOccupant(interact.Location, layer) : base.TileManager.GetPrimaryOccupant(interact.Location));
			if (entity == default(Entity))
			{
				entity = interact.Target;
				if (!Require<CPosition>(entity, out CPosition comp) || !comp.Position.IsSameTile(interact.Location))
				{
					return false;
				}
			}
			if (entityManager.RequireComponent<CAppliance>(entity, out var component))
			{
				if (HasComponent<CHeldAppliance>(entity))
				{
					return result;
				}
				if (HasComponent<CImmovable>(entity))
				{
					return result;
				}
				if (should_act)
				{
					ctx.Add<CHeldAppliance>(entity);
					ctx.Add<CHeldBy>(entity);
					ctx.Add<CRemoveView>(entity);
					ctx.Set(entity, new CRequiresView
					{
						Type = ViewType.HeldAppliance
					});
					ctx.Set(entity, new CHeldBy
					{
						Holder = player
					});
					ctx.Set(entity, CPosition.Hidden);
					ctx.Set(player, new CItemHolder
					{
						HeldItem = entity
					});
					base.TileManager.SetOccupant(interact.Location, default(Entity), component.Layer);
				}
				result = true;
				interact.Result = ((!should_act) ? InteractionResult.Possible : InteractionResult.Performed);
			}
			return result;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
