using System;

namespace Gh.Tk
{
	public class SystemStatusItemSpecTip : SystemStatusItem
	{
		private string _title;

		private float _minValue;

		private float _recommendedValue;

		private Func<float> _getValue;

		private Func<float, string> _getDisplayValue;

		public SystemStatusItemSpecTip(string codexId, string title, float minValue, float recommendedValue, Func<float> getValue, Func<float, string> getDisplayValue, string category)
		{
		}

		public float GetValue()
		{
			return 0f;
		}

		public override SystemStatus.PerformanceState GetState()
		{
			return default(SystemStatus.PerformanceState);
		}

		protected override string GetTitleInternal()
		{
			return null;
		}
	}
}
