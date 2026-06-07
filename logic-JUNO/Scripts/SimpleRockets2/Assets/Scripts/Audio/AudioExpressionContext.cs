using ModApi.Craft;

namespace Assets.Scripts.Audio
{
	public class AudioExpressionContext
	{
		public double ASL => CraftNode.Altitude;

		public double AGL => CraftNode.AltitudeAgl;

		public double Apoapsis => CraftNode.Orbit.ApoapsisDistance - CraftNode.Parent.PlanetData.Radius;

		public ICraftNode CraftNode { get; set; }

		public double Eccentricity => CraftNode.Orbit.Eccentricity;

		public bool Grounded => CraftNode.InContactWithPlanet;

		public double Inclination => CraftNode.Orbit.Inclination * 57.29578;

		public bool InWater => CraftNode.InContactWithWater;

		public double Latitude => CraftNode.LatLon.x;

		public double Longitude => CraftNode.LatLon.y;

		public double Periapsis => CraftNode.Orbit.PeriapsisDistance - CraftNode.Parent.PlanetData.Radius;

		public double SurfaceSpeed => CraftNode.SurfaceVelocity.magnitude;

		public double Speed => CraftNode.Velocity.magnitude;
	}
}
