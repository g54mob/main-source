using System;
using UnityEngine;

namespace CareBoo.Serially
{
	[Serializable]
	public class SerializableType : ISerializationCallbackReceiver
	{
		[SerializeField]
		protected string typeId = string.Empty;

		public string TypeNotFoundError => "Could not find type for typeId[" + typeId + "] when trying to deserialize this SerializableType.";

		public Type Type { get; set; }

		public SerializableType()
		{
		}

		public SerializableType(Type type)
		{
			Type = type;
		}

		public static implicit operator bool(SerializableType p_type)
		{
			return (object)p_type.Type != null;
		}

		public static implicit operator Type(SerializableType p_type)
		{
			return p_type.Type;
		}

		public static bool TryGetType(string typeString, out Type type)
		{
			type = Type.GetType(typeString);
			if (!(type != null))
			{
				return string.IsNullOrEmpty(typeString);
			}
			return true;
		}

		public static string ToSerializedType(Type type)
		{
			if (type == null)
			{
				return string.Empty;
			}
			return type.AssemblyQualifiedName;
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (!TryGetType(typeId, out var type))
			{
				Debug.LogError(TypeNotFoundError);
			}
			Type = type;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			string value = ToSerializedType(Type);
			if (!string.IsNullOrEmpty(value))
			{
				typeId = value;
			}
		}
	}
}
