using System;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class EpicGamesStoreData
	{
		[Tooltip("Unique ArtifactID associated with this DLC. Allows association with the binary and the EGS Offer.")]
		public string _ArtifactId;

		[Tooltip("Catalog ID for linking ownership in game")]
		public string _AudienceItemId;
	}
}
