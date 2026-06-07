namespace ICSharpCode.SharpZipLib.Core
{
	public class DirectoryEventArgs : ScanEventArgs
	{
		private bool hasMatchingFiles_;

		public bool HasMatchingFiles => false;

		public DirectoryEventArgs(string name, bool hasMatchingFiles)
			: base(null)
		{
		}
	}
}
