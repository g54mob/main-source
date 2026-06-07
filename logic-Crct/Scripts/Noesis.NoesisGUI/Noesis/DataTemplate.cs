using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataTemplate : FrameworkTemplate
	{
		public Type DataType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TriggerCollection Triggers => null;

		internal new static DataTemplate CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DataTemplate(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataTemplate obj)
		{
			return default(HandleRef);
		}

		public DataTemplate()
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
