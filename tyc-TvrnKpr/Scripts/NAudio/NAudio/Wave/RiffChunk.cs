namespace NAudio.Wave
{
	public class RiffChunk
	{
		public int Identifier { get; }

		public string IdentifierAsString => null;

		public int Length { get; private set; }

		public long StreamPosition { get; private set; }

		public RiffChunk(int identifier, int length, long streamPosition)
		{
		}
	}
}
