using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ModApi.Planet.CustomData
{
	public abstract class CustomSubBiomeTerrainData
	{
		private class CustomSubBiomeTerrainDataRegistration
		{
			public int CustomPlanetVertexDataIndex { get; }

			public Func<CustomSubBiomeTerrainData> Factory { get; }

			public string Id { get; }

			public int Index { get; }

			public bool ShowInPlanetStudio { get; }

			public Type Type { get; }

			public CustomSubBiomeTerrainDataRegistration(string id, int index, int customPlanetVertexDataIndex, Type type, Func<CustomSubBiomeTerrainData> factory, bool showInPlanetStudio)
			{
				Id = id;
				Index = index;
				CustomPlanetVertexDataIndex = customPlanetVertexDataIndex;
				Type = type;
				Factory = factory;
				ShowInPlanetStudio = showInPlanetStudio;
			}
		}

		private static List<CustomSubBiomeTerrainDataRegistration> _registeredItems = new List<CustomSubBiomeTerrainDataRegistration>();

		private CustomSubBiomeTerrainDataRegistration _registrationInfo;

		public int CustomPlanetVertexDataIndex => _registrationInfo?.CustomPlanetVertexDataIndex ?? (-1);

		public virtual string Id => _registrationInfo?.Id;

		public bool ShowInPlanetStudio => _registrationInfo?.ShowInPlanetStudio ?? true;

		public static List<CustomSubBiomeTerrainData> Create()
		{
			int count = _registeredItems.Count;
			List<CustomSubBiomeTerrainData> list = new List<CustomSubBiomeTerrainData>(count);
			for (int i = 0; i < count; i++)
			{
				CustomSubBiomeTerrainData customSubBiomeTerrainData = _registeredItems[i].Factory();
				customSubBiomeTerrainData._registrationInfo = _registeredItems[i];
				list.Add(customSubBiomeTerrainData);
			}
			return list;
		}

		public static int GetIndex(string id)
		{
			int count = _registeredItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (_registeredItems[i].Id == id)
				{
					return _registeredItems[i].Index;
				}
			}
			return -1;
		}

		public static int Register<TSubBiomeData, TVertexData>(string id, Func<CustomSubBiomeTerrainData<TVertexData>> factory, bool showInPlanetStudio) where TSubBiomeData : CustomSubBiomeTerrainData<TVertexData> where TVertexData : CustomPlanetVertexData, new()
		{
			if (_registeredItems.Exists((CustomSubBiomeTerrainDataRegistration x) => x.Id == id))
			{
				throw new Exception("Custom sub biome terrain data with id '" + id + "' has already been registered with the system.");
			}
			int customPlanetVertexDataIndex = CustomPlanetVertexData.Register<TVertexData>(id);
			int count = _registeredItems.Count;
			_registeredItems.Add(new CustomSubBiomeTerrainDataRegistration(id, count, customPlanetVertexDataIndex, typeof(TSubBiomeData), factory, showInPlanetStudio));
			return count;
		}

		public abstract void ApplyBiomeData(CustomPlanetVertexData customPlanetVertexData, float biomeStrength);

		public abstract void RestoreFromXml(XElement xmlCustomData);

		public abstract XElement SaveXml(XElement customDataXml);
	}
	public abstract class CustomSubBiomeTerrainData<TPlanetVertexData> : CustomSubBiomeTerrainData where TPlanetVertexData : CustomPlanetVertexData
	{
		public sealed override void ApplyBiomeData(CustomPlanetVertexData customPlanetVertexData, float biomeStrength)
		{
			ApplyBiomeData((TPlanetVertexData)customPlanetVertexData, biomeStrength);
		}

		public abstract void ApplyBiomeData(TPlanetVertexData vertexData, float biomeStrength);

		public abstract void SaveToXml(XElement customDataXml);

		public sealed override XElement SaveXml(XElement customDataXml)
		{
			SaveToXml(customDataXml);
			return customDataXml;
		}
	}
}
