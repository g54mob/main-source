using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DoubleAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public float? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static DoubleAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DoubleAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DoubleAnimation obj)
		{
			return default(HandleRef);
		}

		public DoubleAnimation()
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
