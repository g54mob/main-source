namespace FluentAssertions.Formatting
{
	internal interface ILineState
	{
		int Length { get; }

		ILineState Flush();

		void Append(string fragment);

		void InsertAtStart(string fragment);

		void InsertAt(int startIndex, string fragment);

		Line Truncate(int characterIndex, int indentation, int whitespaceOffset);

		string Render();
	}
}
