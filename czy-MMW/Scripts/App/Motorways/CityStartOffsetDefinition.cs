using System;
using FixMath;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class CityStartOffsetDefinition
	{
		[Tooltip("The camera starting offset")]
		public Vector3Fixed fixedPosition;

		[Tooltip("The variance from this position")]
		public Fix64 variance;
	}
}
