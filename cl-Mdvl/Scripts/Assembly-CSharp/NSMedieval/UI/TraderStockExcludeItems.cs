using System;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	[FVSerializableKey("TraderStockExcludeItems", "")]
	public class TraderStockExcludeItems : IFVSerializable
	{
		[SerializeField]
		private string type;

		[SerializeField]
		private string value;

		[NonSerialized]
		private TraderStockType typeCache;

		public string Value => value;

		public TraderStockType Type
		{
			get
			{
				if (typeCache == TraderStockType.None)
				{
					typeCache = (TraderStockType)Enum.Parse(typeof(TraderStockType), type, ignoreCase: true);
				}
				return typeCache;
			}
		}

		public TraderStockExcludeItems()
		{
		}

		public bool IsResourceExcluded(Resource resource)
		{
			if (Type == TraderStockType.Group)
			{
				return value.Equals(resource.SortingGroup);
			}
			if (Type == TraderStockType.ProtoId)
			{
				return value.Equals(resource.ProtoId);
			}
			if (Type == TraderStockType.Resource)
			{
				return value.Equals(resource.GetID());
			}
			if (Type == TraderStockType.Material)
			{
				if (!string.IsNullOrEmpty(resource.Material) && Value.Equals(resource.Material))
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public bool IsResourceExcluded(TraderStockResource resource)
		{
			if ((Type == TraderStockType.Animal || Type == TraderStockType.AnimalNoTrade) && resource.Animal != null)
			{
				return value.Equals(resource.Animal.GetID());
			}
			if (resource.Resource == null)
			{
				return false;
			}
			return IsResourceExcluded(resource.Resource);
		}

		public bool IsResourceExcluded(TradeResource resource)
		{
			if ((Type == TraderStockType.Animal || Type == TraderStockType.AnimalNoTrade) && resource.IsCreature && resource.Creature is AnimalInstance animalInstance)
			{
				return value.Equals(animalInstance.Blueprint.GetID());
			}
			if (resource.Resource == null)
			{
				return false;
			}
			return IsResourceExcluded(resource.Resource);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("type", type);
			serializer.Write("value", value);
		}

		public TraderStockExcludeItems(FVDeserializer deserializer)
		{
			type = deserializer.ReadString("type");
			value = deserializer.ReadString("value");
		}
	}
}
