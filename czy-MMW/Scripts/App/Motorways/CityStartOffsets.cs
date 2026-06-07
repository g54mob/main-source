using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class CityStartOffsets
	{
		[Tooltip("The positions that the game can begin in")]
		public List<CityStartOffsetDefinition> offsets;

		public int Count
		{
			get
			{
				if (offsets != null)
				{
					return offsets.Count;
				}
				return 0;
			}
		}
	}
}
