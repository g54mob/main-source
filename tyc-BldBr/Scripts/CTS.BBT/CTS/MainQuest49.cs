using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest49 : Quest
	{
		private StyleGoal _styleGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _styleEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _styleTarget;

		[SerializeField]
		private float _styleTargetUnitInterval = 0.25f;

		[SerializeField]
		[VariablePopup(false)]
		private string _style;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private SubSpeciesServiceGoal _cyberfanGoal;

		[SerializeField]
		private CustomerParameters _cyberfanCustomerParameters;

		[SerializeField]
		[QuestEntryPopup]
		private int _cyberfanEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _cyberfanTarget;

		[SerializeField]
		private int _cyberfanTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _cyberfan;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark01;

		private SubSpeciesServiceGoal _loonyGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _loonyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _loonyTarget;

		[SerializeField]
		private int _loonyTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _loony;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_style, _cyberfan, _loony);
		}

		protected override void StopObservingObjectives()
		{
			_styleGoal?.CleanStopObserving();
			_cyberfanGoal?.CleanStopObserving();
			_loonyGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_cyberfanTarget, _cyberfanTargetValue);
			DialogueLua.SetVariable(_loonyTarget, _loonyTargetValue);
			_styleGoal = new StyleGoal(this, _styleEntry, _style, _styleTarget, _styleTargetUnitInterval, EBarStyle.Cyberpunk);
			_styleGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			});
			_cyberfanGoal = new SubSpeciesServiceGoal(this, _cyberfanEntry, _cyberfan, _cyberfanTarget, ESubSpecies.Cyberfan);
			_cyberfanGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_cyberfanCustomerParameters, _bark01);
			});
			_loonyGoal = new SubSpeciesServiceGoal(this, _loonyEntry, _loony, _loonyTarget, ESubSpecies.Loony);
			_loonyGoal?.StartObserving();
		}
	}
}
