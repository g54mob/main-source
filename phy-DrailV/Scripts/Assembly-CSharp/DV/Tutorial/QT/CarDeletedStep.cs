using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarDeletedStep : ACommsRadioStep<CommsRadioCarDeleter>
	{
		private CommsRadioCarDeleter deleter;

		private TrainCar targetCar;

		private bool deletionHappened;

		public CarDeletedStep(string message, TrainCar car, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			targetCar = car;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			deletionHappened = false;
			CheckEvents();
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (deleter != null)
			{
				deleter.CarDeleted -= OnCarDeleted;
			}
		}

		private void CheckEvents()
		{
			if (deleter != null)
			{
				deleter.CarDeleted -= OnCarDeleted;
			}
			deleter = GetModeController();
			if (deleter != null)
			{
				deleter.CarDeleted += OnCarDeleted;
			}
		}

		private void OnCarDeleted(TrainCar car)
		{
			if (targetCar == null || targetCar == car)
			{
				deletionHappened = true;
			}
		}

		protected override bool InternalCheck()
		{
			return deletionHappened;
		}
	}
}
