using System;
using Jundroo.Common.Math;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class Utils
	{
		public static string FormatNumber(float value, UnitType unitType, string format = "#,##0")
		{
			ConvertUnitType(unitType);
			return value.Format(ConvertUnitType(unitType), solo: false, longName: false, format);
		}

		[MoonSharpHidden]
		private static Jundroo.Common.Math.UnitType ConvertUnitType(UnitType unitType)
		{
			return unitType switch
			{
				UnitType.LongDistance => Jundroo.Common.Math.UnitType.LongDistance, 
				UnitType.ShortDistance => Jundroo.Common.Math.UnitType.ShortDistance, 
				UnitType.TinyDistance => Jundroo.Common.Math.UnitType.TinyDistance, 
				UnitType.Speed => Jundroo.Common.Math.UnitType.Speed, 
				UnitType.Mass => Jundroo.Common.Math.UnitType.Mass, 
				UnitType.Force => Jundroo.Common.Math.UnitType.Force, 
				UnitType.Volume => Jundroo.Common.Math.UnitType.Volume, 
				UnitType.Area => Jundroo.Common.Math.UnitType.Area, 
				UnitType.WingLoading => Jundroo.Common.Math.UnitType.WingLoading, 
				_ => throw new ArgumentOutOfRangeException("unitType", $"Unexpected UnitType value: {unitType}"), 
			};
		}
	}
}
