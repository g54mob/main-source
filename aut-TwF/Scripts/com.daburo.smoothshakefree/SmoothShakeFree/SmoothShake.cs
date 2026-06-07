using UnityEngine;

namespace SmoothShakeFree
{
	[AddComponentMenu("Smooth Shake Free/Smooth Shake Free")]
	public class SmoothShake : ShakeBase
	{
		[Tooltip("Preset to use for this Smooth Shake")]
		public SmoothShakeFreePreset preset;

		[Header("Position Shake Settings")]
		[Tooltip("Settings for Position Shake")]
		public Shaker positionShake;

		[Header("Rotation Shake Settings")]
		[Tooltip("Settings for Rotation Shake")]
		public Shaker rotationShake;

		private float shakeMultiplier = 1f;

		[HideInInspector]
		internal Vector3 startPosition;

		[HideInInspector]
		internal Vector3 startRotation;

		public float ShakeMultiplier
		{
			get
			{
				return shakeMultiplier;
			}
			set
			{
				shakeMultiplier = value;
			}
		}

		internal sealed override void Apply(Vector3[] value)
		{
			base.transform.localPosition = startPosition + value[0] * shakeMultiplier;
			base.transform.localEulerAngles = startRotation + value[1] * shakeMultiplier;
		}

		protected override Shaker[] GetShakers()
		{
			return new Shaker[2] { positionShake, rotationShake };
		}

		internal override void ResetDefaultValues()
		{
			base.transform.localPosition = startPosition;
			base.transform.localEulerAngles = startRotation;
		}

		internal sealed override void SaveDefaultValues()
		{
			startPosition = base.transform.localPosition;
			startRotation = base.transform.localEulerAngles;
		}

		internal sealed override void ApplyPresetSettings(SmoothShakeFreePreset preset)
		{
			positionShake.noiseType = preset.positionShake.noiseType;
			positionShake.amplitude = preset.positionShake.amplitude;
			positionShake.frequency = preset.positionShake.frequency;
			rotationShake.noiseType = preset.rotationShake.noiseType;
			rotationShake.amplitude = preset.rotationShake.amplitude;
			rotationShake.frequency = preset.rotationShake.frequency;
			timeSettings.enableOnStart = preset.timeSettings.enableOnStart;
			timeSettings.constantShake = preset.timeSettings.constantShake;
			timeSettings.fadeInDuration = preset.timeSettings.fadeInDuration;
			timeSettings.fadeOutDuration = preset.timeSettings.fadeOutDuration;
			timeSettings.fadeInCurve = preset.timeSettings.fadeInCurve;
			timeSettings.fadeOutCurve = preset.timeSettings.fadeOutCurve;
			timeSettings.holdDuration = preset.timeSettings.holdDuration;
		}
	}
}
