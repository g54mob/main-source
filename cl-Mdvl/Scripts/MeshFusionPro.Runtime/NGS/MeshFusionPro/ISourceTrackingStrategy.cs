using System.Collections.Generic;

namespace NGS.MeshFusionPro
{
	public interface ISourceTrackingStrategy
	{
		bool GatherComponents(MeshFusionSource source, out string reason);

		void OnCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts);

		void Track(out bool changed);
	}
}
