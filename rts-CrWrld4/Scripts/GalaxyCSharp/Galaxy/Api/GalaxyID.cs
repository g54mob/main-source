using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class GalaxyID : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public static readonly ulong UNASSIGNED_VALUE;

		internal GalaxyID(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		public GalaxyID(ulong _value)
		{
		}

		internal static HandleRef getCPtr(GalaxyID obj)
		{
			return default(HandleRef);
		}

		~GalaxyID()
		{
		}

		public virtual void Dispose()
		{
		}

		public static bool operator ==(GalaxyID other1, GalaxyID other2)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		private bool operator_equals(GalaxyID other)
		{
			return false;
		}

		public ulong ToUint64()
		{
			return 0uL;
		}
	}
}
