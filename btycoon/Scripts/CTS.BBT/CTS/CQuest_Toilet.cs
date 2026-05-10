using System.Collections;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class CQuest_Toilet : CircumstantialQuest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private UIOpenConstructionGoal _uiConstructionGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _uiConstructionEntry;

		private CreateNewRoomGoal _createNewRoomGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _roomEntry;

		private AddRoomAccessGoal _addRoomAccessGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _entranceEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		private BuySpecificFurnitureInteractorGoal<Toilet> _toiletGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _toiletEntry;

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
			_uiConstructionGoal?.CleanStopObserving();
			_createNewRoomGoal?.CleanStopObserving();
			_addRoomAccessGoal?.CleanStopObserving();
			_toiletGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_uiConstructionGoal = new UIOpenConstructionGoal(this, _uiConstructionEntry);
			_uiConstructionGoal?.StartObserving();
			_createNewRoomGoal = new CreateNewRoomGoal(this, _roomEntry);
			_createNewRoomGoal?.StartObserving();
			_addRoomAccessGoal = new AddRoomAccessGoal(this, _entranceEntry);
			_addRoomAccessGoal?.StartObserving(OnRoomAccessAchieved);
			_toiletGoal = new BuySpecificFurnitureInteractorGoal<Toilet>(this, _toiletEntry);
			_toiletGoal?.StartObserving(OnToiletGoalAchieved);
		}

		private void OnRoomAccessAchieved()
		{
			DialogueHelper.StartFeedback(_feedback02);
		}

		private void OnToiletGoalAchieved()
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
