using System.Collections.Generic;

namespace SkywardRay.FileBrowser
{
	public class SfbFilePanel : SfbPanel
	{
		public SfbEntry prefabFileEntry;

		public SfbEntry prefabFolderEntry;

		public SfbEntry prefabLogicalDriveEntry;

		public override void Init(SfbInternal fileBrowser)
		{
		}

		public new void Repopulate(IEnumerable<SfbFileSystemEntry> entries, bool keepScrollPosition)
		{
		}
	}
}
