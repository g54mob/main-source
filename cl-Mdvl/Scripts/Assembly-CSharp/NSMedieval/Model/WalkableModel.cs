using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WalkableModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<int> cantWalkOnTags;

		[SerializeField]
		private string pathfindingPenaltyBlueprint;

		[SerializeField]
		private string walkSpeedMultiplierBlueprint;

		[NonSerialized]
		private PathfindingPenalty pathfindingPenaltyCache;

		[SerializeField]
		private float lockXZRotation;

		[NonSerialized]
		private PathTraversalProvider pathTraversalProvider;

		[NonSerialized]
		private WalkSpeedMultiplier walkSpeedMultiplierCache;

		public List<int> CantWalkOnTags => cantWalkOnTags;

		public PathTraversalProvider StaticTraversalProvider => pathTraversalProvider ?? (pathTraversalProvider = GenerateTraversalProvider());

		public PathfindingPenalty PathfindingPenalty
		{
			get
			{
				if (pathfindingPenaltyCache == null && !string.IsNullOrEmpty(pathfindingPenaltyBlueprint))
				{
					pathfindingPenaltyCache = Repository<PathfindingPenaltyRepository, PathfindingPenalty>.Instance.GetByID(pathfindingPenaltyBlueprint);
				}
				return pathfindingPenaltyCache;
			}
		}

		public WalkSpeedMultiplier WalkSpeedMultiplierBlueprint
		{
			get
			{
				if (walkSpeedMultiplierCache == null && !string.IsNullOrEmpty(walkSpeedMultiplierBlueprint))
				{
					walkSpeedMultiplierCache = Repository<WalkSpeedMultiplierRepository, WalkSpeedMultiplier>.Instance.GetByID(walkSpeedMultiplierBlueprint);
				}
				return walkSpeedMultiplierCache;
			}
		}

		public float LockXZRotation => lockXZRotation;

		public override string GetID()
		{
			return id;
		}

		public PathTraversalProvider GenerateTraversalProvider()
		{
			return new TagTraversalProvider(PathfindingPenalty, GetNonWalkableTags());
		}

		public PathTraversalProvider GenerateTraversalProviderFireWalkable()
		{
			return new TagTraversalProvider(PathfindingPenalty, GetNonWalkableTags(MapNodeTags.Fire));
		}

		public MapNodeTags GetNonWalkableTags(MapNodeTags ignoreTags = MapNodeTags.None)
		{
			MapNodeTags mapNodeTags = MapNodeTags.None;
			if (cantWalkOnTags != null)
			{
				foreach (int cantWalkOnTag in cantWalkOnTags)
				{
					mapNodeTags += (uint)cantWalkOnTag & (uint)(~ignoreTags);
				}
			}
			return mapNodeTags;
		}
	}
}
