using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class LevelEventsIntermediary : MustCallDestroy, IGameEventsBase
	{
		public Action<int> OnMoneyEarned;

		public Action<int> OnBalanceUpdated;

		public Action<float> OnReputationChanged;

		public Action<PrestigeTracker> OnPrestigeChanged;

		public Action<ResearchProject> OnResearchProjectComplete;

		public Action<ResearchProject> OnSandboxResearchProjectComplete;

		public Action<float, ResearchProject> OnResearchPointsAdded;

		public Action<MarketingCampaignComponent> OnCampaignStarted;

		public Action<MonoBeast, int> OnMonoBeastShot;

		public Action<RoomItem, Staff> OnRoomItemUpgradeComplete;

		public Action<Patient, List<Staff>> OnPatientCured;

		public Action<Patient, List<Staff>> OnFatalTreatment;

		public Action<Patient, List<Staff>> OnIneffectiveTreatment;

		public Action<Patient> OnPatientDied;

		public Action<Patient> OnPatientRageQuit;

		public Action<Patient> OnPatientSentHome;

		public Action<Patient> OnAlienExposed;

		public Action<Patient> OnPatientTimeTunnel;

		public Action<Staff> OnStaffPromoted;

		public Action<Staff, QualificationDefinition, Staff> OnStaffQualificationComplete;

		public Action<Staff, Job, bool> OnStaffCompletedJob;

		public Action<int, int, int> OnTimelineUpdated;

		public Action<LevelStatsDatabase.MonthStats> OnEndOfMonthStatsCompiled;

		private App _app;

		private Level _level;

		public LevelEventsIntermediary(App app)
		{
			_app = app;
			App app2 = _app;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			App app3 = _app;
			app3.OnLevelAboutToBeUnloaded = (Action<Level>)Delegate.Combine(app3.OnLevelAboutToBeUnloaded, new Action<Level>(OnLevelAboutToBeUnload));
		}

		public void RestoreFromSave(App app)
		{
			_app = app;
			App app2 = _app;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			App app3 = _app;
			app3.OnLevelAboutToBeUnloaded = (Action<Level>)Delegate.Combine(app3.OnLevelAboutToBeUnloaded, new Action<Level>(OnLevelAboutToBeUnload));
		}

		public override void Destroy()
		{
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			App app2 = _app;
			app2.OnLevelAboutToBeUnloaded = (Action<Level>)Delegate.Remove(app2.OnLevelAboutToBeUnloaded, new Action<Level>(OnLevelAboutToBeUnload));
			if (_level != null)
			{
				OnLevelAboutToBeUnload(_level);
			}
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnMoneyEarned.VerifyIsNull();
			OnBalanceUpdated.VerifyIsNull();
			OnReputationChanged.VerifyIsNull();
			OnPrestigeChanged.VerifyIsNull();
			OnResearchProjectComplete.VerifyIsNull();
			OnResearchPointsAdded.VerifyIsNull();
			OnCampaignStarted.VerifyIsNull();
			OnMonoBeastShot.VerifyIsNull();
			OnRoomItemUpgradeComplete.VerifyIsNull();
			OnPatientCured.VerifyIsNull();
			OnFatalTreatment.VerifyIsNull();
			OnIneffectiveTreatment.VerifyIsNull();
			OnPatientDied.VerifyIsNull();
			OnPatientRageQuit.VerifyIsNull();
			OnPatientSentHome.VerifyIsNull();
			OnPatientTimeTunnel.VerifyIsNull();
			OnTimelineUpdated.VerifyIsNull();
			OnStaffPromoted.VerifyIsNull();
			OnEndOfMonthStatsCompiled.VerifyIsNull();
			OnStaffQualificationComplete.VerifyIsNull();
			OnStaffCompletedJob.VerifyIsNull();
			OnAlienExposed.VerifyIsNull();
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			if (!(_app.GameMode is GameModeSandbox))
			{
				FinanceManager financeManager = level.FinanceManager;
				financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Combine(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarnedInner));
				FinanceManager financeManager2 = level.FinanceManager;
				financeManager2.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager2.OnBalanceUpdated, new Action<int>(OnBalanceUpdatedInner));
				ReputationTracker reputationTracker = level.ReputationTracker;
				reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedInner));
				PrestigeTracker prestigeTracker = level.PrestigeTracker;
				prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Combine(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedInner));
				MarketingManager marketingManager = level.MarketingManager;
				marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStartedInner));
				ResearchManager researchManager = level.ResearchManager;
				researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectCompleteInner));
				ResearchManager researchManager2 = level.ResearchManager;
				researchManager2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAddedInner));
				MonoBeastManager monoBeastManager = level.MonoBeastManager;
				monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShotInner));
				BuildEvents buildEvents = level.BuildEvents;
				buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeCompleteInner));
				CharacterEvents characterEvents = level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCuredInner));
				CharacterEvents characterEvents2 = level.CharacterEvents;
				characterEvents2.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatmentInner));
				CharacterEvents characterEvents3 = level.CharacterEvents;
				characterEvents3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatmentInner));
				CharacterEvents characterEvents4 = level.CharacterEvents;
				characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDiedInner));
				CharacterEvents characterEvents5 = level.CharacterEvents;
				characterEvents5.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuitInner));
				CharacterEvents characterEvents6 = level.CharacterEvents;
				characterEvents6.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents6.OnPatientSentHome, new Action<Patient>(OnPatientSentHomeInner));
				CharacterEvents characterEvents7 = level.CharacterEvents;
				characterEvents7.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents7.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnelInner));
				CharacterEvents characterEvents8 = level.CharacterEvents;
				characterEvents8.OnAlienExposed = (Action<Patient>)Delegate.Combine(characterEvents8.OnAlienExposed, new Action<Patient>(OnAlienExposedInner));
				CharacterEvents characterEvents9 = level.CharacterEvents;
				characterEvents9.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents9.OnStaffPromoted, new Action<Staff>(OnStaffPromoteInner));
				CharacterEvents characterEvents10 = level.CharacterEvents;
				characterEvents10.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents10.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationCompleteInner));
				CharacterEvents characterEvents11 = level.CharacterEvents;
				characterEvents11.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents11.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJobInner));
				level.AddTimelineUpdateListener(OnTimelineUpdatedInner);
				LevelStatsDatabase levelStatsDatabase = level.LevelStatsDatabase;
				levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiledInner));
				_level = level;
			}
		}

		private void OnLevelAboutToBeUnload(Level level)
		{
			if (!(_app.GameMode is GameModeSandbox))
			{
				FinanceManager financeManager = level.FinanceManager;
				financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Remove(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarnedInner));
				FinanceManager financeManager2 = level.FinanceManager;
				financeManager2.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager2.OnBalanceUpdated, new Action<int>(OnBalanceUpdatedInner));
				ReputationTracker reputationTracker = level.ReputationTracker;
				reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Remove(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedInner));
				PrestigeTracker prestigeTracker = level.PrestigeTracker;
				prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Remove(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedInner));
				MarketingManager marketingManager = level.MarketingManager;
				marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStartedInner));
				ResearchManager researchManager = level.ResearchManager;
				researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectCompleteInner));
				ResearchManager researchManager2 = level.ResearchManager;
				researchManager2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(researchManager2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAddedInner));
				MonoBeastManager monoBeastManager = level.MonoBeastManager;
				monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Remove(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShotInner));
				BuildEvents buildEvents = level.BuildEvents;
				buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeCompleteInner));
				CharacterEvents characterEvents = level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCuredInner));
				CharacterEvents characterEvents2 = level.CharacterEvents;
				characterEvents2.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatmentInner));
				CharacterEvents characterEvents3 = level.CharacterEvents;
				characterEvents3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatmentInner));
				CharacterEvents characterEvents4 = level.CharacterEvents;
				characterEvents4.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents4.OnPatientDied, new Action<Patient>(OnPatientDiedInner));
				CharacterEvents characterEvents5 = level.CharacterEvents;
				characterEvents5.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents5.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuitInner));
				CharacterEvents characterEvents6 = level.CharacterEvents;
				characterEvents6.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents6.OnPatientSentHome, new Action<Patient>(OnPatientSentHomeInner));
				CharacterEvents characterEvents7 = level.CharacterEvents;
				characterEvents7.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents7.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnelInner));
				CharacterEvents characterEvents8 = level.CharacterEvents;
				characterEvents8.OnAlienExposed = (Action<Patient>)Delegate.Remove(characterEvents8.OnAlienExposed, new Action<Patient>(OnAlienExposedInner));
				CharacterEvents characterEvents9 = level.CharacterEvents;
				characterEvents9.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents9.OnStaffPromoted, new Action<Staff>(OnStaffPromoteInner));
				CharacterEvents characterEvents10 = level.CharacterEvents;
				characterEvents10.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents10.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationCompleteInner));
				CharacterEvents characterEvents11 = level.CharacterEvents;
				characterEvents11.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents11.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJobInner));
				level.RemoveTimelineUpdateListener(OnTimelineUpdatedInner);
				LevelStatsDatabase levelStatsDatabase = level.LevelStatsDatabase;
				levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiledInner));
				_level = null;
			}
		}

		private void OnAlienExposedInner(Patient alienPatient)
		{
			OnAlienExposed.InvokeSafe(alienPatient);
		}

		private void OnStaffPromoteInner(Staff staff)
		{
			OnStaffPromoted.InvokeSafe(staff);
		}

		private void OnMoneyEarnedInner(int earned, Vector3? inWorldPosition)
		{
			OnMoneyEarned.InvokeSafe(earned);
		}

		private void OnBalanceUpdatedInner(int balance)
		{
			OnBalanceUpdated.InvokeSafe(balance);
		}

		private void OnPatientCuredInner(Patient patient, List<Staff> involvedStaff)
		{
			OnPatientCured.InvokeSafe(patient, involvedStaff);
		}

		private void OnFatalTreatmentInner(Patient patient, List<Staff> involvedStaff)
		{
			OnFatalTreatment.InvokeSafe(patient, involvedStaff);
		}

		private void OnIneffectiveTreatmentInner(Patient patient, List<Staff> involvedStaff)
		{
			OnIneffectiveTreatment.InvokeSafe(patient, involvedStaff);
		}

		private void OnPatientDiedInner(Patient patient)
		{
			OnPatientDied.InvokeSafe(patient);
		}

		private void OnPatientRageQuitInner(Patient patient)
		{
			OnPatientRageQuit.InvokeSafe(patient);
		}

		private void OnPatientSentHomeInner(Patient patient)
		{
			OnPatientSentHome.InvokeSafe(patient);
		}

		private void OnPatientTimeTunnelInner(Patient patient)
		{
			OnPatientTimeTunnel.InvokeSafe(patient);
		}

		private void OnTimelineUpdatedInner(int day, int month, int year)
		{
			OnTimelineUpdated.InvokeSafe(day, month, year);
		}

		private void OnPrestigeChangedInner(PrestigeTracker prestigeTracker)
		{
			OnPrestigeChanged.InvokeSafe(prestigeTracker);
		}

		private void OnResearchProjectCompleteInner(ResearchProject researchProject)
		{
			OnResearchProjectComplete.InvokeSafe(researchProject);
		}

		private void OnSandboxResearchProjectCompleteInner(ResearchProject researchProject)
		{
			OnSandboxResearchProjectComplete.InvokeSafe(researchProject);
		}

		private void OnResearchPointsAddedInner(float points, ResearchProject project)
		{
			OnResearchPointsAdded.InvokeSafe(points, project);
		}

		private void OnMonoBeastShotInner(MonoBeast beast, int killstreak)
		{
			OnMonoBeastShot.InvokeSafe(beast, killstreak);
		}

		private void OnRoomItemUpgradeCompleteInner(RoomItem item, Staff staff)
		{
			OnRoomItemUpgradeComplete.InvokeSafe(item, staff);
		}

		private void OnReputationChangedInner(float reputation)
		{
			OnReputationChanged.InvokeSafe(reputation);
		}

		private void OnEndOfMonthStatsCompiledInner(LevelStatsDatabase.MonthStats monthStats)
		{
			OnEndOfMonthStatsCompiled.InvokeSafe(monthStats);
		}

		private void OnStaffQualificationCompleteInner(Staff staff, QualificationDefinition qualificationDefinition, Staff trainer)
		{
			OnStaffQualificationComplete.InvokeSafe(staff, qualificationDefinition, trainer);
		}

		private void OnStaffCompletedJobInner(Staff staff, Job job, bool success)
		{
			OnStaffCompletedJob.InvokeSafe(staff, job, success);
		}

		private void OnCampaignStartedInner(MarketingCampaignComponent campaign)
		{
			OnCampaignStarted.InvokeSafe(campaign);
		}
	}
}
