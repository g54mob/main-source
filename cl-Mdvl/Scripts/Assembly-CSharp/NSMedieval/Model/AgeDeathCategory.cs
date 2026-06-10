using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AgeDeathCategory
	{
		[SerializeField]
		private IntRange ageRange;

		[SerializeField]
		private float chance;

		public IntRange Range => ageRange;

		public float Chance => chance;
	}
}
