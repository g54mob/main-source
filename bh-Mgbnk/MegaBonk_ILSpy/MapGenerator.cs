using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public enum DrawMode
	{
		NoiseMap,
		Mesh,
		FalloffMap,
		ColorMap
	}

	public DrawMode drawMode;

	public TerrainData terrainData;

	public NoiseData noiseData;

	public TextureData textureData;

	public int levelOfDetail;

	private static int seed = 105;

	public bool autoUpdate;

	private float[,] falloffMap;

	private MapDisplay _003Cdisplay_003Ek__BackingField;

	public static int mapChunkSize = 241;

	public static int worldScale = 12;

	public GameObject mesh;

	public static MapGenerator Instance;

	public static float[,] staticNoiseMap;

	public float[,] heightMap;

	public MapDisplay display
	{
		get
		{
			return _003Cdisplay_003Ek__BackingField;
		}
		private set
		{
			_003Cdisplay_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		Instance = this;
		TerrainData terrainData = this.terrainData;
		TextureData textureData = this.textureData;
		float num = terrainData.heightCurve.Evaluate(0f);
		TerrainData terrainData2 = this.terrainData;
		float num2 = terrainData.heightMultiplier * terrainData.uniformScale;
		float savedMinHeight = num * num2;
		float num3 = terrainData2.heightCurve.Evaluate(1f);
		float num4 = terrainData2.heightMultiplier * terrainData2.uniformScale;
		float savedMaxHeight = num3 * num4;
		textureData.savedMinHeight = savedMinHeight;
		textureData.savedMaxHeight = savedMaxHeight;
	}

	private void OnValuesUpdated()
	{
		if (!(this != null))
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if (!(gameObject != null))
		{
			return;
		}
		GameObject gameObject2 = base.gameObject;
		if (!gameObject2.activeInHierarchy || Application.isPlaying)
		{
			return;
		}
		GenerateMap();
		float[,] array = GeneratePerlinNoiseMap(0);
		MapDisplay mapDisplay = UnityEngine.Object.FindObjectOfType<MapDisplay>();
		float[,] array3;
		if (drawMode != DrawMode.NoiseMap)
		{
			if (drawMode == DrawMode.Mesh)
			{
				TerrainData terrainData = this.terrainData;
				MeshData meshData = MeshGenerator.GenerateTerrainMesh(array, terrainData.heightMultiplier, terrainData.heightCurve, levelOfDetail);
				Mesh sharedMesh = meshData.CreateMesh();
				mapDisplay.meshFilter.sharedMesh = sharedMesh;
				Mesh sharedMesh2 = mapDisplay.meshFilter.sharedMesh;
				mapDisplay.meshCollider.sharedMesh = sharedMesh2;
				return;
			}
			if (drawMode != DrawMode.FalloffMap)
			{
				return;
			}
			float[,] array2 = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
			array3 = array2;
		}
		else
		{
			array3 = array;
		}
		Texture2D texture = TextureGenerator.TextureFromHeightMap(array3);
		mapDisplay.DrawTexture(texture);
	}

	public unsafe void GenerateMap(MapData mapData, StageData stageData, int seed = 105)
	{
		//IL_0027: Expected O, but got Ref
		Transform transform = mesh.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
		terrainData = stageData.proceduralTerrainData;
		noiseData = stageData.proceduralNoiseData;
		GenerateMap(seed);
	}

	public void GenerateMap(int seed = 105)
	{
		float[,] array = GeneratePerlinNoiseMap(seed);
		heightMap = array;
		TerrainData terrainData = this.terrainData;
		TextureData textureData = this.textureData;
		float num = terrainData.heightCurve.Evaluate(0f);
		TerrainData terrainData2 = this.terrainData;
		float num2 = terrainData.heightMultiplier * terrainData.uniformScale;
		float savedMinHeight = num * num2;
		float num3 = terrainData2.heightCurve.Evaluate(1f);
		float num4 = terrainData2.heightMultiplier * terrainData2.uniformScale;
		float savedMaxHeight = num3 * num4;
		textureData.savedMinHeight = savedMinHeight;
		textureData.savedMaxHeight = savedMaxHeight;
		MapDisplay mapDisplay = UnityEngine.Object.FindObjectOfType<MapDisplay>();
		_003Cdisplay_003Ek__BackingField = mapDisplay;
		MapDisplay mapDisplay2;
		float[,] array3;
		Texture2D texture;
		if (drawMode != DrawMode.NoiseMap)
		{
			if (drawMode != DrawMode.Mesh)
			{
				if (drawMode == DrawMode.FalloffMap)
				{
					mapDisplay2 = _003Cdisplay_003Ek__BackingField;
					float[,] array2 = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
					array3 = array2;
					goto IL_0359;
				}
				if (drawMode == DrawMode.ColorMap)
				{
					mapDisplay2 = _003Cdisplay_003Ek__BackingField;
					texture = TextureGenerator.ColorTextureFromHeightMap(heightMap, this.textureData);
					goto IL_023f;
				}
			}
			else
			{
				TerrainData terrainData3 = this.terrainData;
				MapDisplay mapDisplay3 = _003Cdisplay_003Ek__BackingField;
				MeshData meshData = MeshGenerator.GenerateTerrainMesh(heightMap, terrainData3.heightMultiplier, terrainData3.heightCurve, levelOfDetail);
				Mesh sharedMesh = meshData.CreateMesh();
				mapDisplay3.meshFilter.sharedMesh = sharedMesh;
				Mesh sharedMesh2 = mapDisplay3.meshFilter.sharedMesh;
				mapDisplay3.meshCollider.sharedMesh = sharedMesh2;
			}
			goto IL_0251;
		}
		mapDisplay2 = _003Cdisplay_003Ek__BackingField;
		array3 = heightMap;
		goto IL_0359;
		IL_023f:
		mapDisplay2.DrawTexture(texture);
		goto IL_0251;
		IL_0359:
		texture = TextureGenerator.TextureFromHeightMap(array3);
		goto IL_023f;
		IL_0251:
		TerrainData terrainData4 = this.terrainData;
		TextureData textureData2 = this.textureData;
		float num5 = terrainData4.heightCurve.Evaluate(0f);
		TerrainData terrainData5 = this.terrainData;
		float num6 = terrainData4.heightMultiplier * terrainData4.uniformScale;
		float savedMinHeight2 = num5 * num6;
		float num7 = terrainData5.heightCurve.Evaluate(1f);
		float num8 = terrainData5.heightMultiplier * terrainData5.uniformScale;
		float savedMaxHeight2 = num7 * num8;
		textureData2.savedMinHeight = savedMinHeight2;
		textureData2.savedMaxHeight = savedMaxHeight2;
	}

	public float[,] GeneratePerlinNoiseMap(NoiseData noiseData, int seed, bool useFalloffMap)
	{
		//IL_0043: Expected O, but got F4
		//IL_0043: Expected F4, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		int num = default(int);
		int octaves = default(int);
		float persistance = default(float);
		float lacunarity = default(float);
		float blend = default(float);
		float[,] result = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, num, noiseData.noiseScale, octaves, persistance, lacunarity, blend, noiseData.octaves, (Vector2)noiseData.persistance);
		if (useFalloffMap)
		{
			if (falloffMap == null)
			{
				float[,] array = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
				falloffMap = array;
			}
			for (int i = 0; i < mapChunkSize; i++)
			{
				object obj = 0;
				while ((nint)obj < mapChunkSize)
				{
					TerrainData terrainData = this.terrainData;
					if (terrainData.useFalloff)
					{
						throw new IndexOutOfRangeException();
					}
					obj++;
				}
			}
		}
		return result;
	}

	public float[,] GeneratePerlinNoiseMap(int seed)
	{
		//IL_0043: Expected O, but got F4
		//IL_0043: Expected F4, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		NoiseData noiseData = this.noiseData;
		int octaves = default(int);
		float persistance = default(float);
		float lacunarity = default(float);
		float blend = default(float);
		float[,] result = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseData.noiseScale, octaves, persistance, lacunarity, blend, noiseData.octaves, (Vector2)noiseData.persistance);
		TerrainData terrainData = this.terrainData;
		if (terrainData.useFalloff)
		{
			if (falloffMap == null)
			{
				float[,] array = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
				falloffMap = array;
			}
			for (int i = 0; i < mapChunkSize; i++)
			{
				object obj = 0;
				while ((nint)obj < mapChunkSize)
				{
					TerrainData terrainData2 = this.terrainData;
					if (terrainData2.useFalloff)
					{
						throw new IndexOutOfRangeException();
					}
					obj++;
				}
			}
		}
		return result;
	}

	public void DrawMapInEditor()
	{
		float[,] array = GeneratePerlinNoiseMap(0);
		MapDisplay mapDisplay = UnityEngine.Object.FindObjectOfType<MapDisplay>();
		float[,] array3;
		if (drawMode != DrawMode.NoiseMap)
		{
			if (drawMode == DrawMode.Mesh)
			{
				TerrainData terrainData = this.terrainData;
				MeshData meshData = MeshGenerator.GenerateTerrainMesh(array, terrainData.heightMultiplier, terrainData.heightCurve, levelOfDetail);
				Mesh sharedMesh = meshData.CreateMesh();
				mapDisplay.meshFilter.sharedMesh = sharedMesh;
				Mesh sharedMesh2 = mapDisplay.meshFilter.sharedMesh;
				mapDisplay.meshCollider.sharedMesh = sharedMesh2;
				return;
			}
			if (drawMode != DrawMode.FalloffMap)
			{
				return;
			}
			float[,] array2 = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
			array3 = array2;
		}
		else
		{
			array3 = array;
		}
		Texture2D texture = TextureGenerator.TextureFromHeightMap(array3);
		mapDisplay.DrawTexture(texture);
	}

	private void OnValidate()
	{
		if (terrainData != null)
		{
			Action value = OnValuesUpdated;
			terrainData.OnValuesUpdate -= value;
			Action value2 = OnValuesUpdated;
			terrainData.OnValuesUpdate += value2;
		}
		if (noiseData != null)
		{
			Action value3 = OnValuesUpdated;
			noiseData.OnValuesUpdate -= value3;
			Action value4 = OnValuesUpdated;
			noiseData.OnValuesUpdate += value4;
		}
	}
}
