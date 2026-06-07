using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LightTower;
using UnityEngine;

[RequireComponent(typeof(PathGenerator), typeof(GroundGenerator), typeof(EnvironmentGenerator))]
public class MapGenerator : MonoBehaviour, ISavable
{
	[SerializeField]
	private int customSeed = -1;

	[Savable("seed", true, false)]
	private int seed = -1;

	[SerializeField]
	[Tooltip("Tamaño minimo del mapa, pudiendo ser mayor dependiendo del tamaño del path generado")]
	private Vector2Int minMapSize = Vector2Int.zero;

	[SerializeField]
	[Tooltip("Distancia minima desde el borde del mapa hasta una casilla de path")]
	private int pathBorderMargin = 15;

	[SerializeField]
	[Tooltip("Distancia minima desde el borde del mapa hasta la casilla inicial del path")]
	private int startingPathBorderMargin = 10;

	[SerializeField]
	[Tooltip("Distancia minima desde el borde del mapa hasta la casilla final del path")]
	private int endingPathBorderMargin = 10;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Define la variación que puede haber en la posición del path con respecto al centro.")]
	private float pathCenteringVariation;

	private PathGenerator pathGenerator;

	private GroundGenerator groundGenerator;

	private EnvironmentGenerator environmentGenerator;

	private Grid grid;

	public Grid Grid
	{
		get
		{
			return grid;
		}
		set
		{
			grid = value;
		}
	}

	public PathGenerator PathGenerator
	{
		get
		{
			if (!pathGenerator)
			{
				PathGenerator = GetComponent<PathGenerator>();
			}
			return pathGenerator;
		}
		set
		{
			pathGenerator = value;
		}
	}

	public GroundGenerator GroundGenerator
	{
		get
		{
			if (!groundGenerator)
			{
				GroundGenerator = GetComponent<GroundGenerator>();
			}
			return groundGenerator;
		}
		set
		{
			groundGenerator = value;
		}
	}

	public EnvironmentGenerator EnvironmentGenerator
	{
		get
		{
			if (!environmentGenerator)
			{
				EnvironmentGenerator = GetComponent<EnvironmentGenerator>();
			}
			return environmentGenerator;
		}
		set
		{
			environmentGenerator = value;
		}
	}

	private void SetupSeed()
	{
		if (customSeed < 0)
		{
			seed = DateTime.Now.Millisecond;
		}
		else
		{
			seed = customSeed;
		}
		UnityEngine.Random.InitState(seed);
	}

	public IEnumerator GenerateMapCoroutine()
	{
		yield return null;
		SetupSeed();
		bool flag = false;
		int maxRegenerationSteps = 5;
		if (Application.isPlaying)
		{
			maxRegenerationSteps = 15;
		}
		int currentRegenerationStep = 0;
		while (!flag && currentRegenerationStep < maxRegenerationSteps)
		{
			UnityEngine.Debug.Log("---- STARTING MAP GENERATION ----");
			base.transform.DeleteAllChildrenImmediate();
			bool flag2 = false;
			int num = 0;
			Stopwatch stopwatchTotal = new Stopwatch();
			stopwatchTotal.Start();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (!flag2)
			{
				flag2 = PathGenerator.GeneratePath();
				num++;
			}
			stopwatch.Stop();
			UnityEngine.Debug.Log("PATH: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s (in " + num + " steps)");
			Vector2 zero = Vector2.zero;
			Vector2 vector = PathGenerator.GetPathBoundingSize();
			zero.x = Mathf.Max(minMapSize.x, vector.x + (float)(pathBorderMargin * 2));
			zero.y = Mathf.Max(minMapSize.y, vector.y + (float)(pathBorderMargin * 2));
			int num2 = Mathf.RoundToInt(zero.x - (vector.x + (float)(pathBorderMargin * 2)));
			int num3 = Mathf.RoundToInt(zero.y - (vector.y + (float)(pathBorderMargin * 2)));
			int num4 = Mathf.FloorToInt((float)UnityEngine.Random.Range(-num2, num2 + 1) * 0.5f * pathCenteringVariation);
			int num5 = Mathf.FloorToInt((float)UnityEngine.Random.Range(-num3, num3 + 1) * 0.5f * pathCenteringVariation);
			PathGenerator.SetPathPosition(new Vector2(Mathf.RoundToInt((float)pathBorderMargin + (float)num2 * 0.5f + (float)num4), Mathf.RoundToInt((float)pathBorderMargin + (float)num3 * 0.5f + (float)num5)));
			if (startingPathBorderMargin > 0)
			{
				Vector3 position = PathGenerator.FirstPathTile.Key.transform.position;
				if (position.x < (float)startingPathBorderMargin)
				{
					PathGenerator.AddPathPosition(Vector2.right * ((float)startingPathBorderMargin - position.x));
					position += Vector3.right * ((float)startingPathBorderMargin - position.x);
				}
				if (zero.x - position.x < (float)startingPathBorderMargin)
				{
					zero.x += (float)startingPathBorderMargin - (zero.x - position.x);
				}
				if (position.z < (float)startingPathBorderMargin)
				{
					PathGenerator.AddPathPosition(Vector2.up * ((float)startingPathBorderMargin - position.z));
					position += Vector3.forward * ((float)startingPathBorderMargin - position.z);
				}
				if (zero.y - position.z < (float)startingPathBorderMargin)
				{
					zero.y += (float)startingPathBorderMargin - (zero.y - position.z);
				}
			}
			if (endingPathBorderMargin > 0)
			{
				Vector3 position2 = PathGenerator.LastPathTile.Key.transform.position;
				if (position2.x < (float)endingPathBorderMargin)
				{
					PathGenerator.AddPathPosition(Vector2.right * ((float)endingPathBorderMargin - position2.x));
					position2 += Vector3.right * ((float)endingPathBorderMargin - position2.x);
				}
				if (zero.x - position2.x < (float)endingPathBorderMargin)
				{
					zero.x += (float)endingPathBorderMargin - (zero.x - position2.x);
				}
				if (position2.z < (float)endingPathBorderMargin)
				{
					PathGenerator.AddPathPosition(Vector2.up * ((float)endingPathBorderMargin - position2.z));
					position2 += Vector3.forward * ((float)endingPathBorderMargin - position2.z);
				}
				if (zero.y - position2.z < (float)endingPathBorderMargin)
				{
					zero.y += (float)endingPathBorderMargin - (zero.y - position2.z);
				}
			}
			Grid = new Grid((int)zero.x, (int)zero.y);
			Grid obj = Grid;
			Tile[] pathTiles = PathGenerator.GetPathTiles();
			obj.AddGridCells(pathTiles);
			yield return GroundGenerator.GenerateGround(PathGenerator.FirstPathTile, PathGenerator.LastPathTile, Grid, PathGenerator.GetPathTiles());
			yield return null;
			bool forceEndGeneration = currentRegenerationStep == maxRegenerationSteps - 1;
			flag = EnvironmentGenerator.GenerateEnvironment(PathGenerator.FirstPathTile, PathGenerator.LastPathTile, Grid, PathGenerator.GetPathTiles(), forceEndGeneration);
			stopwatchTotal.Stop();
			if (!flag)
			{
				currentRegenerationStep++;
				UnityEngine.Debug.Log("<color=red><b>ERROR generating a critical part of map. Restarting. (" + currentRegenerationStep + "/" + maxRegenerationSteps + ")</b></color>");
				UnityEngine.Debug.Log("---------------------------------");
				if (customSeed < 0)
				{
					SetupSeed();
				}
			}
			else
			{
				UnityEngine.Debug.Log("<color=cyan><b>TOTAL: " + (float)stopwatchTotal.ElapsedMilliseconds / 1000f + "s</b></color>");
				UnityEngine.Debug.Log("---------------------------------");
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.Log("<color=red>Unable to generate the map correctly after " + currentRegenerationStep + " attempts.</color>");
		}
		else
		{
			UnityEngine.Debug.Log("<color=green><b>MAP GENERATED SUCCESSFULLY!</b></color>");
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (seed >= 0)
		{
			customSeed = seed;
		}
	}
}
