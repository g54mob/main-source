using System;

namespace Mono.Unix.Native
{
	[Map("struct pollfd")]
	public struct Pollfd : IEquatable<Pollfd>
	{
		public int fd;

		[CLSCompliant(false)]
		public PollEvents events;

		[CLSCompliant(false)]
		public PollEvents revents;

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Pollfd value)
		{
			return false;
		}
	}
}
