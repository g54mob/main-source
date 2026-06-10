using System;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("SimpleResourceCount", "")]
	public struct SimpleResourceCount : IEquatable<SimpleResourceCount>, IFVSerializable
	{
		public Resource Blueprint { get; set; }

		public string BlueprintId => Blueprint.GetID();

		public int Amount { get; set; }

		public SimpleResourceCount(Resource blueprint, int amount)
		{
			Blueprint = blueprint;
			Amount = amount;
		}

		public SimpleResourceCount(ResourceInstance resource)
		{
			Blueprint = resource.Blueprint;
			Amount = resource.Amount;
		}

		public SimpleResourceCount Sub(SimpleResourceCount count)
		{
			if (count.Blueprint != Blueprint)
			{
				throw new Exception("SimpleResourceCount Sub blueprints mismatch!");
			}
			return new SimpleResourceCount(Blueprint, Amount - count.Amount);
		}

		public bool Equals(SimpleResourceCount other)
		{
			if (object.Equals(Blueprint, other.Blueprint))
			{
				return Amount == other.Amount;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is SimpleResourceCount other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Blueprint, Amount);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", BlueprintId);
			serializer.Write("amount", Amount);
		}

		public SimpleResourceCount(FVDeserializer deserializer)
		{
			string id = deserializer.ReadString("blueprintId");
			Blueprint = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			Amount = deserializer.ReadInt("amount");
		}
	}
}
