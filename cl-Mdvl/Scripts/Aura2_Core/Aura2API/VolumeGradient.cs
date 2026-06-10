using System;

namespace Aura2API
{
	[Serializable]
	public struct VolumeGradient
	{
		public float falloffExponent;

		public float xPositiveCubeFade;

		public float xNegativeCubeFade;

		public float yPositiveCubeFade;

		public float yNegativeCubeFade;

		public float zPositiveCubeFade;

		public float zNegativeCubeFade;

		public float angularConeFade;

		public float distanceConeFade;

		public float widthCylinderFade;

		public float yNegativeCylinderFade;

		public float yPositiveCylinderFade;

		public float distanceSphereFade;
	}
}
