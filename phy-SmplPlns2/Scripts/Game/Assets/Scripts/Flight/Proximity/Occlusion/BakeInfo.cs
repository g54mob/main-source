using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	[SerializeField]
	public class BakeInfo
	{
		[SerializeField]
		public class FeatureInfo
		{
			public int featureID;

			public string featureName;

			public float featureSize;
		}

		public float altitudeEpsilon;

		public string bakeDate;

		public int bakeTimeInSeconds;

		public int blocksHalfCountX;

		public int blocksHalfCountY;

		public int blockSize;

		public List<FeatureInfo> features = new List<FeatureInfo>();

		public float maxAltitude;

		public int numFeatures;

		public int numFeatureNameConflicts;

		public int occlusionMask;

		public float startAboveTerrain;

		public float tileSize;

		public int totalRaycasts;
	}
}
