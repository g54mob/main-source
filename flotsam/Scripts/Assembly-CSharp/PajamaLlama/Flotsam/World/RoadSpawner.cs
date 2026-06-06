using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public class RoadSpawner : ISpawner
	{
		internal class RoadElement
		{
			internal Vector3 Position;

			internal Vector3 SpawnPosition;

			internal Quaternion Rotation;

			internal Quaternion SpawnRotation;

			internal int PrefabPoolIndex;

			internal GameObject Instance;

			public RoadElement(Vector3 position, Quaternion rotation)
			{
				SpawnPosition = (Position = position);
				SpawnRotation = (Rotation = rotation);
				PrefabPoolIndex = -1;
			}
		}

		[Serializable]
		public struct PersistentData
		{
			public string Name;

			public Vector2[] Nodes;

			public PersistentData(RoadSpawner roadSpawner)
			{
				Name = roadSpawner.Name;
				Nodes = roadSpawner.Nodes;
			}

			public RoadSpawner ReturnInstance()
			{
				return new RoadSpawner(Name, Nodes);
			}
		}

		private Vector3 _worldTileOffset = Vector3.zero;

		private RoadElement[] _roadElements;

		private WorldManager _worldManager;

		private static List<PrefabPool> _roadPools;

		public string Name { get; private set; }

		public ISpawnerType Type => ISpawnerType.Road;

		public Sprite Icon => null;

		public WorldTile WorldTile => null;

		public Vector3 WorldPosition => Vector3.zero;

		public Vector2 WorldPosition2D => Vector2.zero;

		public Vector2 TilePosition => Vector2.zero;

		public WorldRegionType RegionType => WorldRegionType.None;

		public ScoutingState ScoutingState => ScoutingState.Scouted;

		public Vector2[] Nodes { get; private set; }

		public ISpawnerEvent UpdatedEvent { get; }

		private RoadSpawner(string name, Vector2[] nodes)
		{
			int num = nodes.Length - 1;
			Vector2 vector = nodes[0];
			Vector2 right = Vector2.right;
			Nodes = nodes;
			_roadElements = new RoadElement[num];
			for (int i = 0; i < num; i++)
			{
				Vector2 vector2 = nodes[i + 1];
				Vector2 vector3 = vector2 - vector;
				Vector2 vector4 = vector + vector3 / 2f;
				_roadElements[i] = new RoadElement(vector4.Vector3TopDown(), Quaternion.Euler(0f, 0f - Vector2.SignedAngle(right, vector3), 0f));
				vector = vector2;
			}
			Name = name;
		}

		internal RoadSpawner(HandmadeTileGenerator.Road road)
			: this(road.Name, road.Nodes)
		{
		}

		public void Initialize()
		{
		}

		public void SetWorldTileOffset(Vector3 offset)
		{
			_worldTileOffset = offset;
			RoadElement[] roadElements = _roadElements;
			for (int i = 0; i < roadElements.Length; i++)
			{
				roadElements[i].Position += offset;
			}
		}

		public void Spawn(Transform parent = null)
		{
			if (!TryReturnWorldManager(out var worldManager))
			{
				return;
			}
			RoadElement[] roadElements = _roadElements;
			foreach (RoadElement roadElement in roadElements)
			{
				if (worldManager.IsInSpawnRadius(roadElement.SpawnPosition))
				{
					if (!roadElement.Instance)
					{
						roadElement.Instance = GetInstance(roadElement);
					}
					roadElement.Instance.transform.SetParent(parent);
					roadElement.Instance.transform.position = roadElement.SpawnPosition;
					roadElement.Instance.transform.rotation = roadElement.SpawnRotation;
				}
				else if ((bool)roadElement.Instance)
				{
					_roadPools[roadElement.PrefabPoolIndex].ReleaseInstance(roadElement.Instance);
					roadElement.Instance = null;
				}
			}
		}

		public bool Despawn(bool destroyInstance)
		{
			RoadElement[] roadElements = _roadElements;
			foreach (RoadElement roadElement in roadElements)
			{
				if ((bool)roadElement.Instance)
				{
					_roadPools[roadElement.PrefabPoolIndex].ReleaseInstance(roadElement.Instance);
					roadElement.Instance = null;
				}
			}
			return true;
		}

		public void Move(Vector3 movement)
		{
			throw new NotSupportedException();
		}

		public void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
		{
			RoadElement[] roadElements = _roadElements;
			foreach (RoadElement obj in roadElements)
			{
				Vector3 vector = obj.Position - townheartPosition;
				obj.SpawnPosition = Quaternion.Inverse(townheartRotation) * vector;
				obj.SpawnRotation = obj.Rotation * Quaternion.Inverse(townheartRotation);
			}
		}

		public void CountItems(InventoryAuditor auditor)
		{
			throw new NotSupportedException();
		}

		public float ReturnDistance(Vector3 position)
		{
			float num = float.MaxValue;
			RoadElement[] roadElements = _roadElements;
			foreach (RoadElement roadElement in roadElements)
			{
				float num2 = position.DistanceToSquared(roadElement.Position);
				if (num2 < num)
				{
					num = num2;
				}
			}
			return Mathf.Sqrt(num);
		}

		private bool TryReturnWorldManager(out WorldManager worldManager)
		{
			worldManager = _worldManager;
			if ((bool)worldManager)
			{
				return true;
			}
			worldManager = (_worldManager = GameManager.WorldManager);
			return worldManager != null;
		}

		private GameObject GetInstance(RoadElement roadElement)
		{
			if (_roadPools == null)
			{
				_roadPools = new List<PrefabPool>();
				GameObject[] roads = GameSettings.ReturnWorldSettings().Roads;
				foreach (GameObject prefab in roads)
				{
					_roadPools.Add(new PrefabPool(prefab, "Road Elements", 16));
				}
			}
			if (roadElement.PrefabPoolIndex == -1)
			{
				roadElement.PrefabPoolIndex = UnityEngine.Random.Range(0, _roadPools.Count);
			}
			return _roadPools[roadElement.PrefabPoolIndex].GetInstance();
		}
	}
}
