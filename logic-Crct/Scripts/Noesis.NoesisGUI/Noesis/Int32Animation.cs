using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int32Animation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public int? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Int32Animation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int32Animation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int32Animation obj)
		{
			return default(HandleRef);
		}

		public Int32Animation()
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
