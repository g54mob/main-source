using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Trigger : TriggerBase
	{
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

		public SetterBaseCollection Setters => null;

		public string SourceName
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

		internal new static Trigger CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Trigger(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Trigger obj)
		{
			return default(HandleRef);
		}

		public Trigger()
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
