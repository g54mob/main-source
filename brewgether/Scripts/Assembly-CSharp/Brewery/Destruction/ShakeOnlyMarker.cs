using UnityEngine;

namespace Brewery.Destruction
{
	[AddComponentMenu("Brewery/Destruction/Shake Only Marker")]
	public class ShakeOnlyMarker : MonoBehaviour
	{
		[Header("Optional Overrides")]
		[Tooltip("Override shake duration (0 = use settings default)")]
		[Range(0f, 3f)]
		public float shakeDurationOverride;

		[Tooltip("Override shake intensity (0 = use settings default)")]
		[Range(0f, 20f)]
		public float shakeIntensityOverride;

		public float GetShakeDuration(float defaultValue)
		{
			return 0f;
		}

		public float GetShakeIntensity(float defaultValue)
		{
			return 0f;
		}
	}
}
