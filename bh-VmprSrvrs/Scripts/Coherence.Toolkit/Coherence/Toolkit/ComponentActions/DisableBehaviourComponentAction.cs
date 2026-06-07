using UnityEngine;

namespace Coherence.Toolkit.ComponentActions
{
	[ComponentAction(typeof(Behaviour), "Disable")]
	public class DisableBehaviourComponentAction : ComponentAction
	{
		public override void OnAuthority()
		{
		}

		public override void OnRemote()
		{
		}
	}
}
