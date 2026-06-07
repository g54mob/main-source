using System;
using ModApi.Flight.Sim;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public abstract class OrbitRequirement : LevelRequirement
	{
		private IPlanetNode _planet;

		protected Func<double, string> DisplayGetter { get; set; }

		protected TargetRange TargetRange { get; set; }

		protected Func<IOrbit, double> ValueGetter { get; set; }

		public OrbitRequirement(ILevel level)
			: base(level)
		{
		}

		protected static string FormatAngle(double angle)
		{
			return angle.ToString("n°");
		}

		protected string FormatAltitude(double altitude)
		{
			if (altitude > 0.0 && altitude < _planet.SphereOfInfluence)
			{
				return Units.GetDistanceString((float)altitude);
			}
			return "N/A";
		}

		protected double GetApsisAltitude(double apsis)
		{
			if (apsis > 0.0 && apsis < _planet.SphereOfInfluence)
			{
				return apsis - _planet.PlanetData.Radius;
			}
			return 0.0;
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			LevelRequirementStatus status = LevelRequirementStatus.Incomplete;
			base.DisplayValue = "N/A";
			_planet = base.Level.PlayerCraft.CraftNode.Parent;
			double num = ValueGetter(base.Level.PlayerCraft.CraftNode.Orbit);
			if (TargetRange.IsValid(num))
			{
				status = LevelRequirementStatus.Pass;
			}
			base.DisplayValue = DisplayGetter(num);
			base.Status = status;
		}
	}
}
