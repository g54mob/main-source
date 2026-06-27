using System;
using Restory.Data.Devices;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class ReplaceDeviceTutorialSettings
	{
		[SerializeField]
		private DeviceInfo targetDeviceInfo;

		[SerializeField]
		private GUI_MouseTooltip tooltipPrefab;

		public DeviceInfo TargetDeviceInfo => targetDeviceInfo;

		public GUI_MouseTooltip TooltipPrefab => tooltipPrefab;
	}
}
