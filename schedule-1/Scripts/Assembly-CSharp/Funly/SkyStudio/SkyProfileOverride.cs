using UnityEngine;

namespace Funly.SkyStudio
{
	public class SkyProfileOverride : MonoBehaviour
	{
		public SkyProfile SkyProfile;

		[Range(0f, 1f)]
		public float Strength;

		[Header("Masks")]
		public bool AffectAmbientLight;

		public bool AffectFog;

		public bool AffectSunLight;

		public void Apply(SkyProfileOutput output, float timeOfDay)
		{
		}
	}
}
