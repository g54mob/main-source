using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest69 : Quest
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
		private BBTLockInCellGoal _captureGoal;

		[SerializeField]
		private BBTKillHumanGoal _killsGoal;

		[SerializeField]
		private BBTHaveSpecificFurnitureInteractorGoal<BloodyIceCrusher> _iceCrusherGoal;

		[SerializeField]
		private BBTWorkersAmountGoal _workersGoal;

		protected override void StartObservingObjectives()
		{
			_captureGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_killsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_iceCrusherGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark03);
			});
			_workersGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark04);
			});
		}
	}
}
