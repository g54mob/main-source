using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.States;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class WorldObjectStateCondition : NimbatusCondition
	{
		public List<EState> AllowedStates = new List<EState>();

		protected override void OnInit()
		{
		}

		public override bool IsTrue()
		{
			return AllowedStates.Contains(Behaviour.CurrentState.State);
		}
	}
}
