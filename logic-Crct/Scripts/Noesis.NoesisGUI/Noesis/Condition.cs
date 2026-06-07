using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Condition : BaseComponent
	{
		public BindingBase Binding
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

		internal new static Condition CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Condition(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Condition obj)
		{
			return default(HandleRef);
		}

		public Condition()
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
