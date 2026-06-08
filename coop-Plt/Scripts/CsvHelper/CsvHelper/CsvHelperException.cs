using System;
using System.Text;

namespace CsvHelper
{
	[Serializable]
	public class CsvHelperException : Exception
	{
		[NonSerialized]
		private readonly CsvContext context;

		public CsvContext Context => context;

		protected internal CsvHelperException()
		{
		}

		protected internal CsvHelperException(string message)
			: base(message)
		{
		}

		protected internal CsvHelperException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public CsvHelperException(CsvContext context)
		{
			this.context = context;
		}

		public CsvHelperException(CsvContext context, string message)
			: base(AddDetails(message, context))
		{
			this.context = context;
		}

		public CsvHelperException(CsvContext context, string message, Exception innerException)
			: base(AddDetails(message, context), innerException)
		{
			this.context = context;
		}

		private static string AddDetails(string message, CsvContext context)
		{
			string text = new string(' ', 3);
			StringBuilder stringBuilder = new StringBuilder();
			if (context.Reader != null)
			{
				stringBuilder.AppendLine("IReader state:");
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "ColumnCount", context.Reader.ColumnCount));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "CurrentIndex", context.Reader.CurrentIndex));
				try
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					if (context.Reader.HeaderRecord != null)
					{
						stringBuilder2.Append("[\"");
						stringBuilder2.Append(string.Join("\",\"", context.Reader.HeaderRecord));
						stringBuilder2.Append("\"]");
					}
					stringBuilder.AppendLine(string.Format("{0}{1}:{2}{3}", text, "HeaderRecord", Environment.NewLine, stringBuilder2));
				}
				catch
				{
				}
			}
			if (context.Parser != null)
			{
				stringBuilder.AppendLine("IParser state:");
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "ByteCount", context.Parser.ByteCount));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "CharCount", context.Parser.CharCount));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "Row", context.Parser.Row));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "RawRow", context.Parser.RawRow));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "Count", context.Parser.Count));
				try
				{
					string text2 = (context.Configuration.ExceptionMessagesContainRawData ? context.Parser.RawRecord : "Hidden because ExceptionMessagesContainRawData is false.");
					stringBuilder.AppendLine(text + "RawRecord:" + Environment.NewLine + text2);
				}
				catch
				{
				}
			}
			if (context.Writer != null)
			{
				stringBuilder.AppendLine("IWriter state:");
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "Row", context.Writer.Row));
				stringBuilder.AppendLine(string.Format("{0}{1}: {2}", text, "Index", context.Writer.Index));
				StringBuilder stringBuilder3 = new StringBuilder();
				if (context.Writer.HeaderRecord != null)
				{
					stringBuilder3.Append("[");
					if (context.Writer.HeaderRecord.Length != 0)
					{
						stringBuilder3.Append("\"");
						stringBuilder3.Append(string.Join("\",\"", context.Writer.HeaderRecord));
						stringBuilder3.Append("\"");
					}
					stringBuilder3.Append("]");
				}
				stringBuilder.AppendLine(string.Format("{0}{1}:{2}{3}", text, "HeaderRecord", Environment.NewLine, context.Writer.Row));
			}
			return $"{message}{Environment.NewLine}{stringBuilder}";
		}
	}
}
