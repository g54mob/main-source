using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InertiaExpansionBehavior : IDisposable
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

		public float DesiredExpansion
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal InertiaExpansionBehavior(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InertiaExpansionBehavior obj)
		{
			return default(HandleRef);
		}

		~InertiaExpansionBehavior()
		{
		}

		public virtual void Dispose()
		{
		}

		public InertiaExpansionBehavior()
		{
		}
	}
}
