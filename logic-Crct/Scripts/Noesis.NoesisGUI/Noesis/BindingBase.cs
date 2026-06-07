using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class BindingBase : MarkupExtension
	{
		public int Delay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public object TargetNullValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object FallbackValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string StringFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal BindingBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BindingBase obj)
		{
			return default(HandleRef);
		}

		protected BindingBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
