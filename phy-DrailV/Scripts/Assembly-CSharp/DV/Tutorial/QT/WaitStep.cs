using UnityEngine;

namespace DV.Tutorial.QT
{
	public class WaitStep : AQuickTutorialStep
	{
		private float startTime;

		private float seconds;

		private bool realTime;

		public WaitStep(float seconds, bool realTime = false)
			: base("", null, default(Vector3), shouldRecheck: false)
		{
			this.seconds = seconds;
			this.realTime = realTime;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			startTime = (realTime ? Time.realtimeSinceStartup : Time.time);
		}

		protected override bool InternalCheck()
		{
			return startTime + seconds < (realTime ? Time.realtimeSinceStartup : Time.time);
		}
	}
}
