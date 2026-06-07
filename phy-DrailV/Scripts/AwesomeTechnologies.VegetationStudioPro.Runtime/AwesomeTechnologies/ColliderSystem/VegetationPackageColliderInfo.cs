using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.ColliderSystem
{
	public class VegetationPackageColliderInfo
	{
		[NonSerialized]
		public readonly List<ColliderManager> ColliderManagerList = new List<ColliderManager>();
	}
}
