using System;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;
using UnityEngine.Events;

namespace NWH.VehiclePhysics2.Modules.ABS
{
	[Serializable]
	public class ABSModule : VehicleComponent
	{
		[Tooltip("    Called each frame while ABS is a active.")]
		public UnityEvent absActivated = new UnityEvent();

		[Tooltip("    Is ABS currently active?")]
		public bool active;

		[Tooltip("    ABS will not work below this speed.")]
		public float lowerSpeedThreshold = 1f;

		[Range(0f, 1f)]
		[Tooltip("Longitudinal slip required for ABS to trigger.")]
		public float slipThreshold = 0.16f;

		[Range(0f, 1f)]
		[Tooltip("Range in which brake torque will be reduced. Larger value means less sensitive ABS.")]
		public float slipRange = 0.2f;

		public override bool VC_Enable(bool calledByParent)
		{
			if (base.VC_Enable(calledByParent))
			{
				bool flag = true;
				foreach (Brakes.BrakeTorqueModifier brakeTorqueModifier in vehicleController.brakes.brakeTorqueModifiers)
				{
					if (brakeTorqueModifier == new Brakes.BrakeTorqueModifier(BrakeTorqueModifier))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					vehicleController.brakes.brakeTorqueModifiers.Add(BrakeTorqueModifier);
				}
				return true;
			}
			return false;
		}

		public override bool VC_Disable(bool calledByParent)
		{
			if (base.VC_Disable(calledByParent))
			{
				active = false;
				vehicleController.brakes.brakeTorqueModifiers.RemoveAll((Brakes.BrakeTorqueModifier p) => p == new Brakes.BrakeTorqueModifier(BrakeTorqueModifier));
				return true;
			}
			return false;
		}

		public float BrakeTorqueModifier()
		{
			if (!base.IsActive)
			{
				return 1f;
			}
			active = false;
			if (vehicleController.Speed < lowerSpeedThreshold)
			{
				return 1f;
			}
			if (vehicleController.brakes.IsActive && !vehicleController.powertrain.engine.revLimiterActive && vehicleController.input.Handbrake < 0.1f)
			{
				for (int i = 0; i < vehicleController.powertrain.wheelCount; i++)
				{
					WheelComponent wheelComponent = vehicleController.powertrain.wheels[i];
					if (wheelComponent.wheelUAPI.IsGrounded && wheelComponent.wheelUAPI.LongitudinalSlip * Mathf.Sign(vehicleController.LocalForwardVelocity) > slipThreshold)
					{
						active = true;
						absActivated.Invoke();
						slipRange = ((slipRange < 1E-05f) ? 1E-05f : slipRange);
						return Mathf.Clamp01(wheelComponent.wheelUAPI.LongitudinalSlip - slipThreshold) / slipRange;
					}
				}
			}
			return 1f;
		}
	}
}
