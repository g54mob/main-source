using System;
using UnityEngine;

namespace Pathfinding
{
	[Obsolete("Use an ABPath with the ABPath.endingCondition field instead")]
	public class XPath : ABPath
	{
		[Obsolete("Use ABPath.Construct instead")]
		public new static ABPath Construct(Vector3 start, Vector3 end, OnPathDelegate callback = null)
		{
			return ABPath.Construct(start, end, callback);
		}
	}
}
