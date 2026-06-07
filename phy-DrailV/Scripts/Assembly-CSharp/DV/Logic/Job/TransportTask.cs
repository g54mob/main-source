using System.Collections.Generic;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Logic.Job
{
	public class TransportTask : Task
	{
		private const float HANDBRAKE_APPLIED_THRESHOLD = 0.75f;

		private List<Car> cars;

		private Track startingTrack;

		private Track destinationTrack;

		private List<CargoType> transportedCargoPerCar;

		private bool couplingRequiredAndNotDone;

		private bool anyHandbrakeRequiredAndNotDone;

		public override TaskType InstanceTaskType => TaskType.Transport;

		public TransportTask(List<Car> cars, Track destinationTrack, Track startingTrack = null, List<CargoType> transportedCargoPerCar = null, long timeLimit = 0L, bool isLastTask = false)
			: base(timeLimit, isLastTask)
		{
			this.cars = cars;
			this.startingTrack = startingTrack;
			this.destinationTrack = destinationTrack;
			this.transportedCargoPerCar = transportedCargoPerCar;
		}

		public override float GetTaskPrice()
		{
			return 0f;
		}

		public override TaskData GetTaskData()
		{
			return new TaskData(TaskType.Transport, state, taskStartTime, taskFinishTime, cars, startingTrack, destinationTrack, WarehouseTaskType.None, transportedCargoPerCar, 0f, null, couplingRequiredAndNotDone, anyHandbrakeRequiredAndNotDone);
		}

		public override TaskState UpdateTaskState()
		{
			couplingRequiredAndNotDone = false;
			anyHandbrakeRequiredAndNotDone = false;
			foreach (Car car in cars)
			{
				if (car.CurrentTrack != destinationTrack)
				{
					SetState(TaskState.InProgress);
					return state;
				}
				if (SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.TryGetValue(car, out var value) && value != null)
				{
					if (value.GetAbsSpeed() > 0.3f)
					{
						SetState(TaskState.InProgress);
						return state;
					}
				}
				else
				{
					Debug.LogError("Can't find corresponding TrainCar for car[" + car.ID + "]");
				}
			}
			if (isLastTask)
			{
				Dictionary<Car, TrainCar> logicCarToTrainCar = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar;
				Trainset trainset = null;
				for (int i = 0; i < cars.Count; i++)
				{
					if (logicCarToTrainCar.TryGetValue(cars[i], out var value2) && value2 != null)
					{
						if (trainset == null)
						{
							trainset = value2.trainset;
						}
						else if (trainset != value2.trainset)
						{
							couplingRequiredAndNotDone = true;
							SetState(TaskState.InProgress);
							return state;
						}
					}
					else
					{
						Debug.LogError("Can't find corresponding TrainCar for car[" + cars[i].ID + "]");
					}
				}
				bool flag = false;
				foreach (TrainCar car2 in trainset.cars)
				{
					if (!CarTypes.IsAnyLocomotiveOrTender(car2.carLivery) && car2.brakeSystem.handbrakePosition > 0.75f)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					anyHandbrakeRequiredAndNotDone = true;
					SetState(TaskState.InProgress);
					return state;
				}
			}
			SetState(TaskState.Done);
			return state;
		}
	}
}
