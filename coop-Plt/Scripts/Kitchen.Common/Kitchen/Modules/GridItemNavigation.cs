using System;
using UnityEngine;

namespace Kitchen.Modules
{
	[Serializable]
	public struct GridItemNavigation : IGridItem
	{
		public GridMenuConfig Config;

		public int SnapshotKey => 0;

		public Texture2D GetSnapshot()
		{
			return Config.Icon;
		}

		public static implicit operator GridItemNavigation(GridMenuConfig config)
		{
			return new GridItemNavigation
			{
				Config = config
			};
		}
	}
}
