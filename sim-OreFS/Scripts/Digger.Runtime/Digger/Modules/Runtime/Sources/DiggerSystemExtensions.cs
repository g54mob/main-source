using System.IO;
using Digger.Modules.Core.Sources;

namespace Digger.Modules.Runtime.Sources
{
	public static class DiggerSystemExtensions
	{
		public static void PersistAtRuntime(this DiggerSystem digger)
		{
			if (digger.DisablePersistence)
			{
				return;
			}
			if (!Directory.Exists(digger.PersistentRuntimePathData))
			{
				Directory.CreateDirectory(digger.PersistentRuntimePathData);
			}
			foreach (VoxelChunk item in digger.ChunksToPersist)
			{
				item.Persist();
			}
			digger.ChunksToPersist.Clear();
			digger.Cutter.SaveTo(digger.TerrainHolesRuntimePath);
		}

		public static void DeleteDataPersistedAtRuntime(this DiggerSystem digger)
		{
			if (Directory.Exists(digger.PersistentRuntimePathData))
			{
				Directory.Delete(digger.PersistentRuntimePathData, recursive: true);
			}
		}

		public static void OnPreprocessBuild(this DiggerSystem digger, bool includeVoxelData)
		{
		}
	}
}
