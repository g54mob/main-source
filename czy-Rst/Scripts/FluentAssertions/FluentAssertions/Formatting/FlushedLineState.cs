namespace FluentAssertions.Formatting
{
	internal class FlushedLineState : ILineState
	{
		private string content;

		public int Length => content.Length;

		public FlushedLineState(string content)
		{
			this.content = content;
			base._002Ector();
		}

		public ILineState Flush()
		{
			return this;
		}

		public void Append(string fragment)
		{
			content += fragment;
		}

		public void InsertAtStart(string fragment)
		{
			content = fragment + content;
		}

		public void InsertAt(int startIndex, string fragment)
		{
			content = content.Insert(startIndex, fragment);
		}

		public Line Truncate(int characterIndex, int indentation, int whitespaceOffset)
		{
			string text = content.Substring(characterIndex + whitespaceOffset);
			if (text.Trim().Length > 0)
			{
				content = content.Substring(0, characterIndex + whitespaceOffset);
				return new Line(new string(' ', whitespaceOffset) + text, indentation, whitespaceOffset);
			}
			return null;
		}

		public string Render()
		{
			return content;
		}
	}
}
