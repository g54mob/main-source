namespace SaintsField
{
	public static class EModeExtensions
	{
		public static bool HasFlagFast(this EMode lhs, EMode rhs)
		{
			return (lhs & rhs) != 0;
		}
	}
}
