using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT.UI
{
	public class UIActionListPanel : MonoSingleton<UIActionListPanel>
	{
		private Agent _currentAgent;

		private Canvas _canvas;

		private GraphicRaycaster _graphicRaycaster;

		private LayoutGroup _layoutGroup;

		private List<UIActionListButton> _buttons = new List<UIActionListButton>();

		[SerializeField]
		private int _maxButtons = 6;

		private bool _enabled;

		protected override void SingletonAwake()
		{
			_canvas = GetComponent<Canvas>();
			_graphicRaycaster = GetComponent<GraphicRaycaster>();
			OnAgentSelected(null);
			_layoutGroup = GetComponentInChildren<LayoutGroup>();
			UIActionListButton componentInChildren = _layoutGroup.GetComponentInChildren<UIActionListButton>();
			_buttons.Add(componentInChildren);
			for (int i = 1; i < _maxButtons; i++)
			{
				_buttons.Add(Object.Instantiate(componentInChildren, _layoutGroup.transform));
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			WorldSelector.RegisterToSelection<Agent>(OnAgentSelectionChanged);
		}

		private void OnDisable()
		{
			WorldSelector.UnregisterToSelection<Agent>(OnAgentSelectionChanged);
		}

		private void OnAgentSelectionChanged(Agent agent, bool selected)
		{
			if (selected)
			{
				if (agent == _currentAgent)
				{
					return;
				}
				_currentAgent = agent;
			}
			else
			{
				if (agent != _currentAgent)
				{
					return;
				}
				_currentAgent = null;
			}
			UpdateVisual();
		}

		private void Update()
		{
			if (_enabled && (bool)_currentAgent)
			{
				UpdateButtons();
			}
		}

		private void UpdateButtons()
		{
			int i = 0;
			foreach (AgentAction item in _currentAgent.ActionPlayer.ActionQueue)
			{
				if (i > _maxButtons - 1)
				{
					break;
				}
				if (item.VisibleInActionList)
				{
					_buttons[i].SetActive(p_active: true, item);
					i++;
				}
			}
			for (; i < _maxButtons; i++)
			{
				_buttons[i].SetActive(p_active: false, null);
			}
		}

		private void OnAgentSelected(Agent p_worker)
		{
			_currentAgent = p_worker;
			UpdateVisual();
		}

		private void UpdateVisual()
		{
			if (_enabled && (bool)_currentAgent)
			{
				_canvas.enabled = true;
				_graphicRaycaster.enabled = true;
			}
			else
			{
				_canvas.enabled = false;
				_graphicRaycaster.enabled = false;
			}
		}

		public void SetActive(bool value)
		{
			_enabled = value;
			UpdateVisual();
		}
	}
}
