using System;
using TwitchLib.Client.Exceptions;

namespace TwitchLib.Client.Events
{
	public class OnIncorrectLoginArgs : EventArgs
	{
		public ErrorLoggingInException Exception;
	}
}
