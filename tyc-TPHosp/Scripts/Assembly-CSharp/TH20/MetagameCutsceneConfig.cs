using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class MetagameCutsceneConfig
	{
		public MetagameCutsceneGameIntroDefinition GameIntro;

		public Dictionary<int, MetagameCutsceneHospitalUnlockedDefinition> HospitalUnlockedCutscenes;

		public MetagameCutsceneSandboxUnlockDefinition SandboxUnlockCutscene;

		public MetagameCutsceneCollaborativePortfolioUnlockDefinition CollaborativePortfolioUnlockCutscene;

		public SharedInstance<MetagamePostCutsceneEventDefinition> BigfootCompletePostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> JungleCompletePostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> CloseEncountersCompletePostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> RemixRegion1PostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> OffTheGridPostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> CultureShockPostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> TimeTravelPostCutsceneEvent;

		public SharedInstance<MetagamePostCutsceneEventDefinition> EmergencyPostCutsceneEvent;
	}
}
