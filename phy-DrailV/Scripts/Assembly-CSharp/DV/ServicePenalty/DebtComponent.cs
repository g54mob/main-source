using System;
using DV.JObjectExtstensions;
using DV.ThingTypes;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	[Serializable]
	public class DebtComponent
	{
		private const string START_VALUE_KEY = "start";

		private const string END_VALUE_KEY = "end";

		private const string SNAPSHOT_VALUE_KEY = "snap";

		private const string DEBT_TYPE_KEY = "type";

		private const float UNUSED_SNAPSHOT_VALUE = -1f;

		[SerializeField]
		private ResourceType type;

		[SerializeField]
		private float startValue;

		[SerializeField]
		private float snapshotValue = -1f;

		[SerializeField]
		private float endValue;

		public ResourceType Type => type;

		public float StartValue => startValue;

		public float SnapshotValue => snapshotValue;

		public float EndValue => endValue;

		public float StartToEndDiff => (startValue - endValue).To1Decimal();

		public float StartToSnapshotDiff => (startValue - snapshotValue).To1Decimal();

		public float SnapshotToEndDiff => (snapshotValue - endValue).To1Decimal();

		public bool HasSnapshot => snapshotValue != -1f;

		public DebtComponent(float startValue, ResourceType type)
		{
			this.startValue = startValue;
			this.type = type;
			endValue = startValue;
			snapshotValue = -1f;
		}

		public DebtComponent(float startValue, ResourceType type, float endValue, float snapshotValue)
		{
			this.startValue = startValue;
			this.type = type;
			this.endValue = endValue;
			this.snapshotValue = snapshotValue;
		}

		public DebtComponent(DebtComponent debtComponent)
		{
			startValue = debtComponent.startValue;
			type = debtComponent.type;
			endValue = debtComponent.endValue;
			snapshotValue = debtComponent.snapshotValue;
		}

		public void UpdateStartValue(float newStartValue)
		{
			startValue = newStartValue;
		}

		public void UpdateEndValue(float newEndValue)
		{
			endValue = newEndValue;
		}

		public void UpdateStartValueToEndValue()
		{
			startValue = endValue;
		}

		public void SetSnapshot(float newSnapshotValue)
		{
			snapshotValue = newSnapshotValue;
		}

		public void ClearSnapshot()
		{
			snapshotValue = -1f;
		}

		public void ResetComponent(float value)
		{
			startValue = (endValue = value);
			ClearSnapshot();
		}

		public JObject GetDebtComponentSaveData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("start", startValue);
			jObject.SetFloat("end", endValue);
			if (HasSnapshot)
			{
				jObject.SetFloat("snap", snapshotValue);
			}
			jObject.SetInt("type", (int)type);
			return jObject;
		}

		public static DebtComponent LoadDebtComponentFromSaveData(JObject data)
		{
			float? num = data.GetFloat("start");
			float? num2 = data.GetFloat("end");
			float? num3 = data.GetFloat("snap");
			int? num4 = data.GetInt("type");
			if (!num.HasValue || !(num >= 0f) || !num2.HasValue || !(num2 >= 0f) || !num4.HasValue || !Enum.IsDefined(typeof(ResourceType), num4))
			{
				throw new Exception("Bad load data for DebtComponent!");
			}
			return new DebtComponent(num.Value, (ResourceType)num4.Value, num2.Value, num3 ?? (-1f));
		}
	}
}
