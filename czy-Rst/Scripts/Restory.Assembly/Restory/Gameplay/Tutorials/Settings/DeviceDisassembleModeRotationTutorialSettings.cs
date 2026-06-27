using System;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class DeviceDisassembleModeRotationTutorialSettings
	{
		[SerializeField]
		private GUI_MouseTooltip tooltipPrefab;

		[SerializeField]
		private float rotationAngleToCompleteTutorial = 25f;

		public GUI_MouseTooltip TooltipPrefab => tooltipPrefab;

		public float RotationAngleToCompleteTutorial => rotationAngleToCompleteTutorial;
	}
}
