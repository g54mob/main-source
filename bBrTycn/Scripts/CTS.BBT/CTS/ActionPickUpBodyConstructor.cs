using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionPickUpBodyConstructor : ActionConstructor<AgentActionPickUpBody>
	{
		[SerializeField]
		private SoftReference<Customer> _deadBody;

		protected override AgentActionPickUpBody ConstructAction()
		{
			return new AgentActionPickUpBody(_deadBody);
		}
	}
}
