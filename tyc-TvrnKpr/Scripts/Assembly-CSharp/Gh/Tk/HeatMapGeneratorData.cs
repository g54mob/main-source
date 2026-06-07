using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class HeatMapGeneratorData
	{
		public string effectName;

		public Gradient lowResGradient;

		public int gradientMin;

		public int gradientMax;
	}
}
