using System.Collections.Generic;
using CTS.BBT;
using GameAnalyticsSDK;
using UnityEngine;

namespace CTS
{
	public class ContextualActionsAnalytics : MonoBehaviour
	{
		private Dictionary<string, int> _actions = new Dictionary<string, int>();

		private void OnDisable()
		{
			ContextualAction.ContextualActionExecuting -= OnContextualActionExecuting;
			SendData();
		}

		private void OnEnable()
		{
			ContextualAction.ContextualActionExecuting += OnContextualActionExecuting;
		}

		private void OnContextualActionExecuting(string actionName)
		{
			if (_actions.ContainsKey(actionName))
			{
				_actions[actionName]++;
			}
			else
			{
				_actions.Add(actionName, 1);
			}
		}

		private void SendData()
		{
			foreach (KeyValuePair<string, int> action in _actions)
			{
				GameAnalytics.NewDesignEvent("ContextualActions:" + action.Key, action.Value);
			}
		}
	}
}
