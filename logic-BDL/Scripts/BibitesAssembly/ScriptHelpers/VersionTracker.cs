using System.Collections.Generic;
using System.Linq;
using Utility;

namespace ScriptHelpers
{
	public static class VersionTracker
	{
		private static List<SaveFileChange> saveFilesChanges = new List<SaveFileChange>
		{
			new SaveFileChange
			{
				version = new Version(0, 6, 0, 15)
			},
			new SaveFileChange
			{
				version = new Version(0, 6, 0, 10)
			},
			new SaveFileChange
			{
				version = new Version(0, 6, 0, 4)
			},
			new SaveFileChange
			{
				version = new Version(0, 5, 0, 4)
			},
			new SaveFileChange
			{
				version = new Version(0, 5, 0, 1)
			},
			new SaveFileChange
			{
				version = new Version(0, 4, 2, 1)
			},
			new SaveFileChange
			{
				version = new Version(0, 4),
				canUpdateFromOlderVersion = false
			},
			new SaveFileChange
			{
				version = new Version(0, 3),
				canUpdateFromOlderVersion = false
			}
		};

		public static bool ChangesSinceVersion(Version fromVersion)
		{
			SaveFileChange saveFileChange = saveFilesChanges.OrderByDescending((SaveFileChange v) => v.version).FirstOrDefault();
			if (saveFileChange != null)
			{
				return saveFileChange.version > fromVersion;
			}
			return false;
		}

		public static bool CanUpdateFromVersion(Version fromVersion)
		{
			foreach (SaveFileChange item in saveFilesChanges.OrderByDescending((SaveFileChange v) => v.version))
			{
				if (fromVersion >= item.version)
				{
					break;
				}
				if (!item.canUpdateFromOlderVersion)
				{
					return false;
				}
			}
			return BrainUpdater.CanUpdateFromVersion(fromVersion);
		}
	}
}
