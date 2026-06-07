using System.Collections.Generic;

public class AvailabilityComparer : IEqualityComparer<BuildObjectAvailability>
{
	public bool Equals(BuildObjectAvailability a, BuildObjectAvailability b)
	{
		return a == b;
	}

	public int GetHashCode(BuildObjectAvailability obj)
	{
		return (int)obj;
	}
}
