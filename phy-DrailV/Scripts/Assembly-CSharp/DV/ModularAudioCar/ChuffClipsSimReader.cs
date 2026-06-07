using System;
using System.Collections;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;
using UnityEngine.Audio;

namespace DV.ModularAudioCar
{
	public class ChuffClipsSimReader : AAudioClipSimReader
	{
		[Serializable]
		public class ChuffLoop
		{
			public LayeredAudio chuffLoop;

			public AnimationCurve chuffFrequencyToMasterVolume;

			private bool isActive;

			public bool UpdateLoops(float volumeInput, float chuffFrequency)
			{
				float num = chuffFrequencyToMasterVolume.Evaluate(chuffFrequency);
				bool num2 = isActive;
				isActive = num > 0f;
				chuffLoop.MasterVolume = num;
				if (num2 != isActive)
				{
					chuffLoop.Stop();
				}
				if (isActive)
				{
					chuffLoop.SetVolume(volumeInput);
					chuffLoop.SetPitch(chuffFrequency);
				}
				return isActive;
			}
		}

		[Serializable]
		public class OrderedChuffClips
		{
			public AudioClip[] chuffVariations;
		}

		[Serializable]
		public class IndividualChuffAudioSourceConfig
		{
			public Transform parent;

			public AnimationCurve chuffFrequencyToMasterVolume;

			public float pitch = 1f;

			[Header("X axis is [0, 1] range (mapped internally to [0, maxDistance])")]
			public AnimationCurve spatialCurve;

			public float spread;

			public float minDistance = 1f;

			public float maxDistance = 500f;

			public AudioMixerGroup mixerGroup;

			[NonSerialized]
			public AudioSourceCurves customCurves;
		}

		[PortId(PortValueType.STATE, false)]
		[Header("Ports")]
		public string chuffEventPortId;

		[PortId(PortValueType.PRESSURE, false)]
		public string exhaustPressurePortId;

		[PortId(PortValueType.STATE, false)]
		public string chuffFrequencyPortId;

		[PortId(PortValueType.STATE, false)]
		public string cylinderWaterNormalizedPortId;

		[PortId(PortValueType.CONTROL, false)]
		public string cylinderCockControlPortId;

		[PortId(PortValueType.STATE, false)]
		public string ashesInPipesPortId;

		[Space]
		[Header("Individual chuffs - number of entries must match the number of chuffs per cycle")]
		public OrderedChuffClips[] lowPressureClips;

		public OrderedChuffClips[] mediumPressureClips;

		public OrderedChuffClips[] highPressureClips;

		public IndividualChuffAudioSourceConfig regularChuffConfig;

		public AnimationCurve pressureToVolumeCurve;

		public float mediumPressureThreshold;

		public float highPressureThreshold;

		[Header("Individual water chuffs")]
		public AudioClip[] waterChuffClips;

		public IndividualChuffAudioSourceConfig waterChuffConfig;

		[Header("Individual ash chuffs")]
		public AudioClip[] ashChuffClips;

		public IndividualChuffAudioSourceConfig ashChuffConfig;

		[Space]
		[Header("Loop chuffs")]
		public ChuffLoop[] chuffLoops;

		public ChuffLoop[] waterChuffLoops;

		public ChuffLoop[] ashChuffLoops;

		private Port chuffEventPort;

		private Port exhaustPressurePort;

		private Port chuffFrequencyPort;

		private Port cylinderWaterNormalizedPort;

		private Port cylinderCockControlPort;

		private Port ashesInPipesPort;

		private bool anyLoopOngoing;

		private TrainCar car;

		private Coroutine wheelSlideCoro;

		private Coroutine wheelslipCoro;

		private float WaterChuffVolumeInput
		{
			get
			{
				if (!(cylinderWaterNormalizedPort.Value > 0f) || !(chuffFrequencyPort.Value > 0.1f))
				{
					return 0f;
				}
				return Mathf.Lerp(0.5f, 1f, cylinderWaterNormalizedPort.Value) * Mathf.Lerp(1f, 0.5f, cylinderCockControlPort.Value);
			}
		}

		private float AshChuffVolumeInput => ashesInPipesPort.Value;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			if (!simFlow.TryGetPort(chuffEventPortId, out chuffEventPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(exhaustPressurePortId, out exhaustPressurePort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(chuffFrequencyPortId, out chuffFrequencyPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylinderWaterNormalizedPortId, out cylinderWaterNormalizedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylinderCockControlPortId, out cylinderCockControlPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(ashesInPipesPortId, out ashesInPipesPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ChuffClipsSimReader not initialized properly");
				return;
			}
			if (car.adhesionController != null)
			{
				car.adhesionController.WheelSlideStateChanged += OnWheelSlideChange;
				if (car.adhesionController.wheelslipController.IsSome(out var value))
				{
					value.WheelslipStateChanged += OnWheelslipChange;
				}
			}
			regularChuffConfig.customCurves = ((regularChuffConfig.spatialCurve.length > 0) ? new AudioSourceCurves(null, null, regularChuffConfig.spatialCurve, null) : default(AudioSourceCurves));
			waterChuffConfig.customCurves = ((waterChuffConfig.spatialCurve.length > 0) ? new AudioSourceCurves(null, null, waterChuffConfig.spatialCurve, null) : default(AudioSourceCurves));
			ashChuffConfig.customCurves = ((ashChuffConfig.spatialCurve.length > 0) ? new AudioSourceCurves(null, null, ashChuffConfig.spatialCurve, null) : default(AudioSourceCurves));
			car.MovementStateChanged += OnMovementStateChange;
			chuffEventPort.ValueUpdatedInternally += OnChuff;
		}

		public override void Deinit()
		{
			if (car.adhesionController != null)
			{
				car.adhesionController.WheelSlideStateChanged -= OnWheelSlideChange;
				if (wheelSlideCoro != null)
				{
					StopCoroutine(wheelSlideCoro);
					wheelSlideCoro = null;
				}
				if (car.adhesionController.wheelslipController.IsSome(out var value))
				{
					value.WheelslipStateChanged -= OnWheelslipChange;
					if (wheelslipCoro != null)
					{
						StopCoroutine(wheelslipCoro);
						wheelslipCoro = null;
					}
				}
			}
			car.MovementStateChanged -= OnMovementStateChange;
			car = null;
			if (chuffEventPort != null)
			{
				chuffEventPort.ValueUpdatedInternally -= OnChuff;
			}
			chuffEventPort = null;
			exhaustPressurePort = null;
			chuffFrequencyPort = null;
		}

		private void OnMovementStateChange(bool isMoving)
		{
			if (!(!anyLoopOngoing || isMoving))
			{
				UpdateLoops();
				if (!anyLoopOngoing)
				{
					Debug.LogWarning("Stopped looping chuff via OnMovementStateChange.");
				}
			}
		}

		private void OnWheelslipChange(bool isWheelslipping)
		{
			if (isWheelslipping)
			{
				if (wheelslipCoro != null)
				{
					StopCoroutine(wheelslipCoro);
					wheelslipCoro = null;
				}
				wheelslipCoro = StartCoroutine(WheelslipUpdateCoro());
			}
		}

		private void OnWheelSlideChange(bool isWheelSliding)
		{
			if (isWheelSliding)
			{
				wheelSlideCoro = StartCoroutine(WheelSlideUpdateCoro());
			}
		}

		private IEnumerator WheelSlideUpdateCoro()
		{
			do
			{
				yield return null;
				if (anyLoopOngoing)
				{
					UpdateLoops();
				}
			}
			while (car.adhesionController.IsWheelSliding);
			wheelSlideCoro = null;
		}

		private IEnumerator WheelslipUpdateCoro()
		{
			WheelslipController value;
			do
			{
				yield return null;
				if (anyLoopOngoing)
				{
					UpdateLoops();
				}
			}
			while (!car.adhesionController.wheelslipController.IsSome(out value) || value.IsWheelslipping);
			for (int i = 0; i < 10; i++)
			{
				yield return WaitFor.Seconds(0.1f);
				if (anyLoopOngoing)
				{
					UpdateLoops();
				}
			}
			wheelslipCoro = null;
		}

		private void OnChuff(float chuffIndexFloat)
		{
			float value = exhaustPressurePort.Value;
			float value2 = chuffFrequencyPort.Value;
			UpdateLoops();
			float num = regularChuffConfig.chuffFrequencyToMasterVolume.Evaluate(value2);
			if (num <= 0f)
			{
				return;
			}
			if (value > 1f)
			{
				int num2 = Mathf.RoundToInt(chuffIndexFloat);
				AudioClip[] chuffVariations = ((value < mediumPressureThreshold) ? lowPressureClips : ((value < highPressureThreshold) ? mediumPressureClips : highPressureClips))[num2].chuffVariations;
				float num3 = pressureToVolumeCurve.Evaluate(value);
				NAudio.Play(position: regularChuffConfig.parent.position, volume: num3 * num, pitch: regularChuffConfig.pitch, spread: regularChuffConfig.spread, minDistance: regularChuffConfig.minDistance, maxDistance: regularChuffConfig.maxDistance, mixerGroup: regularChuffConfig.mixerGroup, parent: regularChuffConfig.parent, clips: chuffVariations, curves: regularChuffConfig.customCurves);
			}
			if (cylinderWaterNormalizedPort.Value > 0f && waterChuffClips.Length != 0)
			{
				float num4 = waterChuffConfig.chuffFrequencyToMasterVolume.Evaluate(value2);
				if (num4 > 0f)
				{
					waterChuffClips.Play(waterChuffConfig.parent.position, WaterChuffVolumeInput * num4, waterChuffConfig.pitch, waterChuffConfig.spread, waterChuffConfig.minDistance, waterChuffConfig.maxDistance, mixerGroup: waterChuffConfig.mixerGroup, parent: waterChuffConfig.parent, curves: waterChuffConfig.customCurves);
				}
			}
			float value3 = ashesInPipesPort.Value;
			if (value3 > 0f && ashChuffClips.Length != 0)
			{
				float num5 = ashChuffConfig.chuffFrequencyToMasterVolume.Evaluate(value2);
				if (num5 > 0f)
				{
					ashChuffClips.Play(ashChuffConfig.parent.position, value3 * num5, ashChuffConfig.pitch, ashChuffConfig.spread, ashChuffConfig.minDistance, ashChuffConfig.maxDistance, mixerGroup: ashChuffConfig.mixerGroup, parent: ashChuffConfig.parent, curves: ashChuffConfig.customCurves);
				}
			}
		}

		private void UpdateLoops()
		{
			float volumeInput = Mathf.Max(exhaustPressurePort.Value - 1f, 0f);
			float value = chuffFrequencyPort.Value;
			anyLoopOngoing = false;
			ChuffLoop[] array = chuffLoops;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].UpdateLoops(volumeInput, value))
				{
					anyLoopOngoing = true;
				}
			}
			array = waterChuffLoops;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].UpdateLoops(WaterChuffVolumeInput, value))
				{
					anyLoopOngoing = true;
				}
			}
			array = ashChuffLoops;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].UpdateLoops(AshChuffVolumeInput, value))
				{
					anyLoopOngoing = true;
				}
			}
		}
	}
}
