using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest33 : Quest
	{
		private OpenBarGoal _openBarGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _openBarEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

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

		private SpeciesServiceGoal _vampireServiceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireServiceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireServicesTarget;

		[SerializeField]
		private int _vampireServicesTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireServices;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodBagProduction, _vampireServices);
		}

		protected override void StopObservingObjectives()
		{
			_openBarGoal?.CleanStopObserving();
			_bloodBagProductionGoal?.CleanStopObserving();
			_vampireServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_bloodBagProductionTarget, _bloodBagProductionTargetValue);
			DialogueLua.SetVariable(_vampireServicesTarget, _vampireServicesTargetValue);
			_openBarGoal = new OpenBarGoal(this, _openBarEntry);
			_openBarGoal?.StartObserving(delegate
			{
				DialogueHelper.StartConversation(_feedback01);
			});
			_bloodBagProductionGoal = new BloodBagProductionGoal(this, _bloodBagProductionEntry, _bloodBagProduction, _bloodBagProductionTarget);
			_bloodBagProductionGoal?.StartObserving(delegate
			{
				DialogueHelper.StartConversation(_feedback02);
			});
			_vampireServiceGoal = new SpeciesServiceGoal(this, _vampireServiceEntry, _vampireServices, _vampireServicesTarget, ESpecies.Vampire);
			_vampireServiceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartConversation(_feedback03);
			});
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.WesternBarPackage);
		}
	}
}
