using UnityEngine;

namespace DV.Tutorial.QT
{
	public class InsideColliderRerailService : ACommsRadioService<RerailController>
	{
		private Collider collider;

		public InsideColliderRerailService(Collider collider)
		{
			this.collider = collider;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			base.StartService(host, phase);
			if ((bool)base.Mode)
			{
				base.Mode.ZoneCollider = collider;
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)base.Mode)
			{
				base.Mode.ZoneCollider = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
