using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.PrefabSpawner
{
	public class VegetationItemRuntimePrefabInfo
	{
		[NonSerialized]
		public readonly List<RuntimePrefabManager> RuntimePrefabManagerList = new List<RuntimePrefabManager>();
	}
}
