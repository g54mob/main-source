using UnityEngine;

namespace MyStuff.Graphics
{
	public struct SkyboxState
	{
		public float sunDiscMultiplier;

		public float sunDiscExponent;

		public Color sunDiscColor;

		public Color sunHaloColor;

		public float sunHaloExponent;

		public float sunHaloContribution;

		public Color horizonLineColor;

		public float horizonLineExponent;

		public float horizonLineContribution;

		public Color skyGradientTop;

		public Color skyGradientBottom;

		public float skyGradientExponent;

		public Color ambientSkyColor;

		public Color ambientEquatorColor;

		public Color ambientGroundColor;

		public float ambientIntensity;

		public Color fogColor;

		public float fogDensity;

		public float bloomIntensityMultiplier;

		public float bloomThresholdOffset;

		public float dofFocusDistance;

		public float dofAperture;

		public float dofFocalLength;

		public static SkyboxState Lerp(SkyboxState a, SkyboxState b, float t)
		{
			return default(SkyboxState);
		}
	}
}
