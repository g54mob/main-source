using System;
using System.Collections.Generic;

namespace NGS.MeshFusionPro
{
	[Serializable]
	public class EmptyTrackingStrategy : ISourceTrackingStrategy
	{
		public bool GatherComponents(MeshFusionSource source, out string reason)
		{
			reason = "";
			return true;
		}

		public void OnCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
		}

		public void Track(out bool changed)
		{
			changed = false;
		}
	}
}
