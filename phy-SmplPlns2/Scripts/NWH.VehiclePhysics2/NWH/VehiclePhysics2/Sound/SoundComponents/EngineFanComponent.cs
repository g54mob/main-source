using System;
using UnityEngine;

namespace NWH.VehiclePhysics2.Sound.SoundComponents
{
	[Serializable]
	public class EngineFanComponent : SoundComponent
	{
		[Tooltip("Starting sound pitch at idle RPM.")]
		public float basePitch = 1f;

		[Range(0f, 4f)]
		[Tooltip("Pitch range, redline pitch equals basePitch + pitchRange.")]
		public float pitchRange = 0.1f;

		public override GameObject ContainerGO => vehicleController.soundManager.engineSourceGO;

		public override bool InitLoop => true;

		public override bool VC_Enable(bool calledByParent)
		{
			if (base.VC_Enable(calledByParent) && baseVolume > 0f)
			{
				vehicleController.powertrain.engine.onStart.AddListener(Play);
				vehicleController.powertrain.engine.onStop.AddListener(Stop);
				if (vehicleController.powertrain.engine.IsRunning)
				{
					source.timeSamples = UnityEngine.Random.Range(0, source.clip.samples);
					SetVolume(0f);
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
			if (baseVolume > 0f)
			{
				base.VC_Update();
				float outputRPM = vehicleController.powertrain.engine.OutputRPM;
				SetVolume(baseVolume * (1f - outputRPM / 4000f));
				SetPitch(basePitch + pitchRange * outputRPM / 3000f);
			}
		}

		public override void VC_SetDefaults()
		{
			base.VC_SetDefaults();
			baseVolume = 0.05f;
			if (base.Clip == null)
			{
				AddDefaultClip("EngineFan");
			}
		}
	}
}
