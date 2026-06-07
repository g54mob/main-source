namespace SaintsField
{
	public static class EXPExtensions
	{
		public static bool HasFlagFast(this EXP lhs, EXP rhs)
		{
			return (lhs & rhs) != 0;
		}
	}
}
