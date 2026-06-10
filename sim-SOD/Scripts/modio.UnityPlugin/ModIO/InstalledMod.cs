using System;
using System.Collections.Generic;

namespace ModIO
{
	public struct InstalledMod
	{
		public List<long> subscribedUsers;

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
