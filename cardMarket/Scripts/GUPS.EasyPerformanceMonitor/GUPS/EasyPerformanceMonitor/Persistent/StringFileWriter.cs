using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GUPS.EasyPerformanceMonitor.Persistent
{
	internal class StringFileWriter : AFileWriter<string>
	{
		private object lockObject = new object();

		private int flushCount;

		private StringBuilder stringBuilder;

		private int lineCount;

		private StreamWriter writer;

		public StringFileWriter(string _Path, int _FlushCount = 10)
			: base(_Path)
		{
			flushCount = _FlushCount;
			stringBuilder = new StringBuilder();
			lineCount = 0;
		}

		public override void Write(string _Line)
		{
			lock (lockObject)
			{
				stringBuilder.AppendLine(_Line);
				lineCount++;
			}
			if (lineCount >= flushCount)
			{
				Flush();
			}
		}

		public override async Task WriteAsync(string _Line)
		{
			lock (lockObject)
			{
				stringBuilder.AppendLine(_Line);
				lineCount++;
			}
			if (lineCount >= flushCount)
			{
				await FlushAsync();
			}
		}

		public override void Flush()
		{
			string value = string.Empty;
			lock (lockObject)
			{
				value = stringBuilder.ToString();
				stringBuilder.Clear();
				lineCount = 0;
			}
			lock (lockObject)
			{
				if (writer == null)
				{
					if (!File.Exists(base.Path))
					{
						writer = File.CreateText(base.Path);
					}
					else
					{
						writer = File.AppendText(base.Path);
					}
				}
			}
			writer.Write(value);
			writer.Flush();
		}

		public override async Task FlushAsync()
		{
			string value = string.Empty;
			lock (lockObject)
			{
				value = stringBuilder.ToString();
				stringBuilder.Clear();
				lineCount = 0;
			}
			lock (lockObject)
			{
				if (writer == null)
				{
					if (!File.Exists(base.Path))
					{
						writer = File.CreateText(base.Path);
					}
					else
					{
						writer = File.AppendText(base.Path);
					}
				}
			}
			await writer.WriteAsync(value);
			await writer.FlushAsync();
		}

		public override void Dispose()
		{
			if (writer != null)
			{
				writer.Dispose();
			}
		}
	}
}
