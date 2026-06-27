using System;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_DeviceCheckLine : MonoBehaviour
	{
		[SerializeField]
		private GUI_LineOutputHandler outputHandler;

		[SerializeField]
		private TMP_Text readyStatusText;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName notFoundPreset = PresetName.NotFound;

		[SerializeField]
		private PresetName blockedPreset = PresetName.Blocked;

		[SerializeField]
		private PresetName readyPreset = PresetName.Ready;

		[SerializeField]
		private PresetName notReadyPreset = PresetName.NotReady;

		[SerializeField]
		private PresetName completedPreset = PresetName.Completed;

		public void UpdateStatus(DeviceConnectionStatus status, string deviceCheckInfo)
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
				readyStatusText.text = deviceCheckInfo;
				presetSwitcher.ActivatePreset(readyPreset);
				break;
			case DeviceConnectionStatus.NotReady:
				presetSwitcher.ActivatePreset(notReadyPreset);
				break;
			case DeviceConnectionStatus.Hacked:
				presetSwitcher.ActivatePreset(completedPreset);
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
