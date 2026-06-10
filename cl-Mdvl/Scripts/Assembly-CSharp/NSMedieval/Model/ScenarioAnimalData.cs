using System;
using NSMedieval.Serialization;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("ScenarioAnimalData", "")]
	public struct ScenarioAnimalData : IFVSerializable
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private BodyType bodyType;

		[SerializeField]
		private int count;

		[SerializeField]
		private int lifePhaseIndex;

		[SerializeField]
		private AnimalType animalType;

		public string ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public BodyType BodyType
		{
			get
			{
				return bodyType;
			}
			set
			{
				bodyType = value;
			}
		}

		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
			}
		}

		public int LifePhaseIndex
		{
			get
			{
				return lifePhaseIndex;
			}
			set
			{
				lifePhaseIndex = value;
			}
		}

		public AnimalType AnimalType
		{
			get
			{
				if (animalType.Equals(AnimalType.DomesticNpc))
				{
					animalType = AnimalType.Domestic;
				}
				return animalType;
			}
			set
			{
				animalType = value;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.WriteEnum("bodyType", bodyType);
			serializer.Write("count", count);
			serializer.Write("lifePhaseIndex", lifePhaseIndex);
			serializer.WriteEnum("animalType", animalType);
		}

		public ScenarioAnimalData(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			bodyType = deserializer.ReadEnum("bodyType", BodyType.None);
			count = deserializer.ReadInt("count");
			lifePhaseIndex = deserializer.ReadInt("lifePhaseIndex");
			animalType = deserializer.ReadEnum("animalType", AnimalType.Domestic);
		}
	}
}
