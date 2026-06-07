using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Mode Enable-Disable", 0)]
	public class ModeEnableReaction : MReaction
	{
		[Tooltip("Enable or Disable the Mode temporally, this does not deactivate completely the Mode. Disables modes will remain disabled. and it wont be affected by this")]
		public bool TemporalEnable;

		public IDEnable<ModeID>[] modes;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			IDEnable<ModeID>[] array = modes;
			foreach (IDEnable<ModeID> iDEnable in array)
			{
				Mode mode = mAnimal.Mode_Get(iDEnable.ID);
				if (mode != null)
				{
					if (TemporalEnable)
					{
						mode.Enable_Temporal(iDEnable.enable);
					}
					else
					{
						mode.Active = iDEnable.enable;
					}
				}
			}
			return true;
		}
	}
}
