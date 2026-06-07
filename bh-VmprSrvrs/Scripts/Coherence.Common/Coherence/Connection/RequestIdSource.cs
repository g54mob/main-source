namespace Coherence.Connection
{
	public class RequestIdSource
	{
		private int requestCounter;

		private readonly string idBase;

		public (string, string connectionId) IdBaseLogParam => default((string, string));

		public string Next()
		{
			return null;
		}

		public string Next(out int counter)
		{
			counter = default(int);
			return null;
		}

		private int GetNextRequestCounter()
		{
			return 0;
		}
	}
}
