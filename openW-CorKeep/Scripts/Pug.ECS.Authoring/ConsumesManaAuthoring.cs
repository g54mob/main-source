using Unity.Mathematics;
using UnityEngine;

public class ConsumesManaAuthoring : MonoBehaviour
{
	public int manaCost;

	public float manaCostMultiplier = 1f;

	[HideInInspector]
	public AreaLevelAuthoring levelAuthoring;

	[HideInInspector]
	public CooldownAuthoring cooldownAuth;

	[HideInInspector]
	public WeaponDamageAuthoring weaponDamage;

	[HideInInspector]
	public SecondaryUseAuthoring secondaryUse;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (levelAuthoring == null || levelAuthoring.gameObject != base.gameObject)
			{
				levelAuthoring = GetComponent<AreaLevelAuthoring>();
			}
			if (cooldownAuth == null || cooldownAuth.gameObject != base.gameObject)
			{
				cooldownAuth = GetComponent<CooldownAuthoring>();
			}
			if (weaponDamage == null || weaponDamage.gameObject != base.gameObject)
			{
				weaponDamage = GetComponent<WeaponDamageAuthoring>();
			}
			if (secondaryUse == null || secondaryUse.gameObject != base.gameObject)
			{
				secondaryUse = GetComponent<SecondaryUseAuthoring>();
			}
			if (levelAuthoring != null)
			{
				int level = levelAuthoring.CalculateLevel();
				bool flag = weaponDamage != null && weaponDamage.isRange;
				bool summonsMinion = secondaryUse != null && secondaryUse.mechanic == SecondaryUseMechanic.SpawnMinion;
				float cooldown = ((cooldownAuth != null) ? cooldownAuth.cooldown : (flag ? 0.6f : 0.4f));
				manaCost = LevelToManaCost(level, flag, summonsMinion, cooldown);
			}
		}
	}

	private int LevelToManaCost(int level, bool isRange, bool summonsMinion, float cooldown)
	{
		float num = (summonsMinion ? 2.5f : 1f);
		float num2 = cooldown;
		if (!isRange && !summonsMinion)
		{
			num2 = cooldown / 0.4f;
		}
		return (int)math.round((float)(10 + level) * manaCostMultiplier * num2 * num);
	}

	public int ComputeManaCost()
	{
		int result = manaCost;
		if (TryGetComponent<AreaLevelAuthoring>(out var component) && component.enabled)
		{
			result = ComputeManaCostFromLevel(component.level);
		}
		return result;
	}

	public int ComputeManaCostFromLevel(int level)
	{
		WeaponDamageAuthoring component;
		bool flag = TryGetComponent<WeaponDamageAuthoring>(out component) && component.isRange;
		CooldownAuthoring component2;
		bool num = TryGetComponent<CooldownAuthoring>(out component2);
		SecondaryUseAuthoring component3;
		bool summonsMinion = TryGetComponent<SecondaryUseAuthoring>(out component3) && component3.mechanic == SecondaryUseMechanic.SpawnMinion;
		float cooldown = (num ? component2.cooldown : (flag ? 0.6f : 0.4f));
		return LevelToManaCost(level, flag, summonsMinion, cooldown);
	}
}
