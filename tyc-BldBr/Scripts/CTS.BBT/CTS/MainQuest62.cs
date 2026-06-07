using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest62 : Quest
	{
		private StyleGoal _darkGoal;

		[Header("Dark Style Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _darkEntry;

		[SerializeField]
		private EBarStyle _darkStyle;

		[SerializeField]
		private float _darkTargetUnitInterval;

		[SerializeField]
		[VariablePopup(false)]
		private string _darkTargetUI;

		[SerializeField]
		[VariablePopup(false)]
		private string _darkTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _dark;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _darkFeedback;

		[SerializeField]
		private LocalizedString _darkBark;

		private RoomTypeGoal _vampireRoomsGoal;

		[Header("Vampire Room Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _vampireRoomsEntry;

		[SerializeField]
		private NavigationArea _vampireNavArea;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRoomsTarget;

		[SerializeField]
		private int _vampireRoomsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRooms;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _vampireRoomsFeedback;

		private SubSpeciesServiceGoal _cryptkinServiceGoal;

		[Header("Cryptkin Service Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _cryptkinServiceEntry;

		[SerializeField]
		private ESubSpecies _cryptkin;

		[SerializeField]
		[VariablePopup(false)]
		private string _cryptkinServiceTarget;

		[SerializeField]
		private int _cryptkinServiceTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _cryptkinService;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _cryptkinServiceFeedback;

		[SerializeField]
		private LocalizedString _cryptkinServiceBark;

		private Coroutine _spawns;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_dark, _vampireRooms, _cryptkinService);
		}

		protected override void StopObservingObjectives()
		{
			if (_spawns != null)
			{
				StopCoroutine(_spawns);
			}
			_darkGoal?.CleanStopObserving();
			_vampireRoomsGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_darkTargetUI, _darkTargetUnitInterval * 100f);
			DialogueLua.SetVariable(_vampireRoomsTarget, _vampireRoomsTargetValue);
			DialogueLua.SetVariable(_cryptkinServiceTarget, _cryptkinServiceTargetValue);
			_darkGoal = new StyleGoal(this, _darkEntry, _dark, _darkTarget, _darkTargetUnitInterval, _darkStyle);
			_darkGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_darkFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_darkBark);
			});
			_vampireRoomsGoal = new RoomTypeGoal(this, _vampireRoomsEntry, _vampireRooms, _vampireRoomsTarget, _vampireNavArea);
			_vampireRoomsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_vampireRoomsFeedback);
			});
			if (_spawns == null)
			{
				_spawns = StartCoroutine(SpawnersHelper.CustomerSpreadOutSpawnsCoroutine(_cryptkin, 0f, 120f, 6));
			}
			_cryptkinServiceGoal = new SubSpeciesServiceGoal(this, _cryptkinServiceEntry, _cryptkinService, _cryptkinServiceTarget, _cryptkin);
			_cryptkinServiceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_cryptkinServiceFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_cryptkinServiceBark);
			}, delegate
			{
				StopAllCoroutines();
			});
		}
	}
}
