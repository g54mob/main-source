using System;
using System.Linq;

namespace FluentAssertions.Formatting
{
	public class FormattedObjectGraph
	{
		private readonly LineCollection lines;

		private Line currentLine;

		internal int Indentation { get; private set; }

		public static int SpacesPerIndentation => 4;

		public int LineCount => lines.Count;

		public FormattedObjectGraph(int maxLines)
		{
			lines = new LineCollection(maxLines);
		}

		public void AddFragmentOnNewLine(string fragment)
		{
			FlushCurrentLine();
			GetCurrentLine().Append(fragment);
		}

		public void AddLineOrFragment(string fragment)
		{
			if (lines.Count == 1)
			{
				AddFragment(fragment);
			}
			else
			{
				AddLine(fragment);
			}
		}

		public void AddLine(string content)
		{
			FlushCurrentLine();
			GetCurrentLine().Append(content);
			FlushCurrentLine();
		}

		public void AddFragment(string fragment)
		{
			GetCurrentLine().Append(fragment);
		}

		private void FlushCurrentLine()
		{
			if (currentLine != null)
			{
				currentLine.Flush();
				currentLine = null;
			}
		}

		private Line GetCurrentLine()
		{
			if (currentLine == null)
			{
				currentLine = new Line(Indentation);
				lines.Add(currentLine);
			}
			if (lines.Count > 1)
			{
				currentLine.EnsureWhitespace();
			}
			return currentLine;
		}

		public IDisposable WithIndentation()
		{
			Indentation++;
			return new Disposable(delegate
			{
				if (Indentation > 0)
				{
					Indentation--;
				}
			});
		}

		internal Anchor GetAnchor()
		{
			if (lines.Count == 0)
			{
				return new Anchor(this, null);
			}
			return new Anchor(this, currentLine ?? lines.Last());
		}

		internal static string MakeWhitespace(int indent)
		{
			return new string(' ', indent * SpacesPerIndentation);
		}

		internal bool HasLinesBeyond(Line line)
		{
			return lines.HasLinesBeyond(line);
		}

		internal void AddLineAfter(Line line, string content)
		{
			lines.AddLineAfter(line, new Line(content));
		}

		internal void InsertAtTop(string content)
		{
			lines.InsertAtTop(new Line(content));
		}

		internal void InsertAtLineStartOrTop(string fragment)
		{
			lines.InsertAtLineStartOrTop(fragment);
		}

		internal void SplitLine(Line line, int characterIndex)
		{
			lines.SplitLine(line, characterIndex);
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, lines.Select((Line line) => line.ToString()));
		}
	}
}
