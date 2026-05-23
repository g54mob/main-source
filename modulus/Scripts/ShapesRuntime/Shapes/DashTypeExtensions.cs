namespace Shapes
{
	public static class DashTypeExtensions
	{
		public static bool HasModifier(this DashType type)
		{
			return type switch
			{
				DashType.Angled => true, 
				DashType.Chevron => true, 
				_ => false, 
			};
		}
	}
}
