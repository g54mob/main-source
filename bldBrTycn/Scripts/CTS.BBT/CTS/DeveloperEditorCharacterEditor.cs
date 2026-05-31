using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CTS.BBT.AI;
using CTS.Core;
using CTS.DevConsole;
using CTS.DevConsole.Commands;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class DeveloperEditorCharacterEditor : MonoSingleton<DeveloperEditorCharacterEditor>
	{
		[SerializeField]
		[BoxGroup("Elements")]
		private GameObject[] _elementsToDisable;

		[SerializeField]
		[BoxGroup("HumanData")]
		private GameObject[] _humanDataList;

		[SerializeField]
		[BoxGroup("VampireData")]
		private GameObject[] _vampireDataList;

		[SerializeField]
		[BoxGroup("WorkerData")]
		private GameObject[] _workerDataList;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _noAgentSelected;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _characterNameLabel;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _currentActionLabel;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _funValueTextField;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _bladderValueTextField;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _hungerValueTextField;

		private Agent _currentAgent;

		private AgentActionPlayer _agentActionPlayer;

		private string _tmpValue;

		private Regex _isString = new Regex("^(0|1|0?\\.\\d+|1(\\.0)?)$");

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			WorldSelector.RegisterToSelection<Agent>(OnAgentSelected);
			OnAgentSelected(WorldSelector.GetLastSelected<Agent>(), selected: true);
		}

		private void OnDisable()
		{
			WorldSelector.UnregisterToSelection<Agent>(OnAgentSelected);
			CleanUP();
		}

		private void OnAgentSelected(Agent agent, bool selected)
		{
			if (selected)
			{
				if (agent != _currentAgent)
				{
					CleanUP();
					UpdateCurrentAgent(agent);
				}
			}
			else if (agent == _currentAgent)
			{
				CleanUP();
			}
		}

		public void UpdateCurrentAgent(Agent _value)
		{
			if (!_value)
			{
				return;
			}
			_currentAgent = _value;
			_agentActionPlayer = _currentAgent.ActionPlayer;
			_noAgentSelected.SetActive(value: false);
			_characterNameLabel.text = _currentAgent.agentFirstName + " " + _currentAgent.agentName;
			_currentActionLabel.text = ((_agentActionPlayer.CurrentAction == null) ? "Do nothing" : _agentActionPlayer.CurrentAction.GetType().Name);
			_agentActionPlayer.OnActionChanged += ActionPlayerOnOnActionChanged;
			if (_currentAgent.IsHuman)
			{
				GameObject[] humanDataList = _humanDataList;
				for (int i = 0; i < humanDataList.Length; i++)
				{
					humanDataList[i].SetActive(value: true);
				}
			}
			else if (_currentAgent is Worker)
			{
				GameObject[] humanDataList = _workerDataList;
				for (int i = 0; i < humanDataList.Length; i++)
				{
					humanDataList[i].SetActive(value: true);
				}
			}
			else
			{
				GameObject[] humanDataList = _vampireDataList;
				for (int i = 0; i < humanDataList.Length; i++)
				{
					humanDataList[i].SetActive(value: true);
				}
			}
		}

		public void CleanUP()
		{
			if (_agentActionPlayer != null)
			{
				_agentActionPlayer.OnActionChanged -= ActionPlayerOnOnActionChanged;
			}
			_noAgentSelected.SetActive(value: true);
			GameObject[] elementsToDisable = _elementsToDisable;
			for (int i = 0; i < elementsToDisable.Length; i++)
			{
				elementsToDisable[i].SetActive(value: false);
			}
			_characterNameLabel.text = "<color=\"red\">No agent selected</color>";
			_currentActionLabel.text = "Do nothing";
			_currentAgent = null;
			_agentActionPlayer = null;
		}

		public void ChangeFunValue()
		{
			_tmpValue = Regex.Replace(_funValueTextField.text, "[^0-9.]", "");
			float.TryParse(_tmpValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			if (result >= 0f && result <= 1f)
			{
				DeveloperConsole.ExecuteCommand<CommandAgentNeedSet>(new string[2] { "Fun", _tmpValue });
			}
		}

		public void ChangeBladderValue()
		{
			_tmpValue = Regex.Replace(_bladderValueTextField.text, "[^0-9.]", "");
			float.TryParse(_tmpValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			if (result >= 0f && result <= 1f)
			{
				DeveloperConsole.ExecuteCommand<CommandAgentNeedSet>(new string[2] { "Bladder", _tmpValue });
			}
		}

		public void ChangeHungerValue()
		{
			_tmpValue = Regex.Replace(_hungerValueTextField.text, "[^0-9.]", "");
			float.TryParse(_tmpValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			if (result >= 0f && result <= 1f)
			{
				DeveloperConsole.ExecuteCommand<CommandAgentNeedSet>(new string[2] { "Hunger", _tmpValue });
			}
		}

		public void KillTheAgent()
		{
			DeveloperConsole.ExecuteCommand<CommandAgentHealthDamage>(new string[1] { "100" });
		}

		public void CancelAction()
		{
			DeveloperConsole.ExecuteCommand<CommandAgentCancelAction>(Array.Empty<string>());
		}

		public void GetOutFromTheBar()
		{
			if (_currentAgent.IsDead)
			{
				_currentAgent.Statistics.AddToStatistic(EAgentStatistics.Health, 100f);
				_currentAgent.ContextualFSM.SetStateNormal();
			}
			DeveloperConsole.ExecuteCommand<CommandCustomerLeave>(Array.Empty<string>());
		}

		private void ActionPlayerOnOnActionChanged(AgentAction _value)
		{
			_currentActionLabel.text = ((_value == null) ? "Do nothing" : _value.GetType().Name);
		}
	}
}
