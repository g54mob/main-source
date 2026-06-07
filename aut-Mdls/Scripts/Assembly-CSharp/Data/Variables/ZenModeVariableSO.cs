using Events.Analytics;
using GameAnalyticsSDK;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/ZenMode", fileName = "ZenMode", order = 0)]
	public class ZenModeVariableSO : BoolVariableSO
	{
		[SerializeField]
		private AnalyticsSetDimensionEvent _analyticsSetDimensionEvent;

		public override void SetValue(bool value)
		{
			if (Application.isPlaying)
			{
				string text = (value ? "CREATIVE_MODE" : "CAMPAIGN_MODE");
				GameAnalytics.SetCustomDimension01(text);
				_analyticsSetDimensionEvent.Fire(("game_mode", text));
			}
			base.SetValue(value);
		}
	}
}
