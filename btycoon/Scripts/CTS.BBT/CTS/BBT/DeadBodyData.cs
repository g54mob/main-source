using System;
using CTS.BBT.AI;

namespace CTS.BBT
{
	public struct DeadBodyData : IEquatable<DeadBodyData>
	{
		public Guid Identifier;

		public string FirstName;

		public string LastName;

		public int Credibility;

		public ESubSpecies Type;

		public int BloodQuality;

		public int Money;

		public VigilanceMultipliersData VigilanceData;

		public DeadBodyData(Customer customer)
		{
			FirstName = customer.agentFirstName;
			LastName = customer.agentName;
			Credibility = customer.Credibility;
			Type = customer.CustomerType;
			BloodQuality = customer.BloodQuality;
			Money = customer.Money;
			VigilanceData = customer.VigilanceMultipliersData;
			Identifier = customer.LifeGuid;
		}

		public static implicit operator DeadBodyData(Customer customer)
		{
			return new DeadBodyData(customer);
		}

		public static bool operator ==(DeadBodyData data1, DeadBodyData data2)
		{
			return data1.Equals(data2);
		}

		public static bool operator !=(DeadBodyData data1, DeadBodyData data2)
		{
			return !data1.Equals(data2);
		}

		public bool Equals(DeadBodyData other)
		{
			return Identifier == other.Identifier;
		}

		public override bool Equals(object obj)
		{
			if (obj is DeadBodyData other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Identifier.GetHashCode();
		}
	}
}
