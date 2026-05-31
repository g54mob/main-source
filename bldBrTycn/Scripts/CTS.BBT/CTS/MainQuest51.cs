using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest51 : Quest
	{
		private SubSpeciesServiceGoal _countryServiceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _coutryServiceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _coutryServiceTargetVariableName;

		[SerializeField]
		private int _coutryServiceTargetVariableNameValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _coutryServiceVariableName;

		[SerializeField]
		private CustomerParameters _country;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private SubSpeciesServiceGoal _gobblerServiceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _gobblerServiceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _gobblerServiceTargetVariableName;

		[SerializeField]
		private int _gobblerServiceTargetVariableNameValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _gobblerServiceVariableName;

		[SerializeField]
		private CustomerParameters _gobbler;

		[SerializeField]
		private LocalizedString _bark02;

		private ShakeBloodProductionGoal _shakedBloodGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _shakedBloodEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _shakedBloodTarget;

		[SerializeField]
		private int _shakedBloodTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _shakedBlood;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_coutryServiceVariableName, _gobblerServiceVariableName, _shakedBlood);
		}

		protected override void StopObservingObjectives()
		{
			_countryServiceGoal?.CleanStopObserving();
			_gobblerServiceGoal?.CleanStopObserving();
			_shakedBloodGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_coutryServiceTargetVariableName, _coutryServiceTargetVariableNameValue);
			DialogueLua.SetVariable(_gobblerServiceTargetVariableName, _gobblerServiceTargetVariableNameValue);
			DialogueLua.SetVariable(_shakedBloodTarget, _shakedBloodTargetValue);
			_countryServiceGoal = new SubSpeciesServiceGoal(this, _coutryServiceEntry, _coutryServiceVariableName, _coutryServiceTargetVariableName, _country.Type);
			_countryServiceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartConversation(_feedback01);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_country, _bark01);
			});
			_gobblerServiceGoal = new SubSpeciesServiceGoal(this, _gobblerServiceEntry, _gobblerServiceVariableName, _gobblerServiceTargetVariableName, _gobbler.Type);
			_gobblerServiceGoal?.StartObserving(delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_gobbler, _bark02);
			});
			_shakedBloodGoal = new ShakeBloodProductionGoal(this, _shakedBloodEntry, _shakedBlood, _shakedBloodTarget);
			_shakedBloodGoal?.StartObserving(delegate
			{
				DialogueHelper.StartConversation(_feedback02);
			});
		}
	}
}
