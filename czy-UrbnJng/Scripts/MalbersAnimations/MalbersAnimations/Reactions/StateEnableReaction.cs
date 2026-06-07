using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/State Enable-Disable", 0)]
	public class StateEnableReaction : MReaction
	{
		public IDEnable<StateID>[] states;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			IDEnable<StateID>[] array = states;
			foreach (IDEnable<StateID> iDEnable in array)
			{
				State state = mAnimal.State_Get(iDEnable.ID);
				if (state != null)
				{
					state.Enable(iDEnable.enable);
				}
			}
			return true;
		}
	}
}
