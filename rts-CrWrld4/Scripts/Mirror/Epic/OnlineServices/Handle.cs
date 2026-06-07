using System;

namespace Epic.OnlineServices
{
	public abstract class Handle : IEquatable<Handle>
	{
		public IntPtr InnerHandle { get; internal set; }

		public Handle()
		{
		}

		public Handle(IntPtr innerHandle)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(Handle other)
		{
			return false;
		}

		public static bool operator ==(Handle lhs, Handle rhs)
		{
			return false;
		}

		public static bool operator !=(Handle lhs, Handle rhs)
		{
			return false;
		}
	}
}
