using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class OverallScaleDNAConverterPlugin : DynamicDNAPlugin
	{
		[Serializable]
		public class OverallScaleModifier
		{
			[SerializeField]
			[Tooltip("This is just a label for helping organise entries in the UI")]
			private string _label;

			[SerializeField]
			[Tooltip("If no modifying dna is specified below this scale will be fully applied to the character.")]
			private float _overallScale;

			[SerializeField]
			[Tooltip("Modify how much the overallScale above is applied to the character based on dna value(s) you specify here")]
			private DNAEvaluatorList _modifyingDNA;

			public float overallScale => 0f;

			public List<string> UsedDNANames => null;

			public float GetEvaluatedDNA(UMADnaBase umaDNA)
			{
				return 0f;
			}
		}

		[SerializeField]
		private List<OverallScaleModifier> _overallScaleModifiers;

		public List<OverallScaleModifier> overallScaleModifiers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Dictionary<string, List<int>> IndexesForDnaNames => null;

		public override void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash)
		{
		}
	}
}
