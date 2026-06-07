namespace VoxelBusters.CoreLibrary
{
	public struct URLString
	{
		private string m_value;

		public bool IsValid { get; private set; }

		public bool IsFilePath { get; private set; }

		public static URLString URLWithPath(string path)
		{
			return default(URLString);
		}

		public static URLString FileURLWithPath(string path)
		{
			return default(URLString);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
