using System;
using UnityEngine;

namespace andywiecko.BurstTriangulator
{
	[Serializable]
	public class RefinementThresholds
	{
		[field: SerializeField]
		public float Area { get; set; }

		[field: SerializeField]
		public float Angle { get; set; }
	}
}
