using Events.Analytics;
using GameAnalyticsSDK;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Show Tutorial", fileName = "ShowTutorialSO", order = 0)]
	public class ShowTutorialSO : BoolVariableSO
	{
		[SerializeField]
		private AnalyticsSetDimensionEvent _analyticsSetDimensionEvent;

		public override void SetValue(bool value)
		{
			if (Application.isPlaying)
			{
				string text = (value ? "PLAYED_TUTORIAL" : "SKIPPED_TUTORIAL");
				GameAnalytics.SetCustomDimension02(text);
				_analyticsSetDimensionEvent.Fire(("tutorial_status", text));
			}
			base.SetValue(value);
		}
	}
}
