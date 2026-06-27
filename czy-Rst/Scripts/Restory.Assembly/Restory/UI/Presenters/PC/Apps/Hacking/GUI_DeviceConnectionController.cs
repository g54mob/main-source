using System;
using Restory.Data.Devices;
using Restory.Data.Devices.Quality;
using Restory.Data.Localization;
using Restory.Data.PC;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.UI.Presenters.PC.Apps.Hacking.Lines;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	public class GUI_DeviceConnectionController : MonoBehaviour
	{
		[SerializeField]
		private GUI_DeviceConnectionLine connectionLine;

		[SerializeField]
		private GUI_DeviceCheckLine checkLine;

		[SerializeField]
		private GUI_TypingTutorialLine tutorialLine;

		[SerializeField]
		private HackingContentTable contentTable;

		private LocalizationSystem localizationSystem;

		private DeviceService deviceService;

		private ConnectionSettings settings;

		private DeviceContainer connectedDevice;

		private DeviceConnectionStatus status;

		private float connectionLineOutputProgress;

		private float checkLineOutputProgress;

		private float tutorialLineOutputProgress;

		private bool isOutputComplete;

		public event Action<DeviceConnectionStatus> OnConnectionStatusChanged;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, DeviceService deviceService)
		{
			this.localizationSystem = localizationSystem;
			this.deviceService = deviceService;
		}

		private void Update()
		{
			if (!isOutputComplete && status != DeviceConnectionStatus.None)
			{
				PerformOutput();
			}
		}

		public void Init(ConnectionSettings settings, out string hackingContent)
		{
			this.settings = settings;
			hackingContent = string.Empty;
			connectedDevice = deviceService.PlacedDeviceContainer;
			if (!connectedDevice)
			{
				UpdateStatus(DeviceConnectionStatus.NotFound);
				return;
			}
			IDeviceCategory category = connectedDevice.Device.Info.Category;
			if (!connectedDevice.Device.Info.Hackable || !contentTable.IsTableContainsDataForDeviceCategory(category, out var deviceCheckLocalizationKey, out hackingContent))
			{
				UpdateStatus(DeviceConnectionStatus.NotHackable);
			}
			else if (connectedDevice.AdditionalProperties.ContainsProperty<HackedObjectProperty>())
			{
				UpdateStatus(DeviceConnectionStatus.Hacked);
			}
			else if (!(connectedDevice.Quality is IdealDeviceQuality))
			{
				UpdateStatus(DeviceConnectionStatus.NotReady);
			}
			else
			{
				UpdateStatus(DeviceConnectionStatus.Ready, localizationSystem.GetTranslation(deviceCheckLocalizationKey));
			}
		}

		public void MarkConnectedDeviceAsHacked()
		{
			if (!connectedDevice)
			{
				Debug.LogError("Failed to modify connectedDevice, it was lost");
			}
			else
			{
				connectedDevice.AdditionalProperties.TryToAddProperty(new HackedObjectProperty());
			}
		}

		private void UpdateStatus(DeviceConnectionStatus status, string deviceCheckInfo = "")
		{
			this.status = status;
			connectionLine.UpdateStatus(status);
			checkLine.UpdateStatus(status, deviceCheckInfo);
		}

		private void PerformOutput()
		{
			connectionLine.PerformOutput(connectionLineOutputProgress, out var outputComplete);
			if (!outputComplete)
			{
				connectionLineOutputProgress += Time.deltaTime * settings.OutputSymbolsPerSecond;
				return;
			}
			checkLine.PerformOutput(checkLineOutputProgress, out var outputComplete2);
			if (!outputComplete2)
			{
				checkLineOutputProgress += Time.deltaTime * settings.OutputSymbolsPerSecond;
				return;
			}
			if (status == DeviceConnectionStatus.Ready)
			{
				tutorialLine.PerformOutput(tutorialLineOutputProgress, out var outputComplete3);
				if (!outputComplete3)
				{
					tutorialLineOutputProgress += Time.deltaTime * settings.OutputSymbolsPerSecond;
					return;
				}
			}
			isOutputComplete = true;
			this.OnConnectionStatusChanged?.Invoke(status);
		}
	}
}
