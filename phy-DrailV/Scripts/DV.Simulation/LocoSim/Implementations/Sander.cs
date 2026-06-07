using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Sander : SimComponent
	{
		private const string CONTROL_VALUE_SAVE_KEY = "val";

		public readonly float sandConsumptionRate;

		public readonly float sandCoeficientMax;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference sand;

		public readonly PortReference sandConsumption;

		public readonly Port controlExtIn;

		public readonly Port sandCoefReadOut;

		public readonly Port sandFlowReadOut;

		public float sandFlow;

		public float sandFlowVelocity;

		public override bool HasSaveData => true;

		public Sander(SanderDefinition sDef)
			: base(sDef.ID)
		{
			sandConsumptionRate = sDef.sandConsumptionRate;
			sandCoeficientMax = sDef.sandCoeficientMax;
			if (!string.IsNullOrEmpty(sDef.powerFuseId))
			{
				powerFuseRef = AddFuseReference(sDef.powerFuseId);
			}
			controlExtIn = AddPort(sDef.controlExtIn);
			sandCoefReadOut = AddPort(sDef.sandCoefReadOut);
			sandFlowReadOut = AddPort(sDef.sandFlowReadOut);
			sand = AddPortReference(sDef.sand);
			sandConsumption = AddPortReference(sDef.sandConsumption);
		}

		public override void Tick(float delta)
		{
			float value = sand.Value;
			float value2 = controlExtIn.Value;
			float num = ((value > 0f && (powerFuseRef == null || powerFuseRef.State)) ? value2 : 0f);
			sandFlow = Mathf.SmoothDamp(sandFlow, num, ref sandFlowVelocity, 0.5f, float.PositiveInfinity, delta);
			if ((double)sandFlow < 0.001 && num == 0f)
			{
				sandFlow = 0f;
			}
			if (sandFlow > 0f)
			{
				float num2 = sandFlow * sandConsumptionRate * gameParams.ResourceConsumptionModifier * delta;
				if (value < num2)
				{
					num2 = value;
				}
				sandConsumption.Value = num2;
			}
			sandCoefReadOut.Value = Mathf.Lerp(1f, sandCoeficientMax, sandFlow);
			sandFlowReadOut.Value = sandFlow;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("val", controlExtIn.Value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("val");
			if (num.HasValue)
			{
				controlExtIn.Value = num.Value;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".CONTROL_VALUE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
