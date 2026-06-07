using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class ScenarioWorldTileProvider : IWorldTileProvider
	{
		public class QueuedWorldTile
		{
			public TileGeneratorBase Worldtile { get; private set; }

			public int Index { get; private set; }

			public QueuedWorldTile(TileGeneratorBase worldTile, int index)
			{
				Worldtile = worldTile;
				Index = index;
			}
		}

		[Serializable]
		public struct QueuedWorldTilePersistentData
		{
			public int WorldTileIndex;

			public int Index;

			public QueuedWorldTilePersistentData(QueuedWorldTile instance)
			{
				WorldTileIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(instance.Worldtile);
				Index = instance.Index;
			}
		}

		[SerializeField]
		private List<TileGeneratorBase> _startTiles = new List<TileGeneratorBase>();

		[SerializeField]
		private List<ScenarioTileProvider> _tileProviders = new List<ScenarioTileProvider>();

		private readonly List<QueuedWorldTile> _queuedWorldTiles = new List<QueuedWorldTile>();

		public IReadOnlyList<QueuedWorldTile> QueuedWorldTiles => _queuedWorldTiles;

		public void QueueStartTiles()
		{
			foreach (TileGeneratorBase startTile in _startTiles)
			{
				QueueWorldTile(startTile);
			}
		}

		public void QueueWorldTile(TileGeneratorBase WorldTile, int indexOffset = 0, int minimumIndex = 0)
		{
			int num = Mathf.Max(WorldManager.ReturnLastTileIndex() + indexOffset, minimumIndex);
			foreach (QueuedWorldTile queuedWorldTile in _queuedWorldTiles)
			{
				if (queuedWorldTile.Index >= num)
				{
					if (queuedWorldTile.Index == num)
					{
						num++;
					}
					if (num < queuedWorldTile.Index)
					{
						_queuedWorldTiles.Insert(num, new QueuedWorldTile(WorldTile, num));
						return;
					}
				}
			}
			_queuedWorldTiles.Add(new QueuedWorldTile(WorldTile, num));
		}

		public WorldTile GetNextWorldTile(global::World world, ILandmarkPicker landmarkPicker = null)
		{
			if (TryDequeueWorldTile(WorldManager.ReturnLastTileIndex() + 1, out var worldTile))
			{
				return new WorldTile(world.TileProperties.TileGenerator, worldTile);
			}
			if (TryGetWorldTile(out var worldTile2, world, landmarkPicker))
			{
				return worldTile2;
			}
			return null;
		}

		private bool TryDequeueWorldTile(int index, out TileGeneratorBase worldTile)
		{
			if (_queuedWorldTiles.Count > 0)
			{
				QueuedWorldTile queuedWorldTile = _queuedWorldTiles[0];
				if (queuedWorldTile.Index <= index)
				{
					if (queuedWorldTile.Index < index)
					{
						Debug.LogWarning("Encountered queued world tile with index that is lower than the index of the last active world tile... whoops?!");
					}
					worldTile = queuedWorldTile.Worldtile;
					_queuedWorldTiles.RemoveAt(0);
					return true;
				}
			}
			worldTile = null;
			return false;
		}

		private bool TryGetWorldTile(out WorldTile worldTile, global::World world, ILandmarkPicker landmarkPicker)
		{
			foreach (ScenarioTileProvider tileProvider in _tileProviders)
			{
				if (tileProvider.TryGetWorldTile(out worldTile, world, landmarkPicker))
				{
					return true;
				}
			}
			Debug.LogException(new Exception("Active scenario was unable to generate next WorldTile."));
			worldTile = null;
			return false;
		}

		public void Restore(QueuedWorldTilePersistentData[] queuedWorldTiles)
		{
			for (int i = 0; i < queuedWorldTiles.Length; i++)
			{
				QueuedWorldTilePersistentData queuedWorldTilePersistentData = queuedWorldTiles[i];
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<TileGeneratorBase>(queuedWorldTilePersistentData.WorldTileIndex, out var reference))
				{
					_queuedWorldTiles.Add(new QueuedWorldTile(reference, queuedWorldTilePersistentData.Index));
				}
				else
				{
					Debug.LogException(new PersistenceException("Unable to restore QueuedWorldTile!"));
				}
			}
		}
	}
}
