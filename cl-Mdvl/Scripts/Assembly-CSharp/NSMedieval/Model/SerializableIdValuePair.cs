using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("IdValuePair", "")]
	public class SerializableIdValuePair : IFVSerializable
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float value;

		public string Id => id;

		public float Value => value;

		public SerializableIdValuePair(string id, float value)
		{
			this.id = id;
			this.value = value;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("value", value);
		}

		public SerializableIdValuePair(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			value = deserializer.ReadFloat("value");
		}
	}
}
