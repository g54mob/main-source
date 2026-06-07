using System.Collections.Generic;
using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class RuntimeTerrains : MonoBehaviour
	{
		private float frames;

		public bool moveTerrainsWithCamera;

		public Transform mainCamera;

		private float terrainSize;

		private float totalSize;

		private Vector3[] initPos;

		private Vector3 oldPos;

		private float relativePos;

		private float newPos;

		private float offset;

		public List<TCUnityTerrain> tcTerrains = new List<TCUnityTerrain>();

		public TC_TerrainArea terrainArea;

		private List<TCUnityTerrain> taskList = new List<TCUnityTerrain>();

		private void Start()
		{
			if (moveTerrainsWithCamera)
			{
				if (mainCamera == null)
				{
					Debug.Log("Assign the Main Camera");
					Debug.Break();
				}
				UpdateMoveTerrain();
			}
		}

		private void OnEnable()
		{
			terrainArea = TC_Area2D.current.terrainAreas[0];
			tcTerrains = terrainArea.terrains;
			Start();
		}

		private void Update()
		{
			UpdateMoveTerrain();
		}

		private void UpdateMoveTerrain()
		{
			if (terrainArea == null || mainCamera == null)
			{
				return;
			}
			if (initPos == null || initPos.Length != tcTerrains.Count)
			{
				StartMoveTerrains();
			}
			UpdateTerrainPositionsX();
			UpdateTerrainPositionsZ();
			if (taskList.Count > 0)
			{
				for (int i = 0; i < taskList.Count; i++)
				{
					TC_Generate.instance.Generate(taskList[i], instantGenerate: false);
				}
				taskList.Clear();
			}
		}

		private void StartMoveTerrains()
		{
			terrainSize = tcTerrains[0].terrain.terrainData.size.x;
			totalSize = (float)terrainArea.tiles.x * terrainSize;
			initPos = new Vector3[tcTerrains.Count];
			terrainArea.AssignTerrainArray();
			for (int i = 0; i < tcTerrains.Count; i++)
			{
				initPos[i] = tcTerrains[i].terrain.transform.position;
			}
			offset = terrainSize / 2f;
			_ = totalSize / terrainSize % 2f;
			_ = 0f;
		}

		private void UpdateTerrainPositionsX()
		{
			for (int i = 0; i < tcTerrains.Count; i++)
			{
				TCUnityTerrain tCUnityTerrain = tcTerrains[i];
				Terrain terrain = tCUnityTerrain.terrain;
				relativePos = mainCamera.position.x - initPos[i].x;
				newPos = Mathf.Round((relativePos - offset) / totalSize) * totalSize + initPos[i].x;
				if (terrain.transform.position.x != newPos)
				{
					_ = newPos;
					_ = terrain.transform.position.x;
					tCUnityTerrain.newPos = new Vector3(newPos, terrain.transform.position.y, terrain.transform.position.z);
					tCUnityTerrain.updateTerrainPos = true;
					tCUnityTerrain.active = true;
					taskList.Add(tCUnityTerrain);
				}
			}
			oldPos.x = Mathf.Round(mainCamera.position.x / terrainSize) * terrainSize;
		}

		private void UpdateTerrainPositionsZ()
		{
			for (int i = 0; i < tcTerrains.Count; i++)
			{
				TCUnityTerrain tCUnityTerrain = tcTerrains[i];
				Terrain terrain = tCUnityTerrain.terrain;
				relativePos = mainCamera.position.z - initPos[i].z;
				newPos = Mathf.Round((relativePos - offset) / totalSize) * totalSize + initPos[i].z;
				if (terrain.transform.position.z == newPos)
				{
					continue;
				}
				if (newPos > terrain.transform.position.z)
				{
					tCUnityTerrain.tileZ = terrainArea.tiles.y - 1;
					for (int j = 1; j < terrainArea.tiles.y; j++)
					{
						terrainArea.GetTCUnityTerrainTile(tCUnityTerrain.tileX, j).tileZ = j - 1;
					}
				}
				else
				{
					tCUnityTerrain.tileZ = 0;
					for (int k = 0; k < terrainArea.tiles.y - 1; k++)
					{
						terrainArea.GetTCUnityTerrainTile(tCUnityTerrain.tileX, k).tileZ = k + 1;
					}
				}
				tCUnityTerrain.newPos = new Vector3(terrain.transform.position.x, terrain.transform.position.y, newPos);
				tCUnityTerrain.updateTerrainPos = true;
				tCUnityTerrain.active = true;
				if (!taskList.Contains(tCUnityTerrain))
				{
					taskList.Add(tCUnityTerrain);
				}
			}
			oldPos.z = Mathf.Round(mainCamera.position.z / terrainSize) * terrainSize;
		}
	}
}
