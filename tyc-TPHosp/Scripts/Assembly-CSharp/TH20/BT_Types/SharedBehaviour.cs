using System;
using BehaviorDesigner.Runtime;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedBehaviour : SharedVariable<ExternalBehaviorTree>
	{
		public static implicit operator SharedBehaviour(ExternalBehaviorTree value)
		{
			return new SharedBehaviour
			{
				Value = value
			};
		}
	}
}
