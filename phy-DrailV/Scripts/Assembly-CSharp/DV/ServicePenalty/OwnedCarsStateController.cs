using System;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class OwnedCarsStateController : SingletonBehaviour<OwnedCarsStateController>
	{
		public readonly List<ExistingOwnedCarDebt> existingOwnedCarStates = new List<ExistingOwnedCarDebt>();

		public readonly List<StagedOwnedCarDebt> currentlyDestroyedOwnedCarStates = new List<StagedOwnedCarDebt>();

		private List<DisplayableDebt> sortedList = new List<DisplayableDebt>();

		public int NumberOfCarStates => sortedList.Count;

		public event Action EntriesUpdated;

		public new static string AllowAutoCreate()
		{
			return "[OwnedCarsStateController]";
		}

		public void RegisterCarStateTracker(TrainCar car, SimulatedCarDebtTracker carDebtTracker)
		{
			ExistingOwnedCarDebt existingCarState = new ExistingOwnedCarDebt(carDebtTracker, car);
			existingOwnedCarStates.Add(existingCarState);
			currentlyDestroyedOwnedCarStates.RemoveAll((StagedOwnedCarDebt state) => state.ID == existingCarState.ID);
			UpdateSortedList();
			this.EntriesUpdated?.Invoke();
		}

		public void StageCarStateTrackerOnDestroy(LocoDebtTrackerBase carDebtTrackerToStage)
		{
			int num = existingOwnedCarStates.FindIndex((ExistingOwnedCarDebt debt) => debt.carDebtTrackerBase == carDebtTrackerToStage);
			if (num == -1)
			{
				Debug.LogError("Unexpected error: LocoDebtTrackerBase[" + carDebtTrackerToStage.GetDebtData().id + "] is not part of the existingOwnedCarStates! Ignoring stage");
				return;
			}
			ExistingOwnedCarDebt existingOwnedCarDebt = existingOwnedCarStates[num];
			existingOwnedCarStates.RemoveAt(num);
			existingOwnedCarDebt.UpdateDebtState();
			CarDebtData carDebtData = CarDebtData.FilterOutUnchangedComponents(existingOwnedCarDebt.carDebtTrackerBase.GetDebtData(), returnEmptyDebtInsteadOfNull: true);
			if (carDebtData != null)
			{
				StagedOwnedCarDebt item = new StagedOwnedCarDebt(carDebtData);
				currentlyDestroyedOwnedCarStates.Add(item);
			}
			else
			{
				Debug.LogError("Unexpected state: stagedDebtData is null! Ignoring stage request");
			}
			UpdateSortedList();
			this.EntriesUpdated?.Invoke();
		}

		public void RefreshOwnedCarsStatesData()
		{
			foreach (ExistingOwnedCarDebt existingOwnedCarState in existingOwnedCarStates)
			{
				existingOwnedCarState.UpdateDebtState();
			}
			UpdateSortedList();
		}

		public void UpdateSortedList()
		{
			sortedList.Clear();
			sortedList.AddRange(existingOwnedCarStates.Where((ExistingOwnedCarDebt carState) => !carState.car.preventDebtDisplay));
			sortedList.AddRange(currentlyDestroyedOwnedCarStates);
			sortedList.Sort((DisplayableDebt x, DisplayableDebt y) => y.GetTotalPrice().CompareTo(x.GetTotalPrice()));
		}

		public DisplayableDebt GetIthSortedVehicleState(int i)
		{
			if (i < 0 || i >= sortedList.Count)
			{
				Debug.LogError($"Index for selecting state is out of range (Entries count {sortedList.Count},  attempted index: {i})");
				return null;
			}
			return sortedList[i];
		}

		public JObject[] GetDestroyedOwnedCarsSaveData()
		{
			JObject[] array = new JObject[currentlyDestroyedOwnedCarStates.Count];
			for (int i = 0; i < currentlyDestroyedOwnedCarStates.Count; i++)
			{
				array[i] = currentlyDestroyedOwnedCarStates[i].carDebtData.GetCarDebtSaveData();
			}
			return array;
		}

		public void LoadDestroyedOwnedCarsSaveData(JObject[] data)
		{
			foreach (JObject jObject in data)
			{
				if (jObject != null)
				{
					CarDebtData carDebtData;
					try
					{
						carDebtData = CarDebtData.LoadCarDebtFromSaveData(jObject);
					}
					catch (Exception message)
					{
						Debug.LogWarning("Loading of CarDebtData entry for currentlyDestroyedOwnedCarStates failed due to invalid data. Skipping this entry");
						Debug.LogError(message);
						continue;
					}
					StagedOwnedCarDebt item = new StagedOwnedCarDebt(carDebtData);
					currentlyDestroyedOwnedCarStates.Add(item);
				}
			}
			UpdateSortedList();
		}
	}
}
