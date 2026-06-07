using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ThicknessAnimation : BaseAnimation
	{
		public static DependencyProperty ByProperty => null;

		public static DependencyProperty FromProperty => null;

		public static DependencyProperty ToProperty => null;

		public Thickness? From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Thickness? To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Thickness? By
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ThicknessAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ThicknessAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ThicknessAnimation obj)
		{
			return default(HandleRef);
		}

		public ThicknessAnimation()
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
