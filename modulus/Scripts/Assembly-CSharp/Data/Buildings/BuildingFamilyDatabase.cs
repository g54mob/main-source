using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "UI/Toolbar/BuildingFamilyDatabase", fileName = "BuildingFamilyDatabase", order = 0)]
	public class BuildingFamilyDatabase : ScriptableObject
	{
		public List<BuildingFamilyData> BuildingFamilies;

		public List<BuildingCategoryData> BuildingCategories;

		public BuildingFamilyData GetBuildingFamilyDataWithId(int id)
		{
			return BuildingFamilies.FirstOrDefault((BuildingFamilyData x) => x.ID == id);
		}

		public BuildingCategoryData GetBuildingCategoryDataWithId(BuildingCategoryType type)
		{
			return BuildingCategories.FirstOrDefault((BuildingCategoryData x) => x.Type == type);
		}

		public Color GetFamilyColorById(int id)
		{
			return BuildingFamilies.FirstOrDefault((BuildingFamilyData x) => x.ID == id).Color;
		}

		public Color GetFamilyColorByIndex(int index)
		{
			return BuildingFamilies[index].Color;
		}
	}
}
