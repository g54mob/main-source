using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Autonomy List")]
	public class AgentAutonomyList : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, AgentAutonomousAction> _actions;

		[SerializeField]
		private List<AgentAutonomyList> _fallbacks = new List<AgentAutonomyList>();

		public ReadOnlyDictionary<StringKey, AgentAutonomousAction> Actions => _actions;

		public ReadOnlyList<AgentAutonomyList> Fallbacks => _fallbacks;
	}
}
