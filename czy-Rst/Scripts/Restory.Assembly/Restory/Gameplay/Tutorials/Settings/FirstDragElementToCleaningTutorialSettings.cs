using System;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class FirstDragElementToCleaningTutorialSettings
	{
		[SerializeField]
		private GUI_MouseTooltip tooltipPrefab;

		public GUI_MouseTooltip TooltipPrefab => tooltipPrefab;
	}
}
