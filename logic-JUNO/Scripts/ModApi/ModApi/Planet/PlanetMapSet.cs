using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetMapSet
	{
		public class MapSampleResult
		{
			private float[] _values;

			public float Height => _values[0];

			public int NumBiomes { get; private set; }

			public MapSampleResult(int numBiomes)
			{
				NumBiomes = numBiomes;
				_values = new float[numBiomes + 1];
			}

			public float GetBiomeStrength(int biomeIndex)
			{
				if (biomeIndex == 0)
				{
					float num = 1f;
					for (int i = 1; i < _values.Length; i++)
					{
						num -= _values[i];
					}
					return num;
				}
				return _values[biomeIndex];
			}

			public void SetDefaultValues()
			{
				for (int i = 0; i < _values.Length; i++)
				{
					_values[i] = 0f;
				}
			}

			public void SetValue(int index, float value)
			{
				_values[index] = value;
			}
		}

		private List<PlanetMap> _biomeMaps;

		private PlanetMap _heightMap;

		public int BiomeMapSize { get; private set; }

		public PlanetMap HeightMap => _heightMap;

		public int NumBiomes => _biomeMaps.Count + 1;

		public PlanetMapSet(int heightMapSize, int biomeMapSize)
			: this(new PlanetMap(heightMapSize), biomeMapSize)
		{
		}

		private PlanetMapSet(PlanetMap heightMap, int biomeMapSize)
		{
			BiomeMapSize = biomeMapSize;
			_biomeMaps = new List<PlanetMap>();
			_heightMap = heightMap;
		}

		public static PlanetMapSet Load(string path)
		{
			using FileStream input = File.OpenRead(path);
			using BinaryReader binaryReader = new BinaryReader(input);
			int size = binaryReader.ReadInt32();
			int num = binaryReader.ReadInt32();
			int num2 = binaryReader.ReadInt32();
			PlanetMapSet planetMapSet = new PlanetMapSet(PlanetMap.Load(binaryReader, size), num);
			for (int i = 0; i < num2; i++)
			{
				PlanetMap item = PlanetMap.Load(binaryReader, num);
				planetMapSet._biomeMaps.Add(item);
			}
			return planetMapSet;
		}

		public void AddBiomeMap()
		{
			_biomeMaps.Add(new PlanetMap(BiomeMapSize));
		}

		public MapSampleResult CreateSampleResult()
		{
			return new MapSampleResult(_biomeMaps.Count + 1);
		}

		public PlanetMap GetBiomeMap(int biome)
		{
			if (biome == 0)
			{
				throw new ArgumentException("Cannot get biome map at index 0. That is the default biome and does not have a dedicated map.");
			}
			int index = biome - 1;
			return _biomeMaps[index];
		}

		public void RemoveBiomeMap(int biome)
		{
			if (biome == 0)
			{
				throw new Exception("Cannot remove default biome");
			}
			int index = biome - 1;
			_biomeMaps.RemoveAt(index);
		}

		public void SampleMaps(Vector3d position, MapSampleResult result, float[][] preallocatedArray)
		{
			float value = _heightMap.Sample(position, preallocatedArray);
			result.SetValue(0, value);
			int num = 1;
			foreach (PlanetMap biomeMap in _biomeMaps)
			{
				float value2 = biomeMap.Sample(position, preallocatedArray);
				result.SetValue(num, value2);
				num++;
			}
		}

		public void Save(string path)
		{
			using FileStream output = new FileStream(path, FileMode.Create, FileAccess.Write);
			using BinaryWriter binaryWriter = new BinaryWriter(output);
			binaryWriter.Write(_heightMap.Size);
			binaryWriter.Write(BiomeMapSize);
			binaryWriter.Write(_biomeMaps.Count);
			_heightMap.Write(binaryWriter);
			foreach (PlanetMap biomeMap in _biomeMaps)
			{
				biomeMap.Write(binaryWriter);
			}
		}
	}
}
