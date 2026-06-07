using System.IO;
using UnityEngine;

public class TerrainDataDeserializer
{
	public const string SPLAT_DATA_FILE_NAME = "TerrainSplatData";

	public (float[][,,] allSplats, int terrainSpan, float heightMapResolution, float splatResolution, int terrainSize) ReadData()
	{
		if (File.Exists(Path.Combine(Application.dataPath, "TerrainSplatData")))
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(Path.Combine(Application.dataPath, "TerrainSplatData"), FileMode.Open)))
			{
				int num = binaryReader.ReadInt32();
				int item = binaryReader.ReadInt32();
				float item2 = binaryReader.ReadSingle();
				int num2 = binaryReader.ReadInt32();
				int item3 = binaryReader.ReadInt32();
				float[][,,] array = new float[num][,,];
				for (int i = 0; i < num; i++)
				{
					float[,,] array2 = new float[num2, num2, 16];
					for (int j = 0; j < array2.GetLength(0); j++)
					{
						for (int k = 0; k < array2.GetLength(1); k++)
						{
							for (int l = 0; l < array2.GetLength(2); l++)
							{
								array2[j, k, l] = binaryReader.ReadSingle();
							}
						}
					}
					array[i] = array2;
				}
				return (allSplats: array, terrainSpan: item, heightMapResolution: item2, splatResolution: num2, terrainSize: item3);
			}
		}
		Debug.LogError("Terrain splat data file not found.");
		return (allSplats: null, terrainSpan: 0, heightMapResolution: 0f, splatResolution: 0f, terrainSize: 0);
	}

	public (int infosLength, int terrainSpan, float heightMapResolution, float splatResolution, int terrainSize) ReadHeader()
	{
		if (File.Exists(Path.Combine(Application.dataPath, "TerrainSplatData")))
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(Path.Combine(Application.dataPath, "TerrainSplatData"), FileMode.Open)))
			{
				int item = binaryReader.ReadInt32();
				int item2 = binaryReader.ReadInt32();
				float item3 = binaryReader.ReadSingle();
				int num = binaryReader.ReadInt32();
				int item4 = binaryReader.ReadInt32();
				return (infosLength: item, terrainSpan: item2, heightMapResolution: item3, splatResolution: num, terrainSize: item4);
			}
		}
		Debug.LogError("Terrain splat data file not found.");
		return (infosLength: 0, terrainSpan: 0, heightMapResolution: 0f, splatResolution: 0f, terrainSize: 0);
	}
}
