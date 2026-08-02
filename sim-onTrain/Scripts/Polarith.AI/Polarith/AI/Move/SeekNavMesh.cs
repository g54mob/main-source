using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Move
{
	[Serializable]
	public class SeekNavMesh : RadiusSteeringBehaviour
	{
		private IList<NavMeshHit> hits = new List<NavMeshHit>();

		private Vector3 position;

		private Vector3 direction;

		private float distanceMultiplier;

		private float value;

		public IList<NavMeshHit> NavMeshHits => hits;

		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected virtual float inversion => 1f;

		protected override bool StartSteering()
		{
			for (int i = 0; i < hits.Count; i++)
			{
				if (hits[i].hit && !(hits[i].distance < InnerRadius))
				{
					position = hits[i].position;
					if (VectorProjection == VectorProjectionType.PlaneXZ)
					{
						position.y = 0f;
					}
					direction = position - self.Position;
					distanceMultiplier = MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius, OuterRadius, direction.magnitude);
					for (int j = 0; j < sensor.ReceptorCount; j++)
					{
						structure = sensor.GetReceptor(j).Structure;
						value = (UseSignificance ? percept.Significance : 1f) * structure.Magnitude * ResultMagnitude * MapBySensitivity(ValueMapping, structure, inversion * direction, SensitivityOffset);
						WriteValue(ValueWriting, TargetObjective, j, value * MagnitudeMultiplier * distanceMultiplier, LayerBlending != LayerBlendingType.None);
					}
				}
			}
			return false;
		}
	}
}
