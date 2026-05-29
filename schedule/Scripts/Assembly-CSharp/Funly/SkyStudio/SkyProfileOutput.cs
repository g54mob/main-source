using UnityEngine;

namespace Funly.SkyStudio
{
	public class SkyProfileOutput
	{
		public Color ambientSkyColor;

		public Color ambientEquatorColor;

		public Color ambientGroundColor;

		public Color fogColor;

		public float fogEndDistance;

		public Color sunLightColor;

		public float sunLightIntensity;

		public SkyProfileOutput(SkyProfile skyProfile, float timeOfDay)
		{
		}
	}
}
