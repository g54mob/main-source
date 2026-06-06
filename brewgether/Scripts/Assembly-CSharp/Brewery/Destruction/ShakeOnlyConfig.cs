using System;
using UnityEngine;

namespace Brewery.Destruction
{
	[Serializable]
	public class ShakeOnlyConfig
	{
		[Tooltip("Duration of the shake animation")]
		public float shakeDuration;

		[Tooltip("Shake intensity (rotation degrees)")]
		public float shakeIntensity;

		[Tooltip("Number of shake oscillations")]
		public int shakeCount;

		[Tooltip("LeanTween ease type for shake")]
		public LeanTweenType easeType;

		[Tooltip("Tags that should only shake, never be destroyed")]
		public string[] shakeOnlyTags;
	}
}
