using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Seek : RadiusSteeringBehaviour
	{
		public bool ForEachReceptor;

		protected override bool forEachPercept => !ForEachReceptor;

		protected override bool forEachReceptor => ForEachReceptor;

		protected override void PerceptSteering()
		{
			ResultDirection = startDirection;
			ResultMagnitude = startMagnitude;
		}

		protected override void ReceptorSteering()
		{
			ResultDirection = percept.Position - self.Position - structure.Position;
			ResultMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius + percept.Radius, OuterRadius + percept.Radius, ResultDirection.magnitude);
		}
	}
}
