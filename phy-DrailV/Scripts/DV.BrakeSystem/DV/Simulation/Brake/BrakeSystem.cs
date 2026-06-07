using System;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class BrakeSystem : MonoBehaviour
	{
		public enum BrakeCylinderPressureCalculation
		{
			Regular = 0,
			CopyFront = 1,
			CopyRear = 2,
			CopyMax = 3
		}

		public class HeatController
		{
			private const float TEMPERATURE_GAIN_RATE = 1.5f;

			private const float COOLING_RATE = 0.004f;

			private const float OVERHEATING_TEMPERATURE_MIN = 600f;

			private const float OVERHEATING_TEMPERATURE_MAX = 1000f;

			private const float OUTSIDE_TEMPERATURE = 25f;

			private const float OVERHEATING_BRAKING_MAX_REDUCTION_FACTOR = 0.12f;

			[NonSerialized]
			public float currentAbsSpeed;

			[NonSerialized]
			public float overheatReductionFactor = 1f;

			[NonSerialized]
			public float overheatPercentage;

			[NonSerialized]
			public float temperature = 25f;

			public event Action<bool> OverheatingActiveStateChanged;

			public void ResetState()
			{
				overheatReductionFactor = 1f;
				bool num = overheatPercentage > 0f;
				overheatPercentage = 0f;
				temperature = 25f;
				currentAbsSpeed = 0f;
				if (num)
				{
					this.OverheatingActiveStateChanged?.Invoke(obj: false);
				}
			}

			public void UpdateTemperature(float brakingFactor, float dt)
			{
				float num = 0f;
				if (currentAbsSpeed > 0f && brakingFactor > 0.001f)
				{
					num += currentAbsSpeed * brakingFactor * 1.5f;
				}
				if (temperature > 25f)
				{
					float num2 = 24f;
					num -= (temperature - num2) * 0.004f;
				}
				temperature += num * dt;
				temperature = Mathf.Clamp(temperature, 25f, 1000f);
				float num3 = overheatPercentage;
				overheatPercentage = Mathf.InverseLerp(600f, 1000f, temperature);
				overheatReductionFactor = Mathf.Lerp(1f, 0.12f, overheatPercentage);
				if (num3 == 0f && overheatPercentage > 0f)
				{
					this.OverheatingActiveStateChanged?.Invoke(obj: true);
				}
				else if (num3 > 0f && overheatPercentage == 0f)
				{
					this.OverheatingActiveStateChanged?.Invoke(obj: false);
				}
			}
		}

		private const float BRAKE_FACTOR_CHANGED_EVENT_THRESHOLD = 0.05f;

		private const float AUDIO_SMOOTH_TIME = 0.5f;

		[NonSerialized]
		public BrakeGameParams gameParams;

		[NonSerialized]
		public Brakeset brakeset;

		[NonSerialized]
		public int indexInBrakeset;

		public bool hasCompressor;

		public float compressorProductionRate;

		public float compressorActivationPressure = 7f;

		public float mainResVolume;

		public bool hasMainResConnections;

		public bool hasTrainBrake;

		public bool selfLappingController = true;

		[NonSerialized]
		public bool trainBrakeCutout;

		[NonSerialized]
		public float trainBrakePosition;

		[NonSerialized]
		public AnimationCurve trainBrakeCurve;

		public bool hasIndependentBrake;

		[NonSerialized]
		public float independentBrakePosition;

		[NonSerialized]
		public AnimationCurve indBrakeCurve;

		public bool hasHandbrake = true;

		[NonSerialized]
		public float handbrakePosition;

		[NonSerialized]
		public bool ignoreOverheating;

		public BrakeCylinderPressureCalculation brakeCylinderPressureCalculation;

		[NonSerialized]
		public float brakePipePressure = 1f;

		[NonSerialized]
		public float mainReservoirPressure = 1f;

		[NonSerialized]
		public float auxReservoirPressure = 1f;

		[NonSerialized]
		public float controlReservoirPressure = 1f;

		[NonSerialized]
		public bool controlReservoirPressureReleased;

		[NonSerialized]
		public float brakeCylinderPressure = 1f;

		[NonSerialized]
		public float brakeCylinderPressureUnsmoothed = 1f;

		[NonSerialized]
		public float brakingFactor;

		[NonSerialized]
		public float unaffectedTargetBrakingFactor;

		[NonSerialized]
		public bool compressorActivationSignal;

		[NonSerialized]
		public HeatController heatController = new HeatController();

		[NonSerialized]
		public float pipeMassFlow;

		[NonSerialized]
		public float mainResToPipeFlow;

		[NonSerialized]
		public float exhaustMassFlow;

		[NonSerialized]
		public float pipeExhaustFlow;

		internal float mainReservoirPressureUnsmoothed = 1f;

		internal float prevBrakingFactor;

		internal float brakingFactorRef;

		internal float mainResPressureRef;

		internal float brakePipePressureRef;

		internal float brakeCylinderPressureRef;

		internal float mainResToPipeFlowRef;

		internal float pipeExhaustFlowRef;

		private HoseAndCock _front;

		private HoseAndCock _rear;

		public float MainResAirMass => mainResVolume * mainReservoirPressureUnsmoothed;

		public float BrakeCylinderPressureNormalized => Mathf.InverseLerp(1f, 4.5f, brakeCylinderPressure);

		public float TrainPipePressureFactor => Mathf.InverseLerp(6f, 4.5f, brakeset.pipePressure);

		public float MainResPressureNormalized => Mathf.InverseLerp(1f, 9f, mainReservoirPressure);

		public HoseAndCock Front
		{
			get
			{
				if (_front == null)
				{
					_front = new HoseAndCock(this, isFront: true);
				}
				return _front;
			}
		}

		public HoseAndCock Rear
		{
			get
			{
				if (_rear == null)
				{
					_rear = new HoseAndCock(this, isFront: false);
				}
				return _rear;
			}
		}

		public event Action<bool> CompressorActivationSignalChanged;

		public event Action BrakeCylinderReleased;

		public event Action<(float value, bool forced)> HandbrakePositionChanged;

		public event Action BrakingFactorChanged;

		public event MainReservoirPressureChangedDelegate MainResPressureChanged;

		public void Initialize(bool hasCompressor, bool hasMainResConnections, bool hasTrainBrake, bool selfLappingController, bool hasIndependentBrake, bool hasHandbrake, bool ignoreOverheating, BrakeCylinderPressureCalculation brakeCylinderPressureCalculation, AnimationCurve trainBrakeCurve, AnimationCurve indBrakeCurve)
		{
			this.hasCompressor = hasCompressor;
			this.hasMainResConnections = hasMainResConnections;
			this.hasTrainBrake = hasTrainBrake;
			this.selfLappingController = selfLappingController;
			this.hasIndependentBrake = hasIndependentBrake;
			this.hasHandbrake = hasHandbrake;
			this.ignoreOverheating = ignoreOverheating;
			this.brakeCylinderPressureCalculation = brakeCylinderPressureCalculation;
			this.trainBrakeCurve = trainBrakeCurve;
			this.indBrakeCurve = indBrakeCurve;
		}

		public void ResetState()
		{
			compressorProductionRate = 0f;
			trainBrakePosition = 0f;
			independentBrakePosition = 0f;
			handbrakePosition = 0f;
			heatController.ResetState();
			mainReservoirPressure = 1f;
			mainReservoirPressureUnsmoothed = 1f;
			brakePipePressure = 1f;
			controlReservoirPressure = 1f;
			controlReservoirPressureReleased = false;
			brakeCylinderPressure = 1f;
			brakeCylinderPressureUnsmoothed = 1f;
			brakingFactor = 0f;
			unaffectedTargetBrakingFactor = 0f;
			prevBrakingFactor = 0f;
			if (compressorActivationSignal)
			{
				ToggleCompressorActivationSignal();
			}
			mainResToPipeFlow = (pipeExhaustFlow = 0f);
			brakingFactorRef = (brakeCylinderPressureRef = 0f);
			mainResPressureRef = (mainResToPipeFlowRef = 0f);
			brakePipePressureRef = (pipeExhaustFlowRef = 0f);
		}

		public void ForceCylinderPressure(float target = 4.5f)
		{
			brakeCylinderPressureUnsmoothed = target;
		}

		public void ClearCylinderPressure()
		{
			brakeCylinderPressureUnsmoothed = 1f;
		}

		public void ReleaseBrakeCylinderPressure()
		{
			this.BrakeCylinderReleased?.Invoke();
			controlReservoirPressureReleased = true;
		}

		public void ToggleCompressorActivationSignal()
		{
			compressorActivationSignal = !compressorActivationSignal;
			this.CompressorActivationSignalChanged?.Invoke(compressorActivationSignal);
		}

		public void SetHandbrakePosition(float valueToSet, bool forced = true)
		{
			if (!hasHandbrake)
			{
				Debug.LogError("Unexpected state: Calling SetHandbrakePosition but hasHandbrake is set to false! Ignoring request");
				return;
			}
			valueToSet = Mathf.Clamp01(valueToSet);
			handbrakePosition = valueToSet;
			this.HandbrakePositionChanged?.Invoke((valueToSet, forced));
		}

		public void Fire_MainReservoirPressureChanged()
		{
			this.MainResPressureChanged?.Invoke(MainResPressureNormalized, mainReservoirPressure);
		}

		public void BrakingFactorChangeUpdate()
		{
			if (Mathf.Abs(brakingFactor - prevBrakingFactor) > 0.05f || (brakingFactor == 0f && prevBrakingFactor != 0f))
			{
				prevBrakingFactor = brakingFactor;
				this.BrakingFactorChanged?.Invoke();
			}
		}

		public void SetBrakePipePressure(float value)
		{
			if (brakeset == null)
			{
				Debug.LogError("Attempt to SetBrakePipePressure with no Brakeset available");
			}
			else if (brakeset.cars.Count != 1)
			{
				Debug.LogError("Attempt to SetBrakePipePressure on Brakeset with multiple cars");
			}
			else
			{
				brakeset.pipePressure = (brakePipePressure = value);
			}
		}

		public void SetMainReservoirPressure(float value)
		{
			mainReservoirPressure = (mainReservoirPressureUnsmoothed = value);
		}

		public void SetAuxReservoirPressure(float value)
		{
			auxReservoirPressure = value;
		}

		public void SetControlReservoirPressure(float value = 6f)
		{
			controlReservoirPressure = value;
		}

		private static float TransferWithMassLimit(float dt, ref float p1, ref float p2, float v1, float v2, float transferSpeedMult, float massLimit)
		{
			float num = p1 - p2;
			float num2 = Mathf.Min(dt * transferSpeedMult * num, massLimit);
			p1 -= num2 / v1;
			p2 += num2 / v2;
			return num2;
		}

		private static float OneWayFlow(float dt, ref float p1, ref float p2, float v1, float v2, float transferSpeedMult, float p2PressureLimit = float.PositiveInfinity)
		{
			float num = p1 - p2;
			if (num < 0f)
			{
				return 0f;
			}
			if (p2 >= p2PressureLimit)
			{
				return 0f;
			}
			float a = num * v1 * v2 / (v1 + v2);
			float b = Mathf.Max(0f, (p2PressureLimit - p2) * v2);
			float massLimit = Mathf.Min(a, b);
			return TransferWithMassLimit(dt, ref p1, ref p2, v1, v2, transferSpeedMult, massLimit);
		}

		public static float VentToAtmosphere(float dt, ref float p, float v, float transferSpeedMult, float pressureLimit = 1f)
		{
			float p2 = 1f;
			return TransferWithMassLimit(dt, ref p, ref p2, v, 10000f, transferSpeedMult, v * Mathf.Abs(p - pressureLimit));
		}

		private void SimulateCompressor(float dt)
		{
			float num = mainReservoirPressureUnsmoothed;
			if (compressorProductionRate > 0.001f)
			{
				float num2 = dt * gameParams.CompressorProductionModifier * compressorProductionRate / mainResVolume;
				mainReservoirPressureUnsmoothed = Mathf.Clamp(mainReservoirPressureUnsmoothed + num2, 1f, 9f);
			}
			pipeMassFlow += OneWayFlow(dt, ref brakeset.pipePressure, ref mainReservoirPressureUnsmoothed, brakeset.pipeVolume, mainResVolume, BrakeSystemConsts.BP_TO_MR_EQ_SPEED_MULTIPLIER) / dt;
			if (!compressorActivationSignal && mainReservoirPressureUnsmoothed < compressorActivationPressure)
			{
				ToggleCompressorActivationSignal();
			}
			else if (compressorActivationSignal && mainReservoirPressureUnsmoothed >= 9f)
			{
				ToggleCompressorActivationSignal();
			}
			if (Mathf.Abs(mainReservoirPressure - mainReservoirPressureUnsmoothed) > 0.0001f || num != mainReservoirPressureUnsmoothed)
			{
				Fire_MainReservoirPressureChanged();
			}
		}

		private void SimulateTrainBrake(float dt)
		{
			if (!trainBrakeCutout)
			{
				return;
			}
			if (selfLappingController)
			{
				float t = ((trainBrakeCurve != null) ? trainBrakeCurve.Evaluate(trainBrakePosition) : trainBrakePosition);
				float num = Mathf.Lerp(6f, 4.5f, t);
				if (num < brakeset.pipePressure)
				{
					exhaustMassFlow += VentToAtmosphere(dt, ref brakeset.pipePressure, brakeset.pipeVolume, BrakeSystemConsts.DUMP_EQ_SPEED_MULTIPLIER, num) / dt;
				}
				else if (num > brakeset.pipePressure)
				{
					pipeMassFlow += OneWayFlow(dt, ref mainReservoirPressureUnsmoothed, ref brakeset.pipePressure, mainResVolume, brakeset.pipeVolume, BrakeSystemConsts.MR_TO_BP_EQ_SPEED_MULTIPLIER, num) / dt;
				}
			}
			else if (trainBrakePosition > 0.9f)
			{
				exhaustMassFlow += VentToAtmosphere(dt, ref brakeset.pipePressure, brakeset.pipeVolume, 150f) / dt;
			}
			else if (trainBrakePosition > 0.5f)
			{
				exhaustMassFlow += VentToAtmosphere(dt, ref brakeset.pipePressure, brakeset.pipeVolume, BrakeSystemConsts.DUMP_EQ_SPEED_MULTIPLIER, brakeset.pipePressure - 0.2f * dt) / dt;
			}
			else if (!(trainBrakePosition > 0.1f))
			{
				pipeMassFlow += OneWayFlow(dt, ref mainReservoirPressureUnsmoothed, ref brakeset.pipePressure, mainResVolume, brakeset.pipeVolume, BrakeSystemConsts.MR_TO_BP_EQ_SPEED_MULTIPLIER, 6f) / dt;
			}
		}

		private float TargetCylinderPressure()
		{
			float num = controlReservoirPressure - brakeset.pipePressure;
			if (num < 0.3000002f)
			{
				return 1f;
			}
			float t = Mathf.InverseLerp(0.3000002f, 1.5f, num);
			return Mathf.Lerp(1.5f, 4.5f, t);
		}

		private void SimulateLocoControlValve(float dt)
		{
			float num = TargetCylinderPressure();
			if (hasIndependentBrake)
			{
				float t = ((indBrakeCurve != null) ? indBrakeCurve.Evaluate(independentBrakePosition) : independentBrakePosition);
				float b = Mathf.Lerp(1f, 4.5f, t);
				num = Mathf.Max(num, b);
			}
			if (num < brakeCylinderPressureUnsmoothed)
			{
				exhaustMassFlow += VentToAtmosphere(dt, ref brakeCylinderPressureUnsmoothed, 10f, BrakeSystemConsts.IND_DUMP_EQ_SPEED_MULTIPLIER, num) / dt;
			}
			else if (num > brakeCylinderPressureUnsmoothed)
			{
				pipeMassFlow += OneWayFlow(dt, ref mainReservoirPressureUnsmoothed, ref brakeCylinderPressureUnsmoothed, mainResVolume, 10f, BrakeSystemConsts.MR_TO_IND_BP_EQ_SPEED_MULTIPLIER, num) / dt;
			}
			if (controlReservoirPressureReleased)
			{
				controlReservoirPressure = 1f;
				controlReservoirPressureReleased = false;
			}
			else if (controlReservoirPressure < brakeset.pipePressure)
			{
				controlReservoirPressure = brakeset.pipePressure;
			}
		}

		private void SimulateCarControlValve(float dt)
		{
			float transferSpeedMult = ((auxReservoirPressure > BrakeSystemConsts.SLOW_RECHARGE_THRESHOLD) ? (BrakeSystemConsts.BP_TO_AUX_EQ_SPEED_MULTIPLIER * BrakeSystemConsts.SLOW_RECHARGE_MULTIPLIER) : BrakeSystemConsts.BP_TO_AUX_EQ_SPEED_MULTIPLIER);
			pipeMassFlow += OneWayFlow(dt, ref brakeset.pipePressure, ref auxReservoirPressure, brakeset.pipeVolume, 50f, transferSpeedMult) / dt;
			float num = TargetCylinderPressure();
			float num2 = brakeCylinderPressureUnsmoothed - num;
			if (num2 > 0.01f)
			{
				exhaustMassFlow += VentToAtmosphere(dt, ref brakeCylinderPressureUnsmoothed, 10f, BrakeSystemConsts.CYLINDER_VENT_EQ_SPEED_MULTIPLIER, num) / dt;
			}
			else if (num2 < -0.01f)
			{
				pipeMassFlow += OneWayFlow(dt, ref auxReservoirPressure, ref brakeCylinderPressureUnsmoothed, 50f, 10f, BrakeSystemConsts.CYLINDER_APPLY_EQ_SPEED_MULTIPLIER, num) / dt;
			}
			if (controlReservoirPressureReleased)
			{
				controlReservoirPressure = 1f;
				controlReservoirPressureReleased = false;
			}
			else if (controlReservoirPressure < brakeset.pipePressure)
			{
				controlReservoirPressure = brakeset.pipePressure;
			}
		}

		private void SimulateLeakage(float dt)
		{
			VentToAtmosphere(dt, ref auxReservoirPressure, 50f, BrakeSystemConsts.AUX_RES_LEAK_EQ_SPEED_MULTIPLIER);
			VentToAtmosphere(dt, ref brakeCylinderPressureUnsmoothed, 10f, BrakeSystemConsts.CYLINDER_LEAK_EQ_SPEED_MULTIPLIER);
		}

		private void SimulateBrakingForce(float dt)
		{
			float a = Mathf.InverseLerp(1.5f, 4.5f, brakeCylinderPressureUnsmoothed);
			float num = handbrakePosition;
			if (!brakeset.anyHandbrakeApplied && num > 0f)
			{
				brakeset.anyHandbrakeApplied = true;
			}
			float num2 = (unaffectedTargetBrakingFactor = Mathf.Max(a, num)) * heatController.overheatReductionFactor;
			brakingFactor = Mathf.SmoothDamp(brakingFactor, num2, ref brakingFactorRef, 0.2f);
			if (brakingFactor < 0.01f && brakingFactor > 0f && num2 == 0f)
			{
				brakingFactor = 0f;
				brakingFactorRef = 0f;
			}
			if (gameParams.OverheatingAllowed && !ignoreOverheating)
			{
				heatController.UpdateTemperature(brakingFactor, dt);
			}
			BrakingFactorChangeUpdate();
		}

		private void SimulateAngleCocks()
		{
			Front.UpdatePressurized();
			Rear.UpdatePressurized();
		}

		private float BrakePipeSoundCurve(float massFlow)
		{
			float num = Mathf.Clamp01(massFlow / BrakeSystemConsts.PIPE_AUDIO_SATURATION);
			if (num < 0.1f)
			{
				return 5f * num;
			}
			return 5f / 9f * num + 4f / 9f;
		}

		private void UpdateReadouts(float dt)
		{
			mainReservoirPressure = Mathf.SmoothDamp(mainReservoirPressure, mainReservoirPressureUnsmoothed, ref mainResPressureRef, 0.8f);
			brakePipePressure = Mathf.SmoothDamp(brakePipePressure, brakeset.pipePressure, ref brakePipePressureRef, 0.3f);
			mainResToPipeFlow = Mathf.SmoothDamp(mainResToPipeFlow, BrakePipeSoundCurve(pipeMassFlow), ref mainResToPipeFlowRef, 0.5f);
			pipeExhaustFlow = Mathf.SmoothDamp(pipeExhaustFlow, exhaustMassFlow / BrakeSystemConsts.VENT_AUDIO_SATURATION, ref pipeExhaustFlowRef, 0.5f);
			brakeCylinderPressure = Mathf.SmoothDamp(brakeCylinderPressure, brakeCylinderPressureUnsmoothed, ref brakeCylinderPressureRef, 0.3f);
		}

		public void Tick(float dt)
		{
			pipeMassFlow = 0f;
			exhaustMassFlow = 0f;
			if (hasCompressor)
			{
				SimulateCompressor(dt);
				if (hasTrainBrake)
				{
					SimulateTrainBrake(dt);
				}
				SimulateLocoControlValve(dt);
			}
			else if (brakeCylinderPressureCalculation == BrakeCylinderPressureCalculation.Regular)
			{
				SimulateCarControlValve(dt);
			}
			else
			{
				switch (brakeCylinderPressureCalculation)
				{
				case BrakeCylinderPressureCalculation.CopyFront:
					if (Front.IsFullyConnected)
					{
						BrakeSystem parentSystem3 = Front.connectedTo.parentSystem;
						brakeCylinderPressureUnsmoothed = parentSystem3.brakeCylinderPressureUnsmoothed;
						controlReservoirPressure = parentSystem3.controlReservoirPressure;
					}
					if (controlReservoirPressureReleased)
					{
						if (!Front.IsFullyConnected)
						{
							controlReservoirPressure = 1f;
							brakeCylinderPressureUnsmoothed = 1f;
						}
						controlReservoirPressureReleased = false;
					}
					break;
				case BrakeCylinderPressureCalculation.CopyRear:
					if (Rear.IsFullyConnected)
					{
						BrakeSystem parentSystem4 = Rear.connectedTo.parentSystem;
						brakeCylinderPressureUnsmoothed = parentSystem4.brakeCylinderPressureUnsmoothed;
						controlReservoirPressure = parentSystem4.controlReservoirPressure;
					}
					if (controlReservoirPressureReleased)
					{
						if (!Rear.IsFullyConnected)
						{
							controlReservoirPressure = 1f;
							brakeCylinderPressureUnsmoothed = 1f;
						}
						controlReservoirPressureReleased = false;
					}
					break;
				case BrakeCylinderPressureCalculation.CopyMax:
				{
					float num = -1f;
					float num2 = -1f;
					if (Front.IsFullyConnected)
					{
						BrakeSystem parentSystem = Front.connectedTo.parentSystem;
						num = parentSystem.brakeCylinderPressureUnsmoothed;
						num2 = parentSystem.controlReservoirPressure;
					}
					if (Rear.IsFullyConnected)
					{
						BrakeSystem parentSystem2 = Rear.connectedTo.parentSystem;
						num = Mathf.Max(num, parentSystem2.brakeCylinderPressureUnsmoothed);
						num2 = Mathf.Max(num2, parentSystem2.controlReservoirPressure);
					}
					if (num > -1f)
					{
						brakeCylinderPressureUnsmoothed = num;
					}
					if (num2 > -1f)
					{
						controlReservoirPressure = num2;
					}
					if (controlReservoirPressureReleased)
					{
						if (!Front.IsFullyConnected && !Rear.IsFullyConnected)
						{
							controlReservoirPressure = 1f;
							brakeCylinderPressureUnsmoothed = 1f;
						}
						controlReservoirPressureReleased = false;
					}
					break;
				}
				default:
					Debug.LogError(string.Format("Unhandled {0} case: {1}", "brakeCylinderPressureCalculation", brakeCylinderPressureCalculation));
					break;
				}
			}
			if (gameParams.PressureLeakAllowed)
			{
				SimulateLeakage(dt);
			}
			SimulateBrakingForce(dt);
			SimulateAngleCocks();
			UpdateReadouts(dt);
		}
	}
}
