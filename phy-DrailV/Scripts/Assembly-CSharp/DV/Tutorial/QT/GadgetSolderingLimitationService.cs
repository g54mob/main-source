using DV.Customization.Gadgets;
using DV.Utils;

namespace DV.Tutorial.QT
{
	public class GadgetSolderingLimitationService : ATutorialService
	{
		private GadgetBase[] gadgets;

		public GadgetSolderingLimitationService(GadgetBase[] gadgets)
		{
			this.gadgets = gadgets;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedSoldering = gadgets;
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)SingletonBehaviour<GadgetSystemUtility>.Instance)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedSoldering = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
