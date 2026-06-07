using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataTrigger : TriggerBase
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

		public SetterBaseCollection Setters => null;

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

		internal new static DataTrigger CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DataTrigger(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataTrigger obj)
		{
			return default(HandleRef);
		}

		public DataTrigger()
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
