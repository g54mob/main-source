using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas
{
	public class PotData : GrowContainerData
	{
		public PlantData PlantData;

		public PotData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, string soilID, float soilLevel, int remainingSoilUses, float waterLevel, string[] appliedAdditives, PlantData plantData)
			: base(default(Guid), null, 0, null, default(Vector2), 0, null, 0f, 0, 0f, null)
		{
		}
	}
}
