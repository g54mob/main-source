using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.DeviceSales;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionsLastSubmittedDeviceTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IInitializable, IDisposable
	{
		private DeviceInfo lastSubmittedDeviceInfo;

		private bool wasLastSubmittedDeviceBestTime;

		private readonly Dictionary<DeviceInfo, bool> lastSubmittedDevicesBestTimeByDevice = new Dictionary<DeviceInfo, bool>();

		private FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService;

		private CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker;

		public bool HasSubmittedDevice => lastSubmittedDeviceInfo;

		public DeviceInfo LastSubmittedDeviceInfo => lastSubmittedDeviceInfo;

		public bool WasLastSubmittedDeviceBestTime => wasLastSubmittedDeviceBestTime;

		[Inject]
		private void Construct(FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService, CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker)
		{
			this.freeSaleShippingDevicesTrackingService = freeSaleShippingDevicesTrackingService;
			this.competitionsDeviceContainersTracker = competitionsDeviceContainersTracker;
		}

		public void Initialize()
		{
			freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc += ResolveOnPreDevicePackClaimedByNpc;
		}

		public void Dispose()
		{
			freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc -= ResolveOnPreDevicePackClaimedByNpc;
		}

		public void SetLastSubmittedDevice(DeviceInfo submittedDeviceInfo, bool wasBestTime)
		{
			lastSubmittedDeviceInfo = submittedDeviceInfo;
			wasLastSubmittedDeviceBestTime = wasBestTime;
			if ((bool)submittedDeviceInfo)
			{
				lastSubmittedDevicesBestTimeByDevice[submittedDeviceInfo] = wasBestTime;
			}
		}

		public bool TryGetWasLastSubmittedDeviceBestTime(DeviceInfo submittedDeviceInfo, out bool wasBestTime)
		{
			return lastSubmittedDevicesBestTimeByDevice.TryGetValue(submittedDeviceInfo, out wasBestTime);
		}

		private void ResolveOnPreDevicePackClaimedByNpc(ShipmentDevicePack submittedDevicePack)
		{
			if ((bool)submittedDevicePack)
			{
				DeviceContainer deviceContainer = submittedDevicePack.DeviceContainer;
				if ((bool)deviceContainer && deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition)
				{
					SetLastSubmittedDevice(deviceContainer.Device.Info, competitionsDeviceContainersTracker.WasPreviousTimeBeaten(deviceContainer));
				}
			}
		}

		public object CaptureState()
		{
			try
			{
				List<SubmittedDeviceBestTimeSaveData> list = new List<SubmittedDeviceBestTimeSaveData>(lastSubmittedDevicesBestTimeByDevice.Count);
				foreach (KeyValuePair<DeviceInfo, bool> item in lastSubmittedDevicesBestTimeByDevice)
				{
					list.Add(new SubmittedDeviceBestTimeSaveData
					{
						DeviceInfo = item.Key,
						WasBestTime = item.Value
					});
				}
				return new CompetitionsLastSubmittedDeviceTrackingServiceSaveData
				{
					LastSubmittedDevicesBestTime = list,
					LastSubmittedDeviceInfo = lastSubmittedDeviceInfo,
					WasLastSubmittedDeviceBestTime = wasLastSubmittedDeviceBestTime
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
				CompetitionsLastSubmittedDeviceTrackingServiceSaveData competitionsLastSubmittedDeviceTrackingServiceSaveData = DataMigrationWizard.Migrate<CompetitionsLastSubmittedDeviceTrackingServiceSaveData>(state, base.gameObject);
				lastSubmittedDevicesBestTimeByDevice.Clear();
				if (competitionsLastSubmittedDeviceTrackingServiceSaveData.LastSubmittedDevicesBestTime != null)
				{
					foreach (SubmittedDeviceBestTimeSaveData item in competitionsLastSubmittedDeviceTrackingServiceSaveData.LastSubmittedDevicesBestTime)
					{
						if ((bool)item.DeviceInfo)
						{
							lastSubmittedDevicesBestTimeByDevice[item.DeviceInfo] = item.WasBestTime;
						}
					}
				}
				if (!competitionsLastSubmittedDeviceTrackingServiceSaveData.LastSubmittedDeviceInfo)
				{
					lastSubmittedDeviceInfo = null;
					wasLastSubmittedDeviceBestTime = false;
					return;
				}
				lastSubmittedDeviceInfo = competitionsLastSubmittedDeviceTrackingServiceSaveData.LastSubmittedDeviceInfo;
				wasLastSubmittedDeviceBestTime = competitionsLastSubmittedDeviceTrackingServiceSaveData.WasLastSubmittedDeviceBestTime;
				if (!lastSubmittedDevicesBestTimeByDevice.ContainsKey(lastSubmittedDeviceInfo))
				{
					lastSubmittedDevicesBestTimeByDevice[lastSubmittedDeviceInfo] = wasLastSubmittedDeviceBestTime;
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
