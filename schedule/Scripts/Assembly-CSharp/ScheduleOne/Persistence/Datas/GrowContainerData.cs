using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas
{
	public class GrowContainerData : GridItemData
	{
		public string SoilID;

		public float SoilLevel;

		public int RemainingSoilUses;

		public float WaterLevel;

		public string[] AppliedAdditives;

		public GrowContainerData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, string soilID, float soilLevel, int remainingSoilUses, float waterLevel, string[] appliedAdditives)
			: base(default(Guid), null, 0, null, default(Vector2), 0)
		{
		}

		public void ConvertOldAdditiveFormatToNew()
		{
		}
	}
}
