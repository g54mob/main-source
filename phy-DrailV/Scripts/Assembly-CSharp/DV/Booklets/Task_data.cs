using System;
using System.Collections.Generic;
using System.Linq;
using DV.Logic.Job;
using DV.ThingTypes;

namespace DV.Booklets
{
	[Serializable]
	public class Task_data
	{
		public TaskType type;

		public TaskType instanceTaskType;

		public TaskState state;

		public float taskStartTime;

		public float taskFinishTime;

		public List<Car_data> cars;

		public TrackID startTrackID;

		public TrackID destinationTrackID;

		public WarehouseTaskType warehouseTaskType;

		public List<CargoType> cargoTypePerCar;

		public float totalCargoAmount;

		public bool couplingRequiredAndNotDone;

		public bool anyHandbrakeRequiredAndNotDone;

		public Task_data[] nestedTasks;

		public Task_data(TaskType type, TaskType instanceTaskType, TaskState state, float taskStartTime, float taskFinishTime, List<Car_data> cars, TrackID startTrackID, TrackID destinationTrackID, WarehouseTaskType warehouseTaskType, List<CargoType> cargoTypePerCar, float totalCargoAmount, bool couplingRequiredAndNotDone, bool anyHandbrakeRequiredAndNotDone, Task_data[] nestedTasks)
		{
			this.type = type;
			this.instanceTaskType = instanceTaskType;
			this.state = state;
			this.taskStartTime = taskStartTime;
			this.taskFinishTime = taskFinishTime;
			this.cars = cars;
			this.startTrackID = startTrackID;
			this.destinationTrackID = destinationTrackID;
			this.warehouseTaskType = warehouseTaskType;
			this.cargoTypePerCar = cargoTypePerCar;
			this.totalCargoAmount = totalCargoAmount;
			this.couplingRequiredAndNotDone = couplingRequiredAndNotDone;
			this.anyHandbrakeRequiredAndNotDone = anyHandbrakeRequiredAndNotDone;
			this.nestedTasks = nestedTasks;
		}

		public Task_data(Task task)
		{
			instanceTaskType = task.InstanceTaskType;
			TaskData td = task.GetTaskData();
			type = td.type;
			state = td.state;
			taskStartTime = td.taskStartTime;
			taskFinishTime = td.taskFinishTime;
			cars = td.cars?.Select((Car c) => new Car_data(c, c.CurrentTrack == td.destinationTrack)).ToList();
			destinationTrackID = td.destinationTrack?.ID;
			startTrackID = td.startTrack?.ID;
			warehouseTaskType = td.warehouseTaskType;
			cargoTypePerCar = td.cargoTypePerCar;
			totalCargoAmount = td.totalCargoAmount;
			couplingRequiredAndNotDone = td.couplingRequiredAndNotDone;
			anyHandbrakeRequiredAndNotDone = td.anyHandbrakeRequiredAndNotDone;
			nestedTasks = td.nestedTasks?.Select((Task t) => new Task_data(t)).ToArray();
		}
	}
}
