using System;
using UnityEngine;

namespace andywiecko.BurstTriangulator
{
	[Serializable]
	public class TriangulationSettings
	{
		[field: SerializeField]
		public bool AutoHolesAndBoundary { get; set; }

		[field: SerializeField]
		public RefinementThresholds RefinementThresholds { get; }

		[field: SerializeField]
		public bool RefineMesh { get; set; }

		[field: SerializeField]
		public bool ValidateInput { get; set; }

		[field: SerializeField]
		public bool Verbose { get; set; }

		[field: SerializeField]
		public bool RestoreBoundary { get; set; }

		[field: SerializeField]
		public int SloanMaxIters { get; set; }

		[field: SerializeField]
		public Preprocessor Preprocessor { get; set; }
	}
}
