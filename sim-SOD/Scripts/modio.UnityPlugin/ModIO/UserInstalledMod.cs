using System;

namespace ModIO
{
	public struct UserInstalledMod
	{
		public bool updatePending;

		public string directory;

		public string metadata;

		public string version;

		public string changeLog;

		public DateTime dateAdded;

		public ModProfile modProfile;

		public bool enabled;
	}
}
