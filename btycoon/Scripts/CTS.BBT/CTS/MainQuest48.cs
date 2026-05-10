using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest48 : Quest
	{
		private SpeciesServiceGoal _vampireGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireTarget;

		[SerializeField]
		private int _vampireTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampire;

		[SerializeField]
		private LocalizedString _bark01;

		private SpeciesServiceGoal _humanGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _humanEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanTarget;

		[SerializeField]
		private int _humanTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _human;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark02;

		private BloodBagProductionGoal _bloodBagProductionGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodBagProductionEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodBagProductionTarget;

		[SerializeField]
		private int _bloodBagProductionTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodBagProduction;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vampire, _human, _bloodBagProduction);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<LevelParameters>.Instance.SetOpened(p_value: true);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_vampireGoal?.CleanStopObserving();
			_humanGoal?.CleanStopObserving();
			_bloodBagProductionGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_vampireTarget, _vampireTargetValue);
			DialogueLua.SetVariable(_humanTarget, _humanTargetValue);
			DialogueLua.SetVariable(_bloodBagProductionTarget, _bloodBagProductionTargetValue);
			_vampireGoal = new SpeciesServiceGoal(this, _vampireEntry, _vampire, _vampireTarget, ESpecies.Vampire);
			_vampireGoal?.StartObserving(delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_humanGoal = new SpeciesServiceGoal(this, _humanEntry, _human, _humanTarget, ESpecies.Human);
			_humanGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_bloodBagProductionGoal = new BloodBagProductionGoal(this, _bloodBagProductionEntry, _bloodBagProduction, _bloodBagProductionTarget);
			_bloodBagProductionGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			});
		}
	}
}
