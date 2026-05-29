using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ActionDebugLoopConstructor : ActionConstructor<ActionDebugLoop>
	{
		[InfoBox("This action is for debugging purposes only, mainly testing an infinite loop in the ActionPlayer", EInfoBoxType.Normal)]
		[SerializeField]
		[ReadOnly]
		private bool _info;

		protected override ActionDebugLoop ConstructAction()
		{
			return new ActionDebugLoop();
		}
	}
}
