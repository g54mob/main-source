using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class CraftExpressionContext
	{
		private PayloadRequirement _parentPayloadRequirement;

		public double Altitude => CraftNode.Altitude;

		public double AltitudeAGL => CraftNode.AltitudeAgl;

		public double Apoapsis => CraftNode.Orbit.ApoapsisDistance - CraftNode.Parent.PlanetData.Radius;

		public bool CanWarp => CraftNode.CanWarp;

		public ICraftNode CraftNode { get; set; }

		public double Eccentricity => CraftNode.Orbit.Eccentricity;

		public bool Grounded => CraftNode.InContactWithPlanet;

		public bool HasCommandPod => CraftNode.HasCommandPod;

		public double Inclination => CraftNode.Orbit.Inclination * 57.29578;

		public bool InWater => CraftNode.InContactWithWater;

		public bool IsPlayer => CraftNode.IsPlayer;

		public float Mass => CraftNode.CraftMass;

		public int NumAstronauts => CraftNode.CraftScript?.NumAstronauts ?? 0;

		public int PartCount => CraftNode.CraftPartCount;

		public bool PayloadActivated => _parentPayloadRequirement?.Part?.Data?.Activated == true;

		public double Periapsis => CraftNode.Orbit.PeriapsisDistance - CraftNode.Parent.PlanetData.Radius;

		public double SurfaceVelocity => CraftNode.SurfaceVelocity.magnitude;

		public double Velocity => CraftNode.Velocity.magnitude;

		public CraftExpressionContext(PayloadRequirement parentPayloadRequirement)
		{
			_parentPayloadRequirement = parentPayloadRequirement;
		}
	}
}
