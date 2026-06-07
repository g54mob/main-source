using System;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[Serializable]
	public class GearboxComponent : PowertrainComponent
	{
		[SerializeField]
		public float Efficiency { get; set; } = 1f;

		[SerializeField]
		public float GearRatio { get; set; } = 1f;

		public override float ForwardStep(float torque, float inertiaSum, float dt)
		{
			inputTorque = torque;
			inputInertia = inertiaSum;
			float clampedGearRatio = GetClampedGearRatio();
			if (outputNameHash == 0 || Mathf.Approximately(clampedGearRatio, 0f))
			{
				outputTorque = 0f;
				outputInertia = 0f;
				return 0f;
			}
			outputTorque = inputTorque * clampedGearRatio * Efficiency;
			outputInertia = (inertiaSum + inertia) * (clampedGearRatio * clampedGearRatio);
			float num = _output.ForwardStep(outputTorque, outputInertia, dt);
			if (Efficiency > 0.0001f)
			{
				return num / (Mathf.Abs(clampedGearRatio) * Efficiency);
			}
			return num / Mathf.Abs(clampedGearRatio);
		}

		public override float QueryAngularVelocity(float angularVelocity, float dt)
		{
			inputAngularVelocity = angularVelocity;
			float clampedGearRatio = GetClampedGearRatio();
			if (outputNameHash == 0 || Mathf.Approximately(clampedGearRatio, 0f))
			{
				outputAngularVelocity = 0f;
				return angularVelocity;
			}
			outputAngularVelocity = angularVelocity / clampedGearRatio;
			return _output.QueryAngularVelocity(outputAngularVelocity, dt) * clampedGearRatio;
		}

		public override float QueryInertia()
		{
			float clampedGearRatio = GetClampedGearRatio();
			if (outputNameHash == 0 || Mathf.Approximately(clampedGearRatio, 0f))
			{
				return inertia;
			}
			float num = _output.QueryInertia() / (clampedGearRatio * clampedGearRatio);
			return inertia + num;
		}

		public override void VC_Validate(VehicleController vc)
		{
			base.VC_Validate(vc);
			if (Mathf.Approximately(GearRatio, 0f))
			{
				PC_LogWarning(vc, name + ": Gear Ratio is zero or very close to zero. It will act as disconnected. Calculations will use a tiny non-zero value internally to avoid errors.");
			}
			if (Efficiency < 0f || Efficiency > 1f)
			{
				PC_LogWarning(vc, $"{name}: Efficiency ({Efficiency}) is outside the valid range [0, 1]. Clamping.");
				Efficiency = Mathf.Clamp01(Efficiency);
			}
		}

		private float GetClampedGearRatio()
		{
			if (Mathf.Approximately(GearRatio, 0f))
			{
				return Mathf.Sign(GearRatio) * 1E-05f;
			}
			return GearRatio;
		}
	}
}
