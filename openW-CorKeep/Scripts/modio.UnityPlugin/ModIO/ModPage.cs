using System;

namespace ModIO
{
	[Serializable]
	public struct ModPage
	{
		public ModProfile[] modProfiles;

		public long totalSearchResultsFound;
	}
}
