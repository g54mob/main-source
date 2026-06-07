using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class TaskData
	{
		public readonly TaskType type;

		public readonly TaskState state;

		public readonly float taskStartTime;

		public readonly float taskFinishTime;

		public readonly List<Car> cars;

		public readonly Track startTrack;

		public readonly Track destinationTrack;

		public readonly bool couplingRequiredAndNotDone;

		public readonly bool anyHandbrakeRequiredAndNotDone;

		public readonly WarehouseTaskType warehouseTaskType;

		public readonly List<CargoType> cargoTypePerCar;

		public readonly float totalCargoAmount;

		public readonly List<Task> nestedTasks;

		public TaskData(TaskType type, TaskState state, float taskStartTime, float taskFinishTime, List<Car> cars = null, Track startTrack = null, Track destinationTrack = null, WarehouseTaskType warehouseTaskType = WarehouseTaskType.None, List<CargoType> cargoTypePerCar = null, float amount = 0f, List<Task> nestedTasks = null, bool couplingRequiredAndNotDone = false, bool anyHandbrakeRequiredAndNotDone = false)
		{
			this.type = type;
			this.state = state;
			this.taskStartTime = taskStartTime;
			this.taskFinishTime = taskFinishTime;
			this.cars = cars;
			this.destinationTrack = destinationTrack;
			this.startTrack = startTrack;
			this.warehouseTaskType = warehouseTaskType;
			this.cargoTypePerCar = cargoTypePerCar;
			totalCargoAmount = amount;
			this.nestedTasks = nestedTasks;
			this.couplingRequiredAndNotDone = couplingRequiredAndNotDone;
			this.anyHandbrakeRequiredAndNotDone = anyHandbrakeRequiredAndNotDone;
		}
	}
}
