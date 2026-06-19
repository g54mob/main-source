using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedRuntimeAnimatorController : SharedVariable<RuntimeAnimatorController>
	{
		public static implicit operator SharedRuntimeAnimatorController(RuntimeAnimatorController value)
		{
			return new SharedRuntimeAnimatorController
			{
				Value = value
			};
		}
	}
}
