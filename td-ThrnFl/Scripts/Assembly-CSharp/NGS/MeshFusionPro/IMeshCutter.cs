using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public interface IMeshCutter
	{
		void Cut(Mesh mesh, MeshCuttingInfo cuttingInfo);

		void Cut(Mesh mesh, IList<MeshCuttingInfo> cuttingInfos);
	}
}
