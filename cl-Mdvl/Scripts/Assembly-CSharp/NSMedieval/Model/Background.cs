using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Background : BackgroundBase
	{
		[SerializeField]
		private FloatRange weightCoefficientRange;

		[SerializeField]
		private IntRange ageRange;

		public FloatRange WeightCoefficientRange => weightCoefficientRange;

		public IntRange AgeRange => ageRange;
	}
}
