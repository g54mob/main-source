using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest70 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback04;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		private LocalizedString _bark04;

		[SerializeField]
		private CustomerParameters _loony;

		[SerializeField]
		private BBTMachineCorpsesGoal _machineCorpseGoal;

		[SerializeField]
		private BBTStockAmountQualityGoal _granitasGoal;

		[SerializeField]
		private BBTHaveSpecificFurnitureInteractorGoal<ITrapMachine> _trapsGoal;

		[SerializeField]
		private BBTSubSpeciesServiceGoal _loonyGoal;

		protected override void StartObservingObjectives()
		{
			_machineCorpseGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_granitasGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_trapsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark03);
			});
			_loonyGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_loony, _bark04);
			});
		}
	}
}
