using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Malbers/Scriptables/Set Float Var Listener", 0)]
	public class SetFloatVarReaction : Reaction
	{
		[Header("Set Float Var Listener")]
		[Tooltip("ID for the Var Listener. If is set to -1 it will get the first Bool Listener found")]
		public IntReference ID = new IntReference(-1);

		public FloatReference newValue = new FloatReference();

		public override Type ReactionType => typeof(FloatVarListener);

		protected override bool _TryReact(Component reactor)
		{
			List<FloatVarListener> list = reactor.GetComponents<FloatVarListener>().ToList();
			if ((int)ID != -1)
			{
				list = list.FindAll((FloatVarListener x) => x.ID.Value == ID.Value);
			}
			if (list != null)
			{
				foreach (FloatVarListener item in list)
				{
					item.SetValue(newValue.Value);
				}
				return true;
			}
			return false;
		}
	}
}
