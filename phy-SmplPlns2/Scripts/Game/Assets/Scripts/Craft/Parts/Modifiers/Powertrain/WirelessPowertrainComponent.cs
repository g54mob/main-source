using System.Collections.Generic;
using NWH.VehiclePhysics2.Powertrain;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class WirelessPowertrainComponent : PowertrainComponent
	{
		public List<PowertrainComponent> Outputs { get; private set; } = new List<PowertrainComponent>();

		public WirelessPowertrainComponent()
		{
			inertia = 0.02f;
		}

		public override float ForwardStep(float torque, float inertiaSum, float dt)
		{
			inputTorque = torque;
			inputInertia = inertiaSum;
			int count = Outputs.Count;
			if (count == 0)
			{
				outputTorque = torque;
				return 0f;
			}
			float num = torque / (float)count;
			float inertiaSum2 = (inertiaSum + inertia) / (float)count;
			float num2 = 0f;
			outputTorque = 0f;
			for (int i = 0; i < count; i++)
			{
				if (Outputs[i] != null)
				{
					num2 += Outputs[i].ForwardStep(num, inertiaSum2, dt);
					outputTorque += num;
				}
			}
			return num2;
		}

		public override float QueryAngularVelocity(float angularVelocity, float dt)
		{
			inputAngularVelocity = angularVelocity;
			int count = Outputs.Count;
			if (count == 0)
			{
				outputAngularVelocity = angularVelocity;
				return angularVelocity;
			}
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				if (Outputs[i] != null)
				{
					num += Outputs[i].QueryAngularVelocity(angularVelocity, dt);
				}
			}
			outputAngularVelocity = num / (float)count;
			return outputAngularVelocity;
		}

		public override float QueryInertia()
		{
			float num = inertia;
			for (int i = 0; i < Outputs.Count; i++)
			{
				if (Outputs[i] != null)
				{
					num += Outputs[i].QueryInertia();
				}
			}
			return num;
		}
	}
}
