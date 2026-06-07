using System;
using System.Collections.Generic;

namespace Mirage.NetworkProfiler
{
	[Serializable]
	public class Frame
	{
		public List<MessageInfo> Messages = new List<MessageInfo>();

		public int Bytes;
	}
}
