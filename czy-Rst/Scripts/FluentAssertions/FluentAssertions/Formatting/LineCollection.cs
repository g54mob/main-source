using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Formatting
{
	internal class LineCollection : IEnumerable<Line>, IEnumerable
	{
		private readonly List<Line> lines;

		public int Count => lines.Count;

		public LineCollection(int maxLines)
		{
			_003CmaxLines_003EP = maxLines;
			lines = new List<Line>();
			base._002Ector();
		}

		public bool HasLinesBeyond(Line line)
		{
			if (line != null || lines.Count <= 1)
			{
				if (line != null)
				{
					return lines.IndexOf(line) < lines.Count - 1;
				}
				return false;
			}
			return true;
		}

		public void Add(Line line)
		{
			lines.Add(line);
			OnCollectionIsModified();
		}

		public void AddLineAfter(Line line, Line newLine)
		{
			int num = lines.IndexOf(line);
			Insert(num + 1, newLine);
		}

		public void InsertAtTop(Line newLine)
		{
			Insert(0, newLine);
		}

		public void InsertAtLineStartOrTop(string fragment)
		{
			if (lines.Count == 1)
			{
				lines[0].InsertAtStart(fragment);
			}
			else
			{
				Insert(0, new Line(fragment));
			}
		}

		public void SplitLine(Line line, int characterIndex)
		{
			int num = lines.IndexOf(line);
			Line line2 = line.Truncate(characterIndex);
			if (line2 != null)
			{
				Insert(num + 1, line2);
			}
		}

		private void Insert(int index, Line item)
		{
			lines.Insert(index, item);
			OnCollectionIsModified();
			if (index == 0 && lines.Count > 1)
			{
				lines[1].EnsureWhitespace();
			}
		}

		private void OnCollectionIsModified()
		{
			if (lines.Count > _003CmaxLines_003EP)
			{
				lines.Add(new Line(0));
				lines.Add(new Line($"(Output has exceeded the maximum of {_003CmaxLines_003EP} lines. " + "Increase FormattingOptions.MaxLines on AssertionScope or AssertionConfiguration to include more lines.)"));
				throw new MaxLinesExceededException();
			}
		}

		public IEnumerator<Line> GetEnumerator()
		{
			return lines.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
