using System;
using System.Linq;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ManualOilingPoints : SimComponent
	{
		[Serializable]
		public class OilingPoint
		{
			public Port oilLevelReadOut;

			public Port oilLevelNormalizedReadOut;

			public Port pointDoorExtIn;

			public Port refillExtIn;

			public Port refillingFlowNormalizedReadOut;

			public OilingPoint(Port oilLevelReadOut, Port oilLevelNormalizedReadOut, Port pointDoorExtIn, Port refillExtIn, Port refillingFlowNormalizedReadOut)
			{
				this.oilLevelReadOut = oilLevelReadOut;
				this.oilLevelNormalizedReadOut = oilLevelNormalizedReadOut;
				this.pointDoorExtIn = pointDoorExtIn;
				this.refillExtIn = refillExtIn;
				this.refillingFlowNormalizedReadOut = refillingFlowNormalizedReadOut;
			}

			public JObject GetSaveStateData()
			{
				JObject jObject = new JObject();
				jObject.SetBool("open", pointDoorExtIn.Value > 0f);
				jObject.SetFloat("oilLevel", oilLevelNormalizedReadOut.Value);
				return jObject;
			}

			public void SetSaveStateData(ManualOilingPoints mop, JObject savedData)
			{
				bool? flag = savedData.GetBool("open");
				if (flag.HasValue && flag.Value)
				{
					pointDoorExtIn.Value = 1f;
				}
				float? num = savedData.GetFloat("oilLevel");
				if (num.HasValue)
				{
					oilLevelReadOut.Value = num.Value * mop.capacity;
					oilLevelNormalizedReadOut.Value = num.Value;
				}
			}
		}

		public const float SR_HANDLED = 0f;

		public const float SR_INSTANT_REFILL_CODE = 1f;

		private const string OILING_POINTS_SAVE_KEY = "oilingPoints";

		private const string OILING_POINT_OPEN_SAVE_KEY = "open";

		private const string OIL_LEVEL_NORMALIZED_SAVE_KEY = "oilLevel";

		private const float MOVING_THRESHOLD_RPM = 10f;

		private const float PERCENTAGE_DAMAGE_THRESHOLD = 0.05f;

		private const float MECHANICAL_HEALTH_LOW_OIL_AUDIO_THRESHOLD = 0.03f;

		public float capacity;

		public float consumptionPerRev;

		public float pointOpenConsumptionMultiplier;

		public float leakPerSecond;

		public float refillRate;

		public float damagePerRevWhenEmpty;

		public readonly PortReference oilStorage;

		public readonly PortReference oilConsumption;

		public readonly PortReference wheelRpm;

		public readonly Port mechanicalDamageReadOut;

		public readonly Port mechanicalPowerTrainHealthExtIn;

		public readonly Port lowestOilLevelNormalizedReadOut;

		public readonly Port lowestOilLevelAudioReadOut;

		public readonly Port specialRequestExtIn;

		public readonly OilingPoint[] oilingPoints;

		public override bool HasSaveData => true;

		public ManualOilingPoints(ManualOilingPointsDefinition mopDef)
			: base(mopDef.ID)
		{
			capacity = mopDef.capacity;
			consumptionPerRev = mopDef.consumptionPerRev;
			pointOpenConsumptionMultiplier = mopDef.pointOpenConsumptionMultiplier;
			leakPerSecond = mopDef.leakPerHour / 3600f;
			refillRate = mopDef.refillRate;
			damagePerRevWhenEmpty = mopDef.damagePerRevWhenEmpty;
			oilStorage = AddPortReference(mopDef.oilStorage);
			oilConsumption = AddPortReference(mopDef.oilConsumption);
			wheelRpm = AddPortReference(mopDef.wheelRpm);
			mechanicalDamageReadOut = AddPort(mopDef.mechanicalDamageReadOut);
			mechanicalPowerTrainHealthExtIn = AddPort(mopDef.mechanicalPowerTrainHealthExtIn, 1f);
			lowestOilLevelNormalizedReadOut = AddPort(mopDef.lowestOilLevelNormalizedReadOut);
			lowestOilLevelAudioReadOut = AddPort(mopDef.lowestOilLevelAudioReadOut);
			specialRequestExtIn = AddPort(mopDef.specialRequestExtIn);
			specialRequestExtIn.ValueUpdatedInternally += OnSpecialRequest;
			if (mopDef.oilingPoints.Length == 0)
			{
				Debug.LogError("Unexpected state: oilingPoints not set!");
			}
			oilingPoints = new OilingPoint[mopDef.oilingPoints.Length];
			for (int i = 0; i < mopDef.oilingPoints.Length; i++)
			{
				oilingPoints[i] = new OilingPoint(AddPort(mopDef.oilingPoints[i].oilLevelReadOut), AddPort(mopDef.oilingPoints[i].oilLevelNormalizedReadOut), AddPort(mopDef.oilingPoints[i].pointDoorExtIn), AddPort(mopDef.oilingPoints[i].refillExtIn), AddPort(mopDef.oilingPoints[i].refillingFlowNormalizedReadOut));
			}
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Abs(wheelRpm.Value);
			bool flag = num > 10f;
			float num2 = num / 60f * delta;
			float num3 = 0f;
			float num4 = leakPerSecond * delta;
			float num5 = 1f;
			OilingPoint[] array = oilingPoints;
			foreach (OilingPoint oilingPoint in array)
			{
				float num6 = 0f;
				float num7 = oilingPoint.oilLevelReadOut.Value;
				float num8 = num7 / capacity;
				if (num7 > 0f)
				{
					num7 -= num4;
					if (num7 < 0f)
					{
						num7 = 0f;
					}
					num8 = num7 / capacity;
				}
				if (flag)
				{
					if (num7 > 0f)
					{
						float num9 = 1f;
						if (oilingPoint.pointDoorExtIn.Value > 0f)
						{
							num9 = pointOpenConsumptionMultiplier;
						}
						num7 -= consumptionPerRev * num9 * num2;
						if (num7 < 0f)
						{
							num7 = 0f;
						}
					}
					if (num8 <= 0.05f && gameParams.DrivetrainFailuresAllowed)
					{
						num3 += num2 * damagePerRevWhenEmpty * Mathf.InverseLerp(0.05f, 0f, num8);
					}
				}
				else
				{
					float value = oilStorage.Value;
					if (oilingPoint.refillExtIn.Value > 0f && value > 0f && num7 < capacity)
					{
						num6 = 1f;
						float b = capacity - num7;
						float num10 = Mathf.Min(refillRate * num6 * delta, Mathf.Min(value, b));
						num7 += num10;
						float value2 = num10 * gameParams.ResourceConsumptionModifier;
						oilConsumption.Value = value2;
					}
				}
				oilingPoint.oilLevelReadOut.Value = num7;
				num8 = num7 / capacity;
				oilingPoint.oilLevelNormalizedReadOut.Value = num8;
				num5 = Mathf.Min(num5, num8);
				oilingPoint.refillingFlowNormalizedReadOut.Value = num6;
			}
			if (!gameParams.DrivetrainFailuresAllowed)
			{
				lowestOilLevelNormalizedReadOut.Value = 1f;
				lowestOilLevelAudioReadOut.Value = 1f;
			}
			else
			{
				lowestOilLevelNormalizedReadOut.Value = num5;
				float value3 = mechanicalPowerTrainHealthExtIn.Value;
				if (value3 < 0.03f)
				{
					lowestOilLevelAudioReadOut.Value = ((value3 > 0f) ? Mathf.Lerp(num5, 1f, NumberUtil.MapClamp(value3, 0f, 0.03f, 1f, 0f)) : 1f);
				}
				else
				{
					lowestOilLevelAudioReadOut.Value = num5;
				}
			}
			mechanicalDamageReadOut.Value = num3;
		}

		private void OnSpecialRequest(float requestCode)
		{
			if (specialRequestExtIn.Value != 1f)
			{
				return;
			}
			OilingPoint[] array = oilingPoints;
			foreach (OilingPoint oilingPoint in array)
			{
				float value = oilStorage.Value;
				if (!(value <= 0f))
				{
					float value2 = oilingPoint.oilLevelReadOut.Value;
					if (!(value2 >= capacity))
					{
						float b = capacity - value2;
						float num = Mathf.Min(value, b);
						value2 += num;
						float value3 = num * gameParams.ResourceConsumptionModifier;
						oilConsumption.Value = value3;
						oilingPoint.oilLevelReadOut.Value = value2;
						float value4 = value2 / capacity;
						oilingPoint.oilLevelNormalizedReadOut.Value = value4;
					}
				}
			}
			specialRequestExtIn.Value = 0f;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			JObject[] value = oilingPoints.Select((OilingPoint op) => op.GetSaveStateData()).ToArray();
			jObject.SetJObjectArray("oilingPoints", value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			if (savedData == null)
			{
				return;
			}
			JObject[] jObjectArray = savedData.GetJObjectArray("oilingPoints");
			if (jObjectArray != null && jObjectArray.Length == oilingPoints.Length)
			{
				for (int i = 0; i < oilingPoints.Length; i++)
				{
					oilingPoints[i].SetSaveStateData(this, jObjectArray[i]);
				}
			}
		}
	}
}
