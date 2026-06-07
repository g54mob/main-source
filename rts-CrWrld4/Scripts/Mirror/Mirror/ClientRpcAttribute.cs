using System;

namespace Mirror
{
	public class ClientRpcAttribute : Attribute
	{
		public int channel;

		public bool includeOwner;
	}
}
