using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	public struct ModDependencies
	{
		public ModId modId;

		public string modName;

		public DateTime dateAdded;
	}
}
