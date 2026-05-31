using System;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorkerDataPanelNavigation : AbsAgentPanel
	{
		[SerializeField]
		private Button _infoButton;

		[SerializeField]
		private Button _statsButton;

		[SerializeField]
		private Button _assignationButton;

		[SerializeField]
		private Button _priorityButton;

		[SerializeField]
		private Button _vampDrinkButton;

		[SerializeField]
		private Button _humanDrinkButton;

		[SerializeField]
		private Button _uniformsButton;

		private static AgentPanelGroup.showMode _showData;

		public AgentPanelGroup.showMode ShowData
		{
			get
			{
				return _showData;
			}
			set
			{
				_showData = value;
				_assignationButton.interactable = _showData != AgentPanelGroup.showMode.Assignation;
				_infoButton.interactable = _showData != AgentPanelGroup.showMode.Info;
				_statsButton.interactable = _showData != AgentPanelGroup.showMode.Stats;
				_priorityButton.interactable = _showData != AgentPanelGroup.showMode.Priority;
				_vampDrinkButton.interactable = _showData != AgentPanelGroup.showMode.VampDrink;
				_humanDrinkButton.interactable = _showData != AgentPanelGroup.showMode.HumanDrink;
				_uniformsButton.interactable = _showData != AgentPanelGroup.showMode.Uniform;
				this.OnShowButtonChanged?.Invoke(_showData);
			}
		}

		public event Action<AgentPanelGroup.showMode> OnShowButtonChanged;

		protected override void Awake()
		{
			_infoButton.onClick.AddListener(SelectInfo);
			_statsButton.onClick.AddListener(SelectStats);
			_priorityButton.onClick.AddListener(SelectPriority);
			_assignationButton.onClick.AddListener(SelectAssignation);
			_vampDrinkButton.onClick.AddListener(SelectVampDrink);
			_humanDrinkButton.onClick.AddListener(SelectHumanDrink);
			_uniformsButton.onClick.AddListener(SelectUniforms);
		}

		protected override void OnDestroy()
		{
			_infoButton.onClick.RemoveListener(SelectInfo);
			_statsButton.onClick.RemoveListener(SelectStats);
			_priorityButton.onClick.RemoveListener(SelectPriority);
			_assignationButton.onClick.RemoveListener(SelectAssignation);
			_vampDrinkButton.onClick.RemoveListener(SelectVampDrink);
			_humanDrinkButton.onClick.RemoveListener(SelectHumanDrink);
		}

		private void Start()
		{
			ShowData = AgentPanelGroup.showMode.Info;
		}

		private void SelectInfo()
		{
			ShowData = AgentPanelGroup.showMode.Info;
		}

		private void SelectStats()
		{
			ShowData = AgentPanelGroup.showMode.Stats;
		}

		private void SelectPriority()
		{
			ShowData = AgentPanelGroup.showMode.Priority;
		}

		private void SelectAssignation()
		{
			ShowData = AgentPanelGroup.showMode.Assignation;
		}

		private void SelectVampDrink()
		{
			ShowData = AgentPanelGroup.showMode.VampDrink;
		}

		private void SelectHumanDrink()
		{
			ShowData = AgentPanelGroup.showMode.HumanDrink;
		}

		private void SelectUniforms()
		{
			ShowData = AgentPanelGroup.showMode.Uniform;
		}

		public void SetAgentInfo(Agent agent)
		{
			_assignationButton?.transform.parent.gameObject.SetActive(agent is Worker);
			_infoButton?.transform.parent.gameObject.SetActive(value: true);
			_statsButton?.transform.parent.gameObject.SetActive(agent is Worker);
			_priorityButton?.transform.parent.gameObject.SetActive(agent is Worker);
			_vampDrinkButton?.transform.parent.gameObject.SetActive(!agent.IsHuman && !(agent is Worker));
			_humanDrinkButton?.transform.parent.gameObject.SetActive(agent.IsHuman);
			_uniformsButton?.transform.parent.gameObject.SetActive(agent is Worker);
		}

		public override void ClearAgentInfo()
		{
		}

		public override void SetAgentInfo()
		{
		}
	}
}
