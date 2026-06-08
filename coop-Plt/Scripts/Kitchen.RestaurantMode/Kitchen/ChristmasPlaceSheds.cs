using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ChristmasPlaceSheds : GameSystemBase
	{
		public EntityQuery Sheds;

		private HashSet<int> ShedRooms = new HashSet<int>();

		private List<Entity> Inputs = new List<Entity>();

		private List<Entity> Outputs = new List<Entity>();

		protected override void Initialise()
		{
			base.Initialise();
			Sheds = GetEntityQuery(typeof(CChristmasShedPlaceholder), typeof(CPosition));
			RequireForUpdate(Sheds);
		}

		protected override void OnUpdate()
		{
			EntityContext ctx = new EntityContext(base.EntityManager);
			using NativeArray<Entity> nativeArray = Sheds.ToEntityArray(Allocator.Temp);
			if (nativeArray.Length == 0)
			{
				return;
			}
			Inputs.Clear();
			Outputs.Clear();
			ShedRooms.Clear();
			foreach (Entity item in nativeArray)
			{
				if (Require<CChristmasShedPlaceholder>(item, out CChristmasShedPlaceholder comp) && Require<CPosition>(item, out CPosition comp2))
				{
					(comp.IsOutput ? Outputs : Inputs).Add(item);
					int roomID = base.TileManager.GetTile(comp2).RoomID;
					ShedRooms.Add(roomID);
				}
			}
			int num = Math.Min(Inputs.Count, Outputs.Count);
			for (int i = 0; i < num; i++)
			{
				Entity e = Inputs[i];
				Entity e2 = Outputs[i];
				Entity entity = Replace(ctx, e);
				Entity entity2 = Replace(ctx, e2);
				if (!(entity == default(Entity)) && !(entity2 == default(Entity)))
				{
					ctx.Set(entity, new CConveyTeleport
					{
						Target = entity2
					});
				}
			}
			foreach (int shedRoom in ShedRooms)
			{
				Entity entity3 = ctx.CreateEntity();
				ctx.Set(entity3, new EnforcePlayerBounds.CRoomMarker
				{
					RoomID = shedRoom
				});
			}
			base.EntityManager.DestroyEntity(Sheds);
		}

		private Entity Replace(EntityContext ctx, Entity e)
		{
			if (!Require<CPosition>(e, out CPosition comp))
			{
				return default(Entity);
			}
			if (!Require<CChristmasShedPlaceholder>(e, out CChristmasShedPlaceholder comp2))
			{
				return default(Entity);
			}
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CCreateAppliance
			{
				ID = comp2.ShedID
			});
			ctx.Set(entity, comp);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
