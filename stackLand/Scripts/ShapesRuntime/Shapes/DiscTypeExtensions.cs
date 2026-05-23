namespace Shapes
{
	internal static class DiscTypeExtensions
	{
		public static bool HasThickness(this DiscType type)
		{
			if (type != DiscType.Ring)
			{
				return type == DiscType.Arc;
			}
			return true;
		}

		public static bool HasSector(this DiscType type)
		{
			if (type != DiscType.Pie)
			{
				return type == DiscType.Arc;
			}
			return true;
		}
	}
}
