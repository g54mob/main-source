namespace Sirenix.OdinInspector
{
	public sealed class TitleGroupAttribute : PropertyGroupAttribute
	{
		public string Subtitle;

		public TitleAlignments Alignment;

		public bool HorizontalLine;

		public bool BoldTitle;

		public bool Indent;

		public TitleGroupAttribute(string title, string subtitle = null, TitleAlignments alignment = TitleAlignments.Left, bool horizontalLine = true, bool boldTitle = true, bool indent = false, float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
