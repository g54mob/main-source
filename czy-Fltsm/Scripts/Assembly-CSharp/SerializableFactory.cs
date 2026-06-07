using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;

public static class SerializableFactory
{
	private static Dictionary<SerializationMarkers, ISerializableInstantiator> _instantiators;

	public static void RegisterInstantiator<T>() where T : SerializableBase, new()
	{
		SerializationMarkers marker = new T().Marker;
		if (_instantiators == null)
		{
			_instantiators = new Dictionary<SerializationMarkers, ISerializableInstantiator>();
		}
		if (_instantiators.ContainsKey(marker))
		{
			Debugger.Error("SerialiableInstantiators " + typeof(T)?.ToString() + " and " + _instantiators[marker]?.ToString() + " have duplicate serialization markers");
		}
		else
		{
			_instantiators.Add(marker, new SerializableInstantiator<T>());
		}
	}

	public static SerializableBase ReturnInstance(SerializationMarkers marker)
	{
		if (_instantiators == null)
		{
			throw new Exception("No serialiable instantiators have been registered with the SerialiableFactory.");
		}
		if (_instantiators.TryGetValue(marker, out var value))
		{
			return value.Instantiate();
		}
		Debugger.Error("No serializable instantiator found for serialization marker (" + marker.ToString() + ")!");
		return null;
	}
}
