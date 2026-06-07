using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class JobBookletTest_FreightHaul : ABookletTest
	{
		public StationInfo destinationStationInfo = new StationInfo("Destination Station North", "Something", "DE", Color.blue);

		public StationInfo originStationInfo = new StationInfo("Starting Station West", "Dairy Farm", "ST", Color.red);

		public JobLicenses requiredLicenses = JobLicenses.Hazmat1 | JobLicenses.Military1 | JobLicenses.FreightHaul;

		public bool overview;

		protected override GameObject CreateBooklet()
		{
			return (overview ? BookletCreator_Job.Create(CreateJobData(), base.transform.position, base.transform.rotation, base.transform) : BookletCreator_JobOverview.Create(CreateJobData(), base.transform.position, base.transform.rotation, base.transform)).gameObject;
		}

		protected Job_data CreateJobData()
		{
			List<Car_data> cars = new List<Car_data>
			{
				new Car_data("CAR-01", TrainCarType.BoxcarGreen.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-02", TrainCarType.TankYellow.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-03", TrainCarType.AutorackGreen.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f),
				new Car_data("CAR-04", TrainCarType.FlatbedEmpty.ToV2(), derailed: false, isOnDestinationTrack: false, 20f, 2000f, 10f)
			};
			List<CargoType> cargoTypePerCar = new List<CargoType>
			{
				CargoType.CannedFood,
				CargoType.DairyProducts,
				CargoType.NewCars,
				CargoType.SteelBillets
			};
			Task_data task_data = new Task_data(TaskType.Transport, TaskType.Transport, TaskState.InProgress, 100f, 150f, cars, new TrackID("ST", "W", "6", "L"), new TrackID("ST", "W", "7", "O"), WarehouseTaskType.None, cargoTypePerCar, 23400f, couplingRequiredAndNotDone: false, anyHandbrakeRequiredAndNotDone: false, null);
			return new Job_data("SL-01", JobType.Transport, JobState.Available, 0f, 0f, 50f, 34500f, 23000f, 58982f, requiredLicenses, new Task_data[1] { task_data }, originStationInfo, destinationStationInfo);
		}
	}
}
