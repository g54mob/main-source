using UnityEngine;

namespace GRP
{
	public class SceneryLight : SceneryTarget
	{
		public Light myLight;

		public bool rotation;

		public bool color;

		public bool intensity;

		private float intensityMultiplier;

		private float defaultIntensity;

		private void OnValidate()
		{
		}

		protected override void Setup()
		{
		}
	}
}
