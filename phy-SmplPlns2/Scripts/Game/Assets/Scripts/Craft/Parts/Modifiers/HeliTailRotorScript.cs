using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Simulation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class HeliTailRotorScript : BladedEngineScript
	{
		private Transform _collectiveShaft;

		private Vector3 _collectiveShaftNeutralPosition;

		private HeliTailRotorData _data;

		private float _lastAvRateGyro;

		private bool _rateGyroUsingHeadingHoldMode;

		private InputControllerScript _tailInput;

		private PidController _tailPid;

		private InputControllerScript _tailTrim;

		public bool BladeGripIsOnLeadingEdge => _data.ReverseRotation;

		public override string FriendlyName => "Tail Rotor";

		public float TailInputWithTrim => _tailInput.Value + _tailTrim.Value * _data.TrimScale;

		public Vector3 YawVec => base.BladeAssemblyHub.forward;

		private float ComPlacementReverse => Mathf.Sign(CalculateAngularVelocityImpactFromForce(base.BodyNonRotatingBase.transform, _part.Aircraft.OrientedCenterOfMassRigidBodies.position, Vector3.forward, Vector3.zero).y);

		private float TailInputReverse => ComPlacementReverse;

		public static Vector3 CalculateAngularVelocityImpactFromForce(Transform localAvTransform, Vector3 worldCenterOfMass, Vector3 localForceDir, Vector3 localForcePos)
		{
			Vector3 rhs = localAvTransform.InverseTransformPoint(worldCenterOfMass) - localForcePos;
			return Vector3.Cross(localForceDir, rhs);
		}

		public override void Initialize(bool remoteCraft)
		{
			_data = (HeliTailRotorData)base.Engine;
			base.Initialize(remoteCraft);
			base.BladeMotion = BladeMotionType.Both;
			_collectiveShaft = base.RotatingHeadAssembly.Find("TailRotor/TailCollectiveShaft");
			_collectiveShaftNeutralPosition = _collectiveShaft.transform.localPosition;
			_tailPid = new PidController();
			base.DirectPitchControl = true;
			if (base.LoadContext == CraftLoadContext.Flight && !remoteCraft)
			{
				base.Power *= 500f;
				SetMaxSlip(0f);
			}
		}

		protected override void FlightFixedUpdate(in CraftUpdateFrameData frame)
		{
			base.FlightFixedUpdate(in frame);
			base.BodyNonRotatingBase.AddTorque(GetYawAxisDragTorque(YawVec, base.DragTorque, base.Rpm));
		}

		protected override void FlightUpdate(bool remoteCraft)
		{
			base.FlightUpdate(remoteCraft);
			UpdateCollectiveShaft();
			if (Debug.isDebugBuild && UnityEngine.Input.GetKeyUp(KeyCode.Keypad0))
			{
				AdvanceNextTailmode(displayMessage: true);
			}
		}

		protected override float GetDirectControlPitchValue()
		{
			return GetTailPitch(_data.TailMode);
		}

		protected override float GetEngineAudioPitch()
		{
			return Mathf.Clamp(Math.Abs(base.PropellerPitch) * 5f, 0.1f, 2f) * base.RpmPercentOfMaxClamp01;
		}

		protected override void RotateBlade(BladeAssembly blade, float neutralRotation, float pitchDegrees)
		{
			blade.Grip.localEulerAngles = new Vector3(0f, BladeGripIsOnLeadingEdge ? 180 : 0, 0f);
			blade.Root.Rotate(new Vector3(0f, neutralRotation + pitchDegrees, 0f), Space.Self);
		}

		protected override void SetupInput(InputControllerScript inputController)
		{
			base.SetupInput(inputController);
			if (inputController.InputController.Name == "tailInput")
			{
				_tailInput = inputController;
			}
			else if (inputController.InputController.Name == "tailTrim")
			{
				_tailTrim = inputController;
			}
		}

		private void AdvanceNextTailmode(bool displayMessage)
		{
			switch (_data.TailMode)
			{
			case HeliTailRotorData.TailModeType.HeadingHold:
				_data.TailMode = HeliTailRotorData.TailModeType.Manual;
				break;
			case HeliTailRotorData.TailModeType.Manual:
				_data.TailMode = HeliTailRotorData.TailModeType.Rate;
				break;
			case HeliTailRotorData.TailModeType.Rate:
				_data.TailMode = HeliTailRotorData.TailModeType.HeadingHold;
				break;
			}
			if (displayMessage)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage($"Tail Mode: {_data.TailMode}");
			}
		}

		private float GetTailPitch(HeliTailRotorData.TailModeType tailMode)
		{
			float b = 0f;
			switch (tailMode)
			{
			case HeliTailRotorData.TailModeType.HeadingHold:
				b = GetTailPitchFromHeadingHoldGyro(resetPid: false);
				break;
			case HeliTailRotorData.TailModeType.Manual:
				b = TailInputWithTrim * TailInputReverse;
				break;
			case HeliTailRotorData.TailModeType.Rate:
				b = GetTailPitchFromRateGyro();
				break;
			}
			return Mathf.Clamp(Mathf.Lerp(base.PropellerPitch, b, Time.deltaTime / _data.LinkageSpeed), -0.25f, 0.25f);
		}

		private float GetTailPitchFromHeadingHoldGyro(bool resetPid)
		{
			if (resetPid)
			{
				_tailPid.Reset();
			}
			float target = TailInputWithTrim * _data.TailSpeed;
			float tailYawAngularVelocity = GetTailYawAngularVelocity();
			_tailPid.PidGains = _data.PidGainsHeadingHold;
			_tailPid.ErrorMaxAccum = MathF.PI / 4f;
			return TailInputReverse * _tailPid.Update(tailYawAngularVelocity, target, Time.deltaTime);
		}

		private float GetTailPitchFromRateGyro()
		{
			float tailYawAngularVelocity = GetTailYawAngularVelocity();
			float num = TailInputWithTrim * _data.TailSpeed;
			float tailYawAngularAcceleration = GetTailYawAngularAcceleration(tailYawAngularVelocity, ref _lastAvRateGyro);
			num += 0f - Mathf.Pow(Mathf.Abs(tailYawAngularVelocity), 2.5f) * Mathf.Sign(tailYawAngularVelocity);
			_tailPid.PidGains = _data.PidGainsRate;
			_tailPid.ErrorMaxAccum = null;
			return TailInputReverse * _tailPid.Update(tailYawAngularAcceleration, num, Time.deltaTime);
		}

		private float GetTailYawAngularAcceleration(float yawAv, ref float lastAngularVelocity)
		{
			float num = yawAv - lastAngularVelocity;
			lastAngularVelocity = yawAv;
			return num / Time.deltaTime;
		}

		private float GetTailYawAngularVelocity()
		{
			return base.BodyNonRotatingBase.transform.InverseTransformDirection(base.BodyNonRotatingBase.angularVelocity).y;
		}

		private Vector3 GetYawAxisDragTorque(Vector3 yawVec, float dragTorque, float rpm)
		{
			return yawVec * (dragTorque * Mathf.Sign(rpm) * 5f);
		}

		private void UpdateCollectiveShaft()
		{
			_collectiveShaft.localPosition = _collectiveShaftNeutralPosition + _collectiveShaft.InverseTransformDirection(_collectiveShaft.up) * (base.PropellerPitch * 0.35f);
		}
	}
}
