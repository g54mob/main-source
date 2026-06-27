using System;

namespace FluentAssertions.Formatting
{
	internal class Line
	{
		private int indentation;

		private ILineState state;

		private int whitespaceOffset;

		public int Length => state.Length;

		public int LengthWithoutOffset => Length - whitespaceOffset;

		public Line(int indentation)
		{
			state = new BuildingLineState();
			this.indentation = indentation;
		}

		public Line(string content)
		{
			state = new FlushedLineState(content);
		}

		public Line(string truncatedContent, int indentation, int whitespaceOffset)
		{
			state = new FlushedLineState(truncatedContent);
			this.indentation = indentation;
			this.whitespaceOffset = whitespaceOffset;
		}

		public void Flush()
		{
			state = state.Flush();
		}

		public void Append(string fragment)
		{
			state.Append(fragment);
		}

		public void InsertAtStart(string fragment)
		{
			state.InsertAtStart(fragment);
		}

		public void Insert(int characterIndex, string fragment)
		{
			int startIndex = Math.Min(characterIndex + whitespaceOffset, Length);
			state.InsertAt(startIndex, fragment);
		}

		public void EnsureWhitespace()
		{
			if (indentation > 0)
			{
				string text = FormattedObjectGraph.MakeWhitespace(indentation);
				whitespaceOffset = text.Length;
				state.InsertAt(0, text);
				indentation = 0;
			}
		}

		public Line Truncate(int characterIndex)
		{
			Flush();
			return state.Truncate(characterIndex, indentation, whitespaceOffset);
		}

		public override string ToString()
		{
			return state.Render().TrimEnd(Array.Empty<char>());
		}
	}
}
