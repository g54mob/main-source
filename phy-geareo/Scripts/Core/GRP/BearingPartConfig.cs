using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class BearingPartConfig : PartConfig
	{
		public int velocity;

		public float simTorque;

		public float simSpring;

		public float simDamper;

		public AnimationCurve simSpringOverAngle;

		public override Thing CreateThing()
		{
			return null;
		}
	}
}
