using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest63 : Quest
	{
		private BlueBloodBagProductionGoal _blueBloodBagsGoal;

		[Header("Blue Blood Bags Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _blueBloodBagsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _blueBloodBagsTarget;

		[SerializeField]
		private int _blueBloodBagsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _blueBloodBags;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _blueBloodBagsFeedback;

		[SerializeField]
		private LocalizedString _blueBloodBagsBark;

		private EarlGreyProductionGoal _earlGreyGoal;

		[Header("Earl Grey Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _earlGreyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _earlGreyTarget;

		[SerializeField]
		private int _earlGreyTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _earlGrey;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _earlGreyFeedback;

		[SerializeField]
		private LocalizedString _earlGreyBark;

		private ShakeBloodProductionGoal _shakedBloodGoal;

		[Header("Shaked Blood Goal")]
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
		private string _shakedBloodFeedback;

		[SerializeField]
		private LocalizedString _shakedBloodBark;

		private BloodyWineProductionGoal _bloodyWineGoal;

		[Header("Bloody Wine Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _bloodyWineEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodyWineTarget;

		[SerializeField]
		private int _bloodyWineTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodyWine;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _bloodyWineFeedback;

		[SerializeField]
		private LocalizedString _bloodyWineBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_blueBloodBags, _earlGrey, _shakedBlood, _bloodyWine);
		}

		protected override void StopObservingObjectives()
		{
			_blueBloodBagsGoal?.CleanStopObserving();
			_earlGreyGoal?.CleanStopObserving();
			_shakedBloodGoal?.CleanStopObserving();
			_bloodyWineGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_blueBloodBagsTarget, _blueBloodBagsTargetValue);
			DialogueLua.SetVariable(_earlGreyTarget, _earlGreyTargetValue);
			DialogueLua.SetVariable(_shakedBloodTarget, _shakedBloodTargetValue);
			DialogueLua.SetVariable(_bloodyWineTarget, _bloodyWineTargetValue);
			_blueBloodBagsGoal = new BlueBloodBagProductionGoal(this, _blueBloodBagsEntry, _blueBloodBags, _blueBloodBagsTarget);
			_blueBloodBagsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_blueBloodBagsFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_blueBloodBagsBark);
			});
			_earlGreyGoal = new EarlGreyProductionGoal(this, _earlGreyEntry, _earlGrey, _earlGreyTarget);
			_earlGreyGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_earlGreyFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_earlGreyBark);
			});
			_shakedBloodGoal = new ShakeBloodProductionGoal(this, _shakedBloodEntry, _shakedBlood, _shakedBloodTarget);
			_shakedBloodGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_shakedBloodFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_shakedBloodBark);
			});
			_bloodyWineGoal = new BloodyWineProductionGoal(this, _bloodyWineEntry, _bloodyWine, _bloodyWineTarget);
			_bloodyWineGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_bloodyWineFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_bloodyWineBark);
			});
		}
	}
}
