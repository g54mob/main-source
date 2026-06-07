using UnityEngine;

namespace Coherence.Toolkit.ComponentActions
{
	[ComponentAction(typeof(Renderer), "Disable")]
	public class DisableRendererComponentAction : ComponentAction
	{
		public override void OnAuthority()
		{
		}

		public override void OnRemote()
		{
		}
	}
}
