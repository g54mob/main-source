using DV.Customization.Gadgets;
using DV.Utils;

namespace DV.Tutorial.QT
{
	public class GadgetWiringLimitationService : ATutorialService
	{
		private GadgetBase[] gadgets;

		public GadgetWiringLimitationService(GadgetBase[] gadgets)
		{
			this.gadgets = gadgets;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedWiring = gadgets;
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)SingletonBehaviour<GadgetSystemUtility>.Instance)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedWiring = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
