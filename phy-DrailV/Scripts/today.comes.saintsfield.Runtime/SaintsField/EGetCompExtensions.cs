namespace SaintsField
{
	public static class EGetCompExtensions
	{
		public static bool HasFlagFast(this EGetComp lhs, EGetComp rhs)
		{
			return (lhs & rhs) != 0;
		}
	}
}
