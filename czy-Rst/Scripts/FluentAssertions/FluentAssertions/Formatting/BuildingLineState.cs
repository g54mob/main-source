using System.Text;

namespace FluentAssertions.Formatting
{
	internal class BuildingLineState : ILineState
	{
		private StringBuilder builder = new StringBuilder();

		public int Length => builder.Length;

		public ILineState Flush()
		{
			FlushedLineState result = new FlushedLineState(builder.ToString());
			builder = null;
			return result;
		}

		public void Append(string fragment)
		{
			builder.Append(fragment);
		}

		public void InsertAtStart(string fragment)
		{
			builder.Insert(0, fragment);
		}

		public void InsertAt(int startIndex, string fragment)
		{
			builder.Insert(startIndex, fragment);
		}

		public Line Truncate(int characterIndex, int indentation, int whitespaceOffset)
		{
			return null;
		}

		public string Render()
		{
			return builder.ToString();
		}
	}
}
