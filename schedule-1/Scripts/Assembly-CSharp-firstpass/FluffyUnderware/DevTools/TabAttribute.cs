namespace FluffyUnderware.DevTools
{
	public class TabAttribute : GroupAttribute
	{
		public readonly string TabName;

		public readonly string TabBarName;

		public TabAttribute(string pathAndName)
			: base(null)
		{
		}

		private static bool split(string pathAndName, out string path, out string tabBar, out string tabname)
		{
			path = null;
			tabBar = null;
			tabname = null;
			return false;
		}
	}
}
