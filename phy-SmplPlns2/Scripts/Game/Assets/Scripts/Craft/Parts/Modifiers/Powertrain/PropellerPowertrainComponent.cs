using System;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller;
using NWH.Common.Utility;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[Serializable]
	public class PropellerPowertrainComponent : PowertrainComponent
	{
		private const float DefaultMaxRpm = 5000f;

		private float _dragTorqueFromAssembly;

		public bool IsEnabled { get; set; } = true;

		public float MaxRpm { get; set; } = 5000f;

		public PropellerAssemblyScript PropellerAssembly { get; set; }

		public override float ForwardStep(float torque, float inertiaSum, float dt)
		{
			if (float.IsNaN(torque) || float.IsNaN(inertiaSum))
			{
				torque = 0f;
				inertiaSum = 0f;
			}
			inputTorque = torque;
			inputInertia = inertiaSum;
			if (PropellerAssembly == null || !IsEnabled)
			{
				outputTorque = inputTorque;
				_dragTorqueFromAssembly = 0f;
				return 0f;
			}
			_dragTorqueFromAssembly = PropellerAssembly.GetDragTorque() / 0.01f;
			outputTorque = inputTorque - _dragTorqueFromAssembly;
			return 0f - _dragTorqueFromAssembly;
		}

		public override float QueryAngularVelocity(float angularVelocity, float dt)
		{
			inputAngularVelocity = angularVelocity;
			float num = UnitConverter.RPMToAngularVelocity(MaxRpm);
			outputAngularVelocity = Mathf.Clamp(inputAngularVelocity, 0f - num, num);
			float outputRPM = base.OutputRPM;
			if (PropellerAssembly != null)
			{
				PropellerAssembly.UpdateRPMFromPowertrain(outputRPM, outputAngularVelocity);
			}
			return outputAngularVelocity;
		}

		public override float QueryInertia()
		{
			return inertia;
		}

		public override bool VC_Disable(bool calledByParent)
		{
			if (base.VC_Disable(calledByParent))
			{
				if (PropellerAssembly != null)
				{
					PropellerAssembly.UpdateRPMFromPowertrain(0f, 0f);
				}
				_dragTorqueFromAssembly = 0f;
				return true;
			}
			return false;
		}

		public override void VC_Validate(VehicleController vc)
		{
			base.VC_Validate(vc);
			if (PropellerAssembly == null && vc != null)
			{
				PC_LogWarning(vc, "PropellerAssemblyScript is not assigned. This component will not function.");
			}
			if (MaxRpm <= 0f)
			{
				MaxRpm = 5000f;
				PC_LogWarning(vc, "MaxRPM must be greater than 0. Setting to default.");
			}
		}
	}
}
