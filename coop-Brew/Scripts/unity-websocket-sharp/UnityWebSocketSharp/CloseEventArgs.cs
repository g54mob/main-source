using System;

namespace UnityWebSocketSharp
{
	internal class CloseEventArgs : EventArgs
	{
		private bool _clean;

		private PayloadData _payloadData;

		public ushort Code => 0;

		public string Reason => null;

		public bool WasClean => false;

		internal CloseEventArgs(PayloadData payloadData, bool clean)
		{
		}
	}
}
