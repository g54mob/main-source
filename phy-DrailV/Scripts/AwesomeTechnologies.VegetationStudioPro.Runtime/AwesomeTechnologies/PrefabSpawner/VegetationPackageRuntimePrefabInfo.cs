using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.PrefabSpawner
{
	public class VegetationPackageRuntimePrefabInfo
	{
		[NonSerialized]
		public readonly List<VegetationItemRuntimePrefabInfo> RuntimePrefabManagerList = new List<VegetationItemRuntimePrefabInfo>();
	}
}
