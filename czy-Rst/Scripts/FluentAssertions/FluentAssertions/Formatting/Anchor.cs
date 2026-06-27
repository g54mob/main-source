namespace FluentAssertions.Formatting
{
	internal class Anchor
	{
		private readonly FormattedObjectGraph parent;

		private readonly int indentation;

		private readonly int characterIndex;

		private readonly Line line;

		private readonly bool lineWasEmptyAtCreation;

		public bool UseLineBreaks { get; set; }

		private bool RenderOnSingleLine
		{
			get
			{
				if (!UseLineBreaks)
				{
					return !parent.HasLinesBeyond(line);
				}
				return false;
			}
		}

		public Anchor(FormattedObjectGraph parent, Line line)
		{
			indentation = parent.Indentation;
			this.parent = parent;
			this.line = line;
			lineWasEmptyAtCreation = line == null || line.Length == 0;
			characterIndex = line?.LengthWithoutOffset ?? 0;
		}

		public void InsertFragment(string fragment)
		{
			if (line == null)
			{
				parent.InsertAtLineStartOrTop(fragment);
			}
			else
			{
				line.Insert(characterIndex, fragment);
			}
			if (line != null && !RenderOnSingleLine)
			{
				parent.SplitLine(line, characterIndex + fragment.Length);
			}
		}

		public void InsertLineOrFragment(string fragment)
		{
			if (RenderOnSingleLine)
			{
				if (line == null)
				{
					parent.InsertAtLineStartOrTop(fragment);
				}
				else
				{
					line.Insert(characterIndex, fragment);
				}
				return;
			}
			string content = FormattedObjectGraph.MakeWhitespace(indentation) + fragment;
			if (lineWasEmptyAtCreation)
			{
				parent.InsertAtTop(content);
			}
			else
			{
				parent.AddLineAfter(line, content);
			}
		}

		internal void AddLineOrFragment(string fragment)
		{
			if (line == null)
			{
				parent.AddLineOrFragment(fragment);
			}
			else if (RenderOnSingleLine)
			{
				line.Append(fragment);
			}
			else
			{
				parent.AddLine(fragment);
			}
		}
	}
}
