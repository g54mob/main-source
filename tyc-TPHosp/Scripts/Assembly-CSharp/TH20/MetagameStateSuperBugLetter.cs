namespace TH20
{
	public class MetagameStateSuperBugLetter : MetagameState
	{
		private bool _showIntroLetter;

		private bool _showCompletedLetter;

		public MetagameStateSuperBugLetter(MetagameMap map)
			: base(map)
		{
		}

		public override void Enter()
		{
			_showIntroLetter = false;
			_showCompletedLetter = false;
			CollaborativeMetagameData collaborativeMetagameData = Metagame?.CollaborativeMetagameData;
			if (collaborativeMetagameData == null)
			{
				return;
			}
			SuperBugProjectManager superBugProjectManager = Metagame?.SuperBugManager;
			if (superBugProjectManager == null)
			{
				return;
			}
			SuperBugDefinition downloadedProjectDefinition = superBugProjectManager.DownloadedProjectDefinition;
			if (downloadedProjectDefinition == null)
			{
				return;
			}
			SuperBugData data = superBugProjectManager.Data;
			if (data != null)
			{
				if (data.IsCompleted() && !collaborativeMetagameData.HasSeenSuperBugCompletion(downloadedProjectDefinition.SuperBugID))
				{
					_showCompletedLetter = true;
				}
				else if (!collaborativeMetagameData.HasSeenSuperBugIntro(downloadedProjectDefinition.SuperBugID))
				{
					_showIntroLetter = true;
				}
			}
		}

		public override void Resume(State resumingFrom)
		{
			base.Resume(resumingFrom);
			if (resumingFrom is MetagameStateLetterEvent)
			{
				CollaborativeSidebarMenu collaborativeSidebarMenu = MetagameMap.HUD.FindMenu<CollaborativeSidebarMenu>();
				if (collaborativeSidebarMenu != null)
				{
					collaborativeSidebarMenu.PingButton();
				}
			}
		}

		public override void Update()
		{
			if (_showCompletedLetter)
			{
				OpenLetterMenu.Definition definition = new OpenLetterMenu.Definition
				{
					EnvelopePrefab = Metagame.MetagameConfig.SuperBugLetterPrefab,
					BodyText = Metagame.SuperBugManager.DownloadedProjectDefinition.CompletedLetterText,
					SignatureText = new LocalisedString("Collaborative/GUI/Letter_Signature"),
					UseExtraButton = true,
					ExtraButtonText = new LocalisedString("Collaborative/Complete_ViewProject_CS")
				};
				PushState(new MetagameStateLetterEvent(MetagameMap, definition, ShowCollaborativeResearchMenu));
				Metagame.CollaborativeMetagameData.OnSeenSuperBugCompletion(Metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID);
				_showCompletedLetter = false;
			}
			else if (_showIntroLetter)
			{
				OpenLetterMenu.Definition definition2 = new OpenLetterMenu.Definition
				{
					EnvelopePrefab = Metagame.MetagameConfig.SuperBugLetterPrefab,
					BodyText = Metagame.SuperBugManager.DownloadedProjectDefinition.IntroLetterText,
					SignatureText = new LocalisedString("Collaborative/GUI/Letter_Signature"),
					UseExtraButton = true,
					ExtraButtonText = new LocalisedString("Collaborative/Complete_ViewProject_CS")
				};
				PushState(new MetagameStateLetterEvent(MetagameMap, definition2, ShowCollaborativeResearchMenu));
				Metagame.CollaborativeMetagameData.OnSeenSuperBugIntro(Metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID);
				_showIntroLetter = false;
			}
			else
			{
				PopState();
			}
		}

		public override void Exit()
		{
		}

		private void ShowCollaborativeResearchMenu()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				CollaborativeResearchMenu collaborativeResearchMenu = MetagameMap.HUD.FindMenu<CollaborativeResearchMenu>();
				if (collaborativeResearchMenu == null)
				{
					collaborativeResearchMenu = MetagameMap.HUD.CreateMenu<CollaborativeResearchMenu>();
				}
				collaborativeResearchMenu.Initialise(MetagameMap.App);
			}
		}
	}
}
