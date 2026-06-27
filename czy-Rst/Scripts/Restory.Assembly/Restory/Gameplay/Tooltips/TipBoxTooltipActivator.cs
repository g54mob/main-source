using Restory.Gameplay.Tips;
using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public class TipBoxTooltipActivator : TooltipActivatorBase
	{
		[SerializeField]
		private TipBox tipBox;

		[SerializeField]
		private string emptyTipBoxLocalizationKey;

		public int AccumulatedTips => tipBox.AccumulatedTips;

		public string EmptyTipBoxLocalizationKey => emptyTipBoxLocalizationKey;
	}
}
