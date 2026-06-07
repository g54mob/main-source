using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest56 : Quest
	{
		private ReaperMarkGoal _reaperMarkGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _reaperMarkEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperMarkTarget;

		[SerializeField]
		private int _reaperMarkTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperMark;

		private KillHunterGoal _killHuntersGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _killHuntersEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _killHuntersTarget;

		[SerializeField]
		private int _killHuntersTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _killHunters;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_reaperMark, _killHunters);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SpawnHunters(_killHuntersTargetValue * 2);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_reaperMarkGoal?.CleanStopObserving();
			_killHuntersGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_reaperMarkTarget, _reaperMarkTargetValue);
			DialogueLua.SetVariable(_killHuntersTarget, _killHuntersTargetValue);
			_reaperMarkGoal = new ReaperMarkGoal(this, _reaperMarkEntry, _reaperMark, _reaperMarkTarget);
			_reaperMarkGoal?.StartObserving();
			_killHuntersGoal = new KillHunterGoal(this, _killHuntersEntry, _killHunters, _killHuntersTarget);
			_killHuntersGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
		}
	}
}
