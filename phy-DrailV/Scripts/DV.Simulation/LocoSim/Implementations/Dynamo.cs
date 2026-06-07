using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Dynamo : SimComponent
	{
		public readonly float steamConsumption;

		public readonly float minOperatingPressure;

		public readonly float smoothTime;

		public readonly PortReference dynamoControl;

		public readonly PortReference steamPressure;

		public readonly Port steamConsumptionReadOut;

		public readonly Port dynamoFlowNormalizedReadOut;

		private float dynamoFlowSmoothVelocity;

		public Dynamo(DynamoDefinition dDef)
			: base(dDef.ID)
		{
			steamConsumption = dDef.steamConsumption;
			minOperatingPressure = dDef.minOperatingPressure;
			smoothTime = dDef.smoothTime;
			steamPressure = AddPortReference(dDef.steamPressure);
			dynamoControl = AddPortReference(dDef.dynamoControl);
			dynamoFlowNormalizedReadOut = AddPort(dDef.dynamoFlowNormalizedReadOut);
			steamConsumptionReadOut = AddPort(dDef.steamConsumptionReadOut);
		}

		public override void Tick(float delta)
		{
			float num = 0f;
			if (steamPressure.Value > minOperatingPressure && dynamoControl.Value > 0f)
			{
				num = 1f;
			}
			float value = dynamoFlowNormalizedReadOut.Value;
			if (num == 0f && value < 0.01f)
			{
				value = 0f;
				dynamoFlowSmoothVelocity = 0f;
			}
			else if (num == 1f && value > 0.99f)
			{
				value = 1f;
				dynamoFlowSmoothVelocity = 0f;
			}
			else
			{
				value = Mathf.SmoothDamp(value, num, ref dynamoFlowSmoothVelocity, smoothTime, float.PositiveInfinity, delta);
			}
			dynamoFlowNormalizedReadOut.Value = value;
			steamConsumptionReadOut.Value = value * steamConsumption;
		}
	}
}
