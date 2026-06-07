using System;

namespace Mirror
{
	public class CommandAttribute : Attribute
	{
		public int channel;

		public bool requiresAuthority;
	}
}
