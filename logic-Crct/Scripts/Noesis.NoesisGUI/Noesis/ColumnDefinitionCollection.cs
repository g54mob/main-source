using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColumnDefinitionCollection : UICollection<ColumnDefinition>
	{
		internal new static ColumnDefinitionCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColumnDefinitionCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ColumnDefinitionCollection obj)
		{
			return default(HandleRef);
		}

		public ColumnDefinitionCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
