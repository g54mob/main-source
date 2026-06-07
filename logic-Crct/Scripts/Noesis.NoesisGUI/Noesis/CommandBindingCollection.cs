using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CommandBindingCollection : UICollection<CommandBinding>
	{
		internal new static CommandBindingCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CommandBindingCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(CommandBindingCollection obj)
		{
			return default(HandleRef);
		}

		public CommandBindingCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
