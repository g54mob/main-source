using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest72 : Quest
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
		private BBTBlueBloodBagProductionGoal _blueGoal;

		[SerializeField]
		private BBTNoLoanGoal _loanGoal;

		[SerializeField]
		private BBTBarValueGoal _valueGoal;

		[SerializeField]
		private BBTPrestigeMaxGoal _prestigeGoal;

		protected override void StartObservingObjectives()
		{
			_blueGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_loanGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			});
			_valueGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			});
			_prestigeGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
		}
	}
}
