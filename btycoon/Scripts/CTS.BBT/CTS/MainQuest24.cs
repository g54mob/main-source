using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest24 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		[SerializeField]
		[QuestEntryPopup]
		private int _iceEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private BuySpecificFurnitureInteractorGoal<BloodyIceCrusher> _iceGoal;

		private BuySpecificFurnitureInteractorGoal<TheDip> _dipGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _dipEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		[QuestEntryPopup]
		private int _humanServicesEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanTargetVariableName;

		[SerializeField]
		private LocalizedString _bark01;

		private SpeciesServiceGoal _humanServicesGoal;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_humanVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			return DialogueHelper.DialogueCoroutine(_dialogue01, _reward01);
		}

		protected override void StopObservingObjectives()
		{
			_iceGoal?.CleanStopObserving();
			_dipGoal?.CleanStopObserving();
			_humanServicesGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_iceGoal = new BuySpecificFurnitureInteractorGoal<BloodyIceCrusher>(this, _iceEntry);
			_dipGoal = new BuySpecificFurnitureInteractorGoal<TheDip>(this, _dipEntry);
			_humanServicesGoal = new SpeciesServiceGoal(this, _humanServicesEntry, _humanVariableName, _humanTargetVariableName, ESpecies.Human);
			_iceGoal?.StartObserving(OnIceGoalAchieved);
			_dipGoal?.StartObserving(OnDipGoalAchieved);
			_humanServicesGoal?.StartObserving(OnHumanServicesGoalAchieved);
		}

		private void OnIceGoalAchieved()
		{
			_iceGoal.Achieved -= OnIceGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnDipGoalAchieved()
		{
			_dipGoal.Achieved -= OnDipGoalAchieved;
			DialogueHelper.StartConversation(_feedback02);
		}

		private void OnHumanServicesGoalAchieved()
		{
			_humanServicesGoal.Achieved -= OnHumanServicesGoalAchieved;
			Barks.BarkAnyHumanCustomer(_bark01);
		}
	}
}
