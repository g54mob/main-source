using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class GameObjectExists : NimbatusCondition
	{
		public GameObject Target;

		public override bool IsTrue()
		{
			return Target != null;
		}
	}
}
