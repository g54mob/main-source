using UnityEngine;

namespace Coherence.Interpolation
{
	[CreateAssetMenu(fileName = "InterpolationSettings.asset", menuName = "coherence/Interpolation Settings")]
	public class InterpolationSettings : ScriptableObject
	{
		public static readonly string EmptyInterpolationName;

		public static readonly string DefaultInterpolationName;

		public const double SimulationFramesPerSecond = 60.0;

		public const float DefaultSampleRate = 20f;

		public const float DefaultMaxOvershootAllowed = 5f;

		public static readonly string DefaultSettingsPath;

		[SerializeReference]
		public Interpolator interpolator;

		public SmoothingSettings smoothing;

		public LatencySettings latencySettings;

		[Tooltip("If any two consecutive samples exceed the maximum distance, the buffer is cleared to teleport to the latest sample.")]
		public float maxDistance;

		[Tooltip("Max number of samples to proceed into extrapolation after overshooting the final sample in the buffer.")]
		public float maxOvershootAllowed;

		private static InterpolationSettings empty;

		private bool? isInterpolationNone;

		public static InterpolationSettings Empty => null;

		public bool IsInterpolationNone => false;

		public static InterpolationSettings CreateEmpty()
		{
			return null;
		}

		public static InterpolationSettings CreateDefault()
		{
			return null;
		}
	}
}
