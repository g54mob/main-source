using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Run : Inline
	{
		public static DependencyProperty TextProperty => null;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Run CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Run(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Run obj)
		{
			return default(HandleRef);
		}

		public Run()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Run(string text)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
