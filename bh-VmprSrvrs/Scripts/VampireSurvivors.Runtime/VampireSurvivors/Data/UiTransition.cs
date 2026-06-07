using System;
using System.Collections.Generic;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Data
{
	public struct UiTransition
	{
		public Action<CharacterController, Dictionary<string, object>> TransitionPredicate;

		public CharacterController TriggeredByPlayer;

		public Dictionary<string, object> Arguments;

		public UITransitionType TransitionType;
	}
}
