using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MoonSharp.Interpreter;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public abstract class ProtocolServer
	{
		public bool TRACE;

		public bool TRACE_RESPONSE;

		protected const int BUFFER_SIZE = 4096;

		protected const string TWO_CRLF = "\r\n\r\n";

		protected static readonly Regex CONTENT_LENGTH_MATCHER;

		protected static readonly Encoding Encoding;

		private int _sequenceNumber;

		private Stream _outputStream;

		private ByteBuffer _rawData;

		private int _bodyLength;

		private bool _stopRequested;

		public ProtocolServer()
		{
		}

		public void ProcessLoop(Stream inputStream, Stream outputStream)
		{
		}

		public void Stop()
		{
		}

		public void SendEvent(Event e)
		{
		}

		protected abstract void DispatchRequest(string command, Table args, Response response);

		private void ProcessData()
		{
		}

		private void Dispatch(string req)
		{
		}

		protected void SendMessage(ProtocolMessage message)
		{
		}

		private static byte[] ConvertToBytes(ProtocolMessage request)
		{
			return null;
		}
	}
}
