using System;
using System.Collections.Generic;
using DV.Damage;
using DV.Utils;
using DV.Wheels;
using LocoSim.Implementations.Wheels;
using Unity.Profiling;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class WheelsAudioModule : CarAudioModule
	{
		[Serializable]
		public class WheelslipAudioDefinition
		{
			public LayeredAudio wheelslipAudio;

			public LayeredAudio derailedWheelslipAudio;

			public int[] correspondingPoweredWheelsIndices;

			[NonSerialized]
			public List<PoweredWheel> poweredWheels = new List<PoweredWheel>();

			public void Init(PoweredWheelsManager pwm)
			{
				poweredWheels.Clear();
				int[] array = correspondingPoweredWheelsIndices;
				foreach (int num in array)
				{
					if (num >= pwm.poweredWheels.Length || num < 0)
					{
						Debug.LogError(string.Format("Unexpected state: {0}[{1}] is out of range. Skipping setup for this {2}", "pwIndex", num, "WheelslipAudioDefinition"), pwm.gameObject);
					}
					else
					{
						poweredWheels.Add(pwm.poweredWheels[num]);
					}
				}
			}
		}

		private static ProfilerMarker PROFILE_MARKER = new ProfilerMarker("WheelsAudioModule");

		public WheelslipAudioDefinition[] wheelslipAudioDefs;

		public AnimationCurve wheelDamageToMasterVolumeCurve;

		public LayeredAudio wheelDamagedAudio1;

		public LayeredAudio wheelDamagedAudio2;

		private TrainCar trainCar;

		private AdhesionController adhesionController;

		private DamageController damageController;

		private bool wheelDamagedAudio1Exists;

		private bool wheelDamagedAudio2Exists;

		private bool anyWheelDamagedAudioExists;

		private float prevWheelslip;

		private bool wasStopped;

		public override bool ExternalUpdate => true;

		public override void Deinitialize()
		{
			trainCar.OnDerailed -= OnDerail;
			trainCar.OnRerailed -= OnRerail;
			trainCar = null;
			adhesionController = null;
			damageController = null;
			for (int i = 0; i < wheelslipAudioDefs.Length; i++)
			{
				wheelslipAudioDefs[i].poweredWheels.Clear();
			}
		}

		public override void Initialize(TrainCar trainCar)
		{
			this.trainCar = trainCar;
			trainCar.OnDerailed += OnDerail;
			trainCar.OnRerailed += OnRerail;
			adhesionController = this.trainCar.adhesionController;
			damageController = trainCar.GetComponent<DamageController>();
			PoweredWheelsManager pwm = trainCar.SimController?.poweredWheels;
			WheelslipAudioDefinition[] array = wheelslipAudioDefs;
			foreach (WheelslipAudioDefinition obj in array)
			{
				obj.Init(pwm);
				obj.wheelslipAudio.Reset();
				obj.derailedWheelslipAudio.Reset();
			}
			wheelDamagedAudio1Exists = wheelDamagedAudio1;
			wheelDamagedAudio2Exists = wheelDamagedAudio2;
			anyWheelDamagedAudioExists = wheelDamagedAudio1Exists || wheelDamagedAudio2Exists;
			if (wheelDamagedAudio1Exists)
			{
				wheelDamagedAudio1.Reset();
			}
			if (wheelDamagedAudio2Exists)
			{
				wheelDamagedAudio2.Reset();
			}
			prevWheelslip = 0f;
		}

		public override void UpdateModule(float deltaTime)
		{
			if (adhesionController.wheelslipController.IsSome(out var value))
			{
				if (value.wheelslip == 0f)
				{
					if (prevWheelslip != 0f)
					{
						WheelslipAudioDefinition[] array = wheelslipAudioDefs;
						foreach (WheelslipAudioDefinition obj in array)
						{
							obj.wheelslipAudio.Set(0f);
							obj.derailedWheelslipAudio.Set(0f);
						}
					}
				}
				else
				{
					float num = (trainCar.derailed ? 0f : 1f);
					float num2 = (trainCar.groundFriction.IsGrounded ? 1f : 0f);
					WheelslipAudioDefinition[] array = wheelslipAudioDefs;
					foreach (WheelslipAudioDefinition wheelslipAudioDefinition in array)
					{
						bool flag = false;
						foreach (PoweredWheel poweredWheel in wheelslipAudioDefinition.poweredWheels)
						{
							if (poweredWheel.IsPowered)
							{
								flag = true;
								break;
							}
						}
						float num3 = (flag ? value.wheelslip : 0f);
						wheelslipAudioDefinition.wheelslipAudio.Set(num * num3);
						wheelslipAudioDefinition.derailedWheelslipAudio.Set((1f - num) * num2 * num3);
					}
				}
				prevWheelslip = value.wheelslip;
			}
			if (!anyWheelDamagedAudioExists)
			{
				return;
			}
			float magnitude = trainCar.rb.velocity.magnitude;
			bool flag2 = magnitude < 0.005f;
			if (flag2 && !wasStopped)
			{
				if (wheelDamagedAudio1Exists)
				{
					wheelDamagedAudio1.MasterVolume = 0f;
					wheelDamagedAudio1.Set(0f);
				}
				if (wheelDamagedAudio2Exists)
				{
					wheelDamagedAudio2.MasterVolume = 0f;
					wheelDamagedAudio2.Set(0f);
				}
			}
			else if (!flag2 && !trainCar.derailed && damageController.wheels != null)
			{
				float masterVolume = wheelDamageToMasterVolumeCurve.Evaluate(damageController.wheels.DamagePercentage);
				float level = magnitude * SingletonBehaviour<AudioManager>.Instance.rollingSpeedMult;
				if (wheelDamagedAudio1Exists)
				{
					wheelDamagedAudio1.MasterVolume = masterVolume;
					wheelDamagedAudio1.Set(level);
				}
				if (wheelDamagedAudio2Exists)
				{
					wheelDamagedAudio2.MasterVolume = masterVolume;
					wheelDamagedAudio2.Set(level);
				}
			}
			wasStopped = flag2;
		}

		private void OnDerail(TrainCar _)
		{
			if (anyWheelDamagedAudioExists && damageController.wheels != null)
			{
				if (wheelDamagedAudio1Exists)
				{
					wheelDamagedAudio1.MasterVolume = 0f;
					wheelDamagedAudio1.Set(0f);
				}
				else
				{
					wheelDamagedAudio2.MasterVolume = 0f;
					wheelDamagedAudio2.Set(0f);
				}
			}
		}

		private void OnRerail()
		{
			if (!adhesionController.wheelslipController.IsNone())
			{
				WheelslipAudioDefinition[] array = wheelslipAudioDefs;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].derailedWheelslipAudio.Set(0f);
				}
			}
		}
	}
}
