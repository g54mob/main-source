using System;
using DV.Customization.Gadgets;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class GadgetMountingLimitationService : ATutorialService
	{
		private Collider[] colliders;

		private float angleLimit;

		private bool strictMode;

		public GadgetMountingLimitationService(Collider[] colliders, float angleLimit, bool strictMode)
		{
			this.colliders = colliders;
			this.angleLimit = Mathf.Cos(angleLimit * ((float)Math.PI / 180f));
			this.strictMode = strictMode;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedPlacement = colliders;
			SingletonBehaviour<GadgetSystemUtility>.Instance.DotProductLimit = angleLimit;
			SingletonBehaviour<GadgetSystemUtility>.Instance.StrictPlacementMode = strictMode;
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)SingletonBehaviour<GadgetSystemUtility>.Instance)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedPlacement = null;
				SingletonBehaviour<GadgetSystemUtility>.Instance.DotProductLimit = 1f;
				SingletonBehaviour<GadgetSystemUtility>.Instance.StrictPlacementMode = false;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
