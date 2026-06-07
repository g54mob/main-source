using System;

namespace DV.ThingTypes
{
	public abstract class Thing_v2_from_v1_enum<Tv1> : Thing_v2 where Tv1 : Enum
	{
		public Tv1 v1;
	}
}
