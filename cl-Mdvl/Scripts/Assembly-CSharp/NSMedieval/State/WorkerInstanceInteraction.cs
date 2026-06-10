using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.State
{
	public class WorkerInstanceInteraction
	{
		private HumanoidInstance humanoid;

		public WorkerInstanceInteraction(HumanoidInstance humanoidOwner)
		{
			humanoid = humanoidOwner;
		}

		public void SetHumanOwner(HumanoidInstance humanoid)
		{
			this.humanoid = humanoid;
		}

		public void FireInteractionEvent(string eventName)
		{
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(eventName, humanoid);
		}

		public void FireWeaponHitEvent()
		{
			FireWeaponEvent("interacted_with_weapon_positive");
		}

		public void FireWeaponMissEvent()
		{
			FireWeaponEvent("interacted_with_weapon_negative");
		}

		public void FireShieldBlockEvent()
		{
			FireShieldEvent("interacted_with_shield_positive");
		}

		public void FireShieldDestroyedEvent()
		{
			FireShieldEvent("interacted_with_shield_negative");
		}

		public void FireArmourEvent()
		{
			EquipmentInstance equippedArmor = CombatCalculator.GetEquippedArmor(humanoid, EquipmentSlotType.BodyArmor);
			if (equippedArmor != null)
			{
				if (humanoid.WorkerBehaviour.WorkerProximity.IsQualityPositive(equippedArmor.Blueprint.Resource.Quality))
				{
					FireEquipmentEvent("interacted_with_armour_positive", equippedArmor);
				}
				if (humanoid.WorkerBehaviour.WorkerProximity.IsQualityNegative(equippedArmor.Blueprint.Resource.Quality))
				{
					FireEquipmentEvent("interacted_with_armour_negative", equippedArmor);
				}
			}
		}

		public void FireGarmentEvent()
		{
			if (humanoid == null || humanoid.HasDisposed)
			{
				return;
			}
			List<EquipmentInstance> equipment = humanoid.GetEquipment();
			if (equipment == null)
			{
				return;
			}
			EquipmentInstance equipmentInstance = equipment.FirstOrDefault((EquipmentInstance e) => e?.Blueprint != null && e.Blueprint.ItemType == ItemType.Garment);
			if (equipmentInstance != null)
			{
				if (humanoid.WorkerBehaviour.WorkerProximity.IsQualityPositive(equipmentInstance.Blueprint.Resource.Quality))
				{
					FireEquipmentEvent("interacted_with_garment_positive", equipmentInstance);
				}
				if (humanoid.WorkerBehaviour.WorkerProximity.IsQualityNegative(equipmentInstance.Blueprint.Resource.Quality))
				{
					FireEquipmentEvent("interacted_with_garment_negative", equipmentInstance);
				}
			}
		}

		private void FireWeaponEvent(string eventId)
		{
			EquipmentInstance weapon = CombatUtils.GetWeapon(humanoid);
			if (weapon != null)
			{
				FireEquipmentEvent(eventId, weapon);
			}
		}

		private void FireShieldEvent(string eventId)
		{
			EquipmentInstance shield = humanoid.GetShield();
			if (shield != null)
			{
				FireEquipmentEvent(eventId, shield);
			}
		}

		private void FireEquipmentEvent(string eventId, EquipmentInstance equipmentInstance)
		{
			ProducedItemData producedItemData = new ProducedItemData(ResourceUtils.GetLocalizedResourceName(equipmentInstance.Blueprint.Resource), equipmentInstance.ProducerUniqueId);
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(eventId, humanoid, producedItemData);
		}

		public void FireChairInteractionEvent(ChairComponentInstance chairInstance)
		{
			if (chairInstance != null && !chairInstance.HasDisposed && chairInstance.OwnerBuilding != null && !chairInstance.OwnerBuilding.HasDisposed)
			{
				ProducedItemData producedItemData = new ProducedItemData(BuildingUtils.GetLocalizedName(chairInstance.OwnerBuilding.BlueprintId), chairInstance.OwnerBuilding.ProducerUniqueId);
				MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_chair", humanoid, producedItemData);
			}
		}

		public void FireBedInteractionEvent(BedComponentInstance bedInstance, string wakeupEffectorId)
		{
			if (bedInstance != null && !bedInstance.HasDisposed && bedInstance.OwnerBuilding != null && !bedInstance.OwnerBuilding.HasDisposed)
			{
				ProducedItemData producedItemData = new ProducedItemData(BuildingUtils.GetLocalizedName(bedInstance.BaseBuildingBlueprint), bedInstance.OwnerBuilding.ProducerUniqueId);
				if (wakeupEffectorId.Equals("None"))
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_bed", humanoid, producedItemData);
				}
				if (wakeupEffectorId.Contains("Good"))
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_bed_positive", humanoid, producedItemData);
				}
				MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_bed_negative", humanoid, producedItemData);
			}
		}

		public void HandleConsumedDrinkEvent(ResourceInstance resourceInstance)
		{
			if (resourceInstance.ProducerUniqueId == 0)
			{
				return;
			}
			HumanoidInstance workerByCreationID = GlobalSaveController.CurrentVillageData.GetWorkerByCreationID(resourceInstance.ProducerUniqueId);
			if (workerByCreationID != null)
			{
				if (resourceInstance.Blueprint.OnUseEffects.Contains("DrankNiceDrink"))
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("consumed_drink_posıtıve", humanoid, workerByCreationID);
				}
				else
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("consumed_drink", humanoid, workerByCreationID);
				}
			}
		}

		public void HandleConsumedFoodEvent(ResourceInstance resourceInstance)
		{
			if (resourceInstance.ProducerUniqueId == 0)
			{
				return;
			}
			HumanoidInstance workerByCreationID = GlobalSaveController.CurrentVillageData.GetWorkerByCreationID(resourceInstance.ProducerUniqueId);
			if (workerByCreationID != null)
			{
				if (resourceInstance.Blueprint.OnUseEffects.Any((string s) => s.Equals("AteLavishMeal")))
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("consumed_food_posıtıve", humanoid, workerByCreationID);
				}
				else if (resourceInstance.Blueprint.OnUseEffects.Any((string s) => s.Equals("AteDubiousMeal")))
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("consumed_food_negative", humanoid, workerByCreationID);
				}
				else
				{
					MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("consumed_food", humanoid, workerByCreationID);
				}
			}
		}
	}
}
