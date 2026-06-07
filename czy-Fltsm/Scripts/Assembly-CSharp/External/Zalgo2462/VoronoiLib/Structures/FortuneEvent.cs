using System;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	internal interface FortuneEvent : IComparable<FortuneEvent>
	{
		double X { get; }

		double Y { get; }
	}
}
