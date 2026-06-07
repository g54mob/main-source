using System;
using UnityEngine;

namespace Assets.Scripts.CustomWheelCollider
{
	[Serializable]
	public class ResizableWheelColliderData
	{
		[SerializeField]
		public float BrakeTorque = 2500f;

		[SerializeField]
		public float DamperScale = 1f;

		[SerializeField]
		public float GearRatio = 1f;

		[SerializeField]
		public float MaxShaftRpm = 1333f;

		[SerializeField]
		public float MaxTorqueAtMotorShaft = 1500f;

		[SerializeField]
		public float MaxTurningAngle = 30f;

		[SerializeField]
		public float Radius = 1f;

		[SerializeField]
		public bool ReverseDirection;

		[SerializeField]
		public float SimulatedRotationalMass = 1f;

		[SerializeField]
		public float SlipForwardAsymptote = 10f;

		[SerializeField]
		public float SlipForwardExtremum = 8f;

		[SerializeField]
		public float SlipSidewaysAsymptote = 20f;

		[SerializeField]
		public float SlipSidewaysExtremum = 15f;

		[SerializeField]
		public float SpringForceScale = 1f;

		[SerializeField]
		public float SuspensionDistance = 0.25f;

		[SerializeField]
		public float SuspensionStiffness = 0.65f;

		[SerializeField]
		public float ThicknessScale = 1f;

		[SerializeField]
		public float TractionForward = 1f;

		[SerializeField]
		public float TractionSideways = 1f;

		[SerializeField]
		public float TurningRate = 150f;

		[SerializeField]
		public float Width = 1f;

		[SerializeField]
		private bool _suspensionEnabled = true;

		public float MaxTorqueAtWheel => MaxTorqueAtMotorShaft * GearRatio;

		[SerializeField]
		public float MaxWheelRpm => MaxShaftRpm / GearRatio;

		public bool SuspensionEnabled
		{
			get
			{
				return _suspensionEnabled;
			}
			set
			{
				_suspensionEnabled = value;
				if (!_suspensionEnabled)
				{
					Debug.LogError("Wheel collider does not fully support disabled suspension");
				}
			}
		}

		public float CalculateFrictionScale()
		{
			return Mathf.Max(1f, Mathf.Sqrt(Radius * Width));
		}
	}
}
