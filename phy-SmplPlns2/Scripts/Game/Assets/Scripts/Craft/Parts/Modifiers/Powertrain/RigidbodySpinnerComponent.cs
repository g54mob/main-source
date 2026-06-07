using System;
using NWH.Common.Utility;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[Serializable]
	public class RigidbodySpinnerComponent : PowertrainComponent
	{
		public bool enabled = true;

		[Header("Input Torque Smoothing")]
		[Tooltip("Approximate time it will take for the smoothed input torque to reach the target. Smaller values are faster.")]
		public float inputTorqueSmoothTime = 0.05f;

		[Tooltip("The axis of rotation in the local space of the target Rigidbody.")]
		public Vector3 localSpinAxis = Vector3.up;

		[Tooltip("Optional: Maximum RPM for the target Rigidbody. 0 for no limit.")]
		public float maxRPM;

		public Rigidbody sourceRigidbody;

		[Tooltip("The Rigidbody to be spun by this component.")]
		public Rigidbody targetRigidbody;

		[Tooltip("Efficiency of torque transfer (0 to 1). 1 means all input torque is applied.")]
		[Range(0f, 1f)]
		public float torqueTransferEfficiency = 1f;

		[SerializeField]
		[ShowInTelemetry]
		private float _appliedTorqueToSpinner;

		[Header("Debug Info")]
		[SerializeField]
		[ShowInTelemetry]
		private float _currentSpinnerRPM;

		private float _inputTorqueSmoothVelocity;

		[SerializeField]
		[ShowInTelemetry]
		private float _loadTorqueFromSpinner;

		private float _maxAngularVelocityRadS;

		private float _smoothedInputTorque;

		[Header("Coupling Physics")]
		[Tooltip("How 'tight' the connection is. Higher values transfer torque faster but can be less stable.")]
		public float couplingStiffness = 250f;

		public bool Reversed { get; internal set; }

		public override float ForwardStep(float torqueFromUpstream, float inertiaSumFromUpstream, float dt)
		{
			if (float.IsNaN(torqueFromUpstream) || float.IsNaN(inertiaSumFromUpstream))
			{
				torqueFromUpstream = 0f;
				inertiaSumFromUpstream = 0f;
			}
			inputTorque = torqueFromUpstream;
			inputInertia = inertiaSumFromUpstream;
			if (sourceRigidbody == null || targetRigidbody == null || !enabled || dt <= 0f)
			{
				return 0f;
			}
			float num = inputAngularVelocity;
			Vector3 vector = targetRigidbody.transform.TransformDirection(localSpinAxis.normalized);
			float num2 = Vector3.Dot(targetRigidbody.angularVelocity, vector);
			_currentSpinnerRPM = UnitConverter.AngularVelocityToRPM(num2);
			float num3 = num - num2;
			_appliedTorqueToSpinner = num3 * couplingStiffness;
			float f = torqueFromUpstream * torqueTransferEfficiency;
			_appliedTorqueToSpinner = Mathf.Clamp(_appliedTorqueToSpinner, 0f - Mathf.Abs(f), Mathf.Abs(f));
			if (_maxAngularVelocityRadS > 0f)
			{
				if (num2 >= _maxAngularVelocityRadS && _appliedTorqueToSpinner > 0f)
				{
					_appliedTorqueToSpinner = 0f;
				}
				else if (num2 <= 0f - _maxAngularVelocityRadS && _appliedTorqueToSpinner < 0f)
				{
					_appliedTorqueToSpinner = 0f;
				}
			}
			float num4 = (Reversed ? (-1f) : 1f) * _appliedTorqueToSpinner * 0.01f;
			targetRigidbody.AddTorque(vector * num4, ForceMode.Force);
			sourceRigidbody.AddTorque(-vector * num4, ForceMode.Force);
			_loadTorqueFromSpinner = 0f - _appliedTorqueToSpinner;
			outputTorque = 0f;
			return _loadTorqueFromSpinner;
		}

		public override float QueryAngularVelocity(float incomingAngularVelocity, float dt)
		{
			inputAngularVelocity = incomingAngularVelocity;
			if (targetRigidbody == null || dt <= 0f)
			{
				outputAngularVelocity = 0f;
				if (outputNameHash != 0 && _output != null)
				{
					return _output.QueryAngularVelocity(0f, dt);
				}
				return 0f;
			}
			Vector3 rhs = targetRigidbody.transform.TransformDirection(localSpinAxis.normalized);
			outputAngularVelocity = Vector3.Dot(targetRigidbody.angularVelocity, rhs);
			if (outputNameHash != 0 && _output != null)
			{
				return _output.QueryAngularVelocity(outputAngularVelocity, dt);
			}
			return outputAngularVelocity;
		}

		public override float QueryInertia()
		{
			if (targetRigidbody == null)
			{
				if (!(inertia > 0.001f))
				{
					return 0.01f;
				}
				return inertia;
			}
			Vector3 vector = Quaternion.Inverse(targetRigidbody.inertiaTensorRotation) * localSpinAxis.normalized;
			Vector3 vector2 = targetRigidbody.inertiaTensor / 0.01f;
			return Mathf.Max(vector2.x * vector.x * vector.x + vector2.y * vector.y * vector.y + vector2.z * vector.z * vector.z + ((inertia > 0.001f) ? inertia : 0.01f), 0.001f);
		}

		public override bool VC_Disable(bool calledByParent)
		{
			if (base.VC_Disable(calledByParent))
			{
				_currentSpinnerRPM = 0f;
				_appliedTorqueToSpinner = 0f;
				_loadTorqueFromSpinner = 0f;
				return true;
			}
			return false;
		}

		public override void VC_SetDefaults()
		{
			base.VC_SetDefaults();
			name = "RigidbodySpinner";
			inertia = 0.05f;
			torqueTransferEfficiency = 0.95f;
			localSpinAxis = Vector3.up;
		}

		public override void VC_Validate(VehicleController vc)
		{
			base.VC_Validate(vc);
			if (targetRigidbody == null)
			{
				PC_LogWarning(vc, name + ": Target Rigidbody is not assigned. This component will not function.");
			}
			localSpinAxis.Normalize();
			if (localSpinAxis == Vector3.zero)
			{
				PC_LogWarning(vc, name + ": Local Spin Axis cannot be zero. Defaulting to Vector3.up.");
				localSpinAxis = Vector3.up;
			}
		}

		protected override void VC_Initialize()
		{
			base.VC_Initialize();
			if (targetRigidbody == null)
			{
				PC_LogWarning(vehicleController, name + ": Target Rigidbody is not assigned.");
				enabled = false;
			}
			else
			{
				localSpinAxis = localSpinAxis.normalized;
				_maxAngularVelocityRadS = ((maxRPM > 0f) ? UnitConverter.RPMToAngularVelocity(maxRPM) : float.PositiveInfinity);
			}
		}
	}
}
