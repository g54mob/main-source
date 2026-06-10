using UnityEngine;

namespace NGS.MeshFusionPro
{
	public static class LODGroupHelper
	{
		public static bool Contains(this LODGroup group, Renderer renderer)
		{
			LOD[] lODs = group.GetLODs();
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] renderers = lODs[i].renderers;
				for (int j = 0; j < renderers.Length; j++)
				{
					if (renderers[j] == renderer)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
