using UnityEngine;

namespace Coherence.Toolkit.ComponentActions
{
	[ComponentAction(typeof(Collider), "Disable")]
	public class DisableColliderComponentAction : ComponentAction
	{
		public override void OnAuthority()
		{
		}

		public override void OnRemote()
		{
		}
	}
}
