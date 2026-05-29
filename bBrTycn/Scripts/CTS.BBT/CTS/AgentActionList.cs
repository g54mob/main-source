using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/AI/Action List")]
	public class AgentActionList : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, ActionData[]> _actions;

		[SerializeField]
		private List<AgentActionList> _fallbackLists = new List<AgentActionList>();

		public ActionData GetActionData(StringKey key)
		{
			if (_actions.TryGetValue(key, out var value))
			{
				return value.GetRandom();
			}
			foreach (AgentActionList fallbackList in _fallbackLists)
			{
				ActionData actionData = fallbackList.GetActionData(key);
				if ((object)actionData != null)
				{
					return actionData;
				}
			}
			return null;
		}

		public AgentAction InstantiateAction(StringKey key)
		{
			return GetActionData(key).InstantiateAction();
		}
	}
}
