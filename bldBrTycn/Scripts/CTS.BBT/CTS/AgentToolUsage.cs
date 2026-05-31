using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentToolUsage : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private Agent _agentRef;

		[Inject(false)]
		private AgentAnimator _animator;

		[SerializeField]
		private GameObject[] _tools = Array.Empty<GameObject>();

		private readonly List<int> _currentTools = new List<int>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_animator.Events.OnUseTool += OnUseTool;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_animator.Events.OnUseTool -= OnUseTool;
			DisableTools();
		}

		public void OnUseTool(int index)
		{
			if (index < 0)
			{
				DisableTools();
				return;
			}
			index = index.ClampIndex(_tools);
			if (!_currentTools.Contains(index))
			{
				_currentTools.Add(index);
				_tools[index].SetActive(value: true);
			}
		}

		public void DisableTools()
		{
			foreach (int currentTool in _currentTools)
			{
				_tools[currentTool].SetActive(value: false);
			}
			_currentTools.Clear();
		}
	}
}
