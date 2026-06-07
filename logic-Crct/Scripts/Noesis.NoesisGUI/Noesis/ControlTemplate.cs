using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ControlTemplate : FrameworkTemplate
	{
		public Type TargetType
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

		internal new static ControlTemplate CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ControlTemplate(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ControlTemplate obj)
		{
			return default(HandleRef);
		}

		public ControlTemplate()
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
