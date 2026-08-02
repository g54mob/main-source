using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Adjust : RadiusSteeringBehaviour
	{
		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (base.StartSteering())
			{
				if (VectorProjection == VectorProjectionType.PlaneXY)
				{
					ResultDirection = percept.Rotation * Vector3.up;
				}
				else
				{
					ResultDirection = percept.Rotation * Vector3.forward;
				}
				ResultMagnitude = startMagnitude;
				return true;
			}
			return false;
		}
	}
}
