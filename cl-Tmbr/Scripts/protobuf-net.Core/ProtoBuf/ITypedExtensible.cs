using System;

namespace ProtoBuf
{
	public interface ITypedExtensible
	{
		IExtension GetExtensionObject(Type type, bool createIfMissing);
	}
}
