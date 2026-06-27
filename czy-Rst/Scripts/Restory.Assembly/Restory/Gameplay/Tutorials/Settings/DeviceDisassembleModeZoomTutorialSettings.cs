using System;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class DeviceDisassembleModeZoomTutorialSettings
	{
		[SerializeField]
		private GUI_MouseTooltip tooltipPrefab;

		[SerializeField]
		private float zoomAmountToCompleteTutorial = 0.3f;

		public GUI_MouseTooltip TooltipPrefab => tooltipPrefab;

		public float ZoomAmountToCompleteTutorial => zoomAmountToCompleteTutorial;
	}
}
