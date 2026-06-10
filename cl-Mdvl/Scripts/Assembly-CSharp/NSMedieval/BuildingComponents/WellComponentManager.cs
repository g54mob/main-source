using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Terrain;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class WellComponentManager : ComponentBaseManager<WellComponent, WellComponentInstance>
	{
		public WellComponentManager(VillageMap map)
			: base(map)
		{
		}

		public int GetOperationalCount()
		{
			int num = 0;
			foreach (WellComponentInstance value in base.PositionInstance.Values)
			{
				if (value.CanBeUsed)
				{
					num++;
				}
			}
			return num;
		}

		public bool CheckBlueprintWaterSource(Vec3Int center)
		{
			if (Map.BuildingsManagerMain.BuildingExists(BuildingType.Floor, center))
			{
				return false;
			}
			MapNode node = Map.GetNode(center);
			if (node == null)
			{
				return false;
			}
			if (node.IsWater)
			{
				return true;
			}
			int num = center.y;
			while (num > 0)
			{
				num--;
				Vec3Int vec3Int = new Vec3Int(center.x, num, center.z);
				node = Map.GetNode(vec3Int);
				if (node != null)
				{
					if (Map.BuildingsManagerMain.BuildingExists(vec3Int, (BaseBuildingInstance x) => x.BuildingType != BuildingType.Ladder && x.BuildingType != BuildingType.Floor))
					{
						return false;
					}
					if (MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int))
					{
						return false;
					}
					if (node.IsWater)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
