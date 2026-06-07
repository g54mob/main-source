using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Collider))]
	internal sealed class ColliderPreparer : ComponentPreparer<Collider>
	{
		public override void PrepareForPlayback(Collider component, ReplayState additionalData)
		{
			additionalData.Write(component.enabled);
			component.enabled = false;
		}

		public override void PrepareForGameplay(Collider component, ReplayState additionalData)
		{
			bool enabled = additionalData.ReadBool();
			component.enabled = enabled;
		}
	}
}
