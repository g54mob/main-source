using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ToggleGameObject : NimbatusAction
	{
		public GameObject Target;

		public bool TargetState;

		public override void Execute()
		{
			if (Target != null)
			{
				Target.SetActive(TargetState);
			}
		}
	}
}
