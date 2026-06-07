using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Manipulator : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public ulong touchDevice
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public Point position
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal Manipulator(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(Manipulator obj)
		{
			return default(HandleRef);
		}

		~Manipulator()
		{
		}

		public virtual void Dispose()
		{
		}

		public Manipulator()
		{
		}
	}
}
