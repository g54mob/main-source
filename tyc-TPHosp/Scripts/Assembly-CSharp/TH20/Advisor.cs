using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class Advisor : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ConfigCollection
		{
			public List<AdvisorTriggerDefinition> AdvisorTriggers;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public AdvisorLighting Lighting;

			public int NumTriggersProcessedPerUpdate = 3;

			[InspectorTooltip("List must be the same as PriorityLevels enum. 0=VeryHigh, 1=High, 2=Medium, 3=Low, 4=NeverShow")]
			public List<float> PriorityEvaluationIntervals;

			public List<SharedInstance<ConfigCollection>> AdviceTriggerCollections;
		}

		public enum PriorityLevel
		{
			VeryHigh = 0,
			High = 1,
			Medium = 2,
			Low = 3,
			DontShow = 4,
			Max = 5
		}

		[DontSave]
		private App _app;

		[DontSave]
		private Level _level;

		[DontSave]
		private Config _config;

		[DontSave]
		private AdvisorMenu _advisorMenu;

		[DontSave]
		private HUD _hud;

		private readonly List<AdvisorTrigger> _cooldownTriggersList = new List<AdvisorTrigger>();

		private readonly List<AdvisorTrigger> _readyToFireList = new List<AdvisorTrigger>();

		private readonly List<AdvisorMessageDefinition> _urgentMessageList = new List<AdvisorMessageDefinition>();

		private readonly List<AdvisorTrigger> _activeTriggersList = new List<AdvisorTrigger>();

		private float _timeSinceLastMessage;

		private bool _hasInitialisedCollaborativePortfolioEvent;

		[DontSave]
		private List<AdvisorTrigger> _triggersToRemoveFromReadyToFire;

		[DontSave]
		private IEnumerator<AdvisorTrigger> _activeTriggerListEnumerator;

		[DontSave]
		private uint _lastCollaborativeNotificationShown;

		public Advisor(App app, Level level, Config config, HUD hud)
		{
			_app = app;
			_level = level;
			_config = config;
			_hud = hud;
			foreach (SharedInstance<ConfigCollection> adviceTriggerCollection in _config.AdviceTriggerCollections)
			{
				foreach (AdvisorTriggerDefinition advisorTrigger2 in adviceTriggerCollection.Instance.AdvisorTriggers)
				{
					AdvisorTrigger advisorTrigger = advisorTrigger2.CreateAdvisorTrigger();
					if (!(advisorTrigger is AdvisorTriggerReceptionRequired) || !level.CharacterManager.NeverSpawnPatients)
					{
						_activeTriggersList.Add(advisorTrigger);
					}
				}
			}
			Initialise();
		}

		public void RestoreFromSave(App app, Level level, Config config, HUD hud)
		{
			_app = app;
			_level = level;
			_config = config;
			_hud = hud;
			if (_urgentMessageList.Count >= 20)
			{
				_urgentMessageList.Clear();
			}
			Initialise();
		}

		private void Initialise()
		{
			_advisorMenu = _hud.CreateMenu<AdvisorMenu>();
			_advisorMenu.Setup(_level.MetagameMap);
			AdvisorMenu advisorMenu = _advisorMenu;
			advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Combine(advisorMenu.OnAdvisorMessageFinished, new Action(FinishAdviceTrigger));
			_triggersToRemoveFromReadyToFire = new List<AdvisorTrigger>();
			foreach (AdvisorTrigger activeTriggers in _activeTriggersList)
			{
				activeTriggers.OnRegister(_app, _level, this, _advisorMenu);
			}
			_activeTriggerListEnumerator = _activeTriggersList.GetEnumerator();
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			ResearchManager researchManager = _level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnTrainingCourseFinished = (Action<QualificationDefinition>)Delegate.Combine(characterEvents.OnTrainingCourseFinished, new Action<QualificationDefinition>(OnTrainingCourseFinished));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemInvalid = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemInvalid, new Action<RoomItem>(OnRoomItemInvalid));
			if (_level?.Metagame?.CollaborativePortfolio?.AsyncOperationHandler != null)
			{
				CollaborativeAsyncOperationHandler asyncOperationHandler = _level.Metagame.CollaborativePortfolio.AsyncOperationHandler;
				asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Combine(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnCollaborativeAsyncFinished));
				_hasInitialisedCollaborativePortfolioEvent = true;
			}
			ConsoleCommandsDatabase.RegisterCommand("AdvisorTestMessage", "Creates an advisor message", "AdvisorTestMessage", Debug_AdvisorTestMessage);
			ConsoleCommandsDatabase.RegisterCommand("AdvisorTestMessageInterrupt", "Creates an urgent advisor message, which interrupts current Advisor message", "AdvisorTestMessageInterrupt", Debug_AdvisorTestMessageInterrupt);
			ConsoleCommandsDatabase.RegisterCommand("ToggleAdvisor", "Toggles the advisor on and off", "ToggleAdvisor", Debug_ToggleAdvisor);
			ConsoleCommandsDatabase.RegisterCommand("ClearAllAdvisorTriggers", "Clears all current Advisor triggers", "ClearAllAdvisorTriggers", Debug_ClearAllAdvisorTriggers);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ClearAllAdvisorTriggers");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleAdvisor");
			ConsoleCommandsDatabase.UnRegisterCommand("AdvisorTestMessageInterrupt");
			ConsoleCommandsDatabase.UnRegisterCommand("AdvisorTestMessage");
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			ResearchManager researchManager = _level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnTrainingCourseFinished = (Action<QualificationDefinition>)Delegate.Remove(characterEvents.OnTrainingCourseFinished, new Action<QualificationDefinition>(OnTrainingCourseFinished));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemInvalid = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemInvalid, new Action<RoomItem>(OnRoomItemInvalid));
			if (_hasInitialisedCollaborativePortfolioEvent && _level?.Metagame?.CollaborativePortfolio?.AsyncOperationHandler != null)
			{
				CollaborativeAsyncOperationHandler asyncOperationHandler = _level.Metagame.CollaborativePortfolio.AsyncOperationHandler;
				asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Remove(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnCollaborativeAsyncFinished));
				_hasInitialisedCollaborativePortfolioEvent = false;
			}
			AdvisorMenu advisorMenu = _advisorMenu;
			advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Remove(advisorMenu.OnAdvisorMessageFinished, new Action(FinishAdviceTrigger));
			foreach (AdvisorTrigger activeTriggers in _activeTriggersList)
			{
				activeTriggers.OnUnregister();
			}
			_hud.DestroyMenu<AdvisorMenu>();
			base.Destroy();
		}

		public void Update(float deltaTime)
		{
			if (_level.GameTime.IsSuperPaused || _advisorMenu.IsShowingMessage)
			{
				return;
			}
			int num = 0;
			if (num < _urgentMessageList.Count)
			{
				_advisorMenu.ShowAdvisorMessage(_urgentMessageList[num]);
				_urgentMessageList.Remove(_urgentMessageList[num]);
				return;
			}
			_timeSinceLastMessage += deltaTime;
			_readyToFireList.Sort();
			for (int i = 0; i < _readyToFireList.Count; i++)
			{
				AdvisorTrigger advisorTrigger = _readyToFireList[i];
				if (advisorTrigger != null && _timeSinceLastMessage >= _config.PriorityEvaluationIntervals[(int)advisorTrigger.Priority])
				{
					if (advisorTrigger.AreTriggerConditionsMet())
					{
						FireAdviceTrigger(advisorTrigger);
						break;
					}
					_triggersToRemoveFromReadyToFire.Add(advisorTrigger);
				}
			}
			for (int j = 0; j < _triggersToRemoveFromReadyToFire.Count; j++)
			{
				_readyToFireList.Remove(_triggersToRemoveFromReadyToFire[j]);
			}
			_triggersToRemoveFromReadyToFire.Clear();
			for (int k = 0; k < _config.NumTriggersProcessedPerUpdate; k++)
			{
				if (!_activeTriggerListEnumerator.MoveNext())
				{
					_activeTriggerListEnumerator = _activeTriggersList.GetEnumerator();
				}
				AdvisorTrigger current = _activeTriggerListEnumerator.Current;
				if (current != null && !_cooldownTriggersList.Contains(current))
				{
					if (current.AreTriggerConditionsMet())
					{
						_readyToFireList.AddUnique(current);
					}
					else
					{
						_readyToFireList.Remove(current);
					}
				}
			}
			for (int l = 0; l < _cooldownTriggersList.Count; l++)
			{
				AdvisorTrigger advisorTrigger2 = _cooldownTriggersList[l];
				advisorTrigger2.DecrementCooldownTimer(deltaTime);
				if (advisorTrigger2.CooldownTimeRemaining <= 0f)
				{
					_cooldownTriggersList.Remove(advisorTrigger2);
				}
			}
		}

		private void FireAdviceTrigger(AdvisorTrigger trigger)
		{
			_cooldownTriggersList.Add(trigger);
			_readyToFireList.Remove(trigger);
			trigger.TriggerAdvice();
		}

		public void FinishAdviceTrigger()
		{
			_timeSinceLastMessage = 0f;
		}

		public void PushMessage(AdvisorMessageDefinition definition, bool interrupt, PriorityLevel priority)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(definition.FeatureRequired) && _level != null && _level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.HideAll && (priority <= PriorityLevel.VeryHigh || _level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyVeryHighPriority) && (priority <= PriorityLevel.High || _level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyHighPriorityAndAbove) && (priority <= PriorityLevel.Medium || _level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ExcludeLowPriority))
			{
				PushMessageInternal(definition, interrupt);
			}
		}

		public void PushMessageForce(AdvisorMessageDefinition definition, bool interrupt)
		{
			PushMessageInternal(definition, interrupt);
		}

		private void PushMessageInternal(AdvisorMessageDefinition definition, bool interrupt)
		{
			if (interrupt && _advisorMenu != null && _advisorMenu.IsShowingMessage)
			{
				_advisorMenu.HideAdvisorMessage();
			}
			if (definition.ShowIndefinitely && !definition.UserCanDismiss)
			{
				_urgentMessageList.Clear();
			}
			_urgentMessageList.Add(definition);
		}

		public void HideMessage()
		{
			_advisorMenu.HideAdvisorMessage();
		}

		public void AddTriggerCollection(ConfigCollection collection)
		{
			if (collection == null)
			{
				return;
			}
			foreach (AdvisorTriggerDefinition advisorTrigger2 in collection.AdvisorTriggers)
			{
				AdvisorTrigger advisorTrigger = advisorTrigger2.CreateAdvisorTrigger();
				if (!(advisorTrigger is AdvisorTriggerReceptionRequired) || !_level.CharacterManager.NeverSpawnPatients)
				{
					advisorTrigger.OnRegister(_app, _level, this, _advisorMenu);
					_activeTriggersList.Add(advisorTrigger);
				}
			}
			_activeTriggerListEnumerator = _activeTriggersList.GetEnumerator();
		}

		public void ClearAllTriggers()
		{
			foreach (AdvisorTrigger activeTriggers in _activeTriggersList)
			{
				activeTriggers.OnUnregister();
			}
			_activeTriggersList.Clear();
			_activeTriggerListEnumerator = _activeTriggersList.GetEnumerator();
			_readyToFireList.Clear();
			_cooldownTriggersList.Clear();
		}

		private ConsoleCommandResult Debug_AdvisorTestMessage(params string[] args)
		{
			PushMessageForce(new AdvisorMessageDefinition
			{
				Message = "This is a test message!",
				Duration = 60f,
				ShowIndefinitely = false,
				UserCanDismiss = true,
				OverrideAnimationGraph = null,
				DisplayType = AdvisorDisplayType.Information
			}, interrupt: false);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_AdvisorTestMessageInterrupt(params string[] args)
		{
			PushMessageForce(new AdvisorMessageDefinition
			{
				Message = "This is a test message!",
				Duration = 60f,
				ShowIndefinitely = false,
				UserCanDismiss = true,
				OverrideAnimationGraph = null,
				DisplayType = AdvisorDisplayType.Information
			}, interrupt: true);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ToggleAdvisor(params string[] args)
		{
			if (_advisorMenu == null)
			{
				return ConsoleCommandResult.Failed("No advisor menu found!");
			}
			_advisorMenu.IsAdvisorActivated = !_advisorMenu.IsAdvisorActivated;
			return ConsoleCommandResult.Succeeded(string.Format("Advisor is {0}!", _advisorMenu.IsAdvisorActivated ? "Active" : "Disabled"));
		}

		private ConsoleCommandResult Debug_ClearAllAdvisorTriggers(string[] args)
		{
			int count = _activeTriggersList.Count;
			ClearAllTriggers();
			return ConsoleCommandResult.Succeeded($"{count} Advisor Triggers Cleared!");
		}

		public void ShowUnlockedMessage(ISilverUnlockable item)
		{
			LocalisedString unlockMessage = item.GetUnlockMessage();
			string text = ((unlockMessage.Term != null) ? unlockMessage.Translation : ScriptLocalization.Advisor.Item_Unlocked_CS);
			text = text.Replace("{[UNLOCK]}", item.GetUnlockName().Translation);
			PushMessage(new AdvisorMessageDefinition
			{
				Message = text,
				Duration = 10f,
				Icon = item.GetUnlockIcon(),
				UserCanDismiss = true
			}, interrupt: false, PriorityLevel.High);
		}

		private void OnCampaignEnded(MarketingCampaignComponent campaign, bool cancelled)
		{
			if (!cancelled)
			{
				MarketingCampaignDefinition activeCampaign = campaign.ActiveCampaign;
				string message = LocalisedString.Replace(ScriptLocalization.Advisor.MarketingCampaignComplete_CS, "{[CAMPAIGN]}", activeCampaign.NameLocalised.Translation);
				PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					Icon = activeCampaign.Icon,
					CameraFocus = campaign.Item.WorldPosition,
					UserCanDismiss = true
				}, interrupt: false, PriorityLevel.Medium);
			}
		}

		private void OnResearchProjectComplete(ResearchProject researchProject)
		{
			ResearchProjectDefinition definition = researchProject.Definition;
			string message = LocalisedString.Replace(ScriptLocalization.Advisor.ResearchProjectComplete_CS, new SubPair[2]
			{
				new SubPair("{[PROJECT]}", definition.NameLocalised.Translation),
				new SubPair("{[REWARDS]}", RewardUtils.GetFullRewardString(null, definition.Rewards, ", "))
			});
			PushMessage(new AdvisorMessageDefinition
			{
				Message = message,
				Duration = 10f,
				Icon = definition.Icon,
				UserCanDismiss = true
			}, interrupt: false, PriorityLevel.Medium);
		}

		private void OnTrainingCourseFinished(QualificationDefinition qualification)
		{
			string message = LocalisedString.Replace(ScriptLocalization.Advisor.TrainingCourseComplete_CS, "{[QUALIFICATION]}", qualification.NameLocalised.Translation);
			PushMessage(new AdvisorMessageDefinition
			{
				Message = message,
				Duration = 10f,
				Icon = qualification.Icon,
				UserCanDismiss = true
			}, interrupt: false, PriorityLevel.Medium);
		}

		private void OnRoomItemInvalid(RoomItem roomItem)
		{
			if (roomItem == null)
			{
				return;
			}
			StatusIconInvalidItem statusIconInvalidItem = _level.StatusIconManager.GetActiveStatusIcon(roomItem) as StatusIconInvalidItem;
			if (!(statusIconInvalidItem != null) || statusIconInvalidItem.IconType != StatusIcon.Type.InvalidItem || !statusIconInvalidItem.MessageSent)
			{
				return;
			}
			foreach (AdvisorMessageDefinition urgentMessage in _urgentMessageList)
			{
				if (urgentMessage.Icon == statusIconInvalidItem.Icon)
				{
					return;
				}
			}
			string message = ScriptLocalization.Items.Invalid_CS.Replace("{[ITEM]}", roomItem.LocalisedName);
			PushMessage(new AdvisorMessageDefinition
			{
				Message = message,
				Duration = 10f,
				Icon = statusIconInvalidItem.Icon,
				CameraFocus = roomItem.WorldPosition,
				UserCanDismiss = true
			}, interrupt: false, PriorityLevel.VeryHigh);
		}

		private void OnCollaborativeAsyncFinished(CollaborativeAsyncOperation asyncOperation)
		{
			if (!(asyncOperation is CollaborativeAsyncOperationGatherData) || !(_app.GameMode is GameModeCareer) || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			CollaborativePortfolio collaborativePortfolio = _app.CollaborativePortfolio;
			CollaborativeMetagameData collaborativeMetagameData = _app.Metagame.CollaborativeMetagameData;
			List<CollaborativeProject> list = new List<CollaborativeProject>();
			for (int i = 0; i < collaborativePortfolio.ActiveProjectSlots.Count; i++)
			{
				CollaborativeProject collaborativeProject = collaborativePortfolio.ActiveProjectSlots[i];
				if (collaborativeProject != null)
				{
					uint lastViewTimestamp = collaborativeMetagameData.GetLastViewTimestamp(collaborativeProject.ProjectID);
					uint lastUpdateTime = collaborativeProject.LastUpdateTime;
					if (lastUpdateTime > lastViewTimestamp && lastUpdateTime > _lastCollaborativeNotificationShown)
					{
						list.Add(collaborativeProject);
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			_lastCollaborativeNotificationShown = OnlineManager.GetServerTime();
			string message = null;
			Sprite icon = null;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].IsProjectCompleted())
				{
					message = string.Format(LocalizationManager.GetTranslation("Collaborative/Advisor_ProjectCompleted"), list[j].LocalPlayerData.Definition.Name);
					icon = _app.CollaborativeProjectList.SuperBugIcon;
					PushMessage(new AdvisorMessageDefinition
					{
						Message = message,
						Duration = 10f,
						Icon = icon,
						StartCollaborativeMenuOnClick = true,
						UserCanDismiss = true
					}, interrupt: false, PriorityLevel.High);
					return;
				}
			}
			if (list.Count == 1)
			{
				message = string.Format(ScriptLocalization.Collaborative_HUD.AdvisorMessage_ProjectUpdate1_CS, list[0].LocalPlayerData.Definition.Name.Translation);
				icon = _app.CollaborativeProjectList.SuperBugIcon;
			}
			else if (list.Count == 2)
			{
				message = string.Format(ScriptLocalization.Collaborative_HUD.AdvisorMessage_ProjectUpdate2_CS, list[0].LocalPlayerData.Definition.Name.Translation, list[1].LocalPlayerData.Definition.Name.Translation);
				icon = _app.CollaborativeProjectList.SuperBugIcon;
			}
			else if (list.Count == 3)
			{
				message = string.Format(ScriptLocalization.Collaborative_HUD.AdvisorMessage_ProjectUpdate3_CS, list[0].LocalPlayerData.Definition.Name.Translation, list[1].LocalPlayerData.Definition.Name.Translation, list[2].LocalPlayerData.Definition.Name.Translation);
				icon = _app.CollaborativeProjectList.SuperBugIcon;
			}
			PushMessage(new AdvisorMessageDefinition
			{
				Message = message,
				Duration = 10f,
				Icon = icon,
				StartCollaborativeMenuOnClick = true,
				UserCanDismiss = true
			}, interrupt: false, PriorityLevel.High);
		}
	}
}
