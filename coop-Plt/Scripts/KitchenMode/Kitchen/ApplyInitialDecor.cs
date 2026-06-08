using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ApplyInitialDecor : GameSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CApplied : IComponentData
		{
		}

		private EntityQuery DecorApplications;

		private HashSet<int> RoomIDs = new HashSet<int>();

		protected override void Initialise()
		{
			DecorApplications = GetEntityQuery(new QueryHelper().All(typeof(CApplyInitialDecor)).None(typeof(CApplied)));
			RequireForUpdate(DecorApplications);
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = DecorApplications.ToEntityArray(Allocator.Temp);
			base.EntityManager.AddComponent<CApplied>(DecorApplications);
			using NativeArray<CLayoutRoomTile> nativeArray2 = base.Tiles.ToNativeArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				RoomIDs.Clear();
				if (!Require<CApplyInitialDecor>(item, out CApplyInitialDecor comp))
				{
					continue;
				}
				foreach (CLayoutRoomTile item2 in nativeArray2)
				{
					if (!RoomIDs.Contains(item2.RoomID) && item2.Type == comp.Type)
					{
						RoomIDs.Add(item2.RoomID);
						Request(item2.RoomID, comp.Decor);
					}
				}
			}
		}

		protected void Request(int room_id, int decor_id)
		{
			if (GameData.Main.TryGet<Decor>(decor_id, out var output))
			{
				Entity entity = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponentData(entity, new CChangeDecorEvent
				{
					RoomID = room_id,
					DecorID = output.ID,
					Type = output.Type
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
