using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class DistanceValidator : Validator
	{
		[Tooltip("Maximum allowed distance to the nearest edge.")]
		public float MaxDistance = 10f;

		[NonSerialized]
		public IList<Vector3> PathPoints;

		[NonSerialized]
		public Vector3 Position;

		[NonSerialized]
		public int EdgeIndex = -1;

		public override bool Validate()
		{
			if (PathPoints == null || PathPoints.Count < 2)
			{
				return false;
			}
			if (EdgeIndex < 0 || EdgeIndex > PathPoints.Count - 2)
			{
				EdgeIndex = Mathv.GetNearestEdge(PathPoints, Position, MaxDistance);
			}
			if (Vector3.Distance(Mathv.ProjectPointOnLine(Position, PathPoints[EdgeIndex], PathPoints[EdgeIndex + 1]), Position) > MaxDistance)
			{
				return false;
			}
			return true;
		}
	}
}
