using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation
{
	[Serializable]
	internal class ModCollectionEntry
	{
		public ModfileObject currentModfile;

		public ModObject modObject;

		public bool uninstallIfNotSubscribedToCurrentSession;
	}
}
