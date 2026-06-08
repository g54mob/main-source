using System;
using TwitchLib.Client.Enums;

namespace TwitchLib.Client.Events
{
	public class OnSendReceiveDataArgs : EventArgs
	{
		public SendReceiveDirection Direction;

		public string Data;
	}
}
