using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "Factory/Buildings/BuildingObjectDatabase", fileName = "BuildingObjectDatabase", order = 0)]
	public class BuildingObjectDatabase : ScriptableObject
	{
		public List<BuildingObjectData> BuildingDatas;

		public BuildingObjectData GetBuildingDataWithId(int id)
		{
			return BuildingDatas.FirstOrDefault((BuildingObjectData x) => x != null && x.ID == id);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateRelativePositions()
		{
			foreach (BuildingObjectData buildingData in BuildingDatas)
			{
				buildingData.UpdateRelativePositions();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void OrderListToFamilies()
		{
			BuildingDatas.Sort(delegate(BuildingObjectData x, BuildingObjectData y)
			{
				int num = x.FamilyID.CompareTo(y.FamilyID);
				if (num != 0)
				{
					return num;
				}
				num = x.CategoryType.CompareTo(y.CategoryType);
				return (num != 0) ? num : BuildingDatas.IndexOf(x).CompareTo(BuildingDatas.IndexOf(y));
			});
		}
	}
}
