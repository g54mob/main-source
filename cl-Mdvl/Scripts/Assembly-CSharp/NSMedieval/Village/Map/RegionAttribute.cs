using System;

namespace NSMedieval.Village.Map
{
	[Flags]
	public enum RegionAttribute
	{
		None = 0,
		Home = 1,
		Danger = 2,
		AnimalPen = 4,
		Last = 8
	}
}
