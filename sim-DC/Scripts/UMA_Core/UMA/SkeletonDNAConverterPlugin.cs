using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class SkeletonDNAConverterPlugin : DynamicDNAPlugin
	{
		[SerializeField]
		private List<SkeletonModifier> _skeletonModifiers;

		public List<SkeletonModifier> skeletonModifiers
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

		public void AddModifier(SkeletonModifier modifier)
		{
		}

		public override void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash)
		{
		}

		private List<string> SkeletonModifierUsedDNANames(SkeletonModifier skeletonModifier, bool searchLegacy = false, string dnaName = "")
		{
			return null;
		}
	}
}
