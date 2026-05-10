using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class PanicCamera : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private PanicCounter _panicCounter;

		private readonly List<Agent> _panickedAgents = new List<Agent>();

		private int _currentIndex;

		protected override void OnAwake()
		{
			base.OnAwake();
			foreach (Agent panickingAgent in _panicCounter.PanickingAgents)
			{
				_panickedAgents.Add(panickingAgent);
			}
			_button.onClick.AddListener(OnButtonClicked);
			_panicCounter.AgentPanicked += OnAgentPanicked;
		}

		private void OnAgentPanicked(Agent agent, bool isPanicked)
		{
			if (isPanicked)
			{
				_panickedAgents.Add(agent);
				if (_currentIndex == 0)
				{
					_currentIndex = _panickedAgents.Count - 1;
				}
				return;
			}
			int num = _panickedAgents.IndexOf(agent);
			_panickedAgents.RemoveAt(num);
			if (_currentIndex >= num)
			{
				_currentIndex--;
			}
		}

		private void OnButtonClicked()
		{
			Agent agent = _panickedAgents[_currentIndex];
			if (agent.Selection.SelectableObject.CanBeSelectedByMode(CTSSingleton<WorldSelector>.Instance.CurrentSelectionMode))
			{
				WorldSelector.SelectObject(agent.Selection.SelectableObject);
			}
			MonoSingleton<CameraFollowing>.Instance.EventLock(agent.transform);
			IncrementIndex();
		}

		private void IncrementIndex()
		{
			if (_currentIndex >= _panickedAgents.Count - 1)
			{
				_currentIndex = 0;
			}
			else
			{
				_currentIndex++;
			}
		}
	}
}
