using System;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Design;
using Jundroo.Common.Debugging;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class HeliMainRotorScript : BladedEngineScript, IVariableOutput
	{
		private class PrecomputedLiftData
		{
			private const int PrecomputedSamples = 50;

			private float[] _rotorDragValues;

			private float[] _rotorLiftValues;

			private int _rpmInterval;

			public float AngleOfAttack { get; }

			public BladedEngineScript BladedEngine { get; }

			public PrecomputedLiftData(BladedEngineScript bladedEngine, float angleOfAttack)
			{
				BladedEngine = bladedEngine;
				AngleOfAttack = angleOfAttack;
				CalculatePrecomputedRotorForceValues(angleOfAttack, BladedEngine.MaxRpm * 1.5f);
			}

			public float CalculateLiftForceAtRpm(float rpm, float curveExp)
			{
				return CalculateForceAtRpm(_rotorLiftValues, rpm, BladedEngine.MaxRpm, curveExp, _rpmInterval);
			}

			private static float CalculateForceAtRpm(float[] precomputedForceValues, float rpm, float maxRpm, float curveExp, int rpmInterval)
			{
				rpm = Mathf.Abs(rpm);
				if (curveExp != 1f)
				{
					rpm *= Mathf.Pow(rpm / maxRpm, curveExp);
				}
				int num = (int)(rpm / (float)rpmInterval);
				int num2 = num + 1;
				if (num < precomputedForceValues.Length && num2 < precomputedForceValues.Length)
				{
					float a = precomputedForceValues[num];
					float b = precomputedForceValues[num2];
					int num3 = num * rpmInterval;
					float t = (rpm - (float)num3) / (float)rpmInterval;
					return Mathf.Lerp(a, b, t);
				}
				return precomputedForceValues[^1];
			}

			private void CalculatePrecomputedRotorForceValues(float angleOfAttack, float maxRpm)
			{
				_rotorLiftValues = new float[50];
				_rotorDragValues = new float[50];
				_rpmInterval = (int)(maxRpm / 50f);
				float num = 0f;
				for (int i = 0; i < 50; i++)
				{
					BladedEngine.CalculateForces(angleOfAttack, num, 1f, out var lift, out var drag);
					_rotorLiftValues[i] = lift.magnitude;
					_rotorDragValues[i] = drag.magnitude;
					num += (float)_rpmInterval;
				}
			}
		}

		private AudioSource _audioBladeSpin;

		private AudioSource _audioBladeWhirl;

		private PrecomputedLiftData _autoRotationDragForces;

		private float _baseGyrosocpicStabilizationTorque;

		private bool _bladeGripHasNinetyDegreeOffset;

		private Rigidbody _bodyToApplyForcesTo;

		private Vector3 _collectiveYawTorque;

		private InputControllerScript _cyclicPitchAltInput;

		private PrecomputedLiftData _cyclicPitchForces;

		private InputControllerScript _cyclicPitchInput;

		private InputControllerScript _cyclicRollAltInput;

		private PrecomputedLiftData _cyclicRollForces;

		private InputControllerScript _cyclicRollInput;

		private Vector3 _cyclicTorques;

		private HeliMainRotorData _data;

		private float _engineAudioPitch;

		private float _engineOperatingEfficiency;

		private float _engineOperatingEfficiencyClamped;

		private float _groundEffect;

		private float _lastPitchDecel;

		private float _lastRollDecel;

		private RotorPerfScalarsScript _performanceData;

		private Vector3 _rotorAerodynamicForward;

		private Vector3 _rotorAerodynamicRight;

		private Vector3 _rotorAerodynamicUp;

		private float _rotorAirSpeedThroughBlades;

		private float _rotorAngleOfAttack;

		private Transform _rotorDiscBack;

		private Transform _rotorDiscFront;

		private Transform _rotorDiscLeft;

		private Transform _rotorDiscRight;

		private Vector3 _rotorLiftVector;

		[SerializeField]
		private bool _showMainRotorDebug;

		private float _translationalLift;

		public bool BladeGripIsOnLeadingEdge => _data.ReverseRotation;

		public float CyclicPitch { get; private set; }

		public float CyclicRoll { get; private set; }

		public override string FriendlyName => "Main Rotor";

		public Vector3 PitchVector => base.BladeAssemblyHub.right;

		public override int ReportedRpmPriority => 10;

		public Vector3 RollVector => base.BladeAssemblyHub.up;

		public float RotorArea { get; private set; }

		public Vector3 RotorRelativeWind { get; private set; }

		[VariableOutput("RPM", "RotorRPM", 10)]
		public float RotorRPM => Mathf.Abs(base.Rpm);

		public Vector3 ThrustDirection => YawVec;

		public Vector3 YawVec => base.BladeAssemblyHub.forward;

		protected override Vector3 CenterOfMassOffset => _data.CenterOfMassOffset;

		protected override float RpmReductionPercent => 1f;

		private bool ClutchEngaged => !Utilities.CompareFloats(base.EngineTorque, 0f);

		public override void Initialize(bool remoteCraft)
		{
			_data = (HeliMainRotorData)base.Engine;
			_data.CenterOfMassOffsetChanged += OnCenterOfMassOffsetChanged;
			_performanceData = base.gameObject.GetComponent<RotorPerfScalarsScript>();
			base.Initialize(remoteCraft);
			base.BladeMotion = BladeMotionType.Both;
			base.UpdatePitchContinuously = true;
			_bodyToApplyForcesTo = base.BodyNonRotatingBase;
			base.LiftScalar = _performanceData.BaseCollectiveLiftScalar;
			base.DragScalar = _performanceData.BaseCollectiveDragScalar;
			RotorArea = MathF.PI * Mathf.Pow(base.Diameter * 0.5f, 2f);
			if (!remoteCraft)
			{
				base.BodyRotatingBladeAssembly.angularDamping = 0f;
				base.BodyRotatingBladeAssembly.SetInertiaTensor(_performanceData.CalculateTensor(RotorArea));
			}
			base.SimulatePropellersAtZeroThrottle = true;
			_rotorDiscRight = new GameObject("RotorDiscRight").transform;
			_rotorDiscRight.parent = base.transform;
			_rotorDiscRight.SetPositionAndRotation(base.BladeAssemblyHub.position + base.BladeAssemblyHub.right * (base.Diameter * 0.5f), base.BladeAssemblyHub.rotation);
			_rotorDiscFront = new GameObject("RotorDiscFront").transform;
			_rotorDiscFront.parent = base.transform;
			_rotorDiscFront.SetPositionAndRotation(base.BladeAssemblyHub.position + -base.BladeAssemblyHub.up * (base.Diameter * 0.5f), base.BladeAssemblyHub.rotation);
			_rotorDiscLeft = new GameObject("RotorDiscLeft").transform;
			_rotorDiscLeft.parent = base.transform;
			_rotorDiscLeft.SetPositionAndRotation(base.BladeAssemblyHub.position + -base.BladeAssemblyHub.right * (base.Diameter * 0.5f), base.BladeAssemblyHub.rotation);
			_rotorDiscBack = new GameObject("RotorDiscBack").transform;
			_rotorDiscBack.parent = base.transform;
			_rotorDiscBack.SetPositionAndRotation(base.BladeAssemblyHub.position + base.BladeAssemblyHub.up * (base.Diameter * 0.5f), base.BladeAssemblyHub.rotation);
			_baseGyrosocpicStabilizationTorque = RotorArea * _performanceData.GyroscopicStabilizationBaseScalar;
			if (base.LoadContext == CraftLoadContext.Flight && !remoteCraft)
			{
				SetMaxSlip(0.5f);
				base.Power *= _performanceData.EngineInitialPowerScalar;
			}
			_part.GetComponentInChildren<SwashplateAnimatorScript>().Initialize(() => base.PropellerPitch, () => CyclicPitch, () => CyclicRoll, _data.CyclicPitchMaxDeflection, _data.CyclicRollMaxDeflection, BladeGripIsOnLeadingEdge, _bladeGripHasNinetyDegreeOffset, base.ReverseRotation);
			InitializeAudio();
		}

		public override void OnModifierInitialized()
		{
			_data = (HeliMainRotorData)base.Engine;
			_data.CenterOfMassOffsetChanged += OnCenterOfMassOffsetChanged;
			base.OnModifierInitialized();
		}

		public void UpdateOutputs()
		{
		}

		protected override float CalculateMotorDragTorqueFromBladeDragForce(Vector3 bladeDragForce)
		{
			return (bladeDragForce * (base.Diameter * 0.5f)).magnitude;
		}

		protected override void FlightFixedUpdate(in CraftUpdateFrameData frame)
		{
			base.FlightFixedUpdate(in frame);
			_engineOperatingEfficiency = ((base.EngineThrottle != 0f) ? (base.RpmPercentOfMax / base.EngineThrottle) : 1f);
			_engineOperatingEfficiencyClamped = Mathf.Clamp01(_engineOperatingEfficiency);
			Vector3 linearVelocity = base.BodyNonRotatingBase.linearVelocity;
			Vector3 normalized = linearVelocity.normalized;
			_rotorAngleOfAttack = Vector3.Dot(normalized, ThrustDirection);
			_rotorAirSpeedThroughBlades = Vector3.Dot(linearVelocity, ThrustDirection);
			RotorRelativeWind = -linearVelocity;
			_rotorAerodynamicRight = Vector3.Cross(RotorRelativeWind, ThrustDirection);
			_rotorAerodynamicForward = Vector3.Cross(_rotorAerodynamicRight, ThrustDirection);
			_rotorAerodynamicUp = ThrustDirection * Mathf.Sign(Vector3.Dot(Vector3.up, ThrustDirection));
			_rotorLiftVector = Vector3.Cross(normalized, _rotorAerodynamicRight);
			_groundEffect = CalculateGroundEffectScalar();
			_translationalLift = CalculateTranslationalLiftScalar();
			base.LiftScalar = _performanceData.BaseCollectiveLiftScalar * (1f + _groundEffect + _translationalLift);
			Vector3 zero = Vector3.zero;
			Vector3 rollVector = RollVector;
			Vector3 pitchVector = PitchVector;
			Vector3 yawVec = YawVec;
			bool clutchEngaged = ClutchEngaged;
			if (clutchEngaged)
			{
				_collectiveYawTorque = GetYawAxisDragTorque(yawVec, base.DragTorque, base.Rpm);
				zero += _collectiveYawTorque;
			}
			SimulateGyroscopicStabilization(CyclicPitch, CyclicRoll);
			if (zero != Vector3.zero)
			{
				_bodyToApplyForcesTo.AddTorque(zero);
			}
			float autoRotationRatio = 0f;
			if (Vector3.Dot(_rotorAerodynamicUp, _bodyToApplyForcesTo.linearVelocity) < 0f)
			{
				autoRotationRatio = Mathf.Clamp01(Mathf.Abs(_rotorAirSpeedThroughBlades / _performanceData.RelativeWindPeakSpeed));
			}
			bool flag = !clutchEngaged || OverspeedingEnabledDefault;
			if (base.OverspeedingEnabled != flag)
			{
				SetOverspeedingEnabled(flag);
			}
			float num = 0f;
			num += GetRelativeWindMotorTorque(autoRotationRatio);
			num += GetCyclicMotorDrag();
			base.SecondaryMotorTorques = num;
			Vector3 zero2 = Vector3.zero;
			float rollMaxLiftAtRpm = _cyclicRollForces.CalculateLiftForceAtRpm(base.Rpm, _performanceData.CyclicRpmFalloffExpo);
			float pitchMaxLiftAtRpm = _cyclicPitchForces.CalculateLiftForceAtRpm(base.Rpm, _performanceData.CyclicRpmFalloffExpo);
			_cyclicTorques = GetCyclicTorques(rollVector, pitchVector, rollMaxLiftAtRpm, pitchMaxLiftAtRpm);
			zero2 += _rotorAerodynamicUp * GetRelativeWindLift(autoRotationRatio);
			if (float.IsFinite(zero2.magnitude))
			{
				_bodyToApplyForcesTo.AddForce(zero2);
			}
			if (float.IsFinite(_cyclicTorques.magnitude))
			{
				_bodyToApplyForcesTo.AddTorque(_cyclicTorques);
			}
			Thrust = zero2.magnitude / 0.01f;
			SimulateRotorVibrations();
		}

		protected override void FlightUpdate(bool remoteCraft)
		{
			base.FlightUpdate(remoteCraft);
			UpdateAudio(base.RpmPercentOfMax, _engineOperatingEfficiency);
			if (!remoteCraft)
			{
				if (base.EstimateOfUnderwaterPercent > 0.5f)
				{
					if (base.Rpm > 200f)
					{
						DestroyEngine(string.Empty);
					}
					else
					{
						base.BodyRotatingBladeAssembly.angularDamping = 1f;
					}
				}
				else if (base.RpmAbs > base.MaxRpm * _performanceData.RpmPercentToAddParasiticDrag)
				{
					base.BodyRotatingBladeAssembly.angularDamping = 0f;
				}
				else
				{
					base.BodyRotatingBladeAssembly.angularDamping = 0.1f;
				}
			}
			CyclicPitch = BladedEngineScript.GetBladePitchWithLag(_cyclicPitchInput.Value + _cyclicPitchAltInput.Value, CyclicPitch, 10f);
			CyclicRoll = BladedEngineScript.GetBladePitchWithLag(_cyclicRollInput.Value + _cyclicRollAltInput.Value, CyclicRoll, 10f);
		}

		protected override float GetEngineAudioPitch()
		{
			return _engineAudioPitch;
		}

		protected override void OnBladesInitialized()
		{
			base.OnBladesInitialized();
			if (base.LoadContext == CraftLoadContext.Flight && base.PartScript.PhysicsEnabled)
			{
				PrecomputeLiftData();
			}
		}

		protected override void OnUpdate(in CraftUpdateFrameData frame)
		{
			base.OnUpdate(in frame);
			if (_showMainRotorDebug)
			{
				Debug.Log($"Wind speed through blades: {_rotorAirSpeedThroughBlades}, engineEffeciency: {_engineOperatingEfficiency}");
				DebugGizmos.DrawRay(base.name + GetInstanceID() + "_dynRight", base.BodyNonRotatingBase.transform.position, _rotorAerodynamicRight * 5f, Color.red);
				DebugGizmos.DrawRay(base.name + GetInstanceID() + "_dynForward", base.BodyNonRotatingBase.transform.position, _rotorAerodynamicForward * 5f, Color.blue);
				DebugGizmos.DrawRay(base.name + GetInstanceID() + "_dynUp", base.BodyNonRotatingBase.transform.position, _rotorAerodynamicUp * 5f, Color.green);
			}
		}

		protected override void RotateBlade(BladeAssembly blade, float neutralRotation, float pitchDegrees)
		{
			float y = neutralRotation + AdjustBladeAngleOfAttack(blade, pitchDegrees);
			int num = ((!base.ReverseRotation) ? 1 : (-1));
			Vector3 up = blade.Root.up;
			Vector3 right = base.transform.right;
			Vector3 up2 = base.transform.up;
			float value = Vector3.Dot(up, up2) * _data.CyclicPitchMaxDeflection * CyclicPitch * (float)num;
			float value2 = Vector3.Dot(up, -right) * _data.CyclicRollMaxDeflection * CyclicRoll * (float)num;
			float value3 = (0f - pitchDegrees) * 3f;
			value = Mathf.Clamp(value, -5f, 5f);
			value2 = Mathf.Clamp(value2, -5f, 5f);
			value3 = Mathf.Clamp(value3, -5f, 5f);
			float x = (value + value2 + value3) * base.RpmPercentOfMax;
			blade.Grip.localEulerAngles = new Vector3(0f, BladeGripIsOnLeadingEdge ? 180 : 0, 0f);
			blade.Root.Rotate(new Vector3(x, y, 0f), Space.Self);
		}

		protected override void SetupInput(InputControllerScript inputController)
		{
			base.SetupInput(inputController);
			if (inputController.InputController.Name == "cyclicRoll")
			{
				_cyclicRollInput = inputController;
			}
			else if (inputController.InputController.Name == "cyclicPitch")
			{
				_cyclicPitchInput = inputController;
			}
			else if (inputController.InputController.Name == "cyclicRollAlt")
			{
				_cyclicRollAltInput = inputController;
			}
			else if (inputController.InputController.Name == "cyclicPitchAlt")
			{
				_cyclicPitchAltInput = inputController;
			}
		}

		private float AdjustBladeAngleOfAttack(BladeAssembly blade, float basePitchDegrees)
		{
			Vector3 up = blade.Root.up;
			Vector3 right = base.transform.right;
			Vector3 up2 = base.transform.up;
			float num = Vector3.Dot(up, right) * _data.CyclicPitchMaxDeflection * CyclicPitch;
			float num2 = Vector3.Dot(up, up2) * _data.CyclicRollMaxDeflection * CyclicRoll;
			float num3 = num + num2;
			return basePitchDegrees + num3;
		}

		private float CalculateGroundEffectScalar()
		{
			float num = 0f;
			float altitudeAgl = _part.Aircraft.AltitudeAgl;
			if (altitudeAgl < base.Diameter)
			{
				num = 1f - altitudeAgl / base.Diameter;
			}
			return num * _performanceData.GroundEffectScalar;
		}

		private float CalculateTranslationalLiftScalar()
		{
			return Mathf.Clamp01((new Vector2(_bodyToApplyForcesTo.linearVelocity.x, _bodyToApplyForcesTo.linearVelocity.z).magnitude - 5f) / 10f) * _performanceData.TranslationalLiftScalar;
		}

		private float GetCyclicMotorDrag()
		{
			return (0f - _cyclicTorques.magnitude) * _performanceData.CyclicMotorDragCylicTorqueRatio;
		}

		private Vector3 GetCyclicTorques(Vector3 rollAxis, Vector3 pitchAxis, float rollMaxLiftAtRpm, float pitchMaxLiftAtRpm)
		{
			Vector3 zero = Vector3.zero;
			float cyclicPitch = CyclicPitch;
			if (cyclicPitch != 0f)
			{
				float num = Mathf.Pow(Mathf.Abs(cyclicPitch), _performanceData.CyclicPitchInputExpo) * Mathf.Sign(cyclicPitch);
				float num2 = pitchMaxLiftAtRpm * num;
				zero += pitchAxis * num2;
			}
			float cyclicRoll = CyclicRoll;
			if (cyclicRoll != 0f)
			{
				float num3 = Mathf.Pow(Mathf.Abs(cyclicRoll), _performanceData.CyclicRollInputExpo) * Mathf.Sign(cyclicRoll);
				float num4 = rollMaxLiftAtRpm * num3;
				zero += rollAxis * num4;
			}
			return zero * _performanceData.CyclicBaseStrengthScalar;
		}

		private float GetRelativeWindLift(float autoRotationRatio)
		{
			return autoRotationRatio * _autoRotationDragForces.CalculateLiftForceAtRpm(base.Rpm, 1f);
		}

		private float GetRelativeWindMotorTorque(float autoRotationRatio)
		{
			return RotorArea * _performanceData.RelativeWindPassiveTorqueScalar * autoRotationRatio;
		}

		private Vector3 GetYawAxisDragTorque(Vector3 yawVec, float dragTorque, float rpm)
		{
			return yawVec * (dragTorque * Mathf.Sign(rpm) * _performanceData.CollectiveTorqueScalar);
		}

		private void InitializeAudio()
		{
			base.EngineAudioPitchLerpSpeed = 2f;
			float num = (base.Data.Diameter - base.Data.MinDiameter) / (base.Data.MaxDiameter - base.Data.MinDiameter);
			num = 0.25f + 0.75f * num;
			_audioBladeWhirl = base.gameObject.AddComponent<AudioSource>();
			AudioStore.SetupAudioSource(_audioBladeWhirl, AudioStore.HeliMainAudio, AudioStore.HeliMainAudio.Resource);
			_audioBladeWhirl.minDistance *= num;
			_audioBladeWhirl.maxDistance *= num;
			_audioBladeSpin = base.gameObject.AddComponent<AudioSource>();
			AudioStore.SetupAudioSource(_audioBladeSpin, AudioStore.HeliBladesAudio, AudioStore.HeliBladesAudio.Resource);
			_audioBladeSpin.minDistance *= num;
			_audioBladeSpin.maxDistance *= num;
			base.gameObject.AddComponent<LPFbyDistance>().Filter = base.gameObject.AddComponent<AudioLowPassFilter>();
		}

		private void OnCenterOfMassOffsetChanged(HeliMainRotorData source)
		{
			UpdateCenterOfMassForPart();
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Designer.Instance.OnAircraftStructureChanged();
			}
		}

		private void PrecomputeLiftData()
		{
			_cyclicPitchForces = new PrecomputedLiftData(this, _data.CyclicPitchMaxDeflection);
			_cyclicRollForces = new PrecomputedLiftData(this, _data.CyclicRollMaxDeflection);
			_autoRotationDragForces = new PrecomputedLiftData(this, 5f * _performanceData.RelativeWindPassiveLiftScalar);
		}

		private void SimulateGyroscopicStabilization(float pitchInput, float rollInput)
		{
			Vector3 up = Vector3.up;
			Vector3 right = Vector3.right;
			Rigidbody bodyNonRotatingBase = base.BodyNonRotatingBase;
			Vector3 vector = bodyNonRotatingBase.transform.InverseTransformDirection(bodyNonRotatingBase.angularVelocity);
			float y = vector.y;
			float x = vector.x;
			float num = _baseGyrosocpicStabilizationTorque * base.RpmPercentOfMax;
			Vector3 zero = Vector3.zero;
			float num2 = 0.5f / _performanceData.GyroscopicLagScalar;
			if (y != 0f)
			{
				float num3 = (1f - Mathf.Abs(rollInput)) * num;
				if (num3 > _lastRollDecel)
				{
					num3 = Mathf.Lerp(_lastRollDecel, num3, num2 * Time.deltaTime);
				}
				zero += up * ((0f - y) * num3);
				_lastRollDecel = num3;
			}
			if (x != 0f)
			{
				float num4 = (1f - Mathf.Abs(pitchInput)) * num;
				if (num4 > _lastPitchDecel)
				{
					num4 = Mathf.Lerp(_lastPitchDecel, num4, num2 * Time.deltaTime);
				}
				zero += right * ((0f - x) * num4);
				_lastPitchDecel = num4;
			}
			bodyNonRotatingBase.AddRelativeTorque(zero, ForceMode.Acceleration);
		}

		private void SimulateRotorVibrations()
		{
			if (_data.RotorVibrationStrength != 0f)
			{
				float num = 0f;
				num = ((!(base.RpmPercentOfMax < 0.5f)) ? Mathf.Clamp01(0.5f - (base.RpmPercentOfMax - 0.5f)) : base.RpmPercentOfMax);
				num = Mathf.Pow(num, 2f);
				float num2 = num * _data.RotorVibrationStrength;
				base.BodyRotatingBladeAssembly.AddForce(base.BodyRotatingBladeAssembly.transform.up * (num2 * 0.01f));
			}
		}

		private void UpdateAudio(float rpmPercent, float engineOperatingEffeciency)
		{
			_engineAudioPitch = Mathf.Clamp(engineOperatingEffeciency, 0.4f, 1f);
			if (rpmPercent > 0.05f)
			{
				if (!_audioBladeSpin.isPlaying || !_audioBladeWhirl.isPlaying)
				{
					_audioBladeSpin.Play();
					_audioBladeWhirl.Play();
					_audioBladeSpin.timeSamples = (int)(UnityEngine.Random.value * (float)_audioBladeSpin.clip.samples);
					_audioBladeWhirl.timeSamples = (int)(UnityEngine.Random.value * (float)_audioBladeWhirl.clip.samples);
				}
				AdjustAudio(_audioBladeSpin, rpmPercent + 1f, rpmPercent);
				float num = Mathf.Abs(CyclicPitch + CyclicRoll);
				float num2 = Mathf.Abs(base.PropellerPitch);
				float num3 = Mathf.Clamp01((num + num2) * rpmPercent);
				AdjustAudio(_audioBladeWhirl, num3, num3, 1f, 3f);
			}
			else if (_audioBladeSpin.isPlaying || _audioBladeWhirl.isPlaying)
			{
				_audioBladeSpin.Stop();
				_audioBladeWhirl.Stop();
			}
			static void AdjustAudio(AudioSource source, float desiredPitch, float volume, float pitchLerpSpeed = 0.25f, float volumeLerpSpeed = 0.25f)
			{
				source.pitch = Mathf.Lerp(source.pitch, desiredPitch, pitchLerpSpeed * Time.deltaTime);
				source.volume = Mathf.Lerp(source.volume, volume, volumeLerpSpeed * Time.deltaTime);
			}
		}
	}
}
