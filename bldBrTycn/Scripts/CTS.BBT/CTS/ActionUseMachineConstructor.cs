using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionUseMachineConstructor : ActionConstructor<AgentActionUseMachine>
	{
		[SerializeField]
		private SoftReference<MachineBase> _machineToUse;

		protected override AgentActionUseMachine ConstructAction()
		{
			return new AgentActionUseMachine(_machineToUse);
		}
	}
}
