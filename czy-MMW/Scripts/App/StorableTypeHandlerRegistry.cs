using System;
using System.Collections.Generic;

public class StorableTypeHandlerRegistry : IStorableTypeHandlerRegistry
{
	private readonly Dictionary<Type, IStorableTypeHandler> _typeHandlers = new Dictionary<Type, IStorableTypeHandler>();

	public void RegisterHandler<T>(IStorableTypeHandler storableTypeHandler) where T : IStorable
	{
		_typeHandlers[typeof(T)] = storableTypeHandler;
	}

	public IStorableTypeHandler GetHandlerForType(Type storableType)
	{
		foreach (KeyValuePair<Type, IStorableTypeHandler> typeHandler in _typeHandlers)
		{
			if (typeHandler.Key.IsAssignableFrom(storableType))
			{
				return typeHandler.Value;
			}
		}
		return null;
	}

	public IStorableTypeHandler GetHandlerForFilename(string filename, out string playerId, out string deviceId)
	{
		foreach (IStorableTypeHandler value in _typeHandlers.Values)
		{
			if (value.IsFilenameRecognized(filename, out playerId, out deviceId))
			{
				return value;
			}
		}
		playerId = null;
		deviceId = null;
		return null;
	}
}
