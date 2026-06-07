using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class WorldTileVariable : QuestVariableBase
	{
		[SerializeField]
		private WorldTileProviderBase _tileProvider;

		[NonSerialized]
		private WorldTile _worldTile;

		public override QuestVariableType Type => QuestVariableType.WorldTile;

		public WorldTileVariable()
		{
		}

		public WorldTileVariable(WorldTileVariable other)
			: base(other)
		{
			_tileProvider = other._tileProvider;
		}

		public override object Clone()
		{
			return new WorldTileVariable(this);
		}

		public override bool Initialize()
		{
			return true;
		}

		public override bool Validate()
		{
			if (_worldTile != null)
			{
				return _worldTile.IsActive;
			}
			return true;
		}

		protected override T Get<T>()
		{
			if (_worldTile == null)
			{
				_worldTile = GetWorldTile();
			}
			WorldTile worldTile = _worldTile;
			if (worldTile is T)
			{
				return (T)(object)((worldTile is T) ? worldTile : null);
			}
			return default(T);
		}

		private WorldTile GetWorldTile()
		{
			if (GameManager.WorldManager == null || GameManager.WorldManager.World == null)
			{
				return null;
			}
			global::World world = GameManager.WorldManager.World;
			foreach (WorldTile tile in world.Tiles)
			{
				if (_tileProvider.Contains(tile.SubTileGeneratorPrefab))
				{
					_worldTile = tile;
					break;
				}
			}
			_worldTile = _tileProvider.GetNextWorldTile(world);
			world.AddNextTile(_worldTile, synchronous: true);
			return _worldTile;
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			return true;
		}

		public override bool TryGetPersistentData(out IPersistentData persistentData)
		{
			persistentData = null;
			return false;
		}

		public override bool TryRestorePersistentData(IPersistentData persistentData)
		{
			return false;
		}
	}
}
