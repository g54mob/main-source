using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.Work.StateMachine;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Gameplay.Workplace;
using Restory.UI.Presenters.Notepad;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class DeviceCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private const string CHEAT_GENERATED_DEVICE_ID_PREFIX = "cheatGeneratedDevice_";

		private const string COMMON_CATEGORY = "Device Cheats";

		private const string SELECTED_MODEL_NAME = "Selected model                                 ";

		private readonly DeviceService deviceService;

		private readonly DeviceInfoDatabase deviceInfoDatabase;

		private readonly DefaultElementConditions defaultElementConditions;

		private readonly IDService idService;

		private readonly WorkSurface workSurface;

		private readonly GUI_NotepadWindow notepadWindow;

		private readonly WorkStateMachine workStateMachine;

		private readonly List<DeviceInfo> selectableDevices = new List<DeviceInfo>();

		private int selectedDeviceIndex;

		[Category("Device Cheats")]
		[DisplayName("Selected model                                 ")]
		[SROptions.Sort(1)]
		public string SelectedDeviceModelName
		{
			get
			{
				if (selectableDevices.Count == 0)
				{
					return "No devices with elements";
				}
				DeviceInfo deviceInfo = selectableDevices[selectedDeviceIndex];
				return $"{deviceInfo.name}  ({selectedDeviceIndex + 1}/{selectableDevices.Count})";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Device Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleDeviceModelLeft()
		{
			if (selectableDevices.Count != 0)
			{
				selectedDeviceIndex = (selectedDeviceIndex - 1 + selectableDevices.Count) % selectableDevices.Count;
				OnPropertyChanged("SelectedDeviceModelName");
			}
		}

		[Category("Device Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleDeviceModelRight()
		{
			if (selectableDevices.Count != 0)
			{
				selectedDeviceIndex = (selectedDeviceIndex + 1) % selectableDevices.Count;
				OnPropertyChanged("SelectedDeviceModelName");
			}
		}

		[Category("Device Cheats")]
		[DisplayName("Place Device")]
		[SROptions.Sort(3)]
		public void PlaceDeviceButton()
		{
			PlaceIdealDeviceFromCheat();
		}

		[Category("Device Cheats")]
		[DisplayName("Repair Placed Device")]
		[SROptions.Sort(4)]
		public void RepairPlacedDeviceButton()
		{
			if (!deviceService.PlacedDeviceContainer)
			{
				return;
			}
			foreach (ElementSocket elementSocket in deviceService.PlacedDeviceContainer.Device.ElementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					RepairElement(elementSocket.NestedElement);
				}
			}
			UpdateNotepadWindow();
			deviceService.PlacedDeviceContainer.ForceCheckQuality();
		}

		[Category("Device Cheats")]
		[DisplayName("Inspect Placed Device")]
		[SROptions.Sort(5)]
		public void InspectPlacedDeviceButton()
		{
			if (!deviceService.PlacedDeviceContainer)
			{
				return;
			}
			foreach (ElementSocket elementSocket in deviceService.PlacedDeviceContainer.Device.ElementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					elementSocket.NestedElement.ConditionHandler.ElementData.IsInspected = true;
				}
			}
			UpdateNotepadWindow();
		}

		[Inject]
		public DeviceCheats(DeviceService deviceService, DeviceInfoDatabase deviceInfoDatabase, DefaultElementConditions defaultElementConditions, IDService idService, WorkSurface workSurface, GUI_NotepadWindow notepadWindow, WorkStateMachine workStateMachine)
		{
			this.deviceService = deviceService;
			this.deviceInfoDatabase = deviceInfoDatabase;
			this.defaultElementConditions = defaultElementConditions;
			this.idService = idService;
			this.workSurface = workSurface;
			this.notepadWindow = notepadWindow;
			this.workStateMachine = workStateMachine;
		}

		protected override void Init()
		{
			base.Init();
			RebuildSelectableDevicesList();
		}

		private void RebuildSelectableDevicesList()
		{
			selectableDevices.Clear();
			foreach (IDeviceInfo device in deviceInfoDatabase.Devices)
			{
				if (device is DeviceInfo { Elements: not null } deviceInfo && deviceInfo.Elements.Count != 0)
				{
					selectableDevices.Add(deviceInfo);
				}
			}
			selectableDevices.Sort((DeviceInfo a, DeviceInfo b) => string.CompareOrdinal(a.name, b.name));
			selectedDeviceIndex = Mathf.Clamp(selectedDeviceIndex, 0, Mathf.Max(0, selectableDevices.Count - 1));
			OnPropertyChanged("SelectedDeviceModelName");
		}

		private void PlaceIdealDeviceFromCheat()
		{
			if (!(workStateMachine.ActiveState is DetectionWorkState))
			{
				Debug.LogError("Only DetectionWorkState allows to generate new device");
				return;
			}
			if (selectableDevices.Count == 0)
			{
				Debug.LogError("DeviceCheats: no suitable DeviceInfo in deviceInfoDatabase (need at least one device with elements).");
				return;
			}
			selectedDeviceIndex = Mathf.Clamp(selectedDeviceIndex, 0, selectableDevices.Count - 1);
			DeviceInfo device = selectableDevices[selectedDeviceIndex];
			RandomlyGeneratedDeviceCondition deviceCondition = CreateIdealRandomlyGeneratedDeviceCondition(device);
			DeviceData deviceData = deviceService.CreateDeviceData(deviceCondition, workSurface.DeviceSpawnPoint);
			deviceService.DestroyDeviceContainer();
			deviceService.PlaceNewDeviceContainer(deviceData);
			workStateMachine.Enter<DisabledWorkState>();
			workStateMachine.Enter<DetectionWorkState>();
		}

		private RandomlyGeneratedDeviceCondition CreateIdealRandomlyGeneratedDeviceCondition(DeviceInfo device)
		{
			string id = "cheatGeneratedDevice_" + idService.GenerateNew();
			List<ElementData> value;
			using (CollectionPool<List<ElementData>, ElementData>.Get(out value))
			{
				foreach (IElementInfo element in device.Elements)
				{
					if (element is ElementInfo info)
					{
						value.Add(new ElementData
						{
							Info = info,
							Condition = defaultElementConditions.PerfectElementCondition
						});
					}
				}
				return new RandomlyGeneratedDeviceCondition(id, device, null, value);
			}
		}

		private void RepairElement(ElementBase element)
		{
			ElementData elementData = element.ConditionHandler.ElementData;
			if (elementData.Condition is PerfectElementCondition)
			{
				return;
			}
			if (elementData.Condition is DirtyElementCondition)
			{
				element.ConditionHandler.TextureMaskHolder.ClearWorkTexture();
				if (elementData.AdditionalProperty is ScorchedCircuitProperty)
				{
					elementData.AdditionalProperty = null;
				}
			}
			element.ConditionHandler.UpdateCondition(defaultElementConditions.PerfectElementCondition);
		}

		private void UpdateNotepadWindow()
		{
			if (notepadWindow.IsVisible)
			{
				notepadWindow.UpdateInfoFromCurrentDevice();
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
