using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InertiaRotationBehavior : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public float DesiredDeceleration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DesiredRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal InertiaRotationBehavior(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InertiaRotationBehavior obj)
		{
			return default(HandleRef);
		}

		~InertiaRotationBehavior()
		{
		}

		public virtual void Dispose()
		{
		}

		public InertiaRotationBehavior()
		{
		}
	}
}
