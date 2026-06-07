using System;
using System.Collections.Generic;
using ModApi.Planet;

namespace Assets.Scripts.Terrain.CustomData
{
	public abstract class CustomCreateQuadData
	{
		public class CustomCreateQuadDataUnregistered : CustomCreateQuadData
		{
			public override void Initialize(int terrainQuadVertexCount)
			{
			}

			public override void OnQuadDataGenerated(TerrainGeneratorCacheData terrainGeneratorCacheData, CreateQuadData createQuadData)
			{
			}
		}

		private class CustomCreateQuadDataRegistration
		{
			public Func<CustomCreateQuadData> Factory { get; }

			public string Id { get; }

			public int Index { get; }

			public Type Type { get; }

			public CustomCreateQuadDataRegistration(string id, int index, Type type, Func<CustomCreateQuadData> factory)
			{
				Id = id;
				Index = index;
				Type = type;
				Factory = factory;
			}
		}

		private static List<CustomCreateQuadDataRegistration> _registeredItems = new List<CustomCreateQuadDataRegistration>();

		public static CustomCreateQuadData[] Create(int terrainQuadVertexCount)
		{
			int count = _registeredItems.Count;
			CustomCreateQuadData[] array = new CustomCreateQuadData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = _registeredItems[i].Factory();
				array[i].Initialize(terrainQuadVertexCount);
			}
			return array;
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

		public static int Register<T>(string id) where T : CustomCreateQuadData, new()
		{
			return Register(id, () => new T());
		}

		public static int Register<T>(string id, Func<T> factory) where T : CustomCreateQuadData
		{
			if (_registeredItems.Exists((CustomCreateQuadDataRegistration x) => x.Id == id))
			{
				throw new Exception("Custom create quad data with id '" + id + "' has already been registered with the system.");
			}
			int count = _registeredItems.Count;
			_registeredItems.Add(new CustomCreateQuadDataRegistration(id, count, typeof(T), factory));
			return count;
		}

		public abstract void Initialize(int terrainQuadVertexCount);

		public abstract void OnQuadDataGenerated(TerrainGeneratorCacheData terrainGeneratorCacheData, CreateQuadData createQuadData);
	}
}
