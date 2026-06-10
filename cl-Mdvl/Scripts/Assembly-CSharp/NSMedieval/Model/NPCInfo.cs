using System;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("NPCInfo", "EnemyInfo")]
	public class NPCInfo : CharacterInfoBase
	{
		public NPCInfo(BodyType bodyType, int age, float height, float weightCoefficient, Random rnd = null)
			: base(Repository<NameRepository, Names>.Instance.GetFirstName(bodyType, rnd), Repository<NameRepository, Names>.Instance.GetLastName(rnd), bodyType, age, height, weightCoefficient, null)
		{
		}

		public override string GetFullName()
		{
			return base.FirstName + " " + base.LastName;
		}

		public override string GetPhysicalLookKey()
		{
			return "npc_" + base.BodyType.ToString().ToLower();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public NPCInfo(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
