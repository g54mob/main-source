using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarRangeWarningService : ATutorialService
	{
		private const float TIMEOUT = 1f;

		private float range = 10f;

		private TrainCar car;

		private bool wasInRange = true;

		private float lastWarning = float.MinValue;

		public CarRangeWarningService(float range)
		{
			this.range = range;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			car = PlayerManager.Car;
		}

		public override void StopService(bool fullyCompleted)
		{
		}

		public override void UpdateService()
		{
			if (car != null)
			{
				bool flag = Vector3.Distance(car.transform.position, PlayerManager.PlayerTransform.position) <= range;
				if (!flag && wasInRange && Time.time - 1f > lastWarning)
				{
					lastWarning = Time.time;
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt("tutorial/prompt/range_warning", pause: false, null);
				}
				wasInRange = flag;
			}
		}
	}
}
