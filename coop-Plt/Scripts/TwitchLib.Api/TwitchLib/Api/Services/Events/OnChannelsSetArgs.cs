using System;
using System.Collections.Generic;

namespace TwitchLib.Api.Services.Events
{
	public class OnChannelsSetArgs : EventArgs
	{
		public List<string> Channels;
	}
}
