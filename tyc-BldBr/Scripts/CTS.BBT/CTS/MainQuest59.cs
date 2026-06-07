using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest59 : Quest
	{
		private HireGoal _hireGoal;

		[Header("Hire Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _hireEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _hireTarget;

		[SerializeField]
		private int _hireTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _hire;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _hireFeedback;

		[SerializeField]
		private LocalizedString _hireBark;

		private StyleGoal _pirateGoal;

		[Header("Pirate Style Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _pirateEntry;

		[SerializeField]
		private EBarStyle _pirateStyle;

		[SerializeField]
		[Range(0f, 1f)]
		private float _pirateTargetUnitInterval;

		[SerializeField]
		[VariablePopup(false)]
		private string _pirateTargetUI;

		[SerializeField]
		[VariablePopup(false)]
		private string _pirateTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _pirate;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _pirateFeedback;

		[SerializeField]
		private LocalizedString _pirateBark;

		private StyleGoal _tikiGoal;

		[Header("Tiki Style Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _tikiEntry;

		[SerializeField]
		private EBarStyle _tikiStyle;

		[SerializeField]
		[Range(0f, 1f)]
		private float _tikiTargetUnitInterval;

		[SerializeField]
		[VariablePopup(false)]
		private string _tikiTargetUI;

		[SerializeField]
		[VariablePopup(false)]
		private string _tikiTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _tiki;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _tikiFeedback;

		[SerializeField]
		private LocalizedString _tikiBark;

		private TurnoverGoal _turnoverGoal;

		[Header("Turnover Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _turnoverEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _turnoverTarget;

		[SerializeField]
		private int _turnoverTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _turnover;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _turnoverFeedback;

		[SerializeField]
		private LocalizedString _turnoverBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_hire, _pirate, _tiki, _turnover);
		}

		protected override void StopObservingObjectives()
		{
			_hireGoal?.CleanStopObserving();
			_pirateGoal?.CleanStopObserving();
			_tikiGoal?.CleanStopObserving();
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_hireTarget, _hireTargetValue);
			DialogueLua.SetVariable(_turnoverTarget, _turnoverTargetValue);
			DialogueLua.SetVariable(_pirateTargetUI, _pirateTargetUnitInterval * 100f);
			DialogueLua.SetVariable(_tikiTargetUI, _tikiTargetUnitInterval * 100f);
			_hireGoal = new HireGoal(this, _hireEntry, _hire, _hireTarget);
			_hireGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_hireFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_hireBark);
			});
			_pirateGoal = new StyleGoal(this, _pirateEntry, _pirate, _pirateTarget, _pirateTargetUnitInterval, _pirateStyle);
			_pirateGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_pirateFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_pirateBark);
			});
			_tikiGoal = new StyleGoal(this, _tikiEntry, _tiki, _tikiTarget, _tikiTargetUnitInterval, _tikiStyle);
			_tikiGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_tikiFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_tikiBark);
			});
			_turnoverGoal = new TurnoverGoal(this, _turnoverEntry, _turnover, _turnoverTarget);
			_turnoverGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_turnoverFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_turnoverBark);
			});
		}
	}
}
