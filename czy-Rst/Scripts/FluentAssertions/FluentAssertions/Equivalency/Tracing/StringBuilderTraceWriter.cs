using System;
using System.Text;

namespace FluentAssertions.Equivalency.Tracing
{
	public class StringBuilderTraceWriter : ITraceWriter
	{
		private readonly StringBuilder builder = new StringBuilder();

		private int depth = 1;

		public void AddSingle(string trace)
		{
			WriteLine(trace);
		}

		public IDisposable AddBlock(string trace)
		{
			WriteLine(trace);
			WriteLine("{");
			depth++;
			return new Disposable(delegate
			{
				depth--;
				WriteLine("}");
			});
		}

		private void WriteLine(string trace)
		{
			string[] array = SystemExtensions.Split(trace, Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			foreach (string value in array)
			{
				builder.Append(new string(' ', depth * 2)).AppendLine(value);
			}
		}

		public override string ToString()
		{
			return builder.ToString();
		}
	}
}
