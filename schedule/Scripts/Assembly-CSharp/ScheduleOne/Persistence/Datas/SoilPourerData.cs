using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas
{
	public class SoilPourerData : GridItemData
	{
		public string SoilID;

		public SoilPourerData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, string soilID)
			: base(default(Guid), null, 0, null, default(Vector2), 0)
		{
		}
	}
}
