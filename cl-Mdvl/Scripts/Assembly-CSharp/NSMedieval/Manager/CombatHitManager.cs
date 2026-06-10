using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class CombatHitManager
	{
		private static readonly HitEffector[] OnHitEffectorTriggerCache = new HitEffector[25];

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			if (OnHitEffectorTriggerCache != null)
			{
				int i = 0;
				for (int num = OnHitEffectorTriggerCache.Length; i < num; i++)
				{
					OnHitEffectorTriggerCache[i] = null;
				}
			}
		}

		public static CombatMissType HasHit(IDamageDealAgent agent, IDamageTakingAgent target, float additionalPenalty = 0f)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return CombatMissType.None;
			}
			if (Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetSettings(target.DamageAgentType).Exists((DamageTakingAgentSettings item) => item.AbsoluteHitChance))
			{
				return CombatMissType.None;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (!CombatUtils.HasCombatLos(agent.GetGridPosition().ToVector3World(), target.GetGridPosition().ToVector3World(), out var losObjectsCover))
			{
				MonoSingleton<CombatController>.Instance.OnHitMissed(agent, target, CombatMissType.LineOfSight);
				messageBuilder = new FVLogTraceInterpolationHandler(13, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("LOS miss ");
					messageBuilder.AppendFormatted(agent);
					messageBuilder.AppendLiteral(" -> ");
					messageBuilder.AppendFormatted(target);
				}
				Log.Trace(messageBuilder);
				return CombatMissType.LineOfSight;
			}
			float value = UnityEngine.Random.value;
			float num = CombatCalculator.CalculateRangedWeaponHitChanceFinal(agent, target);
			num *= 1f - losObjectsCover;
			additionalPenalty = Mathf.Max(additionalPenalty, 0f);
			if (value >= num - additionalPenalty)
			{
				if (losObjectsCover > 0.05f && value >= num / (1f - losObjectsCover))
				{
					MonoSingleton<CombatController>.Instance.OnHitMissed(agent, target, CombatMissType.Other);
					messageBuilder = new FVLogTraceInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Building cover miss ");
						messageBuilder.AppendFormatted(agent);
						messageBuilder.AppendLiteral(" -> ");
						messageBuilder.AppendFormatted(target);
					}
					Log.Trace(messageBuilder);
					return CombatMissType.Other;
				}
				if (value >= num)
				{
					MonoSingleton<CombatController>.Instance.OnHitMissed(agent, target, CombatMissType.Miss);
					messageBuilder = new FVLogTraceInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Chance miss ");
						messageBuilder.AppendFormatted(agent);
						messageBuilder.AppendLiteral(" -> ");
						messageBuilder.AppendFormatted(target);
					}
					Log.Trace(messageBuilder);
					return CombatMissType.Miss;
				}
				MonoSingleton<CombatController>.Instance.OnHitMissed(agent, target, CombatMissType.Other);
				messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Additional penalty miss ");
					messageBuilder.AppendFormatted(agent);
					messageBuilder.AppendLiteral(" -> ");
					messageBuilder.AppendFormatted(target);
				}
				Log.Trace(messageBuilder);
				return CombatMissType.Other;
			}
			if (UnityEngine.Random.value <= CombatCalculator.GetEvadeChance(target))
			{
				CreatureBase obj = target as CreatureBase;
				if (obj == null || !obj.HasFainted)
				{
					MonoSingleton<CombatController>.Instance.OnHitMissed(agent, target, CombatMissType.Evade);
					messageBuilder = new FVLogTraceInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Evade miss ");
						messageBuilder.AppendFormatted(agent);
						messageBuilder.AppendLiteral(" -> ");
						messageBuilder.AppendFormatted(target);
					}
					Log.Trace(messageBuilder);
					return CombatMissType.Evade;
				}
			}
			messageBuilder = new FVLogTraceInterpolationHandler(8, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatHitManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Hit ");
				messageBuilder.AppendFormatted(agent);
				messageBuilder.AppendLiteral(" -> ");
				messageBuilder.AppendFormatted(target);
			}
			Log.Trace(messageBuilder);
			return CombatMissType.None;
		}

		public static CombatHitInfo DealDamage(IDamageDealAgent damageDealAgent, IDamageTakingAgent target, DamageType damageType, Func<float, float> modifyDamage = null)
		{
			if (CombatUtils.IsNullOrDisposed(damageDealAgent, target))
			{
				return default(CombatHitInfo);
			}
			if (!CombatUtils.IsAlive(target))
			{
				return default(CombatHitInfo);
			}
			float num = CombatCalculator.CalculateArmorDamage(damageDealAgent, target.DamageAgentType);
			Vector2 damageDirectionWorldSpace = (target.GetPosition() - damageDealAgent.GetPosition()).ToVector2XZ();
			var (num2, equipmentInstance) = CombatCalculator.GetBlockChance(target, damageType, damageDirectionWorldSpace);
			if (UnityEngine.Random.value <= num2)
			{
				CombatHitInfo combatHitInfo = new CombatHitInfo
				{
					ArmorDamage = num,
					HasBlocked = true,
					ItemThatBlocked = equipmentInstance
				};
				StatInstance stat = equipmentInstance.GetStat(StatType.Health);
				stat.SetCurrent(stat.Current - num);
				MonoSingleton<CombatController>.Instance.OnHitBlocked(damageDealAgent, target, combatHitInfo);
				DamagePopup.Create(combatHitInfo, target.GetPosition());
				return combatHitInfo;
			}
			bool flag = CombatCalculator.IsCritical(damageDealAgent, target);
			float num3 = CombatCalculator.CalculateDamage(damageDealAgent, target, flag);
			num3 = modifyDamage?.Invoke(num3) ?? num3;
			DealArmorDamage(target, num, flag ? EquipmentSlotType.Head : EquipmentSlotType.BodyArmor);
			if (num3 <= 0f)
			{
				return new CombatHitInfo
				{
					ArmorDamage = num,
					Critical = flag
				};
			}
			CombatHitInfo combatHitInfo2 = new CombatHitInfo
			{
				Damage = num3,
				ArmorDamage = num,
				Critical = flag
			};
			if (target is IDamageDealAgent { CombatAi: not null } damageDealAgent2)
			{
				damageDealAgent2.CombatAi.SetState(CombatAiState.LastDamageTakenTime, GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware);
				damageDealAgent2.CombatAi.SetState(CombatAiState.LastDamageTakenFrom, damageDealAgent);
			}
			if (!DealDamage(target, num3))
			{
				MonoSingleton<CombatController>.Instance.OnDamageTaken(damageDealAgent, target, combatHitInfo2);
				HandleHitEffectors(damageDealAgent, target, combatHitInfo2);
			}
			else
			{
				MonoSingleton<CombatController>.Instance.OnAgentKilled(damageDealAgent, target);
			}
			return combatHitInfo2;
		}

		public static void DealLightningDamage(IDamageTakingAgent target, IEnumerable<HitEffector> hitEffectors, float lightningDamage)
		{
			if (!CombatUtils.IsNullOrDisposed(target))
			{
				float num = 0.25f;
				bool flag = UnityEngine.Random.value < num;
				float num2 = CombatCalculator.CalculateLightningDamage(target, lightningDamage, flag);
				float armorDamage = num2;
				CombatHitInfo hitInfo = new CombatHitInfo
				{
					ArmorDamage = armorDamage,
					Damage = num2,
					Critical = flag
				};
				CheckAndStartHitEffectors(hitEffectors, target, hitInfo);
				DealDamage(target, num2);
			}
		}

		public static bool DealDamage(IDamageTakingAgent target, float damage)
		{
			if (CombatUtils.IsNullOrDisposed(target) || damage <= 0f)
			{
				return false;
			}
			if (target is BaseBuildingInstance baseBuildingInstance)
			{
				DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null)
				{
					float maxClampedDamage = componentInstance.GetMaxClampedDamage(damage);
					if (maxClampedDamage < damage)
					{
						damage = maxClampedDamage;
					}
				}
			}
			StatInstance statInstance = target.Stats?.GetStat(StatType.Health);
			if (statInstance == null || statInstance.Current <= 0.5f)
			{
				return true;
			}
			MonoSingleton<CombatController>.Instance.OnDealDamage(target, damage);
			statInstance.SetCurrent(statInstance.Current - damage);
			if (statInstance.Current > 0.5f)
			{
				return false;
			}
			MonoSingleton<CombatController>.Instance.OnAgentDied(target);
			return true;
		}

		public static bool DealTrapDamage(IDamageTakingAgent target, float damage)
		{
			if (CombatUtils.IsNullOrDisposed(target) || damage <= 0f)
			{
				return false;
			}
			StatInstance stat = target.Stats.GetStat(StatType.Health);
			if (stat == null || stat.Current <= 0.5f)
			{
				return true;
			}
			MonoSingleton<CombatController>.Instance.OnDealDamage(target, damage);
			float num = stat.Current - damage;
			if (num > 0.5f)
			{
				stat.SetCurrent(num);
				return false;
			}
			if (target is AnimalInstance animalInstance)
			{
				animalInstance.KilledByTrap = true;
			}
			stat.SetCurrent(num);
			MonoSingleton<CombatController>.Instance.OnAgentDied(target);
			return true;
		}

		public static void HandleXp(IDamageDealAgent agent, IDamageTakingAgent target, AttackType type, bool hasHit)
		{
			if (CombatUtils.IsNullOrDisposed(agent) || !(agent is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return;
			}
			switch (type)
			{
			case AttackType.Melee:
				humanoidInstance.AddExperience(SkillType.Melee, hasHit ? humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.MeleeHit : humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.MeleeMis, isSilent: true);
				break;
			case AttackType.RangeChargeBefore:
			case AttackType.RangeChargeAfter:
				humanoidInstance.AddExperience(SkillType.Marksman, hasHit ? humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.MarksmanHit : humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.MarksmanMiss, isSilent: true);
				if (target != null && target.DamageAgentType == DamageTakingAgentType.Animal)
				{
					humanoidInstance.AddExperience(SkillType.AnimalHandling, hasHit ? humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.AnimalHandlingHit : humanoidInstance.WorkerBehaviour.WorkerBlueprint.CombatHitXp.AnimalHandlingMiss, isSilent: true);
				}
				break;
			}
		}

		public static void DealTrapDamage(IDamageTakingAgent target, TrapComponentInstance trapComponentInstance)
		{
			if (CombatUtils.IsNullOrDisposed(target) || trapComponentInstance.Underwater || UnityEngine.Random.value > trapComponentInstance.GetChanceToTrigger(target))
			{
				return;
			}
			TrapComponentBlueprint blueprint = trapComponentInstance.Blueprint;
			trapComponentInstance.Trigger();
			if (UnityEngine.Random.value > blueprint.ChanceToHurt)
			{
				DamagePopup.Create(trapComponentInstance.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("trap_misfire"));
				return;
			}
			bool flag = UnityEngine.Random.value < blueprint.CriticalChance;
			float damage = CombatCalculator.CalculateTrapDamage(target, trapComponentInstance, flag);
			float num = CombatCalculator.CalculateTrapArmorDamage(target, trapComponentInstance, flag);
			CombatHitInfo combatHitInfo = new CombatHitInfo
			{
				ArmorDamage = num,
				Damage = damage,
				Critical = flag
			};
			DealTrapDamage(target, damage);
			DealArmorDamage(target, num, EquipmentSlotType.Body | EquipmentSlotType.BodyArmor);
			if (!combatHitInfo.HasBlocked)
			{
				target.GetTransform()?.GetComponent<HitEffect>()?.OnHit();
			}
			MonoSingleton<CombatController>.Instance.OnTrapDamageTaken(trapComponentInstance, target, combatHitInfo);
			CheckAndStartHitEffectors(combatHitInfo.Critical ? blueprint.OnCriticalHitEffectors : blueprint.OnHitEffectors, target, combatHitInfo);
			if (blueprint.OnSuccessfulHitEffector != null && blueprint.OnSuccessfulHitEffector.Length != 0)
			{
				StartSuccessfulHitEffector(blueprint.OnSuccessfulHitEffector, target);
			}
			DamagePopup.Create(combatHitInfo, target.GetPosition());
		}

		public static void DealGateDamage(IDamageTakingAgent target, DoorComponentInstance gateInstance)
		{
			if (CombatUtils.IsNullOrDisposed(target))
			{
				return;
			}
			DoorComponentBlueprint blueprint = gateInstance.Blueprint;
			if (UnityEngine.Random.value > blueprint.ChanceToHurt)
			{
				return;
			}
			float damagePercent = gateInstance.DamagePercent;
			bool flag = UnityEngine.Random.value < blueprint.CriticalChance;
			float damage = CombatCalculator.CalculateGateDamage(target, gateInstance, flag) * damagePercent;
			float num = CombatCalculator.CalculateGateArmorDamage(target, blueprint, flag) * damagePercent;
			CombatHitInfo combatHitInfo = new CombatHitInfo
			{
				ArmorDamage = num,
				Damage = damage,
				Critical = flag
			};
			DealTrapDamage(target, damage);
			DealArmorDamage(target, num, EquipmentSlotType.Body | EquipmentSlotType.BodyArmor);
			if (!combatHitInfo.HasBlocked)
			{
				target.GetTransform()?.GetComponent<HitEffect>()?.OnHit();
			}
			MonoSingleton<CombatController>.Instance.GateDamageTaken(target, combatHitInfo);
			CheckAndStartHitEffectors(combatHitInfo.Critical ? blueprint.OnCriticalHitEffectors : blueprint.OnHitEffectors, target, combatHitInfo);
			DamagePopup.Create(combatHitInfo, target.GetPosition());
			if (target.HasDied && target is HumanoidInstance { EnemyBehaviour: not null })
			{
				if (blueprint.DoorType == DoorType.Drawbridge)
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement("KILL_ENEMY_DRAW");
				}
				if (blueprint.DoorType == DoorType.Portcullis)
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement("KILL_ENEMY_PORT");
				}
			}
		}

		private static void DealArmorDamage(IDamageTakingAgent agent, float damage, EquipmentSlotType equipType)
		{
			if (!CombatUtils.IsNullOrDisposed(agent) && agent.GetEquipment() != null && !(damage <= 0f))
			{
				List<EquipmentInstance> list = agent.GetEquipment().FindAll((EquipmentInstance item) => !item.HasDisposed && item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & equipType) != 0);
				if (list.Count != 0)
				{
					StatInstance stat = list.PickRandom().GetStat(StatType.Health);
					stat.SetCurrent(stat.Current - damage);
				}
			}
		}

		private static void HandleHitEffectors(IDamageDealAgent attacker, IDamageTakingAgent target, CombatHitInfo hitInfo)
		{
			if (!CombatUtils.IsNullOrDisposed(attacker, target))
			{
				if (attacker is AnimalInstance)
				{
					Animal blueprint = ((AnimalInstance)attacker).Blueprint;
					CheckAndStartHitEffectors((!hitInfo.Critical) ? blueprint?.OnHitEffectors : blueprint?.OnCriticalHitEffectors, target, hitInfo);
				}
				else if (attacker is SiegeWeaponProjectileInstance { Blueprint: var blueprint2 })
				{
					CheckAndStartHitEffectors((!hitInfo.Critical) ? blueprint2?.OnHitEffectors : blueprint2?.OnCriticalHitEffectors, target, hitInfo);
					SiegeWeaponHitTryStartStatEffector(blueprint2?.HitModifierEffectorIDs, target);
				}
				else
				{
					HandleWeaponHitEffectors(attacker, target, hitInfo);
				}
			}
		}

		private static void HandleWeaponHitEffectors(IDamageDealAgent attacker, IDamageTakingAgent target, CombatHitInfo hitInfo)
		{
			EquipmentInstance weapon = CombatUtils.GetWeapon(attacker);
			WeaponTypeSettings weaponTypeSettings = ((weapon?.Blueprint != null) ? weapon.WeaponTypeSettings : Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(WeaponType.None));
			HitEffector[] array = weapon?.OnHitEffectors;
			HitEffector[] array2 = weapon?.OnCriticalHitEffectors;
			HitEffector[] array3 = weaponTypeSettings?.OnHitEffectors;
			HitEffector[] array4 = weaponTypeSettings?.OnCriticalHitEffectors;
			HitEffector[] array5 = (hitInfo.Critical ? array2 : array);
			HitEffector[] array6 = (hitInfo.Critical ? array4 : array3);
			IEnumerable<HitEffector> enumerable = array5;
			if (enumerable == null)
			{
				enumerable = array6;
			}
			else if (array6 != null && array6.Length != 0)
			{
				enumerable = array5.Concat(array6);
			}
			CheckAndStartHitEffectors(enumerable, target, hitInfo);
		}

		private static void CheckAndStartHitEffectors(IEnumerable<HitEffector> effectors, IDamageTakingAgent target, CombatHitInfo hitInfo)
		{
			if (effectors == null || CombatUtils.IsNullOrDisposed(target) || !CombatUtils.IsAlive(target) || !(target is CreatureBase))
			{
				return;
			}
			float num = target.Stats.GetStat(StatType.Health)?.Current ?? 0f;
			int num2 = 0;
			foreach (HitEffector effector in effectors)
			{
				float num3 = effector.Threshold * num;
				if (!(hitInfo.Damage < num3))
				{
					OnHitEffectorTriggerCache[num2] = effector;
					num2++;
				}
			}
			int num4;
			switch (num2)
			{
			case 0:
				return;
			default:
				num4 = UnityEngine.Random.Range(0, num2);
				break;
			case 1:
				num4 = 0;
				break;
			}
			int num5 = num4;
			HitEffector hitEffector = OnHitEffectorTriggerCache[num5];
			if (target.Stats.StartEffector(hitEffector.Effector))
			{
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				if (i != num5)
				{
					float durationModifier = 1f;
					if (target is HumanoidInstance { WorkerBehaviour: not null })
					{
						durationModifier = GlobalSaveController.CurrentVillageData.GameParametersCurrent?.WoundSeverityMultiplier ?? 1f;
					}
					if (target.Stats.StartEffector(hitEffector.Effector, durationModifier))
					{
						break;
					}
				}
			}
		}

		private static void StartSuccessfulHitEffector(IEnumerable<HitEffector> effectors, IDamageTakingAgent target)
		{
			if (effectors == null || CombatUtils.IsNullOrDisposed(target) || !CombatUtils.IsAlive(target))
			{
				return;
			}
			foreach (HitEffector effector in effectors)
			{
				if (effector != null && effector.Effector != null && target.Stats != null && !target.Stats.StartEffector(effector.Effector))
				{
					float durationModifier = 1f;
					if (target is HumanoidInstance { WorkerBehaviour: not null })
					{
						durationModifier = GlobalSaveController.CurrentVillageData.GameParametersCurrent?.WoundSeverityMultiplier ?? 1f;
					}
					target.Stats.StartEffector(effector.Effector, durationModifier);
				}
			}
		}

		private static void SiegeWeaponHitTryStartStatEffector(IEnumerable<string> effectors, IDamageTakingAgent target)
		{
			if (effectors == null || CombatUtils.IsNullOrDisposed(target) || !CombatUtils.IsAlive(target) || !(target is CreatureBase { HasDisposed: false } creatureBase))
			{
				return;
			}
			foreach (string effector in effectors)
			{
				creatureBase.Stats?.StartEffector(effector);
			}
		}
	}
}
