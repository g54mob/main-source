using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Extensions;
using Restory.Data.Devices;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Email;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Elements;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public sealed class RandomDevicesGenerationService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private const string GENERATED_DEVICE_ID_PREFIX = "emailGeneratedDevice_";

		[SerializeField]
		private EmailRandomDevicesGenerationSettings settings;

		private readonly List<DeviceInfo> weightedSelectableDevicesList = new List<DeviceInfo>();

		private AvailableDevicesListTrackingService availableDevicesListProvider;

		private AvailableDevicesWorkTypesTrackingService availableDeviceWorkTypesProvider;

		private ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService;

		private DefaultElementConditions defaultElementConditions;

		private IDService idService;

		private PaintingPaletteInfoDatabase palettesDatabase;

		[Inject]
		private void Construct(PaintingPaletteInfoDatabase palettesDatabase, DefaultElementConditions defaultElementConditions, AvailableDevicesListTrackingService availableDevicesListProvider, AvailableDevicesWorkTypesTrackingService availableDeviceWorkTypesProvider, IDService idService, ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService)
		{
			this.palettesDatabase = palettesDatabase;
			this.defaultElementConditions = defaultElementConditions;
			this.idService = idService;
			this.availableDevicesListProvider = availableDevicesListProvider;
			this.availableDeviceWorkTypesProvider = availableDeviceWorkTypesProvider;
			this.elementDirtMaskPresetSelectionService = elementDirtMaskPresetSelectionService;
		}

		public void Initialize()
		{
			RefillDevices();
			availableDevicesListProvider.OnDeviceMadeAvailable += ResolveDeviceMadeAvailable;
		}

		public void Dispose()
		{
			availableDevicesListProvider.OnDeviceMadeAvailable -= ResolveDeviceMadeAvailable;
		}

		public bool TryGetRandomDeviceConditionForEmailOrderFromAvailableDevices(HashSet<DeviceInfo> ignoredDevices, out RandomlyGeneratedDeviceCondition generatedDeviceCondition, out DeviceWorkType[] workTypesForDeviceCondition)
		{
			if (!TryGetRandomAvailableDeviceForEmailOrder(ignoredDevices, out var deviceInfo))
			{
				generatedDeviceCondition = null;
				workTypesForDeviceCondition = null;
				return false;
			}
			return TryGenerateRandomConditionForDevice(deviceInfo, out generatedDeviceCondition, out workTypesForDeviceCondition);
		}

		public bool TryGetRandomAvailableDeviceForEmailOrder(HashSet<DeviceInfo> ignoredDevices, out DeviceInfo deviceInfo)
		{
			List<DeviceInfo> value;
			using (CollectionPool<List<DeviceInfo>, DeviceInfo>.Get(out value))
			{
				value.AddRange(weightedSelectableDevicesList.Where((DeviceInfo device) => ignoredDevices == null || !ignoredDevices.Contains(device)));
				if (value.Count == 0)
				{
					RefillDevices();
					value.AddRange(weightedSelectableDevicesList.Where((DeviceInfo device) => ignoredDevices == null || !ignoredDevices.Contains(device)));
					if (value.Count == 0)
					{
						deviceInfo = null;
						return false;
					}
				}
				int index = UnityEngine.Random.Range(0, value.Count);
				deviceInfo = value[index];
				value.RemoveAt(index);
				return true;
			}
		}

		private void RefillDevices()
		{
			weightedSelectableDevicesList.Clear();
			foreach (AvailableDevicesListEntry availableDevices in availableDevicesListProvider.GetAvailableDevicesList())
			{
				if (availableDevices.IsAvailable && (bool)availableDevices.Device)
				{
					for (int i = 0; i < availableDevices.RandomnessWeight; i++)
					{
						weightedSelectableDevicesList.Add(availableDevices.Device);
					}
				}
			}
		}

		public bool TryGenerateRandomConditionForDevice(DeviceInfo deviceInfo, out RandomlyGeneratedDeviceCondition deviceCondition, out DeviceWorkType[] workTypesFromCondition)
		{
			deviceCondition = null;
			workTypesFromCondition = Array.Empty<DeviceWorkType>();
			if (!deviceInfo)
			{
				return false;
			}
			List<DeviceWorkType> list = CollectionPool<List<DeviceWorkType>, DeviceWorkType>.Get();
			HashSet<DeviceWorkType> hashSet = CollectionPool<HashSet<DeviceWorkType>, DeviceWorkType>.Get();
			List<DeviceWorkTypeClean> list2 = CollectionPool<List<DeviceWorkTypeClean>, DeviceWorkTypeClean>.Get();
			List<DeviceWorkTypePaintBase> list3 = CollectionPool<List<DeviceWorkTypePaintBase>, DeviceWorkTypePaintBase>.Get();
			List<DeviceWorkTypeHacking> list4 = CollectionPool<List<DeviceWorkTypeHacking>, DeviceWorkTypeHacking>.Get();
			List<ElementInfo> list5 = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementData> list6 = CollectionPool<List<ElementData>, ElementData>.Get();
			foreach (DeviceWorkType availableWorkTypes in availableDeviceWorkTypesProvider.GetAvailableWorkTypesList())
			{
				if (!availableWorkTypes.IsAvailable)
				{
					continue;
				}
				list.Add(availableWorkTypes);
				if (!(availableWorkTypes is DeviceWorkTypeClean item))
				{
					if (!(availableWorkTypes is DeviceWorkTypePaintBase item2))
					{
						if (availableWorkTypes is DeviceWorkTypeHacking item3)
						{
							list4.Add(item3);
						}
					}
					else
					{
						list3.Add(item2);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			DeviceWorkTypeRepair deviceWorkTypeRepair = null;
			foreach (DeviceWorkType item5 in list)
			{
				if (item5 is DeviceWorkTypeRepair deviceWorkTypeRepair2)
				{
					deviceWorkTypeRepair = deviceWorkTypeRepair2;
				}
			}
			int num = settings.DirtyElementsAmount.GetRandom();
			int num2 = ((deviceWorkTypeRepair != null && UnityEngine.Random.Range(0f, 1f) < settings.DeviceHasDamagedElementsChance) ? settings.DamagedElementsAmount.GetRandom() : 0);
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (element is ElementInfo item4)
				{
					list5.Add(item4);
				}
			}
			list6.Clear();
			List<ElementData> list7 = new List<ElementData>();
			while (list5.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, list5.Count);
				ElementInfo elementInfo = list5[index];
				ElementData elementData = new ElementData
				{
					Info = elementInfo
				};
				if (elementInfo.CanBeDirty && num > 0 && elementDirtMaskPresetSelectionService.TryToGetDirtMaskCreationPreset(elementInfo.ElementMaterialType, list2, out var preset, out var relevantWorkTypes))
				{
					elementData.Condition = defaultElementConditions.DirtyElementCondition;
					elementData.DirtMaskPresetOverride = preset;
					foreach (DeviceWorkType item6 in relevantWorkTypes)
					{
						hashSet.Add(item6);
					}
					num--;
				}
				else if (elementInfo.CanBeBroken && num2 > 0)
				{
					elementData.Condition = defaultElementConditions.DamagedElementCondition;
					hashSet.Add(deviceWorkTypeRepair);
					num2--;
				}
				else
				{
					elementData.Condition = defaultElementConditions.PerfectElementCondition;
				}
				list5.RemoveAt(index);
				list6.Add(elementData);
			}
			foreach (IElementInfo element2 in deviceInfo.Elements)
			{
				if (!(element2 is ElementInfo elementInfo2))
				{
					continue;
				}
				foreach (ElementData item7 in list6)
				{
					if (!list7.Contains(item7) && item7.Info == elementInfo2)
					{
						list7.Add(item7);
						break;
					}
				}
			}
			if (UnityEngine.Random.value < settings.PaintTaskChance && RandomGeneratorFromWeights.TryToGetRandomObject(list3, out var chosenObject))
			{
				if (!(chosenObject is DeviceWorkTypePaintAnyColors))
				{
					if (!(chosenObject is DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette))
					{
						throw new NotImplementedException();
					}
					DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette2 = (DeviceWorkTypePaintConcretePalette)deviceWorkTypePaintConcretePalette.Clone();
					deviceWorkTypePaintConcretePalette2.ConcretePalette = palettesDatabase.All.GetRandomOrDefault();
					hashSet.Add(deviceWorkTypePaintConcretePalette2);
				}
				else
				{
					hashSet.Add(chosenObject);
				}
			}
			if (deviceInfo.Hackable && UnityEngine.Random.value < settings.HackTaskChance && RandomGeneratorFromWeights.TryToGetRandomObject(list4, out var chosenObject2))
			{
				hashSet.Add(chosenObject2);
			}
			string id = "emailGeneratedDevice_" + idService.GenerateNew();
			deviceCondition = new RandomlyGeneratedDeviceCondition(id, deviceInfo, null, list7);
			workTypesFromCondition = hashSet.ToArray();
			CollectionPool<List<DeviceWorkType>, DeviceWorkType>.Release(list);
			CollectionPool<HashSet<DeviceWorkType>, DeviceWorkType>.Release(hashSet);
			CollectionPool<List<DeviceWorkTypeClean>, DeviceWorkTypeClean>.Release(list2);
			CollectionPool<List<DeviceWorkTypePaintBase>, DeviceWorkTypePaintBase>.Release(list3);
			CollectionPool<List<DeviceWorkTypeHacking>, DeviceWorkTypeHacking>.Release(list4);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list5);
			CollectionPool<List<ElementData>, ElementData>.Release(list6);
			return true;
		}

		private void ResolveDeviceMadeAvailable(AvailableDevicesListEntry newDeviceEntry)
		{
			if (newDeviceEntry.IsAvailable && (bool)newDeviceEntry.Device)
			{
				for (int i = 0; i < newDeviceEntry.RandomnessWeight; i++)
				{
					weightedSelectableDevicesList.Add(newDeviceEntry.Device);
				}
			}
		}

		public object CaptureState()
		{
			try
			{
				return new RandomDevicesGenerationServiceSaveData
				{
					Devices = weightedSelectableDevicesList.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				RandomDevicesGenerationServiceSaveData randomDevicesGenerationServiceSaveData = DataMigrationWizard.Migrate<RandomDevicesGenerationServiceSaveData>(state, base.gameObject);
				weightedSelectableDevicesList.Clear();
				if (randomDevicesGenerationServiceSaveData.Devices != null)
				{
					weightedSelectableDevicesList.AddRange(randomDevicesGenerationServiceSaveData.Devices);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
