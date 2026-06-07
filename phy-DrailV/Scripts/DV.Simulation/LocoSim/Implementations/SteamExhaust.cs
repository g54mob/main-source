using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SteamExhaust : SimComponent
	{
		public const float MIN_DAMPER = 0.1f;

		public readonly float passiveExhaust;

		public readonly float entrainmentRatio;

		public readonly float maxBlowerFlow;

		public readonly float pressureForMaxBlowerFlow;

		public readonly float maxWhistleFlow;

		public readonly PortReference exhaustFlow;

		public readonly Port airFlowReadOut;

		public readonly Port steamConsumptionReadOut;

		public readonly Port totalFlowNormalizedReadOut;

		public readonly Port whistleFlowNormalizedReadOut;

		public readonly PortReference engineMaxFlowReader;

		public readonly PortReference boilerPressure;

		public readonly PortReference blowerControl;

		public readonly PortReference whistleControl;

		public readonly PortReference damperControl;

		private float maxTotalFlow;

		public SteamExhaust(SteamExhaustDefinition seDef)
			: base(seDef.ID)
		{
			passiveExhaust = seDef.passiveExhaust;
			entrainmentRatio = seDef.entrainmentRatio;
			maxBlowerFlow = seDef.maxBlowerFlow;
			pressureForMaxBlowerFlow = seDef.pressureForMaxBlowerFlow;
			maxWhistleFlow = seDef.maxWhistleFlow;
			exhaustFlow = AddPortReference(seDef.exhaustFlow);
			airFlowReadOut = AddPort(seDef.airFlowReadOut);
			steamConsumptionReadOut = AddPort(seDef.steamConsumptionReadOut);
			totalFlowNormalizedReadOut = AddPort(seDef.totalFlowNormalizedReadOut);
			whistleFlowNormalizedReadOut = AddPort(seDef.whistleFlowNormalizedReadOut);
			engineMaxFlowReader = AddPortReference(seDef.engineMaxFlowReader);
			boilerPressure = AddPortReference(seDef.boilerPressure);
			blowerControl = AddPortReference(seDef.blowerControl);
			whistleControl = AddPortReference(seDef.whistleControl);
			damperControl = AddPortReference(seDef.damperControl);
		}

		public override void InitializationAfterConnecting()
		{
			float value = engineMaxFlowReader.Value;
			float num = passiveExhaust + entrainmentRatio * value;
			maxTotalFlow = value + num;
		}

		public override void Tick(float delta)
		{
			float a = Mathf.InverseLerp(1f, pressureForMaxBlowerFlow, boilerPressure.Value);
			float num = maxBlowerFlow * Mathf.Min(a, blowerControl.Value);
			float num2 = Mathf.Min(Mathf.InverseLerp(1f, 2f, boilerPressure.Value), whistleControl.Value);
			whistleFlowNormalizedReadOut.Value = num2;
			float num3 = num2 * maxWhistleFlow;
			float num4 = num + exhaustFlow.Value;
			float num5 = passiveExhaust + entrainmentRatio * num4;
			num5 *= Mathf.Lerp(0.1f, 1f, damperControl.Value);
			airFlowReadOut.Value = num5;
			float num6 = num4 + num5;
			totalFlowNormalizedReadOut.Value = num6 / maxTotalFlow;
			steamConsumptionReadOut.Value = num + num3;
		}
	}
}
