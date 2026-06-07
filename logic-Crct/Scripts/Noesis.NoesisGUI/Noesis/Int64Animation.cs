using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int64Animation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public long? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public long? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public long? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Int64Animation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int64Animation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int64Animation obj)
		{
			return default(HandleRef);
		}

		public Int64Animation()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
