using ModApi.Flight.Sim;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class ApsisRequirement : OrbitRequirement
	{
		public enum ApsisType
		{
			Periapsis = 0,
			Apoapsis = 1
		}

		public ApsisRequirement(ILevel level, ApsisType apsisType, double altitude, double range = 0.0)
			: base(level)
		{
			if (range > 0.0)
			{
				base.Name = $"{apsisType.ToString()} = {Units.GetDistanceString((float)altitude)}";
				base.TargetRange = new TargetRange(altitude, 0.0 - range, range);
			}
			else
			{
				base.Name = $"{apsisType.ToString()} > {Units.GetDistanceString((float)altitude)}";
				base.TargetRange = new TargetRange(altitude, 0.0, double.MaxValue);
			}
			base.DisplayGetter = (double x) => FormatAltitude(x);
			switch (apsisType)
			{
			case ApsisType.Apoapsis:
				base.ValueGetter = (IOrbit x) => GetApsisAltitude(x.ApoapsisDistance);
				break;
			case ApsisType.Periapsis:
				base.ValueGetter = (IOrbit x) => GetApsisAltitude(x.PeriapsisDistance);
				break;
			}
		}
	}
}
