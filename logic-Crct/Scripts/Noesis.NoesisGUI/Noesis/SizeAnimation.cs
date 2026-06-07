using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public Size? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Size? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Size? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static SizeAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SizeAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SizeAnimation obj)
		{
			return default(HandleRef);
		}

		public SizeAnimation()
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
