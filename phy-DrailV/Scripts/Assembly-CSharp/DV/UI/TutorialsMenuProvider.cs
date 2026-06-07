using DV.Common;
using DV.Tutorial.QT;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class TutorialsMenuProvider : ATutorialsMenuProvider
	{
		public const string LocoDE2 = "LocoDE2";

		public const string LocoDE6 = "LocoDE6";

		public const string LocoDH4 = "LocoDH4";

		public const string LocoDM3 = "LocoDM3";

		public const string LocoS282A = "LocoS282A";

		public const string LocoS060 = "LocoS060";

		public const string LocoMicroshunter = "LocoMicroshunter";

		public const string LocoDM1U = "LocoDM1U";

		public override Data GetData()
		{
			QuickTutorialInitiator instance = SingletonBehaviour<QuickTutorialInitiator>.Instance;
			return new Data
			{
				de2Passed = instance.WasTutorialAlreadyPlayed("LocoDE2"),
				de6Passed = instance.WasTutorialAlreadyPlayed("LocoDE6"),
				dh4Passed = instance.WasTutorialAlreadyPlayed("LocoDH4"),
				dm3Passed = instance.WasTutorialAlreadyPlayed("LocoDM3"),
				s282aPassed = instance.WasTutorialAlreadyPlayed("LocoS282A"),
				s060Passed = instance.WasTutorialAlreadyPlayed("LocoS060"),
				microshunterPassed = instance.WasTutorialAlreadyPlayed("LocoMicroshunter"),
				dm1uPassed = instance.WasTutorialAlreadyPlayed("LocoDM1U"),
				isPlayerOnLocoThatSupportsQuickTutorial = instance.IsPlayerOnLocoThatSupportsQuickTutorial(),
				isQuickTutorialRunning = QuickTutorialHost.IsTutorialRunning
			};
		}

		public override void SetData(Data data)
		{
			Data data2 = GetData();
			QuickTutorialInitiator instance = SingletonBehaviour<QuickTutorialInitiator>.Instance;
			if (data2.de2Passed != data.de2Passed)
			{
				Debug.Log($"DE2 tutorial passed changed from {data2.de2Passed} to {data.de2Passed}");
				instance.UpdateProgressionState("LocoDE2", data.de2Passed);
			}
			if (data2.de6Passed != data.de6Passed)
			{
				Debug.Log($"DE6 tutorial passed changed from {data2.de6Passed} to {data.de6Passed}");
				instance.UpdateProgressionState("LocoDE6", data.de6Passed);
			}
			if (data2.dh4Passed != data.dh4Passed)
			{
				Debug.Log($"DH4 tutorial passed changed from {data2.dh4Passed} to {data.dh4Passed}");
				instance.UpdateProgressionState("LocoDH4", data.dh4Passed);
			}
			if (data2.dm3Passed != data.dm3Passed)
			{
				Debug.Log($"DM3 tutorial passed changed from {data2.dm3Passed} to {data.dm3Passed}");
				instance.UpdateProgressionState("LocoDM3", data.dm3Passed);
			}
			if (data2.s282aPassed != data.s282aPassed)
			{
				Debug.Log($"S282A tutorial passed changed from {data2.s282aPassed} to {data.s282aPassed}");
				instance.UpdateProgressionState("LocoS282A", data.s282aPassed);
			}
			if (data2.s060Passed != data.s060Passed)
			{
				Debug.Log($"S060 tutorial passed changed from {data2.s060Passed} to {data.s060Passed}");
				instance.UpdateProgressionState("LocoS060", data.s060Passed);
			}
			if (data2.microshunterPassed != data.microshunterPassed)
			{
				Debug.Log($"Microshunter tutorial passed changed from {data2.microshunterPassed} to {data.microshunterPassed}");
				instance.UpdateProgressionState("LocoMicroshunter", data.microshunterPassed);
			}
			if (data2.dm1uPassed != data.dm1uPassed)
			{
				Debug.Log($"DM1U tutorial passed changed from {data2.dm1uPassed} to {data.dm1uPassed}");
				instance.UpdateProgressionState("LocoDM1U", data.dm1uPassed);
			}
		}

		public override void AbortCurrentQuickTutorial()
		{
			Debug.Log("Requested abort of current quick tutorial");
			QuickTutorialHost.AbortTutorial();
		}

		public override void RunCouplingTutorial()
		{
			Debug.Log("Requested coupling tutorial");
			QuickTutorialHost.StartTutorial(QuickTutorialFactory.CouplingTutorial(PlayerManager.ActiveCamera.transform, announceCompletion: true, doRangeChecks: true));
		}

		public override void RunLocoTutorial()
		{
			Debug.Log("Requested loco tutorial");
			if (IsMetaTutorialHackActive() && QuickTutorialHost.IsTutorialRunning)
			{
				QuickTutorialHost.AbortTutorial();
			}
			SingletonBehaviour<QuickTutorialInitiator>.Instance.StartNow();
		}

		public override bool IsQuickTutorialUserControlAllowed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.QuickTutorialControl))
			{
				return QuickTutorialHost.TutorialAllowsUserControl;
			}
			return false;
		}

		public override bool IsMetaTutorialHackActive()
		{
			return QuickTutorialHost.MetaTutorialHackActive;
		}

		public override bool IsQuickTutorialRunning()
		{
			return QuickTutorialHost.IsTutorialRunning;
		}
	}
}
