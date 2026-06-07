using System;
using System.Collections.Generic;
using System.Linq;
using DV.Booklets;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public static class JobDataExtractor
	{
		public static TransportJobData ExtractTransportJobData(Job_data job)
		{
			if (job.tasksData.Length != 1 || job.tasksData[0].type != TaskType.Transport)
			{
				throw new Exception($"Wrong format of {JobType.Transport} job, can't extract data correctly. Job id: {job.ID}");
			}
			Task_data task_data = job.tasksData[0];
			return new TransportJobData(job, task_data.startTrackID, task_data.destinationTrackID, task_data.cars, task_data.cargoTypePerCar);
		}

		public static ShuntingLoadJobData ExtractShuntingLoadJobData(Job_data job)
		{
			string message = $"Wrong format of {JobType.ShuntingLoad} job, can't extract data correctly. Job id: {job.ID}";
			Task_data task_data = job.tasksData.First();
			if (job.tasksData.Length != 1 || task_data.type != TaskType.Sequential)
			{
				throw new Exception(message);
			}
			Task_data[] nestedTasks = task_data.nestedTasks;
			if (nestedTasks.Length != 3)
			{
				throw new Exception("sequentialLoadTasks doesn't contain 3 sequential tasks! Can't extract data correctly. Job id: " + job.ID);
			}
			if (nestedTasks[0].instanceTaskType != TaskType.Parallel || nestedTasks[1].instanceTaskType != TaskType.Parallel || nestedTasks[2].instanceTaskType != TaskType.Transport)
			{
				throw new Exception(message);
			}
			List<CarDataPerTrackID> startingTracksData = ExtractTrackDataFromParallelTransportTasks(nestedTasks[0].nestedTasks, extractStartTracksData: true);
			ExtractDataFromParallelWarehouseTasks(nestedTasks[1].nestedTasks, WarehouseTaskType.Loading, out var allCars, out var cargoTypePerCar, out var warehouseMachineTrack);
			TrackID destinationTrackID = nestedTasks[2].destinationTrackID;
			return new ShuntingLoadJobData(job, startingTracksData, warehouseMachineTrack, destinationTrackID, allCars, cargoTypePerCar);
		}

		public static ShuntingUnloadJobData ExtractShuntingUnloadJobData(Job_data job)
		{
			string message = $"Wrong format of {JobType.ShuntingUnload} job, can't extract data correctly. Job id: {job.ID}";
			Task_data task_data = job.tasksData.First();
			if (job.tasksData.Length != 1 || task_data.type != TaskType.Sequential)
			{
				throw new Exception(message);
			}
			Task_data[] nestedTasks = task_data.nestedTasks;
			if (nestedTasks.Length != 3)
			{
				throw new Exception("sequentialUnloadTasks doesn't contain 3 sequential tasks! Can't extract data correctly. Job id: " + job.ID);
			}
			if (nestedTasks[0].instanceTaskType != TaskType.Transport || nestedTasks[1].instanceTaskType != TaskType.Parallel || nestedTasks[2].instanceTaskType != TaskType.Parallel)
			{
				throw new Exception(message);
			}
			TrackID startTrackID = nestedTasks[0].startTrackID;
			ExtractDataFromParallelWarehouseTasks(nestedTasks[1].nestedTasks, WarehouseTaskType.Unloading, out var allCars, out var cargoTypePerCar, out var warehouseMachineTrack);
			List<CarDataPerTrackID> destinationTracksData = ExtractTrackDataFromParallelTransportTasks(nestedTasks[2].nestedTasks, extractStartTracksData: false);
			return new ShuntingUnloadJobData(job, startTrackID, warehouseMachineTrack, destinationTracksData, allCars, cargoTypePerCar);
		}

		public static EmptyHaulJobData ExtractEmptyHaulJobData(Job_data job)
		{
			if (job.tasksData.Length != 1 || job.tasksData[0].type != TaskType.Transport)
			{
				throw new Exception($"Wrong format of {JobType.EmptyHaul} job, can't extract data correctly. Job id: {job.ID}");
			}
			Task_data task_data = job.tasksData[0];
			return new EmptyHaulJobData(job, task_data.startTrackID, task_data.destinationTrackID, task_data.cars);
		}

		private static void ExtractDataFromParallelWarehouseTasks(Task_data[] parallelWarehouseTasks, WarehouseTaskType warehouseTaskType, out List<Car_data> allCars, out List<CargoType> cargoTypePerCar, out TrackID warehouseMachineTrack)
		{
			allCars = new List<Car_data>();
			cargoTypePerCar = new List<CargoType>();
			for (int i = 0; i < parallelWarehouseTasks.Length; i++)
			{
				Task_data task_data = parallelWarehouseTasks[i];
				if (task_data.type != TaskType.Warehouse)
				{
					throw new ArgumentException(string.Format("{0}[{1}].{2} expected '{3}', got '{4}'", "parallelWarehouseTasks", i, "type", TaskType.Warehouse, task_data.type));
				}
				if (task_data.warehouseTaskType != warehouseTaskType)
				{
					throw new ArgumentException(string.Format("{0}[{1}].{2} expected '{3}', got '{4}'", "parallelWarehouseTasks", i, "warehouseTaskType", warehouseTaskType, task_data.warehouseTaskType));
				}
				allCars.AddRange(task_data.cars);
				cargoTypePerCar.AddRange(task_data.cargoTypePerCar);
			}
			warehouseMachineTrack = parallelWarehouseTasks[0].destinationTrackID;
		}

		private static List<CarDataPerTrackID> ExtractTrackDataFromParallelTransportTasks(Task_data[] parallelTransportTasks, bool extractStartTracksData)
		{
			List<CarDataPerTrackID> list = new List<CarDataPerTrackID>();
			foreach (Task_data task_data in parallelTransportTasks)
			{
				if (task_data.type != TaskType.Transport)
				{
					throw new Exception("Unexpected format of parallelTransportTasks!");
				}
				list.Add(new CarDataPerTrackID(extractStartTracksData ? task_data.startTrackID : task_data.destinationTrackID, task_data.cars));
			}
			return list;
		}
	}
}
