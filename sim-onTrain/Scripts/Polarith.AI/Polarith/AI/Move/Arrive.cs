using System;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Arrive : RadiusSteeringBehaviour
	{
		[Tooltip("The default multiplier for the velocity if the agent is outside of the radii interval.")]
		public float BaseMagnitude;

		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			ResultDirection = percept.Position - self.Position;
			sqrInnerRadius = (percept.Radius + InnerRadius) * (percept.Radius + InnerRadius);
			sqrOuterRadius = (percept.Radius + OuterRadius) * (percept.Radius + OuterRadius);
			if (ResultDirection.sqrMagnitude < sqrOuterRadius)
			{
				if (RadiusMapping == MappingType.Linear || RadiusMapping == MappingType.Quadratic || RadiusMapping == MappingType.SquareRoot)
				{
					ResultMagnitude = Mathf2.MapLinear(0f, BaseMagnitude, 0f, 1f, MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius + percept.Radius, OuterRadius + percept.Radius, ResultDirection.magnitude));
				}
				else
				{
					ResultMagnitude = Mathf2.MapLinear(BaseMagnitude, 1f, 0f, 1f, MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius + percept.Radius, OuterRadius + percept.Radius, ResultDirection.magnitude));
				}
			}
			else
			{
				ResultMagnitude = BaseMagnitude;
			}
			return true;
		}
	}
}
