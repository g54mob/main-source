using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("EventInteractionTypeFloatDictionary", "")]
	public class EventInteractionTypeFloatDictionary : SerializableDictionary<EventInteractionType, float>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.WriteEnum("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public EventInteractionTypeFloatDictionary()
		{
		}

		public EventInteractionTypeFloatDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadEnumArray<EventInteractionType>("keys");
			base.Values = deserializer.ReadFloatArray("values");
			OnAfterDeserialize();
		}
	}
}
