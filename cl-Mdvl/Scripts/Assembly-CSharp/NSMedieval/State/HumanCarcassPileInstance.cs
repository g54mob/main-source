using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("HumanCarcassPileInstance", "")]
	public class HumanCarcassPileInstance : ResourcePileInstance
	{
		[SerializeField]
		private CreatureBase bodyOwner;

		[SerializeField]
		private string bodyType;

		[SerializeField]
		private List<ResourcePileInstance> inventory;

		[SerializeField]
		private bool markedForStripping;

		public string BodyType => bodyType;

		public CreatureBase BodyOwner => bodyOwner;

		public List<ResourcePileInstance> Inventory => inventory;

		public bool Stripped => inventory.Count == 0;

		public bool MarkedForStripping => markedForStripping;

		public event Action<HumanCarcassPileInstance> InventorySavedEvent;

		public event Action<ResourcePileInstance> ItemRemovedEvent;

		public event Action InventoryClearedEvent;

		public HumanCarcassPileInstance(CarcassResourceInstance resource, Vector3 worldPosition)
			: base(resource, worldPosition)
		{
			bodyOwner = resource.Owner;
			bodyType = ((bodyOwner is HumanoidInstance) ? "worker" : "enemy");
			inventory = new List<ResourcePileInstance>();
			if (resource.Inventory.Count == 0)
			{
				foreach (ResourceInstance item in GetStoredCarcass().Inventory)
				{
					ResourcePileInstance resourcePileInstance = ResourcePileFactory.ProducePile(item, base.GetPosition());
					if (resourcePileInstance != null)
					{
						inventory.Add(resourcePileInstance);
						GetStoredCarcass().AddToInventory(resourcePileInstance.GetStoredResource());
					}
				}
				return;
			}
			foreach (ResourceInstance item2 in resource.Inventory)
			{
				ResourcePileInstance resourcePileInstance2 = ResourcePileFactory.ProducePile(item2, base.GetPosition());
				if (resourcePileInstance2 != null)
				{
					inventory.Add(resourcePileInstance2);
				}
			}
		}

		public override void Dispose()
		{
			bodyOwner = null;
			inventory?.Clear();
			inventory = null;
			this.InventorySavedEvent = null;
			this.ItemRemovedEvent = null;
			this.InventoryClearedEvent = null;
			base.Dispose();
		}

		public override int GetMaxReservers()
		{
			return 1;
		}

		public void MarkForStripping(bool markedForStripping)
		{
			this.markedForStripping = markedForStripping;
			if (this.markedForStripping)
			{
				MonoSingleton<ResourcePileManager>.Instance.CarcassesMarkedForStripping.Add(this);
			}
			else
			{
				MonoSingleton<ResourcePileManager>.Instance.CarcassesMarkedForStripping.Remove(this);
			}
		}

		public void Strip()
		{
			markedForStripping = false;
			foreach (ResourceInstance item in GetStoredCarcass().Inventory)
			{
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item.Clone(), base.WorldPosition);
				item.Dispose();
			}
			GetStoredCarcass().Inventory.Clear();
			foreach (ResourcePileInstance item2 in inventory)
			{
				item2.Dispose();
			}
			inventory.Clear();
			this.InventoryClearedEvent?.Invoke();
		}

		public void SaveInventory(CreatureBase creatureBase)
		{
			if (creatureBase == null)
			{
				return;
			}
			foreach (EquipmentInstance equipment in creatureBase.Inventory.Equipments)
			{
				Resource byID;
				if (equipment.Blueprint.ItemType == ItemType.Garment)
				{
					string id = equipment.Id + "_tainted";
					byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
					if (byID == null)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\Components\\HumanCarcassPileInstance.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Couldn't find tainted version for ");
							messageBuilder.AppendFormatted(equipment.Id);
							messageBuilder.AppendLiteral("; defaulting to standard one.");
						}
						Log.Warning(messageBuilder);
						byID = Repository<ResourceRepository, Resource>.Instance.GetByID(equipment.Id);
					}
				}
				else
				{
					byID = Repository<ResourceRepository, Resource>.Instance.GetByID(equipment.Id);
				}
				ResourceInstance resourceInstance = new ResourceInstance(byID, 1, creatureBase);
				resourceInstance.CloneStatsCurrent(equipment.Stats);
				resourceInstance.SetProducerUniqueId(equipment.ProducerUniqueId);
				ResourcePileInstance resourcePileInstance = ResourcePileFactory.ProducePile(resourceInstance, creatureBase.GetPosition());
				if (resourcePileInstance != null)
				{
					inventory.Add(resourcePileInstance);
					GetStoredCarcass().AddToInventory(resourcePileInstance.GetStoredResource());
				}
			}
			this.InventorySavedEvent?.Invoke(this);
		}

		public void RemoveFromInventory(ResourcePileInstance item)
		{
			inventory.Remove(item);
			GetStoredCarcass().RemoveFromInventory(item.GetStoredResource());
			this.ItemRemovedEvent?.Invoke(item);
		}

		public void ClearInventory()
		{
			inventory?.Clear();
			this.InventoryClearedEvent?.Invoke();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("bodyType", bodyType);
			serializer.Write("bodyOwner", bodyOwner);
			serializer.Write("inventory", inventory);
			serializer.Write("markedForStripping", markedForStripping);
		}

		public HumanCarcassPileInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			bodyType = deserializer.ReadString("bodyType");
			bodyOwner = deserializer.ReadObject<CreatureBase>("bodyOwner");
			inventory = deserializer.ReadObjectList<ResourcePileInstance>("inventory") ?? new List<ResourcePileInstance>();
			markedForStripping = deserializer.ReadBool("markedForStripping");
		}
	}
}
