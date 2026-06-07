using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Collider2D))]
	internal sealed class Collider2DPreparer : ComponentPreparer<Collider2D>
	{
		public override void PrepareForPlayback(Collider2D component, ReplayState additionalData)
		{
			additionalData.Write(component.enabled);
			component.enabled = false;
		}

		public override void PrepareForGameplay(Collider2D component, ReplayState additionalData)
		{
			bool enabled = additionalData.ReadBool();
			component.enabled = enabled;
		}
	}
}
