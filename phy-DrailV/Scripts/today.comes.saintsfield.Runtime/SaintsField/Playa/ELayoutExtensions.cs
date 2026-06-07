namespace SaintsField.Playa
{
	public static class ELayoutExtensions
	{
		public static bool HasFlagFast(this ELayout lhs, ELayout rhs)
		{
			return (lhs & rhs) != 0;
		}
	}
}
