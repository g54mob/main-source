using System;

public interface IStorableTypeHandlerRegistry
{
	void RegisterHandler<T>(IStorableTypeHandler storableTypeHandler) where T : IStorable;

	IStorableTypeHandler GetHandlerForType(Type storableType);

	IStorableTypeHandler GetHandlerForFilename(string filename, out string playerId, out string deviceId);
}
