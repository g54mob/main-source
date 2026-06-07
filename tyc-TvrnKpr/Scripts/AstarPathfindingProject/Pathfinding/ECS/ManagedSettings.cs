using System;
using Unity.Entities;
using Unity.Properties;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	[Serializable]
	[GeneratePropertyBag]
	[TypeManager.TypeOverrides(true, true, true)]
	public class ManagedSettings : IComponentData, IQueryTypeParameter, ICloneable, IEquatable<ManagedSettings>
	{
		[NonSerialized]
		public IOffMeshLinkHandler onTraverseOffMeshLink;

		public PathRequestSettings pathfindingSettings;

		public object Clone()
		{
			return null;
		}

		public ManagedSettings CloneAndSimplifyDefaults(bool simplify)
		{
			return null;
		}

		public bool Equals(ManagedSettings other)
		{
			return false;
		}

		[Preserve]
		public ManagedSettings()
		{
		}
	}
}
