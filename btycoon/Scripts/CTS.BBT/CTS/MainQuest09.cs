using System;
using System.Collections;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest09 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _agencyEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _hiringEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _barEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		protected override IEnumerator QuestIntroduction()
		{
			base.QuestChain.AgencyButtonLocker.Unlock();
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_GoToAgency);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			InterimAgency.OnAgencyEnter -= OnAgencyEnter;
			WorkerHirePanel.Hiring -= OnHiring;
			InterimAgency.OnAgencyQuit -= OnAgencyQuit;
		}

		protected override void StartObservingObjectives()
		{
			InterimAgency.OnAgencyEnter += OnAgencyEnter;
			WorkerHirePanel.Hiring += OnHiring;
			InterimAgency.OnAgencyQuit += OnAgencyQuit;
		}

		protected override void OnResumeQuest()
		{
			base.QuestChain.AgencyButtonLocker.Unlock();
			if (QuestLog.GetQuestEntryState(_questName, _hiringEntry) == QuestState.Success)
			{
				OnAgencyQuit();
			}
			else
			{
				HighlightButton.Highlight(BBTUI.Instance.ButtonID_GoToAgency);
			}
		}

		private void OnAgencyQuit()
		{
			InterimAgency.OnAgencyQuit -= OnAgencyQuit;
			QuestEntrySuccess(_barEntry);
			DialogueHelper.StartConversation(_feedback03);
		}

		private void OnAgencyEnter()
		{
			int currentMoney = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			bool flag = false;
			int num = int.MaxValue;
			foreach (KeyValuePair<Worker, SpawnPoint> spawnedWorker in MonoSingleton<InterimAgency>.Instance.SpawnedWorkers)
			{
				spawnedWorker.Deconstruct(out var key, out var _);
				int workerCost = InterimAgency.GetWorkerCost(key);
				if (currentMoney >= workerCost)
				{
					flag = true;
					break;
				}
				num = Math.Min(num, workerCost);
			}
			if (!flag)
			{
				int num2 = Mathf.CeilToInt((float)(num + 100) / 100f) * 100;
				EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, num2 - currentMoney);
			}
			InterimAgency.OnAgencyEnter -= OnAgencyEnter;
			base.QuestChain.BarButtonLocker.Lock();
			QuestEntrySuccess(_agencyEntry);
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnHiring(Agent agent)
		{
			WorkerHirePanel.Hiring -= OnHiring;
			QuestEntrySuccess(_hiringEntry);
			DialogueHelper.StartConversation(_feedback02);
			base.QuestChain.BarButtonLocker.Unlock();
			base.QuestChain.WorkerManagerLocker.Unlock();
			UnlockingManager.AddUnlockKey(EUnlockKey.BloodStorage);
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.QuestChain.FirstWorker.Dismissable = true;
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.FirstWorker.Dismissable = true;
			base.QuestChain.BarButtonLocker.Unlock();
			base.QuestChain.AgencyButtonLocker.Unlock();
			base.QuestChain.WorkerManagerLocker.Unlock();
			UnlockingManager.AddUnlockKey(EUnlockKey.BloodStorage);
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.BarButtonLocker.Unlock();
			base.QuestChain.AgencyButtonLocker.Unlock();
			base.QuestChain.WorkerManagerLocker.Unlock();
			UnlockingManager.AddUnlockKey(EUnlockKey.BloodStorage);
		}
	}
}
