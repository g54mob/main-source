using System;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class ManualOilingPointsDefinition : SimComponentDefinition
	{
		[Serializable]
		public class OilingPointDefinition
		{
			public PortDefinition oilLevelReadOut;

			public PortDefinition oilLevelNormalizedReadOut;

			public PortDefinition pointDoorExtIn;

			public PortDefinition refillExtIn;

			public PortDefinition refillingFlowNormalizedReadOut;
		}

		[Header("Per oiling point")]
		public float capacity = 5f;

		public float consumptionPerRev = 0.001f;

		public float pointOpenConsumptionMultiplier = 100f;

		public float leakPerHour = 0.125f;

		public float refillRate = 2.5f;

		public float damagePerRevWhenEmpty = 1f;

		public readonly PortReferenceDefinition oilStorage = new PortReferenceDefinition(PortValueType.OIL, "OIL_STORAGE");

		public readonly PortReferenceDefinition oilConsumption = new PortReferenceDefinition(PortValueType.OIL, "OIL_CONSUMPTION", writeAllowed: true);

		public readonly PortReferenceDefinition wheelRpm = new PortReferenceDefinition(PortValueType.RPM, "WHEEL_RPM");

		public readonly PortDefinition mechanicalDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "MECHANICAL_DAMAGE");

		public readonly PortDefinition mechanicalPowerTrainHealthExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "MECHANICAL_PT_HEALTH_EXT_IN");

		public readonly PortDefinition lowestOilLevelNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "LOWEST_OIL_LEVEL_NORMALIZED");

		public readonly PortDefinition lowestOilLevelAudioReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "LOWEST_OIL_LEVEL_AUDIO");

		public readonly PortDefinition specialRequestExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "SPECIAL_REQUEST");

		public OilingPointDefinition[] oilingPoints;

		public override SimComponent InstantiateImplementation()
		{
			return new ManualOilingPoints(this);
		}

		private void OnValidate()
		{
			if (oilingPoints != null)
			{
				for (int i = 0; i < oilingPoints.Length; i++)
				{
					OilingPointDefinition obj = oilingPoints[i];
					obj.oilLevelReadOut.type = PortType.READONLY_OUT;
					obj.oilLevelReadOut.valueType = PortValueType.OIL;
					obj.oilLevelReadOut.ID = $"OIL_LEVEL_{i}";
					obj.oilLevelNormalizedReadOut.type = PortType.READONLY_OUT;
					obj.oilLevelNormalizedReadOut.valueType = PortValueType.OIL;
					obj.oilLevelNormalizedReadOut.ID = $"OIL_LEVEL_NORMALIZED_{i}";
					obj.pointDoorExtIn.type = PortType.EXTERNAL_IN;
					obj.pointDoorExtIn.valueType = PortValueType.CONTROL;
					obj.pointDoorExtIn.ID = $"POINT_DOOR_EXT_IN_{i}";
					obj.refillExtIn.type = PortType.EXTERNAL_IN;
					obj.refillExtIn.valueType = PortValueType.CONTROL;
					obj.refillExtIn.ID = $"REFILL_EXT_IN_{i}";
					obj.refillingFlowNormalizedReadOut.type = PortType.READONLY_OUT;
					obj.refillingFlowNormalizedReadOut.valueType = PortValueType.STATE;
					obj.refillingFlowNormalizedReadOut.ID = $"REFILLING_FLOW_NORMALIZED_{i}";
				}
			}
		}
	}
}
