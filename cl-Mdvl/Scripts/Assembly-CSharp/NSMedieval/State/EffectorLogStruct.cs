using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("EffectorLogStruct", "")]
	public struct EffectorLogStruct : IFVSerializable
	{
		[SerializeField]
		private int uniqueId;

		[SerializeField]
		private string creatureName;

		[SerializeField]
		private readonly string effectorId;

		[SerializeField]
		private readonly float effectorValue;

		public string EffectorId => effectorId;

		public float EffectorValue => effectorValue;

		public int UniqueId => uniqueId;

		public string CreatureName => creatureName;

		public EffectorLogStruct(FVDeserializer deserializer)
		{
			uniqueId = deserializer.ReadInt("uniqueId");
			creatureName = deserializer.ReadString("creatureName");
			effectorId = deserializer.ReadString("effectorId");
			effectorValue = deserializer.ReadFloat("effectorValue");
		}

		public EffectorLogStruct(string effectorId, float effectorValue, CreatureBase creatureBase)
		{
			this.effectorId = effectorId;
			this.effectorValue = effectorValue;
			uniqueId = creatureBase.UniqueId;
			creatureName = creatureBase.GetCharacterInfo().GetFullName();
		}

		public EffectorLogStruct(string effectorId, float effectorValue)
		{
			this.effectorId = effectorId;
			this.effectorValue = effectorValue;
			uniqueId = -1;
			creatureName = string.Empty;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("uniqueId", uniqueId);
			serializer.Write("creatureName", creatureName);
			serializer.Write("effectorId", effectorId);
			serializer.Write("effectorValue", effectorValue);
		}
	}
}
