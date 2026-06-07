using System;
using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class WarehouseTask : Task
	{
		public readonly List<Car> cars;

		public readonly WarehouseTaskType warehouseTaskType;

		public readonly WarehouseMachine warehouseMachine;

		public readonly CargoType cargoType;

		public readonly float cargoAmount;

		public bool readyForMachine;

		public override TaskType InstanceTaskType => TaskType.Warehouse;

		public WarehouseTask(List<Car> cars, WarehouseTaskType warehouseTaskType, WarehouseMachine warehouseMachine, CargoType cargoType, float cargoAmount, long timeLimit = 0L, bool isLastTask = false)
			: base(timeLimit, isLastTask)
		{
			this.cars = cars;
			this.warehouseTaskType = warehouseTaskType;
			this.warehouseMachine = warehouseMachine;
			this.cargoType = cargoType;
			this.cargoAmount = cargoAmount;
		}

		public override float GetTaskPrice()
		{
			return 0f;
		}

		public override TaskState UpdateTaskState()
		{
			readyForMachine = true;
			float num = 0f;
			foreach (Car car in cars)
			{
				if (warehouseTaskType == WarehouseTaskType.Loading)
				{
					if (car.LoadedCargoAmount == 0f)
					{
						SetState(TaskState.InProgress);
						return state;
					}
					num += car.LoadedCargoAmount;
				}
				else if (warehouseTaskType == WarehouseTaskType.Unloading)
				{
					if (car.LoadedCargoAmount > 0f)
					{
						SetState(TaskState.InProgress);
						return state;
					}
					num += car.capacity;
				}
			}
			if (num != cargoAmount)
			{
				throw new Exception(string.Concat("This shouldn't be possible, WarehouseTask cargo ", warehouseTaskType, " amount does not match cargo amount from task!"));
			}
			SetState(TaskState.Done);
			return state;
		}

		public override TaskData GetTaskData()
		{
			List<CargoType> list = new List<CargoType>();
			for (int i = 0; i < cars.Count; i++)
			{
				list.Add(cargoType);
			}
			return new TaskData(TaskType.Warehouse, state, taskStartTime, taskFinishTime, cars, null, warehouseMachine.WarehouseTrack, warehouseTaskType, list, cargoAmount);
		}

		public override void SetJobBelonging(Job job)
		{
			base.SetJobBelonging(job);
			job.JobAbandoned += OnJobAbandoned;
			job.JobTaken += OnJobTaken;
		}

		private void OnJobAbandoned(Job abandonedJob)
		{
			abandonedJob.JobAbandoned -= OnJobAbandoned;
			warehouseMachine.RemoveWarehouseTask(this);
		}

		private void OnJobTaken(Job takenJob, bool _)
		{
			takenJob.JobTaken -= OnJobTaken;
			warehouseMachine.AddWarehouseTask(this);
		}

		public override void OverrideTaskState(TaskSaveData data)
		{
			base.OverrideTaskState(data);
			if (data.state == TaskState.Done)
			{
				warehouseMachine.RemoveWarehouseTask(this);
			}
		}
	}
}
