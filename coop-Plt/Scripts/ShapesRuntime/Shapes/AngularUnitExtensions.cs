using System;

namespace Shapes
{
	public static class AngularUnitExtensions
	{
		public static string[] angUnitToSuffix = new string[3] { "rad", "°", "tr" };

		public static string[] angUnitNames = new string[3] { "Radians", "Degrees", "Turns" };

		public static string[] angUnitNamesShort = new string[3] { "Rad", "Deg", "Turns" };

		public static string Suffix(this AngularUnit unit)
		{
			return angUnitToSuffix[(int)unit];
		}

		public static string Name(this AngularUnit unit)
		{
			return angUnitNames[(int)unit];
		}

		public static string NameShort(this AngularUnit unit)
		{
			return angUnitNamesShort[(int)unit];
		}

		public static float FromRadians(this AngularUnit unit)
		{
			return 1f / unit.ToRadians();
		}

		public static float ToRadians(this AngularUnit unit)
		{
			return unit switch
			{
				AngularUnit.Radians => 1f, 
				AngularUnit.Degrees => (float)Math.PI / 180f, 
				AngularUnit.Turns => (float)Math.PI * 2f, 
				_ => throw new ArgumentOutOfRangeException("unit", unit, null), 
			};
		}
	}
}
