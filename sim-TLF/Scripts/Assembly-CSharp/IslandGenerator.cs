using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[AddComponentMenu("Island Generator/Island Generator")]
public class IslandGenerator : MonoBehaviour
{
	public Terrain terrain;

	private int smoothTimes = 5;

	private int neighboringWalls = 4;

	public int maxRadius;

	private int maxRadius2;

	private int width;

	private int height;

	private int scaleHeightMultip;

	private int scaleWidthMultip;

	private int terrainreso;

	private int scaledWidth;

	private int scaledHeight;

	public Thread th1;

	public bool aborted;

	private int gridSize;

	private int calculatedPixels;

	public string prog;

	private int terrainDataMapHeight;

	private int terrainDataMapWidth;

	public float perlinHeight = 0.02f;

	public float perlinScale = 20f;

	public int mapSmoothTimes = 10;

	public string seed;

	public bool useRandomSeed = true;

	public List<string> usedSeeds = new List<string>(0);

	[Range(0f, 100f)]
	public int randomFillPercent = 50;

	private int[,] map;

	private int[,] mapx2;

	private float[,] heights;

	private float[,] heights2;

	private void Awake()
	{
		terrain = GetComponent<Terrain>();
	}

	public void StartGeneration()
	{
		terrain = GetComponent<Terrain>();
		int heightmapResolution = terrain.terrainData.heightmapResolution;
		int heightmapResolution2 = terrain.terrainData.heightmapResolution;
		scaleHeightMultip = heightmapResolution / 64;
		scaleWidthMultip = heightmapResolution2 / 64;
		height = heightmapResolution / scaleHeightMultip;
		width = heightmapResolution2 / scaleWidthMultip;
		heights = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
		heights2 = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
		GenerateMap();
	}

	private void Thread1()
	{
		for (int i = 0; i < scaledWidth; i++)
		{
			for (int j = 0; j < scaledHeight; j++)
			{
				if (aborted)
				{
					break;
				}
				calculatedPixels++;
				prog = ((float)calculatedPixels / (float)gridSize * 100f).ToString("F0") + "%";
				if (mapx2[i, j] == 2)
				{
					RandomDrop(i, j);
				}
			}
			if (aborted)
			{
				break;
			}
		}
		aborted = false;
	}

	public void ResetSeaFloor()
	{
		terrain = GetComponent<Terrain>();
		heights2 = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
		bool flag = false;
		while (!flag)
		{
			for (int i = 0; i < terrain.terrainData.heightmapResolution; i++)
			{
				for (int j = 0; j < terrain.terrainData.heightmapResolution; j++)
				{
					heights2[i, j] -= 0.001f;
					if (heights2[i, j] <= 0f)
					{
						flag = true;
					}
				}
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights2);
	}

	public void BlendHeights()
	{
		terrain = GetComponent<Terrain>();
		int heightmapResolution = terrain.terrainData.heightmapResolution;
		int heightmapResolution2 = terrain.terrainData.heightmapResolution;
		heights2 = terrain.terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution2);
		for (int i = 0; i < heightmapResolution; i++)
		{
			for (int j = 0; j < heightmapResolution2; j++)
			{
				float num = 0f;
				float num2 = 0f;
				for (int k = i - 1; k < i + 2; k++)
				{
					for (int l = j - 1; l < j + 2; l++)
					{
						if (k >= 0 && l >= 0 && k < heightmapResolution && l < heightmapResolution2)
						{
							num += heights2[k, l];
							num2 += 1f;
						}
					}
				}
				num /= num2;
				heights2[i, j] = num;
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights2);
	}

	private void RandomDrop(int xCoord, int yCoord)
	{
		int num = terrainDataMapWidth;
		int num2 = terrainDataMapWidth - xCoord;
		int num3 = terrainDataMapHeight - yCoord;
		if (num2 < num)
		{
			num = num2;
		}
		if (num3 < num)
		{
			num = num3;
		}
		if (xCoord < num)
		{
			num = xCoord;
		}
		if (yCoord < num)
		{
			num = yCoord;
		}
		if (num > maxRadius2)
		{
			num = maxRadius2;
		}
		for (int i = 0; i < num * 2; i++)
		{
			for (int j = 0; j < num * 2; j++)
			{
				float num4 = (float)i / (float)num / 2f;
				float num5 = (float)j / (float)num / 2f;
				float num6 = Mathf.Sin(num4 * MathF.PI);
				float num7 = Mathf.Sin(num5 * MathF.PI);
				float num8 = num6 / 10f * num7;
				if (heights[xCoord - num + i, yCoord - num + j] < 0.1f && heights[xCoord - num + i, yCoord - num + j] <= num8)
				{
					heights[xCoord - num + i, yCoord - num + j] = num8;
				}
			}
		}
	}

	public void PerlinNoise()
	{
		terrain = GetComponent<Terrain>();
		int heightmapResolution = terrain.terrainData.heightmapResolution;
		int heightmapResolution2 = terrain.terrainData.heightmapResolution;
		float[,] array = terrain.terrainData.GetHeights(0, 0, heightmapResolution2, heightmapResolution);
		float num = (float)DateTime.Now.Millisecond / 1000f;
		for (int i = 0; i < heightmapResolution2; i++)
		{
			for (int j = 0; j < heightmapResolution; j++)
			{
				float num2 = (float)i / (float)heightmapResolution2;
				float num3 = (float)j / (float)heightmapResolution;
				array[i, j] += perlinHeight * Mathf.PerlinNoise((num2 + num) * perlinScale, (num3 + num) * perlinScale);
			}
		}
		terrain.terrainData.SetHeights(0, 0, array);
	}

	private void Flatten()
	{
		for (int i = 0; i < terrain.terrainData.heightmapResolution; i++)
		{
			for (int j = 0; j < terrain.terrainData.heightmapResolution; j++)
			{
				heights[i, j] = 0f;
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);
	}

	private void ScaleMap(int thisHeight, int thisWidth, int[,] thisMap)
	{
		scaledHeight = thisHeight * 2;
		scaledWidth = thisWidth * 2;
		mapx2 = new int[scaledWidth, scaledHeight];
		for (int i = 0; i < thisWidth; i++)
		{
			for (int j = 0; j < thisHeight; j++)
			{
				if (thisMap[i, j] == 1)
				{
					mapx2[i * 2, j * 2] = 1;
					mapx2[i * 2 + 1, j * 2] = 1;
					mapx2[i * 2, j * 2 + 1] = 1;
					mapx2[i * 2 + 1, j * 2 + 1] = 1;
				}
				else
				{
					mapx2[i * 2, j * 2] = 0;
					mapx2[i * 2 + 1, j * 2] = 0;
					mapx2[i * 2, j * 2 + 1] = 0;
					mapx2[i * 2 + 1, j * 2 + 1] = 0;
				}
			}
		}
	}

	private void InvertMap()
	{
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				map[i, j] = ((map[i, j] == 0) ? 1 : 0);
			}
		}
	}

	private void GenerateMap()
	{
		Flatten();
		map = new int[width, height];
		RandomFillMap();
		for (int i = 0; i < smoothTimes; i++)
		{
			SmoothMap();
		}
		InvertMap();
		ScaleMap(height, width, map);
		while (scaledHeight < height * scaleHeightMultip)
		{
			ScaleMap(scaledHeight, scaledWidth, mapx2);
		}
		FindEdges();
		for (int j = 0; j < scaledWidth; j++)
		{
			for (int k = 0; k < scaledHeight; k++)
			{
				if (mapx2[j, k] == 1)
				{
					heights[j, k] = 0.1f;
				}
				if (mapx2[j, k] == 0)
				{
					heights[j, k] = 0f;
				}
			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);
		heights2 = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
	}

	public void CalculateShores()
	{
		terrain = GetComponent<Terrain>();
		terrainreso = terrain.terrainData.heightmapResolution;
		maxRadius2 = (int)((float)maxRadius * (((float)terrainreso - 1f) / 512f));
		gridSize = scaledHeight * scaledWidth;
		calculatedPixels = 0;
		terrainDataMapHeight = terrain.terrainData.heightmapResolution;
		terrainDataMapWidth = terrain.terrainData.heightmapResolution;
		th1 = new Thread(Thread1);
		th1.Start();
	}

	public void SmoothShores()
	{
		terrain = GetComponent<Terrain>();
		terrain.terrainData.SetHeights(0, 0, heights);
		heights2 = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
	}

	private void FindEdges()
	{
		for (int i = 1; i < scaledWidth - 1; i++)
		{
			for (int j = 1; j < scaledHeight - 1; j++)
			{
				if (mapx2[i, j] != 1)
				{
					continue;
				}
				for (int k = i - 1; k < i + 2; k++)
				{
					for (int l = j - 1; l < j + 2; l++)
					{
						if (mapx2[k, l] == 0)
						{
							mapx2[k, l] = 2;
						}
					}
				}
			}
		}
	}

	private void RandomFillMap()
	{
		if (useRandomSeed)
		{
			seed = DateTime.Now.GetHashCode().ToString();
		}
		if (seed == null)
		{
			seed = "0";
		}
		System.Random random = new System.Random(seed.GetHashCode());
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
				{
					map[i, j] = 1;
				}
				else
				{
					map[i, j] = ((random.Next(0, 100) < randomFillPercent) ? 1 : 0);
				}
			}
		}
	}

	private void SmoothMap()
	{
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int surroundingWallCount = GetSurroundingWallCount(i, j);
				if (surroundingWallCount > neighboringWalls)
				{
					map[i, j] = 1;
				}
				else if (surroundingWallCount < neighboringWalls)
				{
					map[i, j] = 0;
				}
			}
		}
	}

	private int GetSurroundingWallCount(int gridX, int gridY)
	{
		int num = 0;
		for (int i = gridX - 1; i <= gridX + 1; i++)
		{
			for (int j = gridY - 1; j <= gridY + 1; j++)
			{
				if (i >= 0 && i < width && j >= 0 && j < height)
				{
					if (i != gridX || j != gridY)
					{
						num += map[i, j];
					}
				}
				else
				{
					num++;
				}
			}
		}
		return num;
	}
}
