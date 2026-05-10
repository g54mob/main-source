using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest22 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _investigatorID;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private Transform _investigatorSpawn;

		private MaxVigilanceGoal _maxVigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentVigilanceVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetVigilanceVariable;

		[SerializeField]
		private int _targetVigilanceVariableValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		private LocalizedString _bark04;

		[SerializeField]
		private LocalizedString _bark05;

		[SerializeField]
		private LocalizedString _bark06;

		private bool _firstInvestigatorSpawned;

		[SerializeField]
		private UIGifsListSO _investigatorHelpingGifs;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentVigilanceVariable);
		}

		private void Update()
		{
			if (QuestLog.GetQuestState(_questName) == QuestState.Active && QuestLog.GetQuestEntryState(_questName, _investigatorID) == QuestState.Active && CTSSingleton<HostileCharacterSpawner>.InstanceExists())
			{
				if (CTSSingleton<HostileCharacterSpawner>.Instance.CurrentInvestigators.Count > 0)
				{
					_firstInvestigatorSpawned = true;
					return;
				}
				CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(_investigatorHelpingGifs);
				SpawnInvestigator();
			}
		}

		private void SpawnInvestigator()
		{
			Customer customer = CTSSingleton<HostileCharacterSpawner>.Instance.SpawnInvestigator();
			if (!(customer == null))
			{
				customer.Tags.AddTag(EAgentTag.CannotLeave);
				customer.ActionPlayer.ForceAction(new AgentActionEnterBar(forceEnter: true), EActionPriority.Forced);
				if (!_firstInvestigatorSpawned)
				{
					_firstInvestigatorSpawned = true;
					Barks.BarkAgent(customer, _bark03);
					DialogueHelper.StartConversation(_feedback01);
					customer.transform.SetPositionAndRotation(_investigatorSpawn.position, _investigatorSpawn.rotation);
				}
			}
		}

		protected override void StopObservingObjectives()
		{
			_maxVigilanceGoal?.CleanStopObserving();
			CustomerActionGetBloodSucked.KilledByWorker -= OnKilledByWorker;
			Agent.EnteringBar -= OnEnteringBar;
			AgentActionTakeOrder.TakingOrder -= OnTakingOrder;
			AgentActionInvestigate.Investigating -= OnInvestigating;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetVigilanceVariable, _targetVigilanceVariableValue);
			_maxVigilanceGoal = new MaxVigilanceGoal(this, _vigilanceEntry, _currentVigilanceVariable, _targetVigilanceVariable);
			_maxVigilanceGoal?.StartObserving();
			CustomerActionGetBloodSucked.KilledByWorker += OnKilledByWorker;
			Agent.EnteringBar += OnEnteringBar;
			AgentActionTakeOrder.TakingOrder += OnTakingOrder;
			AgentActionInvestigate.Investigating += OnInvestigating;
		}

		private void OnEnteringBar(Agent agent)
		{
			if (agent is Customer { IsInvestigator: not false } customer)
			{
				Agent.EnteringBar -= OnEnteringBar;
				Barks.BarkAgent(customer, _bark04);
			}
		}

		private void OnTakingOrder(Agent agent)
		{
			if (agent is Customer { IsInvestigator: not false } customer)
			{
				AgentActionTakeOrder.TakingOrder -= OnTakingOrder;
				Barks.BarkAgent(customer, _bark05);
			}
		}

		private void OnInvestigating(Agent agent)
		{
			if (agent is Customer { IsInvestigator: not false } customer)
			{
				AgentActionInvestigate.Investigating -= OnInvestigating;
				Barks.BarkAgent(customer, _bark06);
			}
		}

		private void OnKilledByWorker(Customer customer)
		{
			if (customer.IsInvestigator)
			{
				CustomerActionGetBloodSucked.KilledByWorker -= OnKilledByWorker;
				Barks.BarkAgent(customer, _bark01);
				DialogueHelper.StartConversation(_feedback02);
				CTSSingleton<HostileCharacterSpawner>.Instance.SetAllowedCount(0.1f);
				QuestEntrySuccess(_investigatorID);
			}
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			CTSSingleton<HostileCharacterSpawner>.Instance.SetAllowedCount(0.1f);
		}
	}
}
