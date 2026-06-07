using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int16Animation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public short? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public short? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public short? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Int16Animation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int16Animation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int16Animation obj)
		{
			return default(HandleRef);
		}

		public Int16Animation()
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
