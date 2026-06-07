namespace Tyd
{
	public static class Extensions
	{
		public static bool IsNullValueNode(this TydNode node)
		{
			TydString tydString = node as TydString;
			if (tydString != null)
			{
				return tydString.Value == null;
			}
			return false;
		}
	}
}
