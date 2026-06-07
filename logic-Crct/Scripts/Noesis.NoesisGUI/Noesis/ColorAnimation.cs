using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColorAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public Color? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ColorAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColorAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ColorAnimation obj)
		{
			return default(HandleRef);
		}

		public ColorAnimation()
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
