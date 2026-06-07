using DV.Customization.Gadgets;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class GadgetUsageLimitationService : ATutorialService
	{
		public delegate string[] GadgetNameListProvider();

		public delegate GameObject[] GadgetInstanceListProvider();

		private readonly GadgetNameListProvider nameProvider;

		private readonly GadgetInstanceListProvider instanceProvider;

		private readonly string[] gadgetPrefabNames;

		private string[] previousLimitations;

		private readonly GameObject[] gadgetInstances;

		private GameObject[] previousInstances;

		public GadgetUsageLimitationService(string[] gadgetPrefabNames)
		{
			this.gadgetPrefabNames = gadgetPrefabNames;
			gadgetInstances = null;
			nameProvider = null;
			instanceProvider = null;
		}

		public GadgetUsageLimitationService(GadgetNameListProvider nameProvider)
		{
			this.nameProvider = nameProvider;
			instanceProvider = null;
			gadgetPrefabNames = null;
			gadgetInstances = null;
		}

		public GadgetUsageLimitationService(GameObject[] gadgetInstances)
		{
			this.gadgetInstances = gadgetInstances;
			this.gadgetInstances = null;
			nameProvider = null;
			instanceProvider = null;
		}

		public GadgetUsageLimitationService(GadgetInstanceListProvider instanceProvider)
		{
			nameProvider = null;
			this.instanceProvider = instanceProvider;
			gadgetPrefabNames = null;
			gadgetInstances = null;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			previousLimitations = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames;
			previousInstances = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances;
			if (nameProvider != null)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = nameProvider();
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = null;
			}
			else if (instanceProvider != null)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = null;
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = instanceProvider();
			}
			else
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = gadgetPrefabNames;
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = gadgetInstances;
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)SingletonBehaviour<GadgetSystemUtility>.Instance)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = previousLimitations;
			}
		}

		public override void UpdateService()
		{
			if (nameProvider != null)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = nameProvider();
			}
			else if (instanceProvider != null)
			{
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = instanceProvider();
			}
		}
	}
}
