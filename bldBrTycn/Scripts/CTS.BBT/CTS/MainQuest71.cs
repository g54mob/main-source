using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest71 : Quest
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
		private CustomerParameters _sirens;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		private LocalizedString _bark04;

		[SerializeField]
		private BBTSubSpeciesServiceGoal _sirensGoal;

		[SerializeField]
		private BBTPositiveReviewsSpeciesGoal _vampireReviewsGoal;

		[SerializeField]
		private BBTPrestigeGainGoal _prestigeGoal;

		[SerializeField]
		private BBTMoneyGoal _moneyGoal;

		protected override void StartObservingObjectives()
		{
			_sirensGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_sirens, _bark01);
			});
			_vampireReviewsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_prestigeGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark03);
			});
			_moneyGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark04);
			});
		}
	}
}
