using DV.Simulation.Brake;
using DV.Utils;
using Unity.Profiling;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class BrakesAudioModule : CarAudioModule
	{
		private static ProfilerMarker PROFILE_MARKER_A = new ProfilerMarker("BrakesAudioModuleDynamicLoad");

		private static ProfilerMarker PROFILE_MARKER_B = new ProfilerMarker("BrakesAudioModuleStaticLoad");

		public LayeredAudio brakeAudio;

		public LayeredAudio brakeSquealAudio;

		public LayeredAudio wheelSlidingAudio;

		public LayeredAudio brakeCylinderExhaustAudio;

		public LayeredAudio airflowAudio;

		public LayeredAudio brakesOverheatingAudio;

		public AudioClip brakeCylinderManualReleaseAudio;

		public AnimationCurve brakeVolumeSpeedCurve;

		public AnimationCurve brakeSquealVolumeSpeedCurve;

		private TrainCar trainCar;

		private TrainPhysicsLod trainPhysicsLod;

		private bool shouldUpdate;

		private bool wasClosedProperly;

		private bool brakeAudioExists;

		private bool brakeSquealAudioExists;

		private bool wheelSlidingAudioExists;

		private bool brakeCylinderExhaustAudioExists;

		private bool airflowAudioExists;

		private bool brakesOverheatingAudioExists;

		private bool wasStopped;

		public override bool ExternalUpdate
		{
			get
			{
				int num;
				if (!shouldUpdate)
				{
					num = ((trainPhysicsLod.CurrentLod <= 3) ? 1 : 0);
					if (num == 0)
					{
						if (!wasClosedProperly)
						{
							if ((bool)brakeAudio)
							{
								brakeAudio.Set(0f);
							}
							if ((bool)brakeSquealAudio)
							{
								brakeSquealAudio.Set(0f);
							}
							if ((bool)wheelSlidingAudio)
							{
								wheelSlidingAudio.Set(0f);
							}
							if ((bool)brakeCylinderExhaustAudio)
							{
								brakeCylinderExhaustAudio.Set(0f);
							}
							if ((bool)airflowAudio)
							{
								airflowAudio.Set(0f);
							}
							if ((bool)brakesOverheatingAudio)
							{
								brakesOverheatingAudio.SetVolume(0f);
								brakesOverheatingAudio.SetPitch(0f);
							}
							wasClosedProperly = true;
							return (byte)num != 0;
						}
						goto IL_00fa;
					}
				}
				else
				{
					num = 1;
				}
				wasClosedProperly = false;
				goto IL_00fa;
				IL_00fa:
				return (byte)num != 0;
			}
		}

		private void Awake()
		{
			brakeAudioExists = brakeAudio != null;
			brakeSquealAudioExists = brakeSquealAudio != null;
			wheelSlidingAudioExists = wheelSlidingAudio != null;
			brakeCylinderExhaustAudioExists = brakeCylinderExhaustAudio != null;
			airflowAudioExists = airflowAudio != null;
			brakesOverheatingAudioExists = brakesOverheatingAudio != null;
		}

		public override void Deinitialize()
		{
			if (brakeCylinderManualReleaseAudio != null && trainCar != null)
			{
				trainCar.brakeSystem.BrakeCylinderReleased -= OnBrakeCylinderManualRelease;
			}
			trainCar.MovementStateChanged -= OnMovementChanged;
			trainCar = null;
			trainPhysicsLod = null;
		}

		public override void Initialize(TrainCar trainCar)
		{
			if (brakeAudio != null)
			{
				brakeAudio.Reset();
			}
			if (brakeSquealAudio != null)
			{
				brakeSquealAudio.Reset();
			}
			if (wheelSlidingAudio != null)
			{
				wheelSlidingAudio.Reset();
			}
			if (brakeCylinderExhaustAudio != null)
			{
				brakeCylinderExhaustAudio.Reset();
			}
			if (airflowAudio != null)
			{
				airflowAudio.Reset();
			}
			if (brakesOverheatingAudio != null)
			{
				brakesOverheatingAudio.Reset();
			}
			this.trainCar = trainCar;
			if (brakeCylinderManualReleaseAudio != null)
			{
				trainCar.brakeSystem.BrakeCylinderReleased += OnBrakeCylinderManualRelease;
			}
			trainCar.MovementStateChanged += OnMovementChanged;
			trainPhysicsLod = trainCar.GetComponent<TrainPhysicsLod>();
			wasStopped = false;
		}

		private void OnMovementChanged(bool moving)
		{
			shouldUpdate = moving;
		}

		public override void UpdateModule(float deltaTime)
		{
			BrakeSystem brakeSystem = trainCar.brakeSystem;
			float brakingFactor = brakeSystem.brakingFactor;
			float absSpeed = trainCar.GetAbsSpeed();
			bool flag = absSpeed < 0.005f;
			if (wasStopped != flag)
			{
				wasStopped = flag;
				if (flag)
				{
					wheelSlidingAudio.Set(0f);
					brakeAudio.Set(0f);
					brakeSquealAudio.Set(0f);
				}
			}
			if (!flag)
			{
				float num = 1f;
				float num2 = (trainCar.derailed ? 0f : 1f);
				if (wheelSlidingAudioExists)
				{
					bool flag2 = trainCar.adhesionController.wheelSlide > 0f;
					wheelSlidingAudio.MasterVolume = (flag2 ? (1f * num2) : 0f);
					if (flag2 && !trainCar.derailed)
					{
						num = 0f;
					}
					wheelSlidingAudio.Set(absSpeed);
				}
				if (brakeAudioExists)
				{
					brakeAudio.MasterVolume = brakingFactor * brakeVolumeSpeedCurve.Evaluate(absSpeed) * num * num2;
					brakeAudio.Set(brakingFactor);
				}
				if (brakeSquealAudioExists)
				{
					brakeSquealAudio.MasterVolume = brakingFactor * brakeSquealVolumeSpeedCurve.Evaluate(absSpeed) * num * num2;
					brakeSquealAudio.Set(absSpeed);
				}
			}
			if (brakeCylinderExhaustAudioExists)
			{
				brakeCylinderExhaustAudio.Set(brakeSystem.pipeExhaustFlow * SingletonBehaviour<AudioManager>.Instance.exhaustMult);
			}
			if (brakesOverheatingAudioExists)
			{
				brakesOverheatingAudio.MasterVolume = Mathf.InverseLerp(1f, 5f, absSpeed);
				brakesOverheatingAudio.SetVolume(brakeSystem.heatController.overheatPercentage * brakeSystem.unaffectedTargetBrakingFactor);
				brakesOverheatingAudio.SetPitch(absSpeed);
			}
			if (airflowAudioExists)
			{
				airflowAudio.Set(brakeSystem.mainResToPipeFlow * SingletonBehaviour<AudioManager>.Instance.airflowMult);
			}
		}

		private void OnBrakeCylinderManualRelease()
		{
			BrakeSystem brakeSystem = trainCar.brakeSystem;
			if (brakeSystem.brakeCylinderPressure > 1.1f && brakeSystem.controlReservoirPressure >= 4.5f)
			{
				brakeCylinderManualReleaseAudio.Play(base.transform.position, 0.5f + 0.5f * brakeSystem.BrakeCylinderPressureNormalized, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}
	}
}
