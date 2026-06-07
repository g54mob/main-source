using System;
using System.Collections.Generic;
using UMA.PoseTools;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class BonePoseDNAConverterPlugin : DynamicDNAPlugin
	{
		[Serializable]
		public class BonePoseDNAConverter
		{
			[Tooltip("The UMABonePose to apply to the character. This will effectively 'morph' the character into a different shape (using bone deformation so clothes will still fit).")]
			[SerializeField]
			private UMABonePose _poseToApply;

			[SerializeField]
			[Tooltip("Make the default weight 1 to apply the pose on start to *all* characters that use this converter or set to 0 so the pose is only applied by 'Modifying DNA' below. If you want to affect this 'per character' use 'Modifying DNA' instead")]
			[Range(0f, 1f)]
			private float _startingPoseWeight;

			[SerializeField]
			[Tooltip("Add dna(s) here that will change the amount that this Pose is applied depending on their evaluated value.")]
			private DNAEvaluatorList _modifyingDNA;

			private float _livePoseWeight;

			private DynamicUMADnaBase _activeDNA;

			public UMABonePose poseToApply
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float startingPoseWeight
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

			public BonePoseDNAConverter()
			{
			}

			public BonePoseDNAConverter(UMABonePose poseToApply, float startingPoseWeight, DNAEvaluatorList modifyingDnas)
			{
			}

			public BonePoseDNAConverter(UMABonePose poseToApply, float startingPoseWeight = 0f, List<DNAEvaluator> modifyingDnas = null)
			{
			}

			public BonePoseDNAConverter(BonePoseDNAConverter other)
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
		private List<BonePoseDNAConverter> _poseDNAConverters;

		public List<BonePoseDNAConverter> poseDNAConverters
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UMABonePose StartingPose
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float StartingPoseWeight
		{
			get
			{
				return 0f;
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
