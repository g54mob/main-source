using System.Collections.Generic;

namespace TH20
{
	public class HospitalPlotItemEqualityComparer : IEqualityComparer<HospitalPlotItem>
	{
		public bool Equals(HospitalPlotItem x, HospitalPlotItem y)
		{
			if (x == null || y == null)
			{
				return false;
			}
			return x.Equals(y);
		}

		public int GetHashCode(HospitalPlotItem obj)
		{
			return obj.Position.GetHashCode() ^ obj.Rotation.GetHashCode() ^ obj.Definition.GetHashCode();
		}
	}
}
