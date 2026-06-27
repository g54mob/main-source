using System;
using System.Collections.Generic;
using Helpers.Extensions;
using Restory.Data.Devices;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionsResultsTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly Dictionary<DeviceInfo, float> competitionsResults = new Dictionary<DeviceInfo, float>();

		public bool TryRecordNewTime(DeviceInfo device, float newTimeInGameSeconds)
		{
			if (!competitionsResults.TryGetValue(device, out var value))
			{
				float value2 = ((newTimeInGameSeconds < (float)device.CompetitionDefaultBestTimeInGameSeconds) ? newTimeInGameSeconds : ((float)device.CompetitionDefaultBestTimeInGameSeconds));
				competitionsResults.Add(device, value2);
				return true;
			}
			if (newTimeInGameSeconds < value)
			{
				competitionsResults[device] = newTimeInGameSeconds;
				return true;
			}
			return false;
		}

		public bool TryGetBestTimeForDevice(DeviceInfo deviceInfo, out float bestTime)
		{
			return competitionsResults.TryGetValue(deviceInfo, out bestTime);
		}

		public object CaptureState()
		{
			try
			{
				return new CompetitionsResultsTrackingServiceSaveData
				{
					DevicesTimes = competitionsResults.Clone()
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
				CompetitionsResultsTrackingServiceSaveData competitionsResultsTrackingServiceSaveData = DataMigrationWizard.Migrate<CompetitionsResultsTrackingServiceSaveData>(state, base.gameObject);
				competitionsResults.Clear();
				foreach (KeyValuePair<DeviceInfo, float> devicesTime in competitionsResultsTrackingServiceSaveData.DevicesTimes)
				{
					competitionsResults.Add(devicesTime.Key, devicesTime.Value);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
