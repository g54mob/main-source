using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarSummonedStep : ACommsRadioStep<CommsRadioCrewVehicle>
	{
		private CommsRadioCrewVehicle crew;

		private bool summonHappened;

		public TrainCar SummonedCar { get; private set; }

		public CarSummonedStep(string message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			summonHappened = false;
			SummonedCar = null;
			CheckEvents();
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (crew != null)
			{
				crew.CarSummoned -= OnCarSummoned;
			}
		}

		private void CheckEvents()
		{
			if (crew != null)
			{
				crew.CarSummoned -= OnCarSummoned;
			}
			crew = GetModeController();
			if (crew != null)
			{
				crew.CarSummoned += OnCarSummoned;
			}
		}

		private void OnCarSummoned(TrainCar car)
		{
			SummonedCar = car;
			summonHappened = true;
		}

		protected override bool InternalCheck()
		{
			return summonHappened;
		}
	}
}
