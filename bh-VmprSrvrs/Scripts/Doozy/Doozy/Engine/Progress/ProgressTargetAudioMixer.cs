using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target AudioMixer", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetAudioMixer : ProgressTarget
	{
		private const float MIN_VALUE = 0.0001f;

		private const float MAX_VALUE = 1f;

		public string ExposedParameterName;

		public AudioMixer TargetMixer;

		public bool UseLogarithmicConversion;

		public override void UpdateTarget(Progressor progressor)
		{
		}

		private static float GetLogarithmicValue(float value)
		{
			return 0f;
		}
	}
}
