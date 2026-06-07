using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Behaviour))]
	internal sealed class BehaviourPreparer : ComponentPreparer<Behaviour>
	{
		public override void PrepareForPlayback(Behaviour component, ReplayState additionalData)
		{
			additionalData.Write(component.enabled);
			component.enabled = false;
		}

		public override void PrepareForGameplay(Behaviour component, ReplayState additionalData)
		{
			bool enabled = additionalData.ReadBool();
			component.enabled = enabled;
		}
	}
}
