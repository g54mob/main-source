namespace Dhs5.Utility.Databases
{
	public class FolderStructureGroupEntry : FolderStructureEntry
	{
		public bool Open { get; private set; }

		public FolderStructureGroupEntry(string content, int level, FolderStructureGroupEntry group, object data = null)
			: base(content, level, group, data)
		{
			base.IsGroup = true;
		}

		public void SetOpen(bool open)
		{
			Open = open;
		}
	}
}
