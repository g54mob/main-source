namespace BestHTTP.SocketIO
{
	public sealed class Error
	{
		public SocketIOErrors Code { get; private set; }

		public string Message { get; private set; }

		public Error(SocketIOErrors code, string msg)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
