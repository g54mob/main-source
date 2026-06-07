using System.Collections.Generic;
using System.Linq;
using DV.LocoRestoration;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Logic.Job
{
	public class WarehouseMachine
	{
		public class WarehouseLoadUnloadDataPerJob
		{
			public enum State
			{
				NoneOfCarsPresentLoadUnloadForbiden = 0,
				SomeCarsPresentLoadUnloadForbiden = 1,
				PartialLoadUnloadPossible = 2,
				FullLoadUnloadPossible = 3
			}

			public readonly string id;

			public readonly State state;

			public readonly List<WarehouseTask> tasksAvailableToProcess;

			public readonly WarehouseSpecialDelivery specialDeliveryToProcess;

			public WarehouseLoadUnloadDataPerJob(string id, List<WarehouseTask> tasksAvailableToProcess, WarehouseSpecialDelivery specialDeliveryToProcess, State state)
			{
				this.id = id;
				this.tasksAvailableToProcess = tasksAvailableToProcess;
				this.specialDeliveryToProcess = specialDeliveryToProcess;
				this.state = state;
			}
		}

		private List<WarehouseTask> currentTasks = new List<WarehouseTask>();

		private Dictionary<Job, List<WarehouseTask>> currentJobToTasks = new Dictionary<Job, List<WarehouseTask>>();

		private List<WarehouseSpecialDelivery> specialDeliveries = new List<WarehouseSpecialDelivery>();

		public Track WarehouseTrack { get; private set; }

		public List<CargoType> SupportedCargoTypes { get; private set; }

		public string ID { get; set; }

		public WarehouseMachine(Track WarehouseTrack, List<CargoType> SupportedCargoTypes)
		{
			this.WarehouseTrack = WarehouseTrack;
			this.SupportedCargoTypes = SupportedCargoTypes;
		}

		public List<WarehouseLoadUnloadDataPerJob> GetCurrentLoadUnloadData(WarehouseTaskType taskType)
		{
			List<WarehouseLoadUnloadDataPerJob> list = new List<WarehouseLoadUnloadDataPerJob>();
			List<WarehouseTask> list2 = new List<WarehouseTask>();
			foreach (KeyValuePair<Job, List<WarehouseTask>> currentJobToTask in currentJobToTasks)
			{
				Job key = currentJobToTask.Key;
				List<WarehouseTask> value = currentJobToTask.Value;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				list2.Clear();
				foreach (WarehouseTask item3 in value)
				{
					if (!IsCargoSupported(item3.cargoType) || item3.warehouseTaskType != taskType)
					{
						break;
					}
					if (CarsPresentOnWarehouseTrack(item3.cars) && item3.readyForMachine)
					{
						list2.Add(item3);
						flag = true;
						continue;
					}
					flag2 = true;
					if (AtLeastOneCarOnWarehouseTrack(item3.cars))
					{
						flag3 = true;
					}
				}
				if (flag || flag3)
				{
					WarehouseLoadUnloadDataPerJob.State state = ((!flag) ? (flag3 ? WarehouseLoadUnloadDataPerJob.State.SomeCarsPresentLoadUnloadForbiden : WarehouseLoadUnloadDataPerJob.State.NoneOfCarsPresentLoadUnloadForbiden) : (flag2 ? WarehouseLoadUnloadDataPerJob.State.PartialLoadUnloadPossible : WarehouseLoadUnloadDataPerJob.State.FullLoadUnloadPossible));
					WarehouseLoadUnloadDataPerJob item = new WarehouseLoadUnloadDataPerJob(key.ID, new List<WarehouseTask>(list2), null, state);
					list.Add(item);
				}
			}
			List<Car> specialDeliveryReservedCars = new List<Car>();
			foreach (WarehouseSpecialDelivery specialDelivery in specialDeliveries)
			{
				if (specialDelivery.deliveryType != taskType)
				{
					continue;
				}
				bool flag4 = true;
				foreach (CargoType_v2 item4 in specialDelivery.cargoToProcess)
				{
					if (!IsCargoSupported(item4.v1))
					{
						flag4 = false;
						break;
					}
				}
				if (flag4)
				{
					List<Car> list3 = ReserveCarsForSpecialDelivery(specialDelivery);
					if (list3 != null && list3.Count > 0)
					{
						WarehouseLoadUnloadDataPerJob item2 = new WarehouseLoadUnloadDataPerJob(specialDelivery.id, null, specialDelivery, WarehouseLoadUnloadDataPerJob.State.FullLoadUnloadPossible);
						list.Add(item2);
					}
				}
			}
			return list;
			List<Car> ReserveCarsForSpecialDelivery(WarehouseSpecialDelivery delivery)
			{
				List<Car> list4 = (from c in WarehouseTrack.GetCarsFullyOnTrack()
					where currentTasks.All((WarehouseTask t) => !t.cars.Contains(c)) && !specialDeliveryReservedCars.Contains(c)
					select c).ToList();
				List<Car> list5 = new List<Car>();
				foreach (CargoType_v2 item5 in delivery.cargoToProcess)
				{
					bool flag5 = false;
					foreach (Car item6 in list4)
					{
						if (DVObjectModel.current.CargoToLoadableCarTypes[item5].Contains(item6.carType.parentType) && (delivery.deliveryType != WarehouseTaskType.Loading || item6.LoadedCargoAmount == 0f) && (delivery.deliveryType != WarehouseTaskType.Unloading || item6.LoadedCargoAmount == 1f || item6.CurrentCargoTypeInCar == item5.v1))
						{
							flag5 = true;
							list5.Add(item6);
							break;
						}
					}
					if (!flag5)
					{
						return null;
					}
				}
				specialDeliveryReservedCars.AddRange(list5);
				delivery.reservedCarsOnTrack = list5;
				return list5;
			}
		}

		public Car LoadOneCarOfTask(WarehouseTask task)
		{
			if (!currentTasks.Contains(task))
			{
				Debug.LogWarning("task is not part of currentTasks! Either loading was interrupted by game quit or something is bad!");
				return null;
			}
			Car car = null;
			float num = task.cargoAmount;
			for (int i = 0; i < task.cars.Count; i++)
			{
				Car car2 = task.cars[i];
				if (car == null && car2.CurrentCargoTypeInCar == CargoType.None && car2.LoadedCargoAmount == 0f)
				{
					car = car2;
					float num2 = ((num >= car2.capacity) ? car2.capacity : num);
					car.LoadCargo(num2, task.cargoType, this);
					num -= num2;
					Debug.Log($"Loaded: {num2} {task.cargoType} to Car[{car2.ID}]");
				}
				else if (car2.CurrentCargoTypeInCar == task.cargoType && car2.LoadedCargoAmount > 0f)
				{
					num -= car2.LoadedCargoAmount;
				}
			}
			if (car != null)
			{
				if (num == 0f)
				{
					RemoveWarehouseTask(task);
				}
				return car;
			}
			Debug.LogWarning("There was no car to load, something is bad!");
			return null;
		}

		public Car UnloadOneCarOfTask(WarehouseTask task)
		{
			if (!currentTasks.Contains(task))
			{
				Debug.LogWarning("task is not part of currentTasks! Either loading was interrupted by game quit or something is bad!");
				return null;
			}
			Car car = null;
			float num = task.cargoAmount;
			for (int i = 0; i < task.cars.Count; i++)
			{
				Car car2 = task.cars[i];
				if (car == null && car2.CurrentCargoTypeInCar == task.cargoType && car2.LoadedCargoAmount > 0f)
				{
					car = car2;
					float loadedCargoAmount = car2.LoadedCargoAmount;
					car.UnloadCargo(loadedCargoAmount, task.cargoType, this);
					num -= loadedCargoAmount;
					Debug.Log($"Unloaded: {loadedCargoAmount} {task.cargoType} from Car[{car2.ID}]");
				}
				else if (car2.CurrentCargoTypeInCar == CargoType.None && car2.LoadedCargoAmount == 0f)
				{
					num -= car2.capacity;
				}
			}
			if (car != null)
			{
				if (num == 0f)
				{
					RemoveWarehouseTask(task);
				}
				return car;
			}
			Debug.LogWarning("There was no car to unload, something is bad!");
			return null;
		}

		public bool AnyTrainToLoadPresentOnTrack()
		{
			foreach (WarehouseTask currentTask in currentTasks)
			{
				if (currentTask.readyForMachine && currentTask.warehouseTaskType == WarehouseTaskType.Loading && CarsPresentOnWarehouseTrack(currentTask.cars))
				{
					return true;
				}
			}
			if (specialDeliveries.Count > 0)
			{
				List<Car> list = null;
				foreach (WarehouseSpecialDelivery specialDelivery in specialDeliveries)
				{
					if (specialDelivery.deliveryType != WarehouseTaskType.Loading)
					{
						continue;
					}
					if (list == null)
					{
						list = (from c in WarehouseTrack.GetCarsFullyOnTrack()
							where currentTasks.All((WarehouseTask t) => !t.cars.Contains(c))
							select c).ToList();
					}
					if (CanCarsHandleSpecialDelivery(list, specialDelivery))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool AnyTrainToUnloadPresentOnTrack()
		{
			foreach (WarehouseTask currentTask in currentTasks)
			{
				if (currentTask.readyForMachine && currentTask.warehouseTaskType == WarehouseTaskType.Unloading && CarsPresentOnWarehouseTrack(currentTask.cars))
				{
					return true;
				}
			}
			if (specialDeliveries.Count > 0)
			{
				List<Car> list = null;
				foreach (WarehouseSpecialDelivery specialDelivery in specialDeliveries)
				{
					if (specialDelivery.deliveryType != WarehouseTaskType.Unloading)
					{
						continue;
					}
					if (list == null)
					{
						list = (from c in WarehouseTrack.GetCarsFullyOnTrack()
							where currentTasks.All((WarehouseTask t) => !t.cars.Contains(c))
							select c).ToList();
					}
					if (CanCarsHandleSpecialDelivery(list, specialDelivery))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool AtLeastOneCarOnWarehouseTrack(List<Car> cars)
		{
			foreach (Car car in cars)
			{
				if (car.CurrentTrack == WarehouseTrack)
				{
					return true;
				}
			}
			return false;
		}

		private bool CarsPresentOnWarehouseTrack(List<Car> cars)
		{
			foreach (Car car in cars)
			{
				if (car.CurrentTrack != WarehouseTrack)
				{
					return false;
				}
			}
			return true;
		}

		public List<Car> TryLoadCargoToAllCarsInstant()
		{
			List<WarehouseTask> list = new List<WarehouseTask>();
			List<Car> list2 = new List<Car>();
			foreach (WarehouseTask currentTask in currentTasks)
			{
				if (currentTask.cars.All((Car car) => car.CurrentTrack == WarehouseTrack && car.CurrentCargoTypeInCar == CargoType.None && car.LoadedCargoAmount == 0f) && IsCargoSupported(currentTask.cargoType) && currentTask.warehouseTaskType == WarehouseTaskType.Loading)
				{
					LoadCargoToCars(currentTask.cars, currentTask.cargoType, currentTask.cargoAmount);
					list2.AddRange(currentTask.cars);
					list.Add(currentTask);
				}
			}
			foreach (WarehouseTask item in list)
			{
				RemoveWarehouseTask(item);
			}
			return list2;
		}

		private void LoadCargoToCars(List<Car> cars, CargoType loadingCargoType, float cargoAmount)
		{
			float num = cargoAmount;
			foreach (Car car in cars)
			{
				float num2 = ((car.capacity <= num) ? car.capacity : num);
				car.LoadCargo(num2, loadingCargoType, this);
				num -= num2;
				Debug.Log("Car[" + car.ID + "] Loaded: " + num2 + " " + loadingCargoType);
			}
			if (num != 0f)
			{
				Debug.LogError("Something is wrong! cargoAmount is not loaded fully!");
			}
		}

		public List<Car> TryUnloadCargoToAllCarsInstant()
		{
			List<WarehouseTask> list = new List<WarehouseTask>();
			List<Car> list2 = new List<Car>();
			foreach (WarehouseTask task in currentTasks)
			{
				if (task.cars.All((Car car) => car.CurrentTrack == WarehouseTrack && car.CurrentCargoTypeInCar == task.cargoType && car.LoadedCargoAmount > 0f) && IsCargoSupported(task.cargoType) && task.warehouseTaskType == WarehouseTaskType.Unloading)
				{
					UnloadCargo(task.cars, task.cargoType, task.cargoAmount);
					list2.AddRange(task.cars);
					list.Add(task);
				}
			}
			foreach (WarehouseTask item in list)
			{
				RemoveWarehouseTask(item);
			}
			return list2;
		}

		private void UnloadCargo(List<Car> cars, CargoType unloadingCargoType, float cargoAmount)
		{
			float num = cargoAmount;
			foreach (Car car in cars)
			{
				float loadedCargoAmount = car.LoadedCargoAmount;
				car.UnloadCargo(loadedCargoAmount, unloadingCargoType, this);
				num -= loadedCargoAmount;
				Debug.Log("Car[" + car.ID + "] Unloaded: " + loadedCargoAmount + " " + unloadingCargoType);
			}
			if (num != 0f)
			{
				Debug.LogError("Something is wrong! cargoAmount is not unloaded fully!");
			}
		}

		public bool IsCargoSupported(CargoType cargoType)
		{
			return SupportedCargoTypes.Contains(cargoType);
		}

		public void AddWarehouseTask(WarehouseTask task)
		{
			currentTasks.Add(task);
			Job job = task.Job;
			if (!currentJobToTasks.ContainsKey(job))
			{
				currentJobToTasks[job] = new List<WarehouseTask>();
			}
			currentJobToTasks[job].Add(task);
		}

		public void RemoveWarehouseTask(WarehouseTask task)
		{
			if (!currentTasks.Remove(task))
			{
				Debug.LogError("Trying to remove task from WarehouseMachine that is not in the currentTasks list.");
			}
			if (currentJobToTasks.TryGetValue(task.Job, out var value))
			{
				if (value.Remove(task))
				{
					if (value.Count == 0)
					{
						currentJobToTasks.Remove(task.Job);
					}
				}
				else
				{
					Debug.LogError("Trying to remove task from WarehouseMachine that is not in the remainingTasks list.");
				}
			}
			else
			{
				Debug.LogError("Trying to remove task from WarehouseMachine that is not in the currentJobToTasks list.");
			}
		}

		public void AddSpecialDelivery(WarehouseSpecialDelivery delivery)
		{
			foreach (CargoType_v2 item in delivery.cargoToProcess)
			{
				if (!IsCargoSupported(item.v1))
				{
					Debug.LogError("Attempted to add delivery of cargo " + item.id + " to WarehouseMachine: " + ID + ", even though it's not supported");
					return;
				}
			}
			specialDeliveries.Add(delivery);
		}

		public void RemoveSpecialDelivery(WarehouseSpecialDelivery delivery)
		{
			if (!specialDeliveries.Remove(delivery))
			{
				Debug.LogError("Trying to remove delivery from WarehouseMachine that is not in the specialDeliveries list");
			}
		}

		public bool CanCarsHandleSpecialDelivery(List<Car> cars, WarehouseSpecialDelivery delivery)
		{
			foreach (CargoType_v2 item in delivery.cargoToProcess)
			{
				bool flag = false;
				foreach (Car car in cars)
				{
					if (DVObjectModel.current.CargoToLoadableCarTypes[item].Contains(car.carType.parentType) && (delivery.deliveryType != WarehouseTaskType.Loading || car.LoadedCargoAmount == 0f) && (delivery.deliveryType != WarehouseTaskType.Unloading || car.LoadedCargoAmount == 1f || car.CurrentCargoTypeInCar == item.v1))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		public List<Car> LoadSpecialDelivery(WarehouseSpecialDelivery delivery)
		{
			for (int i = 0; i < delivery.cargoToProcess.Count; i++)
			{
				delivery.reservedCarsOnTrack[i].LoadCargo(1f, delivery.cargoToProcess[i].v1, this);
			}
			delivery.FireProcessed();
			RemoveSpecialDelivery(delivery);
			return delivery.reservedCarsOnTrack;
		}

		public List<Car> UnloadSpecialDelivery(WarehouseSpecialDelivery delivery)
		{
			for (int i = 0; i < delivery.cargoToProcess.Count; i++)
			{
				delivery.reservedCarsOnTrack[i].UnloadCargo(1f, delivery.cargoToProcess[i].v1, this);
			}
			delivery.FireProcessed();
			RemoveSpecialDelivery(delivery);
			return delivery.reservedCarsOnTrack;
		}
	}
}
