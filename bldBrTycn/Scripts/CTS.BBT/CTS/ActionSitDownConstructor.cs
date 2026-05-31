using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionSitDownConstructor : ActionConstructor<AgentActionSitDown>
	{
		[SerializeField]
		private SoftReference<Seat> _seat;

		protected override AgentActionSitDown ConstructAction()
		{
			return new AgentActionSitDown(_seat);
		}
	}
}
