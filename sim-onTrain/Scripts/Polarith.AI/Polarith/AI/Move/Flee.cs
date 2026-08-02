using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Flee : Seek
	{
		protected override void PerceptSteering()
		{
			base.PerceptSteering();
			ResultDirection *= -1f;
		}

		protected override void ReceptorSteering()
		{
			base.ReceptorSteering();
			ResultDirection *= -1f;
		}
	}
}
