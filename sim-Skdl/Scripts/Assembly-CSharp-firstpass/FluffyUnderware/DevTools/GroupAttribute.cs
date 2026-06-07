namespace FluffyUnderware.DevTools
{
	public class GroupAttribute : DTAttribute, IDTGroupParsingAttribute, IDTGroupRenderAttribute
	{
		public bool Expanded;

		public bool Invisible;

		public string Label;

		public string Tooltip;

		public string HelpURL;

		private string mPath;

		public string Path
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public bool PathIsAbsolute { get; private set; }

		public GroupAttribute(string pathAndName)
			: base(0)
		{
		}
	}
}
