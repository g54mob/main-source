using System;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	internal class FortuneSiteEvent : FortuneEvent, IComparable<FortuneEvent>
	{
		public double X => Site.X;

		public double Y => Site.Y;

		internal FortuneSite Site { get; }

		internal FortuneSiteEvent(FortuneSite site)
		{
			Site = site;
		}

		public int CompareTo(FortuneEvent other)
		{
			int num = Y.CompareTo(other.Y);
			if (num != 0)
			{
				return num;
			}
			return X.CompareTo(other.X);
		}
	}
}
