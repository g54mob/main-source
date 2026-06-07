using System.IO;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public static class fsJsonPrinter
	{
		private static void InsertSpacing(TextWriter stream, int count)
		{
		}

		private static string EscapeString(string str)
		{
			return null;
		}

		private static void BuildCompressedString(fsData data, TextWriter stream)
		{
		}

		private static void BuildPrettyString(fsData data, TextWriter stream, int depth)
		{
		}

		public static string ToJson(fsData data, bool pretty)
		{
			return null;
		}

		public static void PrettyJson(fsData data, TextWriter outputStream)
		{
		}

		public static string PrettyJson(fsData data)
		{
			return null;
		}

		public static void CompressedJson(fsData data, StreamWriter outputStream)
		{
		}

		public static string CompressedJson(fsData data)
		{
			return null;
		}

		private static string ConvertDoubleToString(double d)
		{
			return null;
		}
	}
}
