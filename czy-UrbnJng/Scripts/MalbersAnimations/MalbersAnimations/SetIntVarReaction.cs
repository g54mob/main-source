using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Malbers/Scriptables/Set Int Var Listener", 0)]
	public class SetIntVarReaction : Reaction
	{
		[Header("Set Int Var Listener")]
		[Tooltip("ID for the Var Listener. If is set to -1 it will get the first Bool Listener found")]
		public IntReference ID = new IntReference(-1);

		public IntReference newValue = new IntReference();

		public override Type ReactionType => typeof(IntVarListener);

		protected override bool _TryReact(Component reactor)
		{
			List<IntVarListener> list = reactor.GetComponents<IntVarListener>().ToList();
			if ((int)ID != -1)
			{
				list = list.FindAll((IntVarListener x) => x.ID.Value == ID.Value);
			}
			if (list != null)
			{
				foreach (IntVarListener item in list)
				{
					item.SetValue(newValue.Value);
				}
				return true;
			}
			return false;
		}
	}
}
