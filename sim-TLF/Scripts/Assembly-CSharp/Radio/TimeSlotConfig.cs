using System;
using UnityEngine;

namespace Radio
{
	[Serializable]
	public class TimeSlotConfig
	{
		public string label = "Slot";

		[Tooltip("Час тригера (0..24)")]
		[Range(0f, 24f)]
		public float atHour = 22f;

		[Tooltip("Допуск — наскільки близько до atHour спрацює тригер")]
		[Range(0.01f, 1f)]
		public float tolerance = 0.1f;

		public RadioCondition condition = RadioCondition.Night;

		private bool _fired;

		public bool ShouldFire(float hour)
		{
			bool flag = Mathf.Abs(hour - atHour) <= tolerance;
			if (flag && !_fired)
			{
				_fired = true;
				return true;
			}
			if (!flag)
			{
				_fired = false;
			}
			return false;
		}
	}
}
