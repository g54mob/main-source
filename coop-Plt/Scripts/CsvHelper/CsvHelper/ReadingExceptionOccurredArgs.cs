namespace CsvHelper
{
	public readonly struct ReadingExceptionOccurredArgs
	{
		public readonly CsvHelperException Exception;

		public ReadingExceptionOccurredArgs(CsvHelperException exception)
		{
			Exception = exception;
		}
	}
}
