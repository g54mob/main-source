using UnityEngine;

namespace DV.Tutorial.QT
{
	public class MonitorIndicatorStep : AMonitorStep
	{
		private Indicator indicator;

		private float minValue;

		private float maxValue;

		private float minTime;

		private float startTime;

		public MonitorIndicatorStep(TrainCar loco, AQuickTutorialMessage message, Indicator indicator, float minValue, float maxValue, bool manualDismiss, Vector3 attentionOffset = default(Vector3), float minTime = 0f, Transform attentionPointOverride = null, bool strictDismiss = false)
			: base(loco, message, (attentionPointOverride != null) ? attentionPointOverride : indicator.transform, manualDismiss, attentionOffset, strictDismiss)
		{
			this.indicator = indicator;
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.minTime = minTime;
			ShouldRecheck = false;
		}

		protected override bool CheckCondition()
		{
			float value = indicator.Value;
			if (minTime > 0f)
			{
				if (startTime > 0f && Time.time > startTime + minTime)
				{
					if (value >= minValue)
					{
						return value <= maxValue;
					}
					return false;
				}
				return false;
			}
			if (value >= minValue)
			{
				return value <= maxValue;
			}
			return false;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			startTime = Time.time;
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			startTime = 0f;
		}
	}
}
