using System.Text;

namespace CTS.Core.Utilities
{
	public static class StringBuilderExtensions
	{
		private static int indent;

		public static void NewLine(this StringBuilder p_builder)
		{
			p_builder.AppendLine("");
		}

		public static void IndentedLine(this StringBuilder p_builder, string p_message)
		{
			p_builder.AppendLine("\t".Repeat(indent) + p_message);
		}

		public static void SetIndent(this StringBuilder p_builder, int p_indent)
		{
			indent = p_indent;
		}
	}
}
