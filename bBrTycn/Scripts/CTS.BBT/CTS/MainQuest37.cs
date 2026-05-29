using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest37 : Quest
	{
		private NoInvestigatorsGoal _investigatorGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _investigatorEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _investigatorTarget;

		[SerializeField]
		private int _investigatorTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _investigator;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private DipCorpsesGoal _dipGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _dipEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _dipTarget;

		[SerializeField]
		private int _dipTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _dip;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_investigator, _dip);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SpawnInvestigators(3, forceEnterBar: true);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_investigatorGoal?.CleanStopObserving();
			_dipGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_investigatorGoal = new NoInvestigatorsGoal(this, _investigatorEntry, _investigator, _investigatorTarget);
			_investigatorGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyHumanCustomer(_bark01);
			});
			_dipGoal = new DipCorpsesGoal(this, _dipEntry, _dip, _dipTarget);
			_dipGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
