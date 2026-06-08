using System.Linq;
using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(DestroyAppliancesAtNight))]
	public class SpawnGardenEvents : StartOfNightSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			base.Enabled = false;
		}

		protected override void OnUpdate()
		{
			GardenProfile gardenProfile = base.Data.Get<GardenProfile>().ToList().Random();
			if (gardenProfile.Spawns.Count == 0)
			{
				return;
			}
			NativeArray<CLayoutRoomTile> getTiles = base.GetTiles;
			foreach (CLayoutRoomTile item in getTiles)
			{
				if (item.Type == RoomType.Garden && Random.value < 0.1f && base.TileManager.GetOccupant(item.Position) == default(Entity))
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemProvider));
					base.EntityManager.SetComponentData(entity, new CCreateAppliance
					{
						ID = gardenProfile.SpawnHolder.ID
					});
					CItemProvider componentData = new CItemProvider
					{
						Available = 1,
						Maximum = 1,
						DestroyOnEmpty = true
					};
					componentData.SetAsItem(gardenProfile.GetSpawn());
					base.EntityManager.SetComponentData(entity, componentData);
					base.EntityManager.SetComponentData(entity, new CPosition(item.Position));
				}
			}
			getTiles.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
