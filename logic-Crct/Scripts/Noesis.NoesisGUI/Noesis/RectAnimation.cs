using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RectAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public Rect? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Rect? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Rect? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static RectAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RectAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RectAnimation obj)
		{
			return default(HandleRef);
		}

		public RectAnimation()
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
