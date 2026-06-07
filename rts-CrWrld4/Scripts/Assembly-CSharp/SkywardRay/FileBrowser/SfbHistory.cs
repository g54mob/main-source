using System.Collections.Generic;

namespace SkywardRay.FileBrowser
{
	public class SfbHistory
	{
		private List<SfbFileSystemEntry> history;

		private int currentIndex;

		public SfbFileSystemEntry Current()
		{
			return null;
		}

		public void Add(SfbFileSystemEntry entry)
		{
		}

		public SfbFileSystemEntry Previous()
		{
			return null;
		}

		public SfbFileSystemEntry Next()
		{
			return null;
		}

		public void ReportInvalidEntry(SfbFileSystemEntry entry)
		{
		}

		public void Back()
		{
		}

		public void Forward()
		{
		}

		public void Clear()
		{
		}
	}
}
