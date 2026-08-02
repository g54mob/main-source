using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Follow : SteeringBehaviour
	{
		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			ResultDirection = percept.Position - self.Position;
			ResultMagnitude = 1f;
			return true;
		}
	}
}
