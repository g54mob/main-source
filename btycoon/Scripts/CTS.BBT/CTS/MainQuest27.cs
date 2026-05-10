using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest27 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		private StyleGoal _styleGoal;

		[SerializeField]
		[Range(0f, 1f)]
		private float _targetStyleUnitInterval = 0.3f;

		[SerializeField]
		[QuestEntryPopup]
		private int _styleEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _styleVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _styleTargetVariableName;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

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
		private CustomerParameters _customerToServe;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark01;

		private SubSpeciesServiceGoal _subSpeciesServiceGoal;

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
			_subSpeciesServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_styleGoal = new StyleGoal(this, _styleEntry, _styleVariableName, _styleTargetVariableName, _targetStyleUnitInterval, EBarStyle.Cyberpunk);
			_roomWallStyleGoal = new RoomWallStyleGoal(this, _wallEntry, EBarStyle.Cyberpunk);
			_roomFloorStyleGoal = new RoomFloorStyleGoal(this, _floorEntry, EBarStyle.Cyberpunk);
			_subSpeciesServiceGoal = new SubSpeciesServiceGoal(this, _serviceEntry, _serviceVariableName, _serviceTargetVariableName, _customerToServe.CharacterData.SubSpecies);
			_styleGoal?.StartObserving(OnStyleGoalAchieved);
			_roomWallStyleGoal?.StartObserving();
			_roomFloorStyleGoal?.StartObserving();
			_subSpeciesServiceGoal?.StartObserving(OnServiceGoalAchieved);
		}

		private void OnStyleGoalAchieved()
		{
			_styleGoal.Achieved -= OnStyleGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnServiceGoalAchieved()
		{
			_subSpeciesServiceGoal.Achieved -= OnServiceGoalAchieved;
			DialogueHelper.StartConversation(_feedback02);
			Barks.BarkAnySpecificTypeCustomer(_customerToServe, _bark01);
		}
	}
}
