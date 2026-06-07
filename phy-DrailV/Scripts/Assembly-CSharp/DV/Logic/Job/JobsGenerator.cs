using System;
using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.Logic.Job
{
	public static class JobsGenerator
	{
		public static Job CreateShuntingLoadJob(Station jobOriginStation, StationsChainData chainData, List<CarsPerTrack> startingTracksData, Track destinationTrack, WarehouseMachine loadMachine, List<CarsPerCargoType> carsLoadData, bool forceDumpCargoIfCarsNotEmpty = false, float timeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			if (startingTracksData == null || startingTracksData.Count == 0)
			{
				throw new Exception(string.Format("Error while creating {0} job, {1} is null or empty!", JobType.ShuntingLoad, "startingTracksData"));
			}
			if (carsLoadData == null || carsLoadData.Count == 0)
			{
				throw new Exception(string.Format("Error while creating {0} job, {1} is null or empty!", JobType.ShuntingLoad, "carsLoadData"));
			}
			List<Task> list = new List<Task>();
			for (int i = 0; i < startingTracksData.Count; i++)
			{
				TransportTask item = CreateTransportTask(startingTracksData[i].cars, loadMachine.WarehouseTrack, startingTracksData[i].track);
				list.Add(item);
			}
			ParallelTasks item2 = new ParallelTasks(list, 0L);
			for (int j = 0; j < carsLoadData.Count; j++)
			{
				CargoType_v2 cargoV2 = carsLoadData[j].cargoType.ToV2();
				if (carsLoadData[j].cars.Any((Car car) => !cargoV2.IsLoadableOnCarType(car.carType.parentType)))
				{
					throw new Exception(string.Format("Error while creating {0} job, not all cars from {1}[{2}] can carry {3}!", JobType.ShuntingLoad, "carsLoadData", j, carsLoadData[j].cargoType));
				}
				if (carsLoadData[j].cars.Select((Car car) => car.capacity).Sum() < carsLoadData[j].totalCargoAmount)
				{
					throw new Exception(string.Format("Error while creating {0} job, {1} {2} to load is beyond {3}[{4}].cars capacity!", JobType.ShuntingLoad, carsLoadData[j].totalCargoAmount, carsLoadData[j].cargoType, "carsLoadData", j));
				}
				if (!loadMachine.IsCargoSupported(carsLoadData[j].cargoType))
				{
					throw new Exception(string.Format("Error while creating {0} job, cargo type we want to load [{1}] is not supported by {2}", JobType.ShuntingLoad, carsLoadData[j].cargoType, "loadMachine"));
				}
				if (!(carsLoadData[j].cars.Select((Car car) => car.LoadedCargoAmount).Sum() > 0f) && !carsLoadData[j].cars.Any((Car car) => car.CurrentCargoTypeInCar != CargoType.None))
				{
					continue;
				}
				if (forceDumpCargoIfCarsNotEmpty)
				{
					carsLoadData[j].cars.ForEach(delegate(Car car)
					{
						car.DumpCargo();
					});
				}
				else
				{
					Debug.LogWarning("Initial cargo state on car is not correct. This is valid only when loading save game!");
				}
			}
			List<Task> list2 = new List<Task>();
			for (int num = 0; num < carsLoadData.Count; num++)
			{
				list2.Add(new WarehouseTask(carsLoadData[num].cars, WarehouseTaskType.Loading, loadMachine, carsLoadData[num].cargoType, carsLoadData[num].totalCargoAmount, 0L));
			}
			ParallelTasks item3 = new ParallelTasks(list2, 0L);
			List<CargoType> cargoTypePerCar = GetCargoTypePerCar(carsLoadData);
			TransportTask item4 = CreateTransportTask(carsLoadData.SelectMany((CarsPerCargoType loadData) => loadData.cars).ToList(), destinationTrack, loadMachine.WarehouseTrack, cargoTypePerCar, isLastTask: true);
			Job job = new Job(new SequentialTasks(new List<Task> { item2, item3, item4 }, 0L), JobType.ShuntingLoad, timeLimit, initialWage, chainData, forcedJobId, requiredLicenses);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		public static Job CreateShuntingUnloadJob(Station jobOriginStation, StationsChainData chainData, Track startingTrack, List<CarsPerTrack> destinationTracksData, WarehouseMachine unloadMachine, List<CarsPerCargoType> carsUnloadData, bool forceFillCargoIfMissing = false, float timeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			if (destinationTracksData == null || destinationTracksData.Count == 0)
			{
				throw new Exception(string.Format("Error while creating {0} job, {1} is null or empty!", JobType.ShuntingUnload, "destinationTracksData"));
			}
			if (carsUnloadData == null || carsUnloadData.Count == 0)
			{
				throw new Exception(string.Format("Error while creating {0} job, {1} is null or empty!", JobType.ShuntingUnload, "carsUnloadData"));
			}
			List<CargoType> cargoTypePerCar = GetCargoTypePerCar(carsUnloadData);
			TransportTask item = CreateTransportTask(carsUnloadData.SelectMany((CarsPerCargoType loadData) => loadData.cars).ToList(), unloadMachine.WarehouseTrack, startingTrack, cargoTypePerCar);
			int i;
			for (i = 0; i < carsUnloadData.Count; i++)
			{
				CargoType_v2 cargoV2 = carsUnloadData[i].cargoType.ToV2();
				if (carsUnloadData[i].cars.Any((Car car) => !cargoV2.IsLoadableOnCarType(car.carType.parentType)))
				{
					throw new Exception(string.Format("Error while creating {0} job, not all cars from {1}[{2}] can carry {3}!", JobType.ShuntingUnload, "carsUnloadData", i, carsUnloadData[i].cargoType));
				}
				if (carsUnloadData[i].cars.Select((Car car) => car.capacity).Sum() < carsUnloadData[i].totalCargoAmount)
				{
					throw new Exception(string.Format("Error while creating {0} job, {1} {2} to unload is beyond {3}[{4}].cars capacity!", JobType.ShuntingUnload, carsUnloadData[i].totalCargoAmount, carsUnloadData[i].cargoType, "carsUnloadData", i));
				}
				if (!unloadMachine.IsCargoSupported(carsUnloadData[i].cargoType))
				{
					throw new Exception(string.Format("Error while creating {0} job, cargo type we want to unload [{1}] is not supported by {2}", JobType.ShuntingUnload, carsUnloadData[i].cargoType, "unloadMachine"));
				}
				if (!(carsUnloadData[i].cars.Select((Car car) => car.LoadedCargoAmount).Sum() < carsUnloadData[i].totalCargoAmount) && !carsUnloadData[i].cars.Any((Car car) => car.CurrentCargoTypeInCar != carsUnloadData[i].cargoType))
				{
					continue;
				}
				if (forceFillCargoIfMissing)
				{
					float num = carsUnloadData[i].totalCargoAmount;
					foreach (Car car in carsUnloadData[i].cars)
					{
						car.DumpCargo();
						float num2 = ((num > car.capacity) ? car.capacity : num);
						car.LoadCargo(num2, carsUnloadData[i].cargoType);
						num -= num2;
					}
				}
				else
				{
					Debug.LogWarning("Initial cargo state on car is not correct. This is valid only when loading save game!");
				}
			}
			List<Task> list = new List<Task>();
			for (int num3 = 0; num3 < carsUnloadData.Count; num3++)
			{
				list.Add(new WarehouseTask(carsUnloadData[num3].cars, WarehouseTaskType.Unloading, unloadMachine, carsUnloadData[num3].cargoType, carsUnloadData[num3].totalCargoAmount, 0L));
			}
			ParallelTasks item2 = new ParallelTasks(list, 0L);
			List<Task> list2 = new List<Task>();
			for (int num4 = 0; num4 < destinationTracksData.Count; num4++)
			{
				TransportTask item3 = CreateTransportTask(destinationTracksData[num4].cars, destinationTracksData[num4].track, unloadMachine.WarehouseTrack, null, isLastTask: true);
				list2.Add(item3);
			}
			ParallelTasks item4 = new ParallelTasks(list2, 0L, isLastTask: true);
			Job job = new Job(new SequentialTasks(new List<Task> { item, item2, item4 }, 0L), JobType.ShuntingUnload, timeLimit, initialWage, chainData, forcedJobId, requiredLicenses);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		public static Job CreateTransportJob(Station jobOriginStation, StationsChainData chainData, List<Car> cars, Track destinationTrack, Track startingTrack = null, List<CargoType> transportedCargoPerCar = null, List<float> cargoAmountPerCar = null, bool forceFillCargoIfMissing = false, float timeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			bool num = transportedCargoPerCar != null;
			bool flag = cargoAmountPerCar != null;
			if (num != flag)
			{
				throw new Exception("Error while creating transport job, one of transportedCargoPerCar and cargoAmountPerCar is not initialized!");
			}
			if (num && flag)
			{
				if (transportedCargoPerCar.Count != cargoAmountPerCar.Count)
				{
					throw new Exception("Error while creating transport job, transportedCargoPerCar and cargoAmountPerCar count is not matching!");
				}
				for (int i = 0; i < cars.Count; i++)
				{
					if (!transportedCargoPerCar[i].ToV2().IsLoadableOnCarType(cars[i].carType.parentType))
					{
						throw new Exception(string.Format("Error while creating transport job, {0}[{1}] can't carry specified {2}[{3}]!", "cars", i, "transportedCargoPerCar", i));
					}
					if (cars[i].capacity < cargoAmountPerCar[i])
					{
						throw new Exception(string.Format("Error while creating transport job, {0}[{1}] can't fit in {2}[{3}]", "cargoAmountPerCar", i, "cars", i));
					}
					if (cars[i].LoadedCargoAmount < cargoAmountPerCar[i] || cars[i].CurrentCargoTypeInCar != transportedCargoPerCar[i])
					{
						if (!forceFillCargoIfMissing)
						{
							throw new Exception(string.Format("Error while creating transport job, {0}[{1}] doesn't have required {2}!", cars, i, "cargoAmountPerCar"));
						}
						cars[i].DumpCargo();
						cars[i].LoadCargo(cargoAmountPerCar[i], transportedCargoPerCar[i]);
					}
				}
			}
			Job job = new Job(CreateTransportTask(cars, destinationTrack, startingTrack, transportedCargoPerCar, isLastTask: true), JobType.Transport, timeLimit, initialWage, chainData, forcedJobId, requiredLicenses);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		public static Job CreateEmptyHaulJob(Station jobOriginStation, StationsChainData chainData, List<Car> cars, Track startingTrack, Track destinationTrack, float timeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			Job job = new Job(CreateTransportTask(cars, destinationTrack, startingTrack, null, isLastTask: true), JobType.EmptyHaul, timeLimit, initialWage, chainData, forcedJobId, requiredLicenses);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		public static Job CreateComplexTransportJob(Station jobOriginStation, List<Car> cars, List<Track> destinationCheckpointTracks, Track startingTrack = null, float timeLimit = 0f, float initialWage = 0f)
		{
			List<Task> list = new List<Task>();
			for (int i = 0; i < destinationCheckpointTracks.Count; i++)
			{
				list.Add(CreateTransportTask(cars, destinationCheckpointTracks[i], (i == 0) ? startingTrack : destinationCheckpointTracks[i - 1], null, i == destinationCheckpointTracks.Count - 1));
			}
			Job job = new Job(new SequentialTasks(list, 0L), JobType.ComplexTransport, timeLimit, initialWage);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		public static TransportTask CreateTransportTask(List<Car> cars, Track destinationTrack, Track startingTrack = null, List<CargoType> transportedCargoPerCar = null, bool isLastTask = false)
		{
			if (transportedCargoPerCar != null && transportedCargoPerCar.Count != cars.Count)
			{
				throw new Exception("Error: cars and transportedCargoPerCar are not same length, so we can't create valid TranportTask!");
			}
			return new TransportTask(cars, destinationTrack, startingTrack, transportedCargoPerCar, 0L, isLastTask);
		}

		public static Job CreateJob(Station jobOriginStation, List<Task> tasks)
		{
			Job job = new Job(tasks);
			jobOriginStation.AddJobToStation(job);
			return job;
		}

		private static List<CargoType> GetCargoTypePerCar(List<CarsPerCargoType> carsPerCargoTypeData)
		{
			List<CargoType> list = new List<CargoType>();
			for (int i = 0; i < carsPerCargoTypeData.Count; i++)
			{
				List<Car> cars = carsPerCargoTypeData[i].cars;
				CargoType cargoType = carsPerCargoTypeData[i].cargoType;
				for (int j = 0; j < cars.Count; j++)
				{
					list.Add(cargoType);
				}
			}
			return list;
		}
	}
}
