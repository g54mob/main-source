using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest29 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		[SerializeField]
		[QuestEntryPopup]
		private int _styleEntry;

		[SerializeField]
		[Range(0f, 1f)]
		private float _targetStyleUnitInterval = 0.3f;

		[SerializeField]
		[VariablePopup(false)]
		private string _styleVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _styleTargetVariableName;

		[SerializeField]
		private int _styleTargetVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private StyleGoal _styleGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _wallEntry;

		private RoomWallStyleGoal _roomWallStyleGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _floorEntry;

		private RoomFloorStyleGoal _roomFloorStyleGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _serviceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _serviceVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _serviceTargetVariableName;

		[SerializeField]
		private int _serviceTargetVariableNameValue;

		[SerializeField]
		private CustomerParameters _customerToServe;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark01;

		private SpeciesServiceGoal _speciesServiceGoal;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_styleVariableName);
			ResetVariableTo0(_serviceVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			return DialogueHelper.DialogueCoroutine(_dialogue01, _reward01);
		}

		protected override void StopObservingObjectives()
		{
			_styleGoal?.CleanStopObserving();
			_roomWallStyleGoal?.CleanStopObserving();
			_roomFloorStyleGoal?.CleanStopObserving();
			_speciesServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_styleTargetVariableName, _styleTargetVariableNameValue);
			DialogueLua.SetVariable(_serviceTargetVariableName, _serviceTargetVariableNameValue);
			_styleGoal = new StyleGoal(this, _styleEntry, _styleVariableName, _styleTargetVariableName, _targetStyleUnitInterval, EBarStyle.Industrial);
			_roomWallStyleGoal = new RoomWallStyleGoal(this, _wallEntry, EBarStyle.Industrial);
			_roomFloorStyleGoal = new RoomFloorStyleGoal(this, _floorEntry, EBarStyle.Industrial);
			_speciesServiceGoal = new SpeciesServiceGoal(this, _serviceEntry, _serviceVariableName, _serviceTargetVariableName, ESpecies.Vampire);
			_styleGoal?.StartObserving(OnStyleGoalAchieved);
			_roomWallStyleGoal?.StartObserving();
			_roomFloorStyleGoal?.StartObserving();
			_speciesServiceGoal?.StartObserving(OnServiceGoalAchieved);
		}

		private void OnStyleGoalAchieved()
		{
			_styleGoal.Achieved -= OnStyleGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnServiceGoalAchieved()
		{
			_speciesServiceGoal.Achieved -= OnServiceGoalAchieved;
			DialogueHelper.StartConversation(_feedback02);
			Barks.BarkAnySpecificTypeCustomer(_customerToServe, _bark01);
		}
	}
}
