using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Setter : SetterBase
	{
		public string TargetName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DependencyProperty Property
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Setter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Setter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Setter obj)
		{
			return default(HandleRef);
		}

		public Setter()
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
