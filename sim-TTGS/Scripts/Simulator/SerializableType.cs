using System;
using UnityEngine;

[Serializable]
public class SerializableType : ISerializationCallbackReceiver
{
	[SerializeField]
	private string assemblyQualifiedName = string.Empty;

	public Type Type { get; private set; }

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		assemblyQualifiedName = Type?.AssemblyQualifiedName ?? assemblyQualifiedName;
	}

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
		if (!TryGetType(assemblyQualifiedName, out var type))
		{
			Debug.LogError("Type " + assemblyQualifiedName + " not found");
		}
		else
		{
			Type = type;
		}
	}

	private static bool TryGetType(string typeString, out Type type)
	{
		type = Type.GetType(typeString);
		if (!(type != null))
		{
			return !string.IsNullOrEmpty(typeString);
		}
		return true;
	}

	public static implicit operator Type(SerializableType sType)
	{
		return sType.Type;
	}

	public static implicit operator SerializableType(Type type)
	{
		return new SerializableType
		{
			Type = type
		};
	}
}
