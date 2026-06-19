using System;
using System.IO;
using System.Text;

namespace SharpConfig
{
	internal static class ConfigurationWriter
	{
		private class NonClosingBinaryWriter : BinaryWriter
		{
			public NonClosingBinaryWriter(Stream stream)
				: base(stream)
			{
			}

			protected override void Dispose(bool disposing)
			{
			}
		}

		internal static void WriteToStreamTextual(Configuration cfg, Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (encoding == null)
			{
				encoding = new UTF8Encoding();
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (Section item in cfg)
			{
				if (!flag)
				{
					stringBuilder.AppendLine();
				}
				if (!flag && item.PreComment != null)
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.AppendLine(item.ToString(includeComments: true));
				foreach (Setting item2 in item)
				{
					stringBuilder.AppendLine(item2.ToString(includeComments: true));
				}
				flag = false;
			}
			string text = stringBuilder.ToString();
			byte[] array = new byte[encoding.GetByteCount(text)];
			int bytes = encoding.GetBytes(text, 0, text.Length, array, 0);
			stream.Write(array, 0, bytes);
			stream.Flush();
		}

		internal static void WriteToStreamBinary(Configuration cfg, Stream stream, BinaryWriter writer)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (writer == null)
			{
				writer = new NonClosingBinaryWriter(stream);
			}
			writer.Write(cfg.SectionCount);
			foreach (Section item in cfg)
			{
				writer.Write(item.Name);
				writer.Write(item.SettingCount);
				WriteCommentsBinary(writer, item);
				foreach (Setting item2 in item)
				{
					writer.Write(item2.Name);
					writer.Write(item2.StringValue);
					WriteCommentsBinary(writer, item2);
				}
			}
			writer.Close();
		}

		private static void WriteCommentsBinary(BinaryWriter writer, ConfigurationElement element)
		{
			writer.Write(element.Comment != null);
			if (element.Comment != null)
			{
				writer.Write(' ');
				writer.Write(element.Comment);
			}
			writer.Write(element.PreComment != null);
			if (element.PreComment != null)
			{
				writer.Write(' ');
				writer.Write(element.PreComment);
			}
		}
	}
}
