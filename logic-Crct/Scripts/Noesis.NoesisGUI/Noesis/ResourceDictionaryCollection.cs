using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ResourceDictionaryCollection : UICollection<ResourceDictionary>
	{
		internal new static ResourceDictionaryCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ResourceDictionaryCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ResourceDictionaryCollection obj)
		{
			return default(HandleRef);
		}

		public ResourceDictionaryCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
