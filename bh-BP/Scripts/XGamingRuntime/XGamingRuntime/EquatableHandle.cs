using System;

namespace XGamingRuntime
{
	public abstract class EquatableHandle
	{
		internal abstract IntPtr GetInternalPtr();

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(EquatableHandle handle1, EquatableHandle handle2)
		{
			return false;
		}

		public static bool operator !=(EquatableHandle handle1, EquatableHandle handle2)
		{
			return false;
		}
	}
}
