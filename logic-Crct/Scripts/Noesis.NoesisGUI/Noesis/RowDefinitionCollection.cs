using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RowDefinitionCollection : UICollection<RowDefinition>
	{
		internal new static RowDefinitionCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RowDefinitionCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(RowDefinitionCollection obj)
		{
			return default(HandleRef);
		}

		public RowDefinitionCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
