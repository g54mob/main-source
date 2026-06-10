using System.Collections.Generic;
using System.Linq;
using Models.Blueprint.Settings;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class CombatCalculator
	{
		public static float CalculateDamage(IDamageDealAgent damageDealAgent, IDamageTakingAgent target, bool isCritical)
		{
			if (CombatUtils.IsNullOrDisposed(damageDealAgent, target))
			{
				return 0f;
			}
			float num = CalculateBaseDamage(damageDealAgent, target) * CalculateIgnoresArmor(damageDealAgent, target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			num -= num * CalculateTotalArmorRating(target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			bool flag = false;
			MapNode node = damageDealAgent.GetNode();
			if (node != null)
			{
				flag = (node.Tag & MapNodeTags.Ladder) != 0;
			}
			bool flag2 = target?.GetNode() != null && (target.GetNode().Tag & MapNodeTags.Ladder) != 0;
			if (isCritical)
			{
				num *= 2f;
			}
			else if (target != null && !flag2 && !flag)
			{
				float num2 = damageDealAgent.GetPosition().y - target.GetPosition().y;
				if (num2 >= 1f)
				{
					num *= 1.3f;
				}
				else if (num2 <= -1f)
				{
					num *= 0.8f;
				}
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(damageDealAgent);
			if (flag)
			{
				num = ((weapon != null && CombatConstants.TwoHandWeapons.Contains(weapon.WeaponType)) ? (num * 0.4f) : ((weapon == null) ? (num * 1f) : (num * 0.8f)));
				if (weapon != null && weapon.LadderDamageMod >= 0f)
				{
					num *= weapon.LadderDamageMod;
				}
			}
			if (CombatUtils.IsAgentSwimming(damageDealAgent) && weapon != null)
			{
				num *= weapon.WaterDamageMod;
			}
			if (num > 0.3f && num < 1f)
			{
				num = 1f;
			}
			return num;
		}

		public static float CalculateArmorDamage(IDamageDealAgent damageDealAgent, DamageTakingAgentType targetType)
		{
			float result = 0f;
			EquipmentInstance weapon = CombatUtils.GetWeapon(damageDealAgent);
			if (weapon != null && weapon.ArmorDamage > 0f)
			{
				result = GetBaseDamage(damageDealAgent, targetType) * weapon.ArmorDamage * CalculateAttributeValues(weapon.WeaponTypeSettings.ArmorDamage, damageDealAgent);
			}
			else if (weapon == null)
			{
				WeaponTypeSettings byID = Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None);
				result = GetBaseDamage(damageDealAgent, targetType) * CalculateAttributeValues(byID.ArmorDamage, damageDealAgent);
			}
			return result;
		}

		public static (float coverChance, EquipmentInstance itemThatBlocked) GetBlockChance(IDamageTakingAgent agent, DamageType damageType, Vector2 damageDirectionWorldSpace)
		{
			EquipmentInstance equipmentInstance = agent?.GetBestCombatCoverEquipment(damageType);
			if (equipmentInstance == null)
			{
				return (coverChance: 0f, itemThatBlocked: null);
			}
			if (agent.GetTransform() == null)
			{
				return (coverChance: 0f, itemThatBlocked: null);
			}
			Vector2 agentLookDirection = agent.GetTransform().forward.ToVector2XZ();
			float num = equipmentInstance.Blueprint.GetCoverChance(damageType, agentLookDirection, damageDirectionWorldSpace);
			if (CombatUtils.IsAgentSwimming(agent))
			{
				num *= 0.01f;
			}
			if (CombatUtils.IsAgentOnLadder(agent))
			{
				num *= 0.1f;
			}
			if (damageType == DamageType.Ranged && agent.IsMidStrike)
			{
				num *= 0.05f;
			}
			return (coverChance: num + GetEvadeChance(agent), itemThatBlocked: equipmentInstance);
		}

		public static float CalculateHitChance(IDamageDealAgent agent)
		{
			if (!CombatUtils.IsAlive(agent))
			{
				return -1f;
			}
			return 1f * GetWeaponPrecision(agent);
		}

		public static float CalculatePercisionFallof(IDamageDealAgent agent, IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return 0f;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(agent);
			if (weapon == null)
			{
				return 0f;
			}
			float num = weapon.PrecisionFalloff * CalculateAttributeValues(weapon.WeaponTypeSettings.PrecisionFallof, agent);
			if (target == null)
			{
				return num;
			}
			if (CombatUtils.GetAttackType(agent) == AttackType.Melee)
			{
				Vector3 position = agent.GetPosition();
				Vector3 position2 = target.GetPosition();
				if (Mathf.Approximately(position.x, position2.x) && Mathf.Approximately(position.z, position2.z) && agent.GetNode() != null && agent.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
				{
					return num;
				}
			}
			return Vector3.Distance(agent.GetPosition(), target.GetPosition()) * num;
		}

		public static float CalculateRangedWeaponHitChanceFinal(IDamageDealAgent damageDealAgent, IDamageTakingAgent target)
		{
			float num = damageDealAgent.GetPosition().y - target.GetPosition().y;
			float num2 = CalculateHitChance(damageDealAgent);
			float num3 = CalculatePercisionFallof(damageDealAgent, target);
			float num4 = num2 - num3;
			if (num >= 1f)
			{
				num4 *= 1.3f;
			}
			else if (num <= -1f)
			{
				num4 *= 0.9f;
			}
			return Mathf.Clamp(num4, 0f, 1f);
		}

		public static float GetEvadeChance(IDamageCommonAgent agent)
		{
			return (agent.Stats?.GetAttributeInstance(AttributeType.EvadeChance))?.Value ?? 0f;
		}

		public static float CalculateAttackSpeed(IDamageCommonAgent agent)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return 0f;
			}
			if (agent.HasDied)
			{
				return 0f;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(agent);
			float num = agent.Stats?.GetAttributeInstance(AttributeType.MotorFunction)?.Value ?? 1f;
			if (num == 0f)
			{
				num = 1f;
			}
			float num2 = 0f;
			num2 = ((weapon == null) ? CalculateAttributeValues(Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None).AttackSpeed, agent) : (weapon.AttackSpeed * CalculateAttributeValues(weapon.WeaponTypeSettings.AttackSpeed, agent)));
			if (agent.GetNode() != null && (agent.GetNode().Tag & MapNodeTags.Ladder) != MapNodeTags.None)
			{
				num2 = ((weapon != null && CombatConstants.TwoHandWeapons.Contains(weapon.WeaponType)) ? (num2 * 1.4f) : ((weapon == null) ? (num2 * 1.2f) : (num2 * 1.2f)));
				if (weapon != null && weapon.LadderSpeedMod > 0f)
				{
					num2 *= weapon.LadderSpeedMod;
				}
			}
			if (CombatUtils.IsAgentSwimming(agent) && weapon != null)
			{
				num2 *= weapon.WaterSpeedMod;
			}
			if (weapon != null && weapon.IsNextRoundFlammable)
			{
				num2 *= 1.15f;
			}
			return num2 / num;
		}

		public static float CalculateAttackRange(IDamageCommonAgent agent, WeaponMode weaponModeOverride = null)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return 0f;
			}
			float num = CombatConstants.BaseRange;
			WeaponMode weaponMode = weaponModeOverride ?? CombatUtils.GetWeapon(agent)?.ActiveWeaponMode;
			if (weaponMode != null)
			{
				num += weaponMode.Range * CalculateAttributeValues(weaponMode.WeaponTypeSettings.Range, agent);
			}
			if (agent.GetNode() != null && (agent.GetNode().Tag & MapNodeTags.Ladder) != MapNodeTags.None)
			{
				num += 0.7f;
			}
			return num;
		}

		public static bool IsCritical(IDamageDealAgent damageDealAgent, IDamageTakingAgent target)
		{
			if (!CombatUtils.IsAlive(damageDealAgent) || !CombatUtils.IsAlive(target))
			{
				return false;
			}
			if (target.DamageAgentType == DamageTakingAgentType.Building)
			{
				return false;
			}
			AttributeInstance attributeInstance = ((target.DamageAgentType == DamageTakingAgentType.Animal) ? damageDealAgent.Stats.GetAttributeInstance(AttributeType.AnimalCritChance) : damageDealAgent.Stats.GetAttributeInstance(AttributeType.AttackCritChance));
			bool flag = damageDealAgent.GetNode() != null && (damageDealAgent.GetNode().Tag & MapNodeTags.Ladder) != 0;
			if ((attributeInstance?.Value ?? 0f) <= 0f)
			{
				return false;
			}
			float num = damageDealAgent.GetPosition().y - target.GetPosition().y;
			float num2 = attributeInstance.Value;
			if (num >= 1f && !flag)
			{
				num2 *= 1.5f;
			}
			if (num < 1f && flag)
			{
				num2 *= 1.2f;
			}
			if (flag)
			{
				EquipmentInstance weapon = CombatUtils.GetWeapon(damageDealAgent);
				if (weapon != null && weapon.LadderCritMod > 0f)
				{
					num2 *= weapon.LadderCritMod;
				}
			}
			if (CombatUtils.IsAgentSwimming(damageDealAgent))
			{
				EquipmentInstance weapon2 = CombatUtils.GetWeapon(damageDealAgent);
				if (weapon2 != null && weapon2.WaterCritMod > 0f)
				{
					num2 *= weapon2.WaterCritMod;
				}
			}
			return Random.value <= num2;
		}

		public static float GetPerceptionRange(IDamageCommonAgent agent)
		{
			return agent.Stats.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? 0f;
		}

		public static float CalculateTotalArmorRating(IDamageCommonAgent agent, EquipmentSlotType equipmentType)
		{
			if (!CombatUtils.IsAlive(agent))
			{
				return 0f;
			}
			if (agent.GetEquipment() == null)
			{
				return 0f;
			}
			return GetEquippedArmor(agent, equipmentType)?.GetTotalDurability() ?? 0f;
		}

		public static float GetFleeChance(IDamageDealAgent dealAgent, IDamageTakingAgent takeAgent)
		{
			if (!CombatUtils.IsAlive(dealAgent) || !CombatUtils.IsAlive(takeAgent))
			{
				return 0f;
			}
			if (takeAgent.DamageAgentType == DamageTakingAgentType.Animal)
			{
				AttributeInstance attributeInstance = takeAgent.Stats.GetAttributeInstance(AttributeType.HuntingRunChance);
				AttributeInstance attributeInstance2 = dealAgent.Stats.GetAttributeInstance(AttributeType.HuntingVisibility);
				float num = attributeInstance?.Value ?? 0f;
				float num2 = attributeInstance2?.Value ?? 0f;
				return num * num2;
			}
			return 0f;
		}

		public static EquipmentInstance GetEquippedArmor(IDamageCommonAgent agent, EquipmentSlotType equipmentType)
		{
			if (agent == null || agent.HasDisposed || agent.GetEquipment() == null)
			{
				return null;
			}
			return agent.GetEquipment().Find((EquipmentInstance item) => item != null && item.Blueprint != null && !item.HasDisposed && item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & equipmentType) != 0);
		}

		public static float CalculateBaseDamage(IDamageDealAgent damageDealAgent, IDamageTakingAgent target, bool ignoreWeapon = false)
		{
			return GetBaseDamage(damageDealAgent, target?.DamageAgentType ?? DamageTakingAgentType.NPC, ignoreWeapon);
		}

		public static float GetWeaponPrecision(IDamageDealAgent agent)
		{
			EquipmentInstance weapon = CombatUtils.GetWeapon(agent);
			return CalculateAttributeValues(((weapon != null) ? weapon.WeaponTypeSettings : Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None)).Precision, agent);
		}

		public static float GetWeaponRange(IDamageDealAgent agent)
		{
			return CombatUtils.GetWeapon(agent)?.Range ?? 0f;
		}

		public static bool IsWeaponRanged(IDamageDealAgent agent)
		{
			EquipmentInstance weapon = CombatUtils.GetWeapon(agent);
			if (weapon == null)
			{
				return false;
			}
			return weapon.Range > 2f;
		}

		public static float CalculateLineOfSightObjectsTraversePenalty(VillageMap map, Vec3Int start, Vec3Int end, out MapNode randomTraverseNode)
		{
			IEnumerable<Vector2Int> pointsOnLine2D = GridUtils.GetPointsOnLine2D(start.ToVector2XZ(), end.ToVector2XZ());
			float num = 0f;
			GridDataTypeAttackTraversePenalty data = Repository<GridDataTypeAttackTraversePenaltyData, GridDataTypeAttackTraversePenalty>.Instance.GetData<GridDataTypeAttackTraversePenalty>();
			MapNode mapNode = null;
			MapNode mapNode2 = null;
			randomTraverseNode = null;
			foreach (Vector2Int item in pointsOnLine2D)
			{
				Vec3Int b = new Vec3Int(item.x, start.y, item.y);
				if ((float)Mathf.Abs(start.y - b.y) >= 3.1f || Vec3Int.Distance(in start, in b) <= 2f)
				{
					continue;
				}
				MapNode node = map.GetNode(b);
				if (node.CheckIsDataType(GridDataType.BuildingUnfinished | GridDataType.BuildingFinished | GridDataType.Furniture))
				{
					num = ((BaseBuildingInstance)node.GetWorldObject(GridDataType.BuildingUnfinished | GridDataType.BuildingFinished | GridDataType.Furniture))?.Blueprint.AttackTraversePenalty ?? 0f;
					if (mapNode == null)
					{
						mapNode = node;
					}
					if (randomTraverseNode == null && Random.value >= 0.7f)
					{
						randomTraverseNode = node;
					}
				}
				else if (node.CheckIsDataType(GridDataType.PlantMapResource))
				{
					num = ((PlantMapResourceInstance)node.GetWorldObject(GridDataType.PlantMapResource))?.Blueprint.AttackTraversePenalty ?? 0f;
					if (mapNode == null)
					{
						mapNode = node;
					}
					if (randomTraverseNode == null && Random.value >= 0.7f)
					{
						randomTraverseNode = node;
					}
				}
				else
				{
					if (node.DataType == GridDataType.None)
					{
						continue;
					}
					num = 0f;
					GridDataTypeAttackTraversePenalty.Data[] penalties = data.Penalties;
					for (int i = 0; i < penalties.Length; i++)
					{
						GridDataTypeAttackTraversePenalty.Data data2 = penalties[i];
						if ((node.DataType & data2.DataType) != GridDataType.None)
						{
							num += data2.Penalty;
							if (mapNode2 == null)
							{
								mapNode2 = node;
							}
						}
					}
				}
			}
			if (randomTraverseNode == null)
			{
				randomTraverseNode = mapNode;
			}
			if (randomTraverseNode == null)
			{
				randomTraverseNode = mapNode2;
			}
			return Mathf.Clamp(num, 0f, 1f);
		}

		public static float CalculateAttributeValues(AttributeType[] types, IDamageCommonAgent agent)
		{
			if (agent == null || types == null || types.Length == 0 || agent.Stats == null)
			{
				return 1f;
			}
			float num = 1f;
			foreach (AttributeType type in types)
			{
				AttributeInstance attributeInstance = agent.Stats.GetAttributeInstance(type);
				if (attributeInstance != null)
				{
					num *= attributeInstance.Value;
				}
			}
			return num;
		}

		public static float CalculateTrapDamage(IDamageTakingAgent target, TrapComponentInstance trapComponentInstance, bool isCritical)
		{
			float num = trapComponentInstance.Blueprint.Damage * CalculateTrapIgnoresArmor(target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor, trapComponentInstance);
			num -= num * CalculateTotalArmorRating(target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			if (isCritical)
			{
				num *= 2f;
			}
			return num;
		}

		public static float CalculateGateDamage(IDamageTakingAgent target, DoorComponentInstance gateInstance, bool isCritical)
		{
			DoorComponentBlueprint blueprint = gateInstance.Blueprint;
			float num = ((target.DamageAgentType == DamageTakingAgentType.Worker) ? blueprint.WorkerDamage : blueprint.EnemyDamage) * CalculateGateIgnoresArmor(target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor, gateInstance);
			num -= num * CalculateTotalArmorRating(target, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			if (isCritical)
			{
				num *= 2f;
			}
			return num;
		}

		public static float CalculateTrapArmorDamage(IDamageTakingAgent agent, TrapComponentInstance trapComponentInstance, bool isCritical)
		{
			float damage = trapComponentInstance.Blueprint.Damage;
			float armorDamage = trapComponentInstance.Blueprint.ArmorDamage;
			float num = damage * armorDamage;
			if (isCritical)
			{
				num *= 2f;
			}
			return num;
		}

		public static float CalculateGateArmorDamage(IDamageTakingAgent target, DoorComponentBlueprint gateBlueprint, bool isCritical)
		{
			float num = ((target.DamageAgentType == DamageTakingAgentType.Worker) ? gateBlueprint.WorkerDamage : gateBlueprint.EnemyDamage);
			float armorDamage = gateBlueprint.ArmorDamage;
			float num2 = num * armorDamage;
			if (isCritical)
			{
				num2 *= 2f;
			}
			return num2;
		}

		public static float CalculateLightningDamage(IDamageTakingAgent agent, float damage, bool isCritical)
		{
			float num = damage;
			num -= num * CalculateTotalArmorRating(agent, isCritical ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			if (isCritical)
			{
				num *= 2f;
			}
			return num;
		}

		private static float CalculateTrapIgnoresArmor(IDamageTakingAgent target, EquipmentSlotType type, TrapComponentInstance trapComponentInstance)
		{
			if (!CombatUtils.IsAlive(target))
			{
				return 1f;
			}
			if (target.GetEquipment() == null || target.GetEquipment().Find((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & type) != 0) == null)
			{
				return 1f;
			}
			WeaponTypeSettings byID = Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.Trap);
			return trapComponentInstance.Blueprint.IgnoresArmor * CalculateAttributeValues(byID.IgnoresArmor, trapComponentInstance.OwnerBuilding);
		}

		private static float CalculateGateIgnoresArmor(IDamageTakingAgent target, EquipmentSlotType type, DoorComponentInstance gateInstance)
		{
			if (!CombatUtils.IsAlive(target))
			{
				return 1f;
			}
			if (target.GetEquipment() == null || target.GetEquipment().Find((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & type) != 0) == null)
			{
				return 1f;
			}
			WeaponTypeSettings byID = Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.Trap);
			return gateInstance.Blueprint.IgnoresArmor * CalculateAttributeValues(byID.IgnoresArmor, gateInstance.OwnerBuilding);
		}

		private static float CalculateIgnoresArmor(IDamageDealAgent damageDealAgent, IDamageTakingAgent agent, EquipmentSlotType type)
		{
			if (!CombatUtils.IsAlive(agent))
			{
				return 1f;
			}
			if (agent.GetEquipment() == null || agent.GetEquipment().Find((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & type) != 0) == null)
			{
				return 1f;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(damageDealAgent);
			if (weapon == null)
			{
				return CalculateAttributeValues(Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None).IgnoresArmor, damageDealAgent);
			}
			return weapon.IgnoresArmor * CalculateAttributeValues(weapon.WeaponTypeSettings.IgnoresArmor, damageDealAgent);
		}

		private static float GetBaseDamage(IDamageDealAgent damageDealAgent, DamageTakingAgentType targetType, bool ignoreWeapon = false)
		{
			float baseDamageOverride = damageDealAgent.GetBaseDamageOverride(targetType);
			if (baseDamageOverride > 0f)
			{
				return baseDamageOverride;
			}
			EquipmentInstance equipmentInstance = ((!ignoreWeapon) ? CombatUtils.GetWeapon(damageDealAgent) : null);
			if (targetType == DamageTakingAgentType.Point)
			{
				if (equipmentInstance == null)
				{
					return 0f;
				}
				if (!equipmentInstance.IsNextRoundFlammable)
				{
					return 0f;
				}
				return 1f;
			}
			bool flag = (targetType & (DamageTakingAgentType.Building | DamageTakingAgentType.ResourcePile)) != 0;
			if (equipmentInstance != null)
			{
				if (flag)
				{
					return equipmentInstance.Damage * equipmentInstance.BuildingDamage * CalculateAttributeValues(equipmentInstance.WeaponTypeSettings.BuildingDamage, damageDealAgent);
				}
				return equipmentInstance.Damage * CalculateAttributeValues(equipmentInstance.WeaponTypeSettings.Damage, damageDealAgent);
			}
			WeaponTypeSettings byID = Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None);
			return CalculateAttributeValues(flag ? byID.BuildingDamage : byID.Damage, damageDealAgent);
		}
	}
}
