using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class StandAloneDNA : MonoBehaviour
	{
		private List<UMADnaBase> DNA;

		public List<UMAPackedRecipeBase.UMAPackedDna> PackedDNA;

		public AvatarDefinition avatarDefinition;

		public UMAData umaData;

		public RaceData originalRace;

		private Dictionary<string, DnaSetter> dna;

		private void Start()
		{
		}

		public void LoadDNAFromAvatarDefinition(AvatarDefinition adf)
		{
		}

		public AvatarDefinition SaveDNAToAvatarDefinition()
		{
			return default(AvatarDefinition);
		}

		public Dictionary<string, DnaSetter> GetDNA(UMAData.UMARecipe recipe = null)
		{
			return null;
		}
	}
}
