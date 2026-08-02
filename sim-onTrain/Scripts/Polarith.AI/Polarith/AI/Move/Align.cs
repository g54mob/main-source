using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Align : SteeringBehaviour
	{
		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (VectorProjection == VectorProjectionType.PlaneXY)
			{
				ResultDirection = percept.Rotation * Vector3.up;
			}
			else
			{
				ResultDirection = percept.Rotation * Vector3.forward;
			}
			ResultMagnitude = 1f;
			return true;
		}
	}
}
