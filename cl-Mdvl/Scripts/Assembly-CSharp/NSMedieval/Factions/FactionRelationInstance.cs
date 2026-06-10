using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Factions
{
	[Serializable]
	[FVSerializableKey("FactionRelationInstance", "")]
	public class FactionRelationInstance : IFVSerializable
	{
		[SerializeField]
		private string factionA;

		[SerializeField]
		private string factionB;

		[SerializeField]
		private float friendliness;

		public string FactionA => factionA;

		public string FactionB => factionB;

		public float Friendliness => friendliness;

		public FactionRelationInstance(string factionA, string factionB, float friendliness)
		{
			this.factionA = factionA;
			this.factionB = factionB;
			this.friendliness = friendliness;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("factionA", factionA);
			serializer.Write("factionB", factionB);
			serializer.Write("friendliness", friendliness);
		}

		public FactionRelationInstance(FVDeserializer deserializer)
		{
			factionA = deserializer.ReadString("factionA");
			factionB = deserializer.ReadString("factionB");
			friendliness = deserializer.ReadFloat("friendliness");
		}
	}
}
