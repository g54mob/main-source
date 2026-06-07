using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct AIStandSituation
	{
		public Vector2Int standID;

		public bool hasAccess;

		public int index;

		public AIStandSituation(Stand stand, bool hasAccess = false, int index = -1)
		{
			if (stand == null)
			{
				standID = Vector2Int.zero;
				this.hasAccess = false;
				this.index = -1;
			}
			else
			{
				standID = stand.ID;
				this.hasAccess = hasAccess;
				this.index = index;
			}
		}
	}
}
