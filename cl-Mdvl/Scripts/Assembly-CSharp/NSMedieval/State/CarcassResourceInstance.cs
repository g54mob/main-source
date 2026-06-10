using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("CarcassResourceInstance", "")]
	public class CarcassResourceInstance : ResourceInstance
	{
		[SerializeField]
		private CreatureBase owner;

		[SerializeField]
		private string bodyType;

		[SerializeField]
		private List<ResourceInstance> inventory;

		public CreatureBase Owner => owner;

		public string BodyType => bodyType;

		public List<ResourceInstance> Inventory => inventory;

		public CarcassResourceInstance(CreatureBase owner, Resource blueprint, int amount)
			: base(blueprint, amount, owner)
		{
			this.owner = owner;
			inventory = new List<ResourceInstance>();
			bodyType = (base.BlueprintId.Contains("enemy") ? "enemy" : "worker");
			SetLocalizedInheritedName(owner.GetFullName());
		}

		public CarcassResourceInstance(CreatureBase owner, Resource blueprint, int amount, string bodyType)
			: base(blueprint, amount, owner)
		{
			this.owner = owner;
			inventory = new List<ResourceInstance>();
			this.bodyType = bodyType;
			SetLocalizedInheritedName(owner.GetFullName());
		}

		public override void Dispose()
		{
			owner = null;
			foreach (ResourceInstance item in inventory)
			{
				item.Dispose();
			}
			inventory.Clear();
			inventory = null;
			base.Dispose();
		}

		public string GetName()
		{
			if (owner == null)
			{
				return string.Empty;
			}
			if (owner is HumanoidInstance humanoidInstance && humanoidInstance.IsNpc())
			{
				return UiUtils.GetNPCName(humanoidInstance);
			}
			return owner.GetFullName();
		}

		public void SaveClonedInventory(List<ResourceInstance> inventoryToClone)
		{
			foreach (ResourceInstance item in inventory)
			{
				item.Dispose();
			}
			inventory.Clear();
			foreach (ResourceInstance item2 in inventoryToClone)
			{
				inventory.Add(item2.Clone());
			}
		}

		public void AddToInventory(ResourceInstance item)
		{
			inventory.Add(item);
		}

		public void RemoveFromInventory(ResourceInstance item)
		{
			inventory.Remove(item);
		}

		public override ResourceInstance Clone(int overrideAmount = -1)
		{
			CarcassResourceInstance carcassResourceInstance = new CarcassResourceInstance(Owner, base.Blueprint, (overrideAmount >= 0) ? overrideAmount : base.Amount);
			carcassResourceInstance.CloneStatsCurrent(base.Stats);
			carcassResourceInstance.SetLocalizedInheritedName(base.LocalizedInheritedName);
			carcassResourceInstance.SetFaction(factionOwnership);
			carcassResourceInstance.SaveClonedInventory(inventory);
			return carcassResourceInstance;
		}

		public void DropInventory(Vec3Int gridPosition)
		{
			foreach (ResourceInstance item in inventory)
			{
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item.Clone(), GridUtils.GetWorldPosition(gridPosition));
			}
			inventory.Clear();
		}

		public static CarcassResourceInstance MergeResources(CarcassResourceInstance first, CarcassResourceInstance second)
		{
			CarcassResourceInstance carcassResourceInstance = new CarcassResourceInstance(first.Owner, first.Blueprint, first.Amount + second.Amount);
			foreach (KeyValuePair<StatType, StatInstance> stat in carcassResourceInstance.Stats.Stats)
			{
				float mergedValue = GetMergedValue(first, second, stat.Value.Current, second.GetStatValue(stat.Key));
				stat.Value.SetCurrent(mergedValue);
			}
			carcassResourceInstance.SetLocalizedInheritedName(second.LocalizedInheritedName);
			return carcassResourceInstance;
		}

		public static float GetMergedValue(CarcassResourceInstance first, CarcassResourceInstance second, float firstValue, float secondValue)
		{
			if (first.BlueprintId != second.BlueprintId)
			{
				return firstValue;
			}
			return firstValue * ((float)first.Amount / (float)(first.Amount + second.Amount)) + secondValue * ((float)second.Amount / (float)(first.Amount + second.Amount));
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("owner", owner);
			serializer.Write("bodyType", bodyType);
			serializer.Write("inventory", inventory);
		}

		public CarcassResourceInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			owner = deserializer.ReadObject<CreatureBase>("owner");
			bodyType = deserializer.ReadString("bodyType");
			bodyType = (base.BlueprintId.Contains("enemy") ? "enemy" : "worker");
			inventory = deserializer.ReadObjectList<ResourceInstance>("inventory") ?? new List<ResourceInstance>();
			foreach (ResourceInstance item in inventory)
			{
				if (item.Stats == null)
				{
					MonoSingleton<GlobalSaveController>.Instance.CorruptedCarcassEquipment.Add(item);
					continue;
				}
				item.Stats.SetOwnerOnStats();
				ResourceStatsProducer.ProduceResourceStats(item, item.Blueprint, item.Stats);
			}
		}
	}
}
