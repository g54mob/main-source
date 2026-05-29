using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class AgentPanelGroup : MonoSingleton<AgentPanelGroup>
	{
		public enum showMode
		{
			Info = 0,
			Stats = 1,
			Priority = 2,
			Hire = 3,
			Assignation = 4,
			VampDrink = 5,
			HumanDrink = 6,
			Uniform = 7
		}

		[SerializeField]
		private AgentIdentityPanel _agentIdentityPanel;

		[SerializeField]
		private WorkerFooterPanel _workerFooterPanel;

		[SerializeField]
		private AgentStatsPanel _agentStatesPanel;

		[SerializeField]
		private AgentNeedsPanel _agentNeedsPanel;

		[SerializeField]
		private AgentCredibilityPanel _credibilityPanel;

		[SerializeField]
		private AgentTraitsPanel _agentTraitsPanel;

		[SerializeField]
		private AgentXP_Panel _agentXP_Panel;

		[SerializeField]
		private WorkerPowerPanel _workerPowerPanel;

		[SerializeField]
		private WorkerPriorityPanel _workerPriorityPanel;

		[SerializeField]
		private PriorityActivationPanel _priorityActivationPanel;

		[SerializeField]
		private WorkerHirePanel _workerHirePanel;

		[SerializeField]
		private AgentPanelRoomAssignation _roomAssignation;

		[SerializeField]
		private LikedDrinkPanel _likedDrinkPanel;

		[SerializeField]
		private AgentPanelUniforms _panelUniforms;

		[Header("Navigation")]
		[SerializeField]
		private WorkerDataPanelNavigation _workerDataPanelNavigation;

		[Header("Stats Layout")]
		[SerializeField]
		private TEMP_StatsPanelDispatcher _statsPanelDispatcher;

		private showMode _currentShowMode;

		private CanvasGroupController _groupController;

		public Agent CurrentAgent { get; private set; }

		public static event Action ShowPanelWorker;

		public static event Action HidePanelWorker;

		private void Start()
		{
			_currentShowMode = showMode.Info;
			if ((object)_groupController == null)
			{
				_groupController = GetComponent<CanvasGroupController>();
			}
			_groupController.CanvasShowned += IsShowned;
			_groupController.CanvasShowning += IsShowning;
			_workerDataPanelNavigation.OnShowButtonChanged += RefreshAgentPanelFromNavigation;
		}

		private void OnDestroy()
		{
			_workerDataPanelNavigation.OnShowButtonChanged -= RefreshAgentPanelFromNavigation;
			_groupController.CanvasShowned -= IsShowned;
		}

		private void IsShowning(bool p_shown)
		{
			AgentPanelGroup.ShowPanelWorker?.Invoke();
			if (!p_shown)
			{
				WorldSelector.DeselectAll<Agent>();
			}
		}

		private void IsShowned(bool p_shown)
		{
		}

		private void UpdateActiveStates(showMode showMode)
		{
			bool flag = CurrentAgent is Worker;
			bool isHuman = CurrentAgent.IsHuman;
			_agentIdentityPanel.gameObject.SetActive(value: true);
			_workerDataPanelNavigation.gameObject.SetActive(showMode != showMode.Hire);
			_statsPanelDispatcher.gameObject.SetActive(showMode == showMode.Stats || showMode == showMode.Hire);
			_agentStatesPanel.gameObject.SetActive(showMode == showMode.Info);
			_agentNeedsPanel.gameObject.SetActive(showMode == showMode.Info);
			_credibilityPanel.gameObject.SetActive(showMode == showMode.Info && isHuman);
			_agentTraitsPanel.gameObject.SetActive(showMode == showMode.Stats || (showMode == showMode.Hire && flag));
			_workerHirePanel.gameObject.SetActive(showMode == showMode.Hire && flag);
			_agentXP_Panel.gameObject.SetActive(showMode != showMode.Hire && flag);
			_workerPowerPanel.gameObject.SetActive(showMode == showMode.Stats || (showMode == showMode.Hire && flag));
			_roomAssignation.gameObject.SetActive(showMode == showMode.Assignation);
			_workerPriorityPanel.gameObject.SetActive(showMode == showMode.Priority && flag);
			_priorityActivationPanel.gameObject.SetActive(showMode == showMode.Priority && flag);
			_workerFooterPanel.gameObject.SetActive(showMode != showMode.Priority && showMode != showMode.Hire && showMode != showMode.Assignation && flag);
			_likedDrinkPanel.gameObject.SetActive(!flag && (showMode == showMode.HumanDrink || showMode == showMode.VampDrink));
			_panelUniforms.gameObject.SetActive(showMode == showMode.Uniform && flag);
			_agentIdentityPanel.NeedToBeInteractable(CurrentAgent is Worker && showMode != showMode.Hire);
		}

		private void UpdatePanelOrder()
		{
			switch (_currentShowMode)
			{
			case showMode.Stats:
				if (CurrentAgent is Worker)
				{
					_agentXP_Panel.SetTopParent(_agentIdentityPanel);
					_workerDataPanelNavigation.SetTopParent(_agentXP_Panel);
					_statsPanelDispatcher.SetTopParent(_workerDataPanelNavigation);
					_workerPowerPanel.SetTopParent(_statsPanelDispatcher);
					_agentTraitsPanel.SetTopParent(_workerPowerPanel);
				}
				break;
			case showMode.Info:
				if (CurrentAgent is Worker)
				{
					_agentXP_Panel.SetTopParent(_agentIdentityPanel);
					_workerDataPanelNavigation.SetTopParent(_agentXP_Panel);
					_agentStatesPanel.SetTopParent(_workerDataPanelNavigation);
					_agentNeedsPanel.SetTopParent(_agentStatesPanel);
				}
				else
				{
					_workerDataPanelNavigation.SetTopParent(_agentIdentityPanel);
					_agentStatesPanel.SetTopParent(_workerDataPanelNavigation);
					_agentNeedsPanel.SetTopParent(_agentStatesPanel);
				}
				break;
			case showMode.Priority:
				if (CurrentAgent is Worker)
				{
					_agentXP_Panel.SetTopParent(_agentIdentityPanel);
					_workerDataPanelNavigation.SetTopParent(_agentXP_Panel);
					_workerPriorityPanel.SetTopParent(_workerDataPanelNavigation);
					_priorityActivationPanel.SetTopParent(_workerPriorityPanel);
				}
				break;
			case showMode.Hire:
				if (CurrentAgent is Worker)
				{
					_statsPanelDispatcher.SetTopParent(_agentIdentityPanel);
					_workerPowerPanel.SetTopParent(_statsPanelDispatcher);
					_agentTraitsPanel.SetTopParent(_workerPowerPanel);
					_workerHirePanel.SetTopParent(_agentTraitsPanel);
				}
				break;
			case showMode.HumanDrink:
				_workerDataPanelNavigation.SetTopParent(_agentIdentityPanel);
				_likedDrinkPanel.SetTopParent(_workerDataPanelNavigation);
				break;
			case showMode.VampDrink:
				_workerDataPanelNavigation.SetTopParent(_agentIdentityPanel);
				_likedDrinkPanel.SetTopParent(_workerDataPanelNavigation);
				break;
			case showMode.Assignation:
				break;
			}
		}

		private void Show()
		{
			_agentIdentityPanel.Agent = CurrentAgent;
			_workerFooterPanel.Agent = CurrentAgent as Worker;
			_statsPanelDispatcher.Agent = CurrentAgent;
			UpdateActiveStates(_currentShowMode);
			_workerDataPanelNavigation.SetAgentInfo(CurrentAgent);
			switch (_currentShowMode)
			{
			case showMode.Stats:
				_statsPanelDispatcher.ShowTraitStats();
				_agentXP_Panel.Agent = ((CurrentAgent is Worker) ? CurrentAgent : null);
				_workerPowerPanel.Agent = ((CurrentAgent is Worker) ? CurrentAgent : null);
				_agentTraitsPanel.Agent = CurrentAgent as Worker;
				break;
			case showMode.Info:
				_statsPanelDispatcher.ShowLifeStats();
				_agentXP_Panel.Agent = ((CurrentAgent is Worker) ? CurrentAgent : null);
				_agentStatesPanel.Agent = CurrentAgent;
				_agentNeedsPanel.Agent = CurrentAgent;
				_credibilityPanel.Agent = CurrentAgent;
				break;
			case showMode.Priority:
				_workerPriorityPanel.Agent = CurrentAgent as Worker;
				_agentXP_Panel.Agent = ((CurrentAgent is Worker) ? CurrentAgent : null);
				break;
			case showMode.Hire:
				_statsPanelDispatcher.ShowTraitStats();
				_workerPowerPanel.Agent = ((CurrentAgent is Worker) ? CurrentAgent : null);
				_workerHirePanel.Agent = CurrentAgent as Worker;
				_agentTraitsPanel.Agent = CurrentAgent;
				break;
			case showMode.HumanDrink:
				_likedDrinkPanel.Agent = CurrentAgent;
				break;
			case showMode.VampDrink:
				_likedDrinkPanel.Agent = CurrentAgent;
				break;
			case showMode.Uniform:
				_panelUniforms.Agent = CurrentAgent;
				break;
			}
			if (_currentShowMode == showMode.Assignation)
			{
				_roomAssignation.Agent = CurrentAgent;
			}
			else
			{
				_roomAssignation.Agent = null;
			}
			UpdatePanelOrder();
		}

		public void HidePanel(bool p_destroy = false)
		{
			AgentPanelGroup.HidePanelWorker?.Invoke();
			if (p_destroy)
			{
				_groupController.QuickHide();
				return;
			}
			PhotoCamera.instance.DesactiveCamera();
			_groupController.QuickHide();
			_roomAssignation.Agent = null;
			CurrentAgent = null;
		}

		public void UpdateAgent(Agent p_agent, bool fromNav = false)
		{
			if (p_agent == null)
			{
				PhotoCamera.instance.DesactiveCamera();
				_groupController.QuickHide();
				CurrentAgent = null;
				return;
			}
			if (!fromNav)
			{
				PhotoCamera.instance.ActiveCamera();
			}
			if (CurrentAgent != null && CurrentAgent is Worker)
			{
				((Worker)CurrentAgent).Level.LeveledUp -= RefreshWorkerPanel;
			}
			CurrentAgent = p_agent;
			if (CurrentAgent is Worker worker)
			{
				if (!worker.IsEngaged)
				{
					_currentShowMode = showMode.Hire;
				}
				else if (_currentShowMode == showMode.Hire || _workerDataPanelNavigation.ShowData == showMode.HumanDrink || _workerDataPanelNavigation.ShowData == showMode.VampDrink)
				{
					_workerDataPanelNavigation.ShowData = showMode.Info;
				}
				else
				{
					_currentShowMode = _workerDataPanelNavigation.ShowData;
				}
				worker.Level.LeveledUp += RefreshWorkerPanel;
			}
			else if (CurrentAgent is Customer)
			{
				if (_workerDataPanelNavigation.ShowData != showMode.Info)
				{
					if (CurrentAgent.IsHuman)
					{
						if (_workerDataPanelNavigation.ShowData == showMode.VampDrink)
						{
							_workerDataPanelNavigation.ShowData = showMode.HumanDrink;
						}
						else if (_workerDataPanelNavigation.ShowData != showMode.HumanDrink)
						{
							_workerDataPanelNavigation.ShowData = showMode.Info;
						}
					}
					else if (_workerDataPanelNavigation.ShowData == showMode.HumanDrink)
					{
						_workerDataPanelNavigation.ShowData = showMode.VampDrink;
					}
					else if (_workerDataPanelNavigation.ShowData != showMode.VampDrink)
					{
						_workerDataPanelNavigation.ShowData = showMode.Info;
					}
				}
				_currentShowMode = _workerDataPanelNavigation.ShowData;
			}
			if (CurrentAgent != null)
			{
				_groupController.QuickShow();
				Show();
			}
		}

		private void RefreshWorkerPanel()
		{
		}

		private void RefreshAgentPanelFromNavigation(showMode showData)
		{
			_currentShowMode = showData;
			UpdateAgent(CurrentAgent, fromNav: true);
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}
	}
}
