using DV.Indicators;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class MonitorBrakePressureStep : AMonitorStep
	{
		private AIndicatorBrakePressureReader reader;

		private float minValue;

		private float maxValue;

		public MonitorBrakePressureStep(TrainCar loco, AQuickTutorialMessage message, AIndicatorBrakePressureReader reader, float minValue, float maxValue, bool manualDismiss, Vector3 attentionOffset = default(Vector3))
			: base(loco, message, reader.transform, manualDismiss, attentionOffset)
		{
			this.reader = reader;
			this.minValue = minValue;
			this.maxValue = maxValue;
		}

		protected override bool CheckCondition()
		{
			float getPressureValue = reader.GetPressureValue;
			if (getPressureValue >= minValue)
			{
				return getPressureValue <= maxValue;
			}
			return false;
		}
	}
}
