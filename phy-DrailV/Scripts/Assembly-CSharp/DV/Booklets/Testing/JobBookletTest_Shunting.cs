using System;
using System.Collections.Generic;
using System.Linq;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class JobBookletTest_Shunting : ABookletTest
	{
		public StationInfo loadStationInfo = new StationInfo("Starting Station West", "Dairy Farm", "ST", Color.red);

		public StationInfo unloadStationInfo = new StationInfo("Destination Station North", "Something", "DE", Color.blue);

		public JobLicenses requiredLicenses = JobLicenses.Hazmat1 | JobLicenses.Shunting | JobLicenses.LogisticalHaul;

		public bool multiplePickupsOrDrops;

		public bool load;

		public bool overview;

		private TrackID UNLOADED_TRACK_A = new TrackID("ST", "A", "7", "S");

		private TrackID UNLOADED_TRACK_B = new TrackID("ST", "A", "6", "S");

		private TrackID WAREHOUSE_TRACK = new TrackID("ST", "W", "2", "L");

		private TrackID LOADED_TRACK = new TrackID("ST", "W", "7", "O");

		private List<Car_data> cars;

		private List<CargoType> cargoTypePerCar;

		protected override GameObject CreateBooklet()
		{
			return (overview ? BookletCreator_Job.Create(CreateJobData(), base.transform.position, base.transform.rotation, base.transform) : BookletCreator_JobOverview.Create(CreateJobData(), base.transform.position, base.transform.rotation, base.transform)).gameObject;
		}

		protected Job_data CreateJobData()
		{
			cars = new List<Car_data>
			{
				new Car_data("CAR-01", TrainCarType.BoxcarGreen.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-02", TrainCarType.TankYellow.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-03", TrainCarType.AutorackGreen.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-04", TrainCarType.FlatbedEmpty.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f)
			};
			cargoTypePerCar = new List<CargoType>
			{
				CargoType.CannedFood,
				CargoType.DairyProducts,
				CargoType.NewCars,
				CargoType.SteelBillets
			};
			Task_data task_data = new Task_data(TaskType.Sequential, TaskType.Sequential, TaskState.InProgress, 100f, 150f, cars, load ? UNLOADED_TRACK_A : LOADED_TRACK, load ? LOADED_TRACK : UNLOADED_TRACK_A, WarehouseTaskType.None, cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, GetTaskData());
			return new Job_data("SL-01", load ? JobType.ShuntingLoad : JobType.ShuntingUnload, JobState.Available, 0f, 0f, 50f, 34500f, 23000f, 58982f, requiredLicenses, new Task_data[1] { task_data }, loadStationInfo, unloadStationInfo);
		}

		private Task_data GetUnloadedTask()
		{
			int count = cars.Count / 2;
			List<Car_data> list = cars.Take(count).ToList();
			List<Car_data> list2 = cars.Skip(count).ToList();
			List<CargoType> list3 = cargoTypePerCar.Take(count).ToList();
			List<CargoType> list4 = cargoTypePerCar.Skip(count).ToList();
			Task_data task_data = new Task_data(TaskType.Parallel, TaskType.Parallel, TaskState.InProgress, 100f, 150f, cars, load ? WAREHOUSE_TRACK : UNLOADED_TRACK_A, load ? UNLOADED_TRACK_A : WAREHOUSE_TRACK, WarehouseTaskType.None, cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, new Task_data[2]
			{
				new Task_data(TaskType.Transport, TaskType.Transport, TaskState.InProgress, 100f, 150f, multiplePickupsOrDrops ? list : cars, load ? UNLOADED_TRACK_A : WAREHOUSE_TRACK, load ? WAREHOUSE_TRACK : UNLOADED_TRACK_A, WarehouseTaskType.None, multiplePickupsOrDrops ? list3 : cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null),
				new Task_data(TaskType.Transport, TaskType.Transport, TaskState.InProgress, 100f, 150f, list2, load ? UNLOADED_TRACK_B : WAREHOUSE_TRACK, load ? WAREHOUSE_TRACK : UNLOADED_TRACK_B, WarehouseTaskType.None, list4, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null)
			});
			if (!multiplePickupsOrDrops)
			{
				Array.Resize(ref task_data.nestedTasks, 1);
			}
			return task_data;
		}

		private Task_data GetWarehouseTask()
		{
			int count = cars.Count / 2;
			List<Car_data> list = cars.Take(count).ToList();
			List<Car_data> list2 = cars.Skip(count).ToList();
			List<CargoType> list3 = cargoTypePerCar.Take(count).ToList();
			List<CargoType> list4 = cargoTypePerCar.Skip(count).ToList();
			Task_data task_data = new Task_data(TaskType.Parallel, TaskType.Parallel, TaskState.InProgress, 100f, 150f, cars, load ? UNLOADED_TRACK_B : LOADED_TRACK, WAREHOUSE_TRACK, WarehouseTaskType.None, cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, new Task_data[2]
			{
				new Task_data(TaskType.Warehouse, TaskType.Warehouse, TaskState.InProgress, 100f, 150f, multiplePickupsOrDrops ? list : cars, load ? UNLOADED_TRACK_B : LOADED_TRACK, WAREHOUSE_TRACK, load ? WarehouseTaskType.Loading : WarehouseTaskType.Unloading, multiplePickupsOrDrops ? list3 : cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null),
				new Task_data(TaskType.Warehouse, TaskType.Warehouse, TaskState.InProgress, 100f, 150f, list2, load ? UNLOADED_TRACK_B : LOADED_TRACK, WAREHOUSE_TRACK, load ? WarehouseTaskType.Loading : WarehouseTaskType.Unloading, list4, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null)
			});
			if (!multiplePickupsOrDrops)
			{
				Array.Resize(ref task_data.nestedTasks, 1);
			}
			return task_data;
		}

		private Task_data GetLoadedTask()
		{
			return new Task_data(TaskType.Transport, TaskType.Transport, TaskState.InProgress, 100f, 150f, cars, load ? WAREHOUSE_TRACK : LOADED_TRACK, load ? LOADED_TRACK : WAREHOUSE_TRACK, WarehouseTaskType.None, cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null);
		}

		private Task_data[] GetTaskData()
		{
			if (!load)
			{
				return new Task_data[3]
				{
					GetLoadedTask(),
					GetWarehouseTask(),
					GetUnloadedTask()
				};
			}
			return new Task_data[3]
			{
				GetUnloadedTask(),
				GetWarehouseTask(),
				GetLoadedTask()
			};
		}
	}
}
