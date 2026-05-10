using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest08 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _prestigeID;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestigeVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestigeTargetVariableName;

		[SerializeField]
		private float _prestigeTargetVariableNameValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _clientsID;

		[SerializeField]
		[VariablePopup(false)]
		private string _clientsVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _clientsMaxVariableName;

		[SerializeField]
		private int _clientsMaxVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_prestigeVariableName);
			ResetVariableTo0(_clientsVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueHelper.StartConversation(_feedback01);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			Prestige.PrestigeLevelChanged -= OnPrestigeLevelChanged;
			AgentActionEnterBar.AgentEnteredBar -= OnCustomerEnteredBar;
			Agent.EnteringBar -= OnCustomerEnteredBar;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_prestigeTargetVariableName, _prestigeTargetVariableNameValue);
			DialogueLua.SetVariable(_clientsMaxVariableName, _clientsMaxVariableNameValue);
			Prestige.PrestigeLevelChanged += OnPrestigeLevelChanged;
			OnPrestigeLevelChanged(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel);
			AgentActionEnterBar.AgentEnteredBar += OnCustomerEnteredBar;
		}

		private void OnCustomerEnteredBar(Agent agent)
		{
			if (agent is Customer && IncrementQuestEntryVariable(_clientsID, _clientsVariableName, 1, _clientsMaxVariableName))
			{
				AgentActionEnterBar.AgentEnteredBar -= OnCustomerEnteredBar;
				QuestEntrySuccess(_clientsID);
			}
		}

		private void OnPrestigeLevelChanged(PrestigeLevelData prestigeData)
		{
			if (SetQuestEntryVariable(_prestigeID, _prestigeVariableName, prestigeData.Level, _prestigeTargetVariableName))
			{
				Prestige.PrestigeLevelChanged -= OnPrestigeLevelChanged;
				QuestEntrySuccess(_prestigeID);
			}
		}
	}
}
