using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionsDeviceContainersTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[Serializable]
		private class CompetitionData
		{
			public float SpentSeconds;

			public bool WasCompleted;

			public bool WasPreviousTimeBested;

			public PlacedElementsData ElementsInitialPlacement;
		}

		private DeviceRegistry deviceRegistry;

		private readonly Dictionary<DeviceContainer, CompetitionData> trackedDevicesInCompetitions = new Dictionary<DeviceContainer, CompetitionData>();

		private CompetitionsDeviceContainersTrackingServiceSaveData restoredState;

		[Inject]
		private void Construct(DeviceRegistry deviceRegistry)
		{
			this.deviceRegistry = deviceRegistry;
		}

		public bool TryAddNewCompetition(DeviceContainer deviceContainer, PlacedElementsData elementsInitialPlacement)
		{
			if (trackedDevicesInCompetitions.TryGetValue(deviceContainer, out var _))
			{
				return false;
			}
			trackedDevicesInCompetitions.Add(deviceContainer, new CompetitionData
			{
				ElementsInitialPlacement = elementsInitialPlacement
			});
			return true;
		}

		public bool TrySetNewCompetitionTimeForExistingCompetition(DeviceContainer deviceContainer, float newTimeInGameSeconds, bool setCompetitionToCompleted, bool setCompetitionToHaveBeatenPreviousBestTime)
		{
			if (!trackedDevicesInCompetitions.TryGetValue(deviceContainer, out var value))
			{
				return false;
			}
			value.SpentSeconds = newTimeInGameSeconds;
			value.WasCompleted = setCompetitionToCompleted || value.WasCompleted;
			value.WasPreviousTimeBested = setCompetitionToHaveBeatenPreviousBestTime || value.WasPreviousTimeBested;
			return true;
		}

		public bool TryGetCompetitionData(DeviceContainer deviceContainer, out float currentTimeInGameSeconds, out bool wasCompleted, out bool wasPreviousTimeBested, out PlacedElementsData elementsInitialPlacement)
		{
			if (trackedDevicesInCompetitions.TryGetValue(deviceContainer, out var value))
			{
				currentTimeInGameSeconds = value.SpentSeconds;
				wasCompleted = value.WasCompleted;
				wasPreviousTimeBested = value.WasPreviousTimeBested;
				elementsInitialPlacement = value.ElementsInitialPlacement;
				return true;
			}
			currentTimeInGameSeconds = float.MaxValue;
			wasCompleted = false;
			wasPreviousTimeBested = false;
			elementsInitialPlacement = null;
			return false;
		}

		public bool TryGetElementsInitialPlacement(DeviceContainer deviceContainer, out PlacedElementsData elementsInitialPlacement)
		{
			if (trackedDevicesInCompetitions.TryGetValue(deviceContainer, out var value))
			{
				elementsInitialPlacement = value.ElementsInitialPlacement;
				return elementsInitialPlacement != null;
			}
			elementsInitialPlacement = null;
			return false;
		}

		public bool WasPreviousTimeBeaten(DeviceContainer deviceContainer)
		{
			if (trackedDevicesInCompetitions.TryGetValue(deviceContainer, out var value))
			{
				return value.WasPreviousTimeBested;
			}
			return false;
		}

		public object CaptureState()
		{
			try
			{
				List<DeviceContainerInCompetitionSaveData> value;
				using (CollectionPool<List<DeviceContainerInCompetitionSaveData>, DeviceContainerInCompetitionSaveData>.Get(out value))
				{
					foreach (KeyValuePair<DeviceContainer, CompetitionData> trackedDevicesInCompetition in trackedDevicesInCompetitions)
					{
						value.Add(new DeviceContainerInCompetitionSaveData
						{
							DeviceContainerUniqueID = trackedDevicesInCompetition.Key.UniqueId,
							CurrentTime = trackedDevicesInCompetition.Value.SpentSeconds,
							WasCompleted = trackedDevicesInCompetition.Value.WasCompleted,
							WasPreviousTimeBested = trackedDevicesInCompetition.Value.WasPreviousTimeBested,
							ElementsInitialPlacement = GetPlacedElementsDataClone(trackedDevicesInCompetition.Value.ElementsInitialPlacement)
						});
					}
					return new CompetitionsDeviceContainersTrackingServiceSaveData
					{
						CurrentCompetitions = value.ToArray()
					};
				}
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
				restoredState = DataMigrationWizard.Migrate<CompetitionsDeviceContainersTrackingServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState == null)
			{
				return;
			}
			trackedDevicesInCompetitions.Clear();
			DeviceContainerInCompetitionSaveData[] currentCompetitions = restoredState.CurrentCompetitions;
			foreach (DeviceContainerInCompetitionSaveData deviceContainerInCompetitionSaveData in currentCompetitions)
			{
				foreach (DeviceContainer item in deviceRegistry.All)
				{
					if (item.UniqueId == deviceContainerInCompetitionSaveData.DeviceContainerUniqueID)
					{
						trackedDevicesInCompetitions.Add(item, new CompetitionData
						{
							SpentSeconds = deviceContainerInCompetitionSaveData.CurrentTime,
							WasCompleted = deviceContainerInCompetitionSaveData.WasCompleted,
							WasPreviousTimeBested = deviceContainerInCompetitionSaveData.WasPreviousTimeBested,
							ElementsInitialPlacement = deviceContainerInCompetitionSaveData.ElementsInitialPlacement
						});
						break;
					}
				}
			}
		}

		private static PlacedElementsData GetPlacedElementsDataClone(PlacedElementsData sourcePlacedElementsData)
		{
			List<ElementTransformData> list = new List<ElementTransformData>();
			foreach (ElementTransformData item in sourcePlacedElementsData.ElementsOnSurface)
			{
				list.Add(new ElementTransformData
				{
					ElementData = item.ElementData.Clone(),
					ElementTransform = item.ElementTransform
				});
			}
			List<ElementTransformData> list2 = new List<ElementTransformData>();
			foreach (ElementTransformData item2 in sourcePlacedElementsData.ElementsInBin)
			{
				list2.Add(new ElementTransformData
				{
					ElementData = item2.ElementData.Clone(),
					ElementTransform = item2.ElementTransform
				});
			}
			return new PlacedElementsData
			{
				ElementsOnSurface = list,
				ElementsInBin = list2
			};
		}
	}
}
