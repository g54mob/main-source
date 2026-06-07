namespace BestHTTP.Core
{
	public readonly struct RequestEventInfo
	{
		public readonly HTTPRequest SourceRequest;

		public readonly RequestEvents Event;

		public readonly HTTPRequestStates State;

		public readonly long Progress;

		public readonly long ProgressLength;

		public readonly byte[] Data;

		public readonly int DataLength;

		public RequestEventInfo(HTTPRequest request, RequestEvents @event)
		{
			SourceRequest = null;
			Event = default(RequestEvents);
			State = default(HTTPRequestStates);
			Progress = 0L;
			ProgressLength = 0L;
			Data = null;
			DataLength = 0;
		}

		public RequestEventInfo(HTTPRequest request, HTTPRequestStates newState)
		{
			SourceRequest = null;
			Event = default(RequestEvents);
			State = default(HTTPRequestStates);
			Progress = 0L;
			ProgressLength = 0L;
			Data = null;
			DataLength = 0;
		}

		public RequestEventInfo(HTTPRequest request, RequestEvents @event, long progress, long progressLength)
		{
			SourceRequest = null;
			Event = default(RequestEvents);
			State = default(HTTPRequestStates);
			Progress = 0L;
			ProgressLength = 0L;
			Data = null;
			DataLength = 0;
		}

		public RequestEventInfo(HTTPRequest request, byte[] data, int dataLength)
		{
			SourceRequest = null;
			Event = default(RequestEvents);
			State = default(HTTPRequestStates);
			Progress = 0L;
			ProgressLength = 0L;
			Data = null;
			DataLength = 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
