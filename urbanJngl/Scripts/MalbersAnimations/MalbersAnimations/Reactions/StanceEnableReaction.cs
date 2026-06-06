using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Stance Enable-Disable", 0)]
	public class StanceEnableReaction : MReaction
	{
		public IDEnable<StanceID>[] stances;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			IDEnable<StanceID>[] array = stances;
			foreach (IDEnable<StanceID> iDEnable in array)
			{
				mAnimal.Stance_Get(iDEnable.ID)?.Enable(iDEnable.enable);
			}
			return true;
		}
	}
}
