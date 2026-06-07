using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Operator;
using UnityEngine;

namespace Data.Minimap
{
	[Serializable]
	[CreateAssetMenu(menuName = "ScriptableObjects/MinimapColorSettings", fileName = "MinimapColorSettings", order = 0)]
	public class MinimapColorSettings : ScriptableObject
	{
		public Color TileColor;

		public Color GrassColor;

		public Color WaterColor;

		public Color DefaultFactoryObjectColor;

		public List<Color> BuildingFamilyColors = new List<Color>();

		[Space]
		public SerializedDictionary<FactoryObjectData, Color> OverrideColor = new SerializedDictionary<FactoryObjectData, Color>();

		public List<FactoryObjectData> FactoryObjectIgnoreList = new List<FactoryObjectData>();

		public List<FactoryObjectData> FactoryObjectsWithTerrainUnderneath = new List<FactoryObjectData>();

		public List<FactoryObjectData> WaterObjectsList = new List<FactoryObjectData>();

		public List<FactoryObjectData> GrassObjectsList = new List<FactoryObjectData>();
	}
}
