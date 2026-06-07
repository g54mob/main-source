using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainResources
{
	[Serializable]
	public class ResourceManagerData
	{
		public List<ResourceData> ResourceList;

		public ResourceManagerData()
		{
			ResourceList = new List<ResourceData>();
		}
	}
}
