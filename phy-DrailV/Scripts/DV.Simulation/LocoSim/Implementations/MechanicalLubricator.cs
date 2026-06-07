using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class MechanicalLubricator : SimComponent
	{
		public const float SR_HANDLED = 0f;

		public const float SR_INSTANT_REFILL_CODE = 1f;

		private const string OIL_LEVEL_SAVE_KEY = "oilNormalized";

		private const float MECHANICAL_HEALTH_LOW_OIL_AUDIO_THRESHOLD = 0.03f;

		private readonly float oilCapacity;

		private readonly float oilLeakageRate;

		private readonly float oilConsumptionPerRev;

		private readonly float refillPerRev;

		private readonly float manualRefillTime;

		private readonly PortReference manualFillRateNormalizedReader;

		private readonly PortReference wheelRpm;

		private readonly PortReference oil;

		private readonly PortReference oilConsumption;

		private readonly Port lubricationRateNormalized;

		private readonly Port lubricationNormalized;

		private readonly Port lubricationAudioNormalized;

		private readonly Port mechanicalPowerTrainHealthExtIn;

		private readonly Port specialRequestExtIn;

		private float oilLevel;

		public override bool HasSaveData => true;

		public MechanicalLubricator(MechanicalLubricatorDefinition mlDef)
			: base(mlDef.ID)
		{
			oilCapacity = mlDef.oilCapacity;
			oilLeakageRate = mlDef.oilLeakageRate;
			oilConsumptionPerRev = mlDef.oilConsumptionPerRev;
			refillPerRev = mlDef.refillPerRev;
			manualRefillTime = mlDef.manualRefillTime;
			manualFillRateNormalizedReader = AddPortReference(mlDef.manualFillRateNormalized);
			wheelRpm = AddPortReference(mlDef.wheelRpm);
			oil = AddPortReference(mlDef.oil);
			oilConsumption = AddPortReference(mlDef.oilConsumption);
			lubricationRateNormalized = AddPort(mlDef.lubricationRateNormalized);
			lubricationNormalized = AddPort(mlDef.lubricationNormalized);
			lubricationAudioNormalized = AddPort(mlDef.lubricationAudioNormalized);
			mechanicalPowerTrainHealthExtIn = AddPort(mlDef.mechanicalPowerTrainHealthExtIn, 1f);
			specialRequestExtIn = AddPort(mlDef.specialRequestExtIn);
			specialRequestExtIn.ValueUpdatedInternally += OnSpecialRequest;
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Abs(wheelRpm.Value) / 60f * delta;
			float num2 = num * oilConsumptionPerRev;
			float num3 = oilLeakageRate * delta;
			oilLevel = Mathf.Max(0f, oilLevel - num2 - num3);
			float value = oil.Value;
			if (value > 0f)
			{
				float b = oilCapacity - oilLevel;
				float num4 = num * refillPerRev;
				float num5 = manualFillRateNormalizedReader.Value * oilCapacity * delta / manualRefillTime;
				float num6 = Mathf.Min(num4 + num5, Mathf.Min(value, b));
				oilLevel += num6;
				lubricationRateNormalized.Value = num6 / (oilCapacity * delta / manualRefillTime);
				float value2 = num6 * gameParams.ResourceConsumptionModifier;
				oilConsumption.Value = value2;
			}
			else
			{
				lubricationRateNormalized.Value = 0f;
			}
			float num7 = oilLevel / oilCapacity;
			lubricationNormalized.Value = num7;
			if (!gameParams.DrivetrainFailuresAllowed)
			{
				lubricationAudioNormalized.Value = 1f;
				return;
			}
			float value3 = mechanicalPowerTrainHealthExtIn.Value;
			if (value3 < 0.03f)
			{
				lubricationAudioNormalized.Value = ((value3 > 0f) ? Mathf.Lerp(num7, 1f, NumberUtil.MapClamp(value3, 0f, 0.03f, 1f, 0f)) : 1f);
			}
			else
			{
				lubricationAudioNormalized.Value = num7;
			}
		}

		private void OnSpecialRequest(float requestCode)
		{
			if (specialRequestExtIn.Value == 1f)
			{
				float value = oil.Value;
				if (!(value <= 0f))
				{
					float b = oilCapacity - oilLevel;
					float num = Mathf.Min(value, b);
					oilLevel += num;
					float value2 = num * gameParams.ResourceConsumptionModifier;
					oilConsumption.Value = value2;
					float value3 = oilLevel / oilCapacity;
					lubricationNormalized.Value = value3;
				}
			}
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("oilNormalized", oilLevel / oilCapacity);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("oilNormalized");
			if (num.HasValue)
			{
				oilLevel = Mathf.Clamp01(num.Value) * oilCapacity;
			}
		}
	}
}
