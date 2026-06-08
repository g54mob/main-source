using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts;
using UnityEngine;

namespace Kitchen
{
	public class DiningDecorator : Decorator
	{
		public override bool Decorate(Room room)
		{
			List<CLayoutAppliancePlacement> list = new List<CLayoutAppliancePlacement>();
			List<Vector2> list2 = new List<Vector2>();
			List<LayoutPosition> list3 = (from r in Blueprint.TilesOfRoom(room)
				orderby Random.value
				select r).ToList();
			int num = 0;
			foreach (LayoutPosition item in list3)
			{
				if (!Blueprint.IsTileOpenSpace(item))
				{
					continue;
				}
				bool flag = true;
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					LayoutPosition layoutPosition = direction + item;
					if (list2.Contains(layoutPosition) || Blueprint.HasFeature(layoutPosition))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				list.Add(new CLayoutAppliancePlacement
				{
					Position = item,
					Appliance = Profile.Table.ID,
					Rotation = Quaternion.identity
				});
				num++;
				if (num >= Profile.MaximumTables)
				{
					break;
				}
				foreach (LayoutPosition item2 in LayoutHelpers.AllNearby)
				{
					LayoutPosition layoutPosition2 = item2 + item;
					list2.Add(layoutPosition2);
				}
			}
			if (num == Profile.MaximumTables)
			{
				list.ForEach(delegate(CLayoutAppliancePlacement p)
				{
					Decorations.Add(p);
				});
				return true;
			}
			return false;
		}
	}
}
