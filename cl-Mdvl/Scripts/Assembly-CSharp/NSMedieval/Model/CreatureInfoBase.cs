using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("CreatureInfoBase", "")]
	public class CreatureInfoBase : IFVSerializable
	{
		[SerializeField]
		private BodyType gender;

		[SerializeField]
		private int age;

		public BodyType BodyType => gender;

		public int Age => age;

		public CreatureInfoBase(BodyType bodyType, int age)
		{
			gender = bodyType;
			this.age = age;
		}

		public CreatureInfoBase()
		{
		}

		public virtual void SetAge(int age)
		{
			this.age = age;
		}

		public void SetGender(BodyType bodyType)
		{
			gender = bodyType;
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.WriteEnum("gender", gender);
			serializer.Write("age", age);
		}

		public CreatureInfoBase(FVDeserializer deserializer)
		{
			gender = deserializer.ReadEnum("gender", BodyType.None);
			age = deserializer.ReadInt("age");
		}
	}
}
