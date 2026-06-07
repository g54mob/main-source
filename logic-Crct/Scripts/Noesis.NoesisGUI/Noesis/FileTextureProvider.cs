using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FileTextureProvider : TextureProvider
	{
		internal new static FileTextureProvider CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FileTextureProvider(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FileTextureProvider obj)
		{
			return default(HandleRef);
		}

		protected FileTextureProvider()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual Stream OpenStream(Uri filename)
		{
			return null;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
