using System;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class ExitDisassembleTutorialSettings
	{
		[SerializeField]
		private GUI_TooltipIndicator tooltipIndicator;

		[SerializeField]
		private Vector2 indicatorSize;

		[SerializeField]
		private Vector2 indicatorOffset;

		public GUI_TooltipIndicator TooltipIndicator => tooltipIndicator;

		public Vector2 IndicatorSize => indicatorSize;

		public Vector2 IndicatorOffset => indicatorOffset;
	}
}
