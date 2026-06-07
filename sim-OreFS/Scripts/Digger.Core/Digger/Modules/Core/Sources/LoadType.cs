namespace Digger.Modules.Core.Sources
{
	public struct LoadType
	{
		public static LoadType Minimal = new LoadType
		{
			loadVoxels = false,
			rebuildMeshes = false,
			syncVoxelsWithTerrain = false
		};

		public static LoadType Minimal_and_LoadVoxels = new LoadType
		{
			loadVoxels = true,
			rebuildMeshes = false,
			syncVoxelsWithTerrain = false
		};

		public static LoadType Minimal_and_LoadVoxels_and_RebuildMeshes = new LoadType
		{
			loadVoxels = true,
			rebuildMeshes = true,
			syncVoxelsWithTerrain = false
		};

		public static LoadType Minimal_and_LoadVoxels_and_SyncVoxelsWithTerrain_and_RebuildMeshes = new LoadType
		{
			loadVoxels = true,
			rebuildMeshes = true,
			syncVoxelsWithTerrain = true
		};

		private bool loadVoxels;

		private bool rebuildMeshes;

		private bool syncVoxelsWithTerrain;

		public bool LoadVoxels => loadVoxels;

		public bool RebuildMeshes => rebuildMeshes;

		public bool SyncVoxelsWithTerrain => syncVoxelsWithTerrain;

		public override string ToString()
		{
			return $"LoadType(loadVoxels={loadVoxels}, rebuildMeshes={rebuildMeshes}, syncVoxelsWithTerrain={syncVoxelsWithTerrain})";
		}

		public bool Equals(LoadType other)
		{
			if (loadVoxels == other.loadVoxels && rebuildMeshes == other.rebuildMeshes)
			{
				return syncVoxelsWithTerrain == other.syncVoxelsWithTerrain;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is LoadType other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((loadVoxels.GetHashCode() * 397) ^ rebuildMeshes.GetHashCode()) * 397) ^ syncVoxelsWithTerrain.GetHashCode();
		}

		public static bool operator ==(LoadType a, LoadType b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(LoadType a, LoadType b)
		{
			return !(a == b);
		}
	}
}
