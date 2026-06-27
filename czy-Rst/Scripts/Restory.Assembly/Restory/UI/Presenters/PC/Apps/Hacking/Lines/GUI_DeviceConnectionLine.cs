using System;
using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_DeviceConnectionLine : MonoBehaviour
	{
		[SerializeField]
		private GUI_LineOutputHandler outputHandler;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName notFoundPreset = PresetName.NotFound;

		[SerializeField]
		private PresetName blockedPreset = PresetName.Blocked;

		[SerializeField]
		private PresetName connectedPreset = PresetName.Connected;

		public void UpdateStatus(DeviceConnectionStatus status)
		{
			switch (status)
			{
			case DeviceConnectionStatus.NotFound:
				presetSwitcher.ActivatePreset(notFoundPreset);
				break;
			case DeviceConnectionStatus.NotHackable:
				presetSwitcher.ActivatePreset(blockedPreset);
				break;
			case DeviceConnectionStatus.Ready:
			case DeviceConnectionStatus.NotReady:
			case DeviceConnectionStatus.Hacked:
				presetSwitcher.ActivatePreset(connectedPreset);
				break;
			default:
				throw new ArgumentOutOfRangeException("status", status, null);
			}
		}

		public void PerformOutput(float outputProgress, out bool outputComplete)
		{
			outputHandler.PerformOutput(outputProgress, out outputComplete);
		}
	}
}
