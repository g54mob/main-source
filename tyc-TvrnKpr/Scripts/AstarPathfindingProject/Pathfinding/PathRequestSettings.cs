using System;
using Unity.Properties;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[Serializable]
	[GeneratePropertyBag]
	public struct PathRequestSettings : IEquatable<PathRequestSettings>
	{
		public GraphMask graphMask;

		public int traversableTags;

		public float[] tagCostMultipliers;

		[FormerlySerializedAs("tagPenalties")]
		public uint[] tagEntryCosts;

		public ITraversalProvider traversalProvider;

		[Obsolete("Use tagEntryCosts or tagCostMultipliers instead")]
		public uint[] tagPenalties
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static PathRequestSettings Default => default(PathRequestSettings);

		public NearestNodeConstraint ToNearestNodeConstraint()
		{
			return default(NearestNodeConstraint);
		}

		public TraversalConstraint ToTraversalConstraint()
		{
			return default(TraversalConstraint);
		}

		public TraversalCosts ToTraversalCosts()
		{
			return default(TraversalCosts);
		}

		public bool Equals(PathRequestSettings other)
		{
			return false;
		}
	}
}
