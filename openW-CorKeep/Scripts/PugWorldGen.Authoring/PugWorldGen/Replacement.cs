using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	[Serializable]
	public struct Replacement
	{
		[Serializable]
		public struct WeightedVariationList
		{
			[ArrayElementTitle("value, weight")]
			public List<ValueWithWeight<int>> value;
		}

		[Header("Object to replace")]
		public ObjectID replaceID;

		public OptionalValue<int> replaceVariation;

		[Header("Replace with")]
		public ObjectID replaceWithID;

		public bool advancedVariationControl;

		[AllowNesting]
		[HideIf("advancedVariationControl")]
		[MinMax(0f, 100f)]
		public Pug.UnityExtensions.RangeInt variation;

		[AllowNesting]
		[ShowIf("advancedVariationControl")]
		public WeightedVariationList weightedVariations;
	}
}
