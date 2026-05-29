namespace AeLa.EasyFeedback.Utility
{
	public static class Markdown
	{
		public enum HeaderLevel
		{
			H1 = 0,
			H2 = 1,
			H3 = 2,
			H4 = 3,
			H5 = 4,
			H6 = 5
		}

		private const string _H1 = "# ";

		private const string _H2 = "## ";

		private const string _H3 = "### ";

		private const string _H4 = "#### ";

		private const string _H5 = "##### ";

		private const string _H6 = "###### ";

		private const string _EM = "*";

		private const string _STRONG = "**";

		private const string _STRIKE = "~~";

		private const string _UL = "- ";

		private const string _OL = ". ";

		private const string _LINK_INLINE_PRE = "[";

		private const string _LINK_INLINE_MID = "](";

		private const string _LINK_INLINE_END = ")";

		private const string _IMG_INLINE_PRE = "![";

		private const string _IMG_INLINE_MID = "](";

		private const string _IMG_INLINE_END = ")";

		private const string _CODE_INLINE = "`";

		private const string _CODE_BLOCK = "```";

		private const string _QUOTE = "> ";

		private const string _HR = "---";

		private const string _ENDL = "\n";

		private const string _LB = "\n\n";

		public const string HR = "---";

		public const string LINE_BREAK = "\n\n";

		public static string Header(string text, HeaderLevel level = HeaderLevel.H1)
		{
			return null;
		}

		public static string H1(string text)
		{
			return null;
		}

		public static string H2(string text)
		{
			return null;
		}

		public static string H3(string text)
		{
			return null;
		}

		public static string H4(string text)
		{
			return null;
		}

		public static string H5(string text)
		{
			return null;
		}

		public static string H6(string text)
		{
			return null;
		}

		public static string Em(string text)
		{
			return null;
		}

		public static string Strong(string text)
		{
			return null;
		}

		public static string Strike(string text)
		{
			return null;
		}

		public static string UnorderedList(string[] items)
		{
			return null;
		}

		public static string OrderedList(string[] items)
		{
			return null;
		}

		public static string Hyperlink(string text, string url)
		{
			return null;
		}

		public static string Image(string url, string alt = "")
		{
			return null;
		}

		public static string Code(string text)
		{
			return null;
		}

		public static string CodeBlock(string text, string language = "")
		{
			return null;
		}

		public static string Blockquote(string text)
		{
			return null;
		}
	}
}
