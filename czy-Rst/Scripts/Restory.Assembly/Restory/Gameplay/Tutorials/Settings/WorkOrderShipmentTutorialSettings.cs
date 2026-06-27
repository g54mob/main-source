using System;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class WorkOrderShipmentTutorialSettings
	{
		[SerializeField]
		private GUI_MouseTooltip mouseTooltipPrefab;

		public GUI_MouseTooltip MouseTooltipPrefab => mouseTooltipPrefab;
	}
}
