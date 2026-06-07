using System;
using System.Collections.Generic;
using Data.FactoryFloor.Islands;
using Data.SaveData;
using SaveData.FactoryFloor.Map;
using UnityEngine;

namespace SaveData.FactoryFloor.Versions
{
	[Serializable]
	public class FactoryMapSaveData_Version0 : IPreviousSaveVersion, ISaveVersion
	{
		public List<FactoryIslandSaveData_Version0> FactoryIslandSaveDatas = new List<FactoryIslandSaveData_Version0>();

		public List<IslandInMapSaveData> Islands = new List<IslandInMapSaveData>();

		public ISaveVersion ToNextVersion()
		{
			List<FactoryIslandSaveData> list = new List<FactoryIslandSaveData>();
			foreach (FactoryIslandSaveData_Version0 factoryIslandSaveData in FactoryIslandSaveDatas)
			{
				Color32[] array = new Color32[factoryIslandSaveData.FloorTextureColors.Length];
				for (int i = 0; i < factoryIslandSaveData.FloorTextureColors.Length; i++)
				{
					if ((double)(int)factoryIslandSaveData.FloorTextureColors[i].r > 0.9)
					{
						array[i] = EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.Tile);
					}
					else if ((double)(int)factoryIslandSaveData.FloorTextureColors[i].g > 0.9)
					{
						array[i] = EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.Grass);
					}
					else if ((double)(int)factoryIslandSaveData.FloorTextureColors[i].b > 0.9)
					{
						array[i] = EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.Hole);
					}
					if ((double)(int)factoryIslandSaveData.HeightTextureColors[i].g > 0.9)
					{
						array[i] = EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.ElevatedGrass);
					}
				}
				list.Add(new FactoryIslandSaveData(factoryIslandSaveData.Size, array, factoryIslandSaveData.Guid));
			}
			return new FactoryMapSaveData(list, Islands, new Bounds(Vector3.zero, Vector3.positiveInfinity));
		}
	}
}
