using System;

namespace WebSocketSharp
{
	public class CloseEventArgs : EventArgs
	{
		private PayloadData _payloadData;

		private bool _wasClean;

		public ushort Code => _payloadData.Code;

		public string Reason => _payloadData.Reason;

		public bool WasClean => _wasClean;

		internal CloseEventArgs(PayloadData payloadData, bool clean)
		{
			_payloadData = payloadData;
			_wasClean = clean;
		}
	}
}
