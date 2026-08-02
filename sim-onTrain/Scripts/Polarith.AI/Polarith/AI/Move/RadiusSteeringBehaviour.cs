using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class RadiusSteeringBehaviour : SteeringBehaviour
	{
		[Tooltip("The minimum radius for considering percepts. If a percept lies below this threshold, it is ignored by this behaviour.")]
		public float InnerRadius;

		[Tooltip("The maximum radius for considering percepts. If a percept lies above this threshold, it is ignored by this behaviour.")]
		public float OuterRadius = 20f;

		[Tooltip("Influences how the result magnitude is mapped according to the 'InnerRadius' and 'OuterRadius'.")]
		public MappingType RadiusMapping = MappingType.InverseLinear;

		protected Vector3 startDirection;

		protected float startMagnitude;

		protected float sqrInnerRadius;

		protected float sqrOuterRadius;

		protected override bool StartSteering()
		{
			startDirection = percept.Position - self.Position;
			sqrInnerRadius = (percept.Radius + InnerRadius) * (percept.Radius + InnerRadius);
			sqrOuterRadius = (percept.Radius + OuterRadius) * (percept.Radius + OuterRadius);
			if (startDirection.sqrMagnitude < sqrInnerRadius || startDirection.sqrMagnitude > sqrOuterRadius)
			{
				return false;
			}
			startMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, percept.Radius + InnerRadius, percept.Radius + OuterRadius, startDirection.magnitude);
			return true;
		}
	}
}
