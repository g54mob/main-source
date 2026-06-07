namespace System
{
	public class TodoException : Exception
	{
		public string Todo { get; }

		public TodoException(string todo)
		{
			Todo = todo;
		}
	}
}
