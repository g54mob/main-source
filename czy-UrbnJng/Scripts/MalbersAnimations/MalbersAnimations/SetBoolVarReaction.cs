using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Malbers/Scriptables/Set Bool Var Listener", 0)]
	public class SetBoolVarReaction : Reaction
	{
		[Header("Set Bool Var Listener")]
		[Tooltip("ID for the Var Listener. If is set to -1 it will get the first Bool Listener found")]
		public IntReference ID = new IntReference(-1);

		public BoolReference newValue;

		public override Type ReactionType => typeof(BoolVarListener);

		protected override bool _TryReact(Component reactor)
		{
			List<BoolVarListener> list = reactor.GetComponents<BoolVarListener>().ToList();
			if ((int)ID != -1)
			{
				list = list.FindAll((BoolVarListener x) => x.ID.Value == ID.Value);
			}
			if (list != null)
			{
				foreach (BoolVarListener item in list)
				{
					item.Value = newValue.Value;
				}
				return true;
			}
			return false;
		}
	}
}
