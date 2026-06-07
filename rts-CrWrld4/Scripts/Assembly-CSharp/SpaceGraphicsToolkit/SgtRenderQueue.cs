using System;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtRenderQueue
	{
		public enum GroupType
		{
			Background = 1000,
			Geometry = 2000,
			AlphaTest = 2450,
			Transparent = 3000,
			Overlay = 4000
		}

		public GroupType Group;

		public int Offset;

		public SgtRenderQueue(GroupType newGroup, int newOffset)
		{
			Group = default(GroupType);
			Offset = 0;
		}

		public static implicit operator int(SgtRenderQueue renderQueue)
		{
			return 0;
		}

		public static implicit operator SgtRenderQueue(GroupType newGroup)
		{
			return default(SgtRenderQueue);
		}
	}
}
