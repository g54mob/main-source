using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;

namespace FluffyUnderware.Curvy.Examples
{
	public class E98_CurvyCamController : SplineController
	{
		[Section("Curvy Cam", true, false, 100)]
		public float MinSpeed;

		public float MaxSpeed;

		public float Mass;

		public float Down;

		public float Up;

		public float Fric;

		protected override void OnEnable()
		{
		}

		protected override void Advance(float speed, float deltaTime)
		{
		}
	}
}
