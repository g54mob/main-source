using System.Collections.Generic;
using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class LevelEntitiesBufferConverter : Converter
{
	private ConditionsTable _cachedConditionsTable;

	private List<ConditionData> _cachedConditionList = new List<ConditionData>();

	private List<EquipmentCondition> _cachedEquipmentConditionList = new List<EquipmentCondition>();

	private List<ConditionData> _cachedSupportandAffixConditionList = new List<ConditionData>();

	private ConditionsTable ConditionsTable
	{
		get
		{
			if (_cachedConditionsTable == null)
			{
				_cachedConditionsTable = ConditionsTable.GetTable();
			}
			return _cachedConditionsTable;
		}
	}

	public override void Convert(GameObject authoring)
	{
		WeaponDamageAuthoring component;
		bool flag = TryGetActiveComponent<WeaponDamageAuthoring>(authoring, out component);
		ExplosiveAuthoring component2;
		bool flag2 = TryGetActiveComponent<ExplosiveAuthoring>(authoring, out component2);
		ProjectileAuthoring component3;
		bool num = TryGetActiveComponent<ProjectileAuthoring>(authoring, out component3);
		MortarProjectileAuthoring component4;
		bool flag3 = TryGetActiveComponent<MortarProjectileAuthoring>(authoring, out component4);
		bool flag4 = (num && flag2) || (component3 != null && component3.mayExplodeWithWindup);
		flag4 = flag4 || (flag3 && flag2);
		ConsumesManaAuthoring component5;
		bool flag5 = TryGetActiveComponent<ConsumesManaAuthoring>(authoring, out component5);
		AreaLevelAuthoring component6;
		bool flag6 = TryGetActiveComponent<AreaLevelAuthoring>(authoring, out component6) && component6.forceGenerateLevelEntities;
		ExtraInventorySizeAuthoring component7;
		bool flag7 = TryGetActiveComponent<ExtraInventorySizeAuthoring>(authoring, out component7);
		GivesConditionsWhenEquippedAuthoring component8;
		bool flag8 = TryGetActiveComponent<GivesConditionsWhenEquippedAuthoring>(authoring, out component8);
		TryGetActiveComponent<SupportsConditionsAuthoring>(authoring, out var component9);
		EntityMonoBehaviourData component10;
		bool flag9 = TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out component10);
		ObjectAuthoring component11;
		bool flag10 = TryGetActiveComponent<ObjectAuthoring>(authoring, out component11);
		if (flag && !flag9 && !flag10)
		{
			Debug.LogError($"Cannot setup weapon leveling without an EntityMonoBehaviourData/ObjectAuthoring component on {authoring}");
			flag = false;
		}
		if (flag8 && !flag9 && !flag10)
		{
			Debug.LogError($"Cannot setup conditions leveling without an EntityMonoBehaviourData/ObjectAuthoring component on {authoring}");
			flag8 = false;
		}
		if (!flag && !flag4 && !flag8 && !flag6 && !flag7)
		{
			return;
		}
		uint num2 = 1u;
		if (flag9)
		{
			num2 = (uint)(component10.objectInfo.objectID + 1);
		}
		else if (flag10)
		{
			num2 = (uint)component11.objectName.GetHashCode();
		}
		EnsureHasBuffer<LevelEntitiesBuffer>();
		for (int i = 0; i <= LevelScaling.GetMaxLevel(); i++)
		{
			Entity entity = CreateAdditionalEntity();
			AddToBuffer(new LevelEntitiesBuffer
			{
				entity = entity
			});
			if (flag)
			{
				float cooldown = component.ComputeCooldown();
				int damage = component.LevelToDamage(i, num2, cooldown);
				AddComponentData(entity, new WeaponDamageCD
				{
					damage = damage
				});
			}
			if (flag4)
			{
				float multiplier = ((component2 != null) ? component2.damageMultiplier : 1f);
				float multiplier2 = ((component2 != null) ? component2.miningDamageMultiplier : 1f);
				int explosionVariation = ((!(component2 != null)) ? 1 : component2.explosionVariation);
				int damage2 = ExplosiveAuthoring.LevelToExplosionDamage(i, multiplier);
				int tileDamage = ExplosiveAuthoring.LevelToMiningDamage(i, multiplier2, isEnemy: false);
				AddComponentData(entity, new IsExplosiveCD
				{
					damage = damage2,
					tileDamage = tileDamage,
					explosionID = ObjectID.Explosion,
					explosionVariation = explosionVariation
				});
				EnsureHasComponent<HasExplodedCD>(componentIsEnabled: false);
			}
			if (flag5)
			{
				int manaCost = component5.ComputeManaCostFromLevel(i);
				AddComponentData(entity, new ConsumesManaCD
				{
					manaCost = manaCost
				});
			}
			if (flag8)
			{
				_cachedEquipmentConditionList.Clear();
				List<EquipmentCondition> cachedEquipmentConditionList = _cachedEquipmentConditionList;
				cachedEquipmentConditionList.AddRange(component8.givesConditionsWhenEquipped);
				List<EquipmentCondition> list = ConditionExtensions.LevelToEquipmentConditionValues(cachedEquipmentConditionList, _cachedConditionList, i, num2, component8.givesConditionsWhenHeldInHand, component8.isArmor, isEnemy: false, ConditionsTable);
				EnsureHasBuffer<GivesConditionsWhenEquippedBuffer>(entity);
				foreach (EquipmentCondition item in list)
				{
					AddToBuffer(entity, new GivesConditionsWhenEquippedBuffer
					{
						equipmentCondition = item
					});
				}
			}
			if (flag7)
			{
				int size = (component7.sameSizeForAllLevels.hasValue ? component7.sameSizeForAllLevels.value : ExtraInventorySizeAuthoring.GetSizeFromLevel(i));
				int nextLevelSize = (component7.sameSizeForAllLevels.hasValue ? component7.sameSizeForAllLevels.value : ExtraInventorySizeAuthoring.GetSizeFromLevel(i + 1));
				AddComponentData(entity, new ExtraInventoryCD
				{
					size = size,
					nextLevelSize = nextLevelSize,
					categoryTagsMask = ObjectCategoryTagsCD.ConvertToBitMask(component7.canOnlyContainObjectsWithCategoryTags),
					isPouch = component7.isPouch
				});
			}
			if (!flag6)
			{
				continue;
			}
			_cachedSupportandAffixConditionList.Clear();
			List<ConditionData> cachedSupportandAffixConditionList = _cachedSupportandAffixConditionList;
			cachedSupportandAffixConditionList.AddRange(component9.initialConditions);
			ConditionExtensions.LevelToConditionValues(cachedSupportandAffixConditionList, i, num2, isHeldInHand: false, isArmor: false, isEnemy: false, ConditionsTable);
			EnsureHasBuffer<ConditionsBuffer>(entity);
			foreach (ConditionData item2 in cachedSupportandAffixConditionList)
			{
				AddToBuffer(entity, new ConditionsBuffer
				{
					condition = new Condition
					{
						conditionData = item2
					}
				});
			}
		}
	}
}
