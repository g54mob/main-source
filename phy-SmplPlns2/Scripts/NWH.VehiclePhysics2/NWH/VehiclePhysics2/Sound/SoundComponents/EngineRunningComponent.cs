using System;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace NWH.VehiclePhysics2.Sound.SoundComponents
{
	[Serializable]
	public class EngineRunningComponent : SoundComponent
	{
		public float pitchRange = 1f;

		public float pitchOffset = 0.2f;

		public float pitchCeiling = 2f;

		[Range(0f, 1f)]
		[Tooltip("    Smoothing of engine volume.")]
		public float smoothing = 0.05f;

		[Range(0f, 1f)]
		[Tooltip("    Volume added to the base engine volume depending on engine state.")]
		public float volumeRange = 0.1f;

		private float _volume;

		private float _volumeVelocity;

		private float _distortion;

		private float _distortionVelocity;

		public override GameObject ContainerGO => vehicleController.soundManager.engineSourceGO;

		public override bool InitLoop => true;

		public override bool VC_Enable(bool calledByParent)
		{
			if (base.VC_Enable(calledByParent))
			{
				vehicleController.powertrain.engine.onStart.AddListener(Play);
				vehicleController.powertrain.engine.onStop.AddListener(Stop);
				if (vehicleController.powertrain.engine.IsRunning)
				{
					source.timeSamples = UnityEngine.Random.Range(0, source.clip.samples);
					Play();
				}
				return true;
			}
			return false;
		}

		public override bool VC_Disable(bool calledByParent)
		{
			if (base.VC_Disable(calledByParent))
			{
				vehicleController.powertrain.engine.onStart.RemoveListener(Play);
				vehicleController.powertrain.engine.onStop.RemoveListener(Stop);
				Stop();
				return true;
			}
			return false;
		}

		public override void VC_Update()
		{
			base.VC_Update();
			EngineComponent engine = vehicleController.powertrain.engine;
			float num = pitchOffset + pitchRange * engine.OutputRPM / 3000f;
			SetPitch((num < 1f) ? num : (pitchCeiling - (pitchCeiling - 1f) * Mathf.Exp((1f - num) / (pitchCeiling - 1f))));
			if (!engine.revLimiterActive)
			{
				_ = engine.ThrottlePosition;
			}
			float num2 = baseVolume;
			num2 += engine.Load * volumeRange;
			num2 -= _distortion;
			num2 = Mathf.Clamp(num2, baseVolume, 2f);
			_volume = Mathf.SmoothDamp(_volume, num2, ref _volumeVelocity, smoothing);
			SetVolume(_volume);
		}

		public override void VC_SetDefaults()
		{
			base.VC_SetDefaults();
			baseVolume = 0.7f;
			volumeRange = 0.3f;
			if (base.Clip == null)
			{
				AddDefaultClip("EngineRunning");
			}
		}
	}
}
