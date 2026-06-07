using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class FeatureData
	{
		public IOccludableFeature feature;

		public int featureID;

		public Vector3[] localCorners;

		public float size;
	}
}
