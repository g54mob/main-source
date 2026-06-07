using UnityEngine;

namespace Coherence.Toolkit.ComponentActions
{
	[ComponentAction(typeof(Renderer), "Handle Material")]
	public class MaterialRendererComponentAction : ComponentAction
	{
		public Material authority;

		public Material remote;

		public override void OnAuthority()
		{
		}

		public override void OnRemote()
		{
		}
	}
}
