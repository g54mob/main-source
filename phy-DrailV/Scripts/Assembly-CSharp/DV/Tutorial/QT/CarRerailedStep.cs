using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarRerailedStep : ACommsRadioStep<RerailController>
	{
		private RerailController rerail;

		private bool rerailHappened;

		public CarRerailedStep(string message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			rerailHappened = false;
			CheckEvents();
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (rerail != null)
			{
				rerail.CarRerailed -= OnCarRerailed;
			}
		}

		private void CheckEvents()
		{
			if (rerail != null)
			{
				rerail.CarRerailed -= OnCarRerailed;
			}
			rerail = GetModeController();
			if (rerail != null)
			{
				rerail.CarRerailed += OnCarRerailed;
			}
		}

		private void OnCarRerailed(TrainCar car)
		{
			rerailHappened = true;
		}

		protected override bool InternalCheck()
		{
			return rerailHappened;
		}
	}
}
