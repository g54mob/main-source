namespace SaintsField
{
	public static class EPickExtensions
	{
		public static bool HasFlagFast(this EPick lhs, EPick rhs)
		{
			return (lhs & rhs) != 0;
		}
	}
}
