using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PointAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public Point? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Point? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Point? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static PointAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PointAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PointAnimation obj)
		{
			return default(HandleRef);
		}

		public PointAnimation()
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
