using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class BlendshapeDNAConverterPlugin : DynamicDNAPlugin
	{
		[Serializable]
		public class BlendshapeDNAConverter
		{
			[Tooltip("The Blendshape to apply to the character.")]
			[SerializeField]
			private string _blendshapeToApply;

			[SerializeField]
			[Tooltip("Make the default weight 1 to apply the blendshape on start to *all* characters that use this converter or set to 0 so the shape is only applied by 'Modifying DNA' below. If you want to affect this 'per character' use 'Modifying DNA' instead")]
			[Range(0f, 1f)]
			private float _startingShapeWeight;

			[SerializeField]
			[Tooltip("Add dna(s) here that will change the amount that this blendshape is applied depending on their evaluated value.")]
			private DNAEvaluatorList _modifyingDNA;

			private float _liveShapeWeight;

			private DynamicUMADnaBase _activeDNA;

			public string blendshapeToApply
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float startingShapeWeight
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public DNAEvaluatorList modifyingDNA
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public List<string> UsedDNANames => null;

			public BlendshapeDNAConverter()
			{
			}

			public BlendshapeDNAConverter(string blendshapeToApply, float startingShapeWeight, DNAEvaluatorList modifyingDnas)
			{
			}

			public BlendshapeDNAConverter(string shapeToApply, float startingShapeWeight = 0f, List<DNAEvaluator> modifyingDnas = null)
			{
			}

			public BlendshapeDNAConverter(BlendshapeDNAConverter other)
			{
			}

			public void ApplyDNA(UMAData umaData, UMASkeleton skeleton, UMADnaBase activeDNA, float masterWeight = 1f)
			{
			}

			public void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash, float masterWeight = 1f)
			{
			}
		}

		[SerializeField]
		private List<BlendshapeDNAConverter> _blendshapeDNAConverters;

		public List<BlendshapeDNAConverter> blendshapeDNAConverters
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

		public override ApplyPassOpts ApplyPass => default(ApplyPassOpts);

		public override void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash)
		{
		}
	}
}
