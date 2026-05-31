using System.Collections;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class C10_Toilets : CircumstantialQuest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private BBTHaveSpecificFurnitureInteractorGoal<Toilet> _specificFurnitureInteractorGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private BBTToiletUseGoal _toiletUseGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback04;

		[SerializeField]
		private LocalizedString _bark03;

		public override void StopObservingStartConditions()
		{
			AgentActionPeeAccident.PeeingHimself -= OnPeeingHimself;
		}

		public override void StartObservingStartConditions()
		{
			AgentActionPeeAccident.PeeingHimself += OnPeeingHimself;
		}

		private void OnPeeingHimself(Agent agent)
		{
			if (!BBTUI.GetCanvas(BBTUI.Instance.ButtonID_InteriorTool).IsHidden)
			{
				AgentActionPeeAccident.PeeingHimself -= OnPeeingHimself;
				StartQuest();
				Barks.KillBark(agent);
				Barks.BarkAgent(agent, _bark01);
			}
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueHelper.StartFeedback(_feedback01);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_specificFurnitureInteractorGoal.StopObserving();
			_toiletUseGoal.StopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_specificFurnitureInteractorGoal.StartObserving(this, delegate
			{
				OnToiletsGoalAchieved();
			});
			_toiletUseGoal.StartObserving(this, delegate
			{
				OnToiletUseGoalAchieved();
			});
		}

		private void OnToiletsGoalAchieved()
		{
			DialogueHelper.StartFeedback(_feedback02);
		}

		private void OnToiletUseGoalAchieved()
		{
			DialogueHelper.StartFeedback(_feedback03);
			Barks.BarkAnyHumanCustomer(_bark02);
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			DialogueHelper.StartFeedback(_feedback04);
			Barks.BarkAnyWorker(_bark03);
		}
	}
}
