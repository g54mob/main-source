using System;
using Data.ResourceTypes;

namespace Data.LevelData
{
	[Serializable]
	public struct ExportResource
	{
		public ResourceType ResourceType;

		public int RequiredRankForUnlock;
	}
}
