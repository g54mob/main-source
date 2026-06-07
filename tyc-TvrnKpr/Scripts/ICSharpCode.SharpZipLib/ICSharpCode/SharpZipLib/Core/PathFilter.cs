namespace ICSharpCode.SharpZipLib.Core
{
	public class PathFilter : IScanFilter
	{
		private NameFilter nameFilter_;

		public PathFilter(string filter)
		{
		}

		public virtual bool IsMatch(string name)
		{
			return false;
		}
	}
}
