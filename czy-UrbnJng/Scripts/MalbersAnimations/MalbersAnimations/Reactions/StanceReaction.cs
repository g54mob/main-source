using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Stance", 0)]
	public class StanceReaction : MReaction
	{
		public Stance_Reaction action;

		[Hide("action", true, new int[] { 6, 4 })]
		public StanceID ID;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			switch (action)
			{
			case Stance_Reaction.Set:
				mAnimal.Stance_Set(ID);
				break;
			case Stance_Reaction.SetPersistent:
			{
				Stance stance = mAnimal.Stance_Get(ID);
				if (stance != null)
				{
					mAnimal.Stance_Set(ID);
					if (!(mAnimal.Stance == ID) && !stance.Queued)
					{
						return false;
					}
					stance.SetPersistent(value: true);
				}
				break;
			}
			case Stance_Reaction.Reset:
			{
				bool persistent = mAnimal.ActiveStance.Persistent;
				mAnimal.ActiveStance.Persistent = false;
				mAnimal.Stance_Reset();
				mAnimal.ActiveStance.Persistent = persistent;
				break;
			}
			case Stance_Reaction.ResetPersistent:
				mAnimal.Stance_Get(ID)?.SetPersistent(value: false);
				mAnimal.Stance_Get(ID)?.SetQueued(value: false);
				mAnimal.Stance_Reset();
				break;
			case Stance_Reaction.Toggle:
				mAnimal.Stance_Toggle(ID);
				break;
			case Stance_Reaction.SetDefault:
				mAnimal.Stance_SetDefault(ID);
				break;
			case Stance_Reaction.RestoreDefault:
				mAnimal.Stance_RestoreDefault();
				break;
			}
			return true;
		}
	}
}
