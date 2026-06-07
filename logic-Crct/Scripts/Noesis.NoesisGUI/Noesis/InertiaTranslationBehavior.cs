using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InertiaTranslationBehavior : IDisposable
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

		public float DesiredDisplacement
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal InertiaTranslationBehavior(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InertiaTranslationBehavior obj)
		{
			return default(HandleRef);
		}

		~InertiaTranslationBehavior()
		{
		}

		public virtual void Dispose()
		{
		}

		public InertiaTranslationBehavior()
		{
		}
	}
}
