using System;
using System.Collections.Generic;
using Services.Save;
using Services.Save.Player;
using UnityEngine;
using WorldEnvironment.Foliage;
using WorldEnvironment.Structures;
using Zenject;

namespace WorldEnvironment.Islands
{
	public class IslandWorldSpawner : MonoBehaviour, IInitializable
	{
		[Header("Links")]
		[SerializeField]
		private IslandObjectView[] _islandPrefabs;

		[SerializeField]
		private Transform _mainIsland;

		[SerializeField]
		private WorldParams _worldParms;

		[Header("Structures")]
		[SerializeField]
		private StructureSpawnConfig _structureConfig;

		[Header("Foliage")]
		[SerializeField]
		private FoliageSpawnConfig _foliageConfig;

		[Header("Island Height")]
		[Tooltip("Максимально на скільки опустити острів вниз від його базової позиції. Острів зміститься по Y на рандомне значення від 0 до -MaxHeightOffset.")]
		[SerializeField]
		private float _maxHeightOffset = 20f;

		private StructureGenerator _structureGenerator;

		private FoliageGenerator _foliageGenerator;

		private List<IslandObjectView> _spawnedIslands = new List<IslandObjectView>();

		[Inject]
		private WorldGridManager _worldGridManager;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private PlayerSaveService _playerSaveService;

		public List<IslandObjectView> SpawnedIslands => _spawnedIslands;

		public event Action OnIslandSpawned;

		public void Initialize()
		{
			if (_structureConfig != null)
			{
				_structureGenerator = new StructureGenerator(_structureConfig, _diContainer);
			}
			else
			{
				Debug.LogWarning("[IslandWorldSpawner] StructureSpawnConfig не призначено!");
			}
			if (_foliageConfig != null)
			{
				_foliageGenerator = new FoliageGenerator(_foliageConfig);
			}
			else
			{
				Debug.LogWarning("[IslandWorldSpawner] FoliageSpawnConfig не призначено!");
			}
			if (_playerSaveService.IsLoaded)
			{
				RenderIslands(5);
			}
			else
			{
				_saveService.OnLoadCompleted += OnSaveServiceLoaded;
			}
		}

		private void OnSaveServiceLoaded()
		{
			_saveService.OnLoadCompleted -= OnSaveServiceLoaded;
			RenderIslands(5);
		}

		private void RenderIslands(int range)
		{
			for (int i = -range; i < range; i++)
			{
				for (int j = -range; j < range; j++)
				{
					IslandWorldGrid gridAt = _worldGridManager.GetGridAt(i, j);
					int length = gridAt.IslandGrid.GetLength(0);
					int length2 = gridAt.IslandGrid.GetLength(1);
					for (int k = 0; k < length; k++)
					{
						for (int l = 0; l < length2; l++)
						{
							if (gridAt.IslandGrid[k, l] > 1)
							{
								int num = length - 1 - k;
								Vector3 cellWorldPos = gridAt.GetCellWorldPos(l, num, _mainIsland.position);
								RenderIsland(cellWorldPos, gridAt.GridX, gridAt.GridY, l, num);
							}
						}
					}
				}
			}
			this.OnIslandSpawned?.Invoke();
		}

		private void RenderIsland(Vector3 pos, int chunkX, int chunkY, int cellX, int cellY)
		{
			System.Random random = new System.Random(_worldParms.Seed ^ ((cellX * 15485863) ^ (chunkX * 73856093)) ^ ((cellY * 32452843) ^ (chunkY * 49979687)));
			int num = random.Next(_islandPrefabs.Length);
			IslandObjectView original = _islandPrefabs[num];
			float num2 = 0f - (float)(random.NextDouble() * (double)_maxHeightOffset);
			Vector3 vector = new Vector3(pos.x, pos.y + num2, pos.z);
			IslandObjectView islandObjectView = UnityEngine.Object.Instantiate(original, vector, Quaternion.identity, base.transform);
			islandObjectView.name = $"Island [Chunk {chunkX},{chunkY}] (Cell {cellX},{cellY})";
			islandObjectView.Init(chunkX, chunkY, cellX, cellY);
			_spawnedIslands.Add(islandObjectView);
			int seed = _worldParms.Seed;
			List<(Vector3 pos, float radius)> structureZones = new List<(Vector3, float)>();
			if (_structureGenerator != null)
			{
				_structureGenerator.ClearData();
				_structureGenerator.SpawnStructuresOnIsland(vector, cellX, cellY, seed, islandObjectView.transform, delegate(Vector3 structurePos, float clearanceRadius)
				{
					structureZones.Add((structurePos, clearanceRadius));
				});
			}
			if (_foliageGenerator == null)
			{
				return;
			}
			_foliageGenerator.ClearData();
			foreach (var item in structureZones)
			{
				_foliageGenerator.AddForbiddenZone(item.pos, item.radius);
			}
			_foliageGenerator.SpawnFoliageOnIsland(vector, cellX, cellY, seed, islandObjectView.transform);
		}
	}
}
