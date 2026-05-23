namespace Shapes
{
	public static class DashTypeExtensions
	{
		public static bool HasModifier(this DashType type)
		{
			if (type == DashType.Angled)
			{
				return true;
			}
			return false;
		}
	}
}
