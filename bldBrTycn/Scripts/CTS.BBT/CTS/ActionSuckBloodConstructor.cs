using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class ActionSuckBloodConstructor : ActionConstructor<AgentActionSuckBlood>, IGive<Crime>
	{
		[SerializeField]
		private SoftReference<Customer> _targetVictim;

		protected override AgentActionSuckBlood ConstructAction()
		{
			return new AgentActionSuckBlood(_targetVictim.Get());
		}

		Crime IGive<Crime>.Get()
		{
			return GetAction().Cast<IGive<Crime>>().Get();
		}
	}
}
