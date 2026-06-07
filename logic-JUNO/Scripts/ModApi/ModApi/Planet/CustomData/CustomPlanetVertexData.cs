using System;
using System.Collections.Generic;

namespace ModApi.Planet.CustomData
{
	public abstract class CustomPlanetVertexData
	{
		public class CustomPlanetVertexDataUnregistered : CustomPlanetVertexData
		{
			public override void ApplyBiomeResults(CustomPlanetVertexData biomePlanetVertexData, float biomeStrength)
			{
			}

			public override void Reset()
			{
			}
		}

		private class CustomPlanetVertexDataRegistration
		{
			public Func<CustomPlanetVertexData> Factory { get; }

			public string Id { get; }

			public int Index { get; }

			public Type Type { get; }

			public CustomPlanetVertexDataRegistration(string id, int index, Type type, Func<CustomPlanetVertexData> factory)
			{
				Id = id;
				Index = index;
				Type = type;
				Factory = factory;
			}
		}

		private static List<CustomPlanetVertexDataRegistration> _registeredItems = new List<CustomPlanetVertexDataRegistration>();

		public static int Version { get; private set; }

		public static CustomPlanetVertexData[] Create()
		{
			int count = _registeredItems.Count;
			CustomPlanetVertexData[] array = new CustomPlanetVertexData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = _registeredItems[i].Factory();
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

		public static bool IsRegistered(string id)
		{
			return GetIndex(id) >= 0;
		}

		public static int Register<T>(string id) where T : CustomPlanetVertexData, new()
		{
			return Register(id, () => new T());
		}

		public static int Register<T>(string id, Func<T> factory) where T : CustomPlanetVertexData, new()
		{
			if (_registeredItems.Exists((CustomPlanetVertexDataRegistration x) => x.Id == id))
			{
				throw new Exception("Custom planet vertex data with id '" + id + "' has already been registered with the system.");
			}
			int count = _registeredItems.Count;
			_registeredItems.Add(new CustomPlanetVertexDataRegistration(id, count, typeof(T), () => new T()));
			Version++;
			return count;
		}

		public static void Unregister(string id)
		{
			int num = _registeredItems.FindIndex((CustomPlanetVertexDataRegistration x) => x.Id == id);
			if (num >= 0)
			{
				_registeredItems[num] = new CustomPlanetVertexDataRegistration("Unregistered_" + Guid.NewGuid().ToString(), num, typeof(CustomPlanetVertexDataUnregistered), () => new CustomPlanetVertexDataUnregistered());
				Version++;
			}
		}

		public abstract void ApplyBiomeResults(CustomPlanetVertexData biomePlanetVertexData, float biomeStrength);

		public abstract void Reset();
	}
	public abstract class CustomPlanetVertexData<T> : CustomPlanetVertexData where T : CustomPlanetVertexData<T>
	{
		public sealed override void ApplyBiomeResults(CustomPlanetVertexData planetBiomeVertexData, float biomeStrength)
		{
			ApplyBiomeResults((T)planetBiomeVertexData, biomeStrength);
		}

		public abstract void ApplyBiomeResults(T planetBiomeVertexData, float biomeStrength);
	}
}
