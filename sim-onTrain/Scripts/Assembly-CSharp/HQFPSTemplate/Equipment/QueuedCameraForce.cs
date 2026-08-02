using System;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class QueuedCameraForce
	{
		public DelayedCameraForce DelayedForce { get; private set; }

		public float PlayTime { get; private set; }

		public QueuedCameraForce(DelayedCameraForce force, float playTime)
		{
			DelayedForce = force;
			PlayTime = playTime;
		}
	}
}
