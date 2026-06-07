using UnityEngine;

namespace Gh.Tk
{
	public class MarketTrendVisual3DUIView : BaseInteractable3DUIView
	{
		public Transform upTrendIcon;

		public Transform downTrendIcon;

		public Transform neutralTrendIcon;

		public void SetTrend(string titleKey, MarketTrend trend, bool showNeutralIcon = false)
		{
		}
	}
}
