using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AgeCategory
	{
		[SerializeField]
		private IntRange ageCategory;

		[SerializeField]
		private IntRange possiblePerks;

		public IntRange Category => ageCategory;

		public IntRange PossiblePerks => possiblePerks;
	}
}
