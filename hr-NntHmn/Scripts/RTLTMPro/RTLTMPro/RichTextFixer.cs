namespace RTLTMPro
{
	public static class RichTextFixer
	{
		public enum TagType
		{
			None = 0,
			Opening = 1,
			Closing = 2,
			SelfContained = 3
		}

		public struct Tag
		{
			public int Start;

			public int End;

			public int HashCode;

			public TagType Type;

			public Tag(int start, int end, TagType type, int hashCode)
			{
				Start = 0;
				End = 0;
				HashCode = 0;
				Type = default(TagType);
			}
		}

		public static void Fix(FastStringBuilder text)
		{
		}

		public static void FindTag(FastStringBuilder str, int start, out Tag tag)
		{
			tag = default(Tag);
		}
	}
}
