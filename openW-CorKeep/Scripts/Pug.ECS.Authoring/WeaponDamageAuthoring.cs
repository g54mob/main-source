using Unity.Mathematics;
using UnityEngine;

public class WeaponDamageAuthoring : MonoBehaviour
{
	public int damage;

	public float damageMultiplier = 1f;

	public bool isRange;

	public bool isMagic;

	[HideInInspector]
	public AreaLevelAuthoring level;

	[HideInInspector]
	public EntityMonoBehaviourData entityMono;

	[HideInInspector]
	public CooldownAuthoring cooldown;

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (level == null || level.gameObject != base.gameObject)
		{
			level = GetComponent<AreaLevelAuthoring>();
		}
		if (entityMono == null || entityMono.gameObject != base.gameObject)
		{
			entityMono = GetComponent<EntityMonoBehaviourData>();
		}
		if (cooldown == null || cooldown.gameObject != base.gameObject)
		{
			cooldown = GetComponent<CooldownAuthoring>();
		}
		if (!(level != null))
		{
			return;
		}
		uint seed = 1u;
		if (entityMono != null)
		{
			seed = (uint)(entityMono.objectInfo.objectID + 1);
		}
		else
		{
			ObjectAuthoring component = GetComponent<ObjectAuthoring>();
			if (component != null)
			{
				seed = (uint)component.objectName.GetHashCode();
			}
		}
		int num = level.CalculateLevel();
		float num2 = ((cooldown != null) ? cooldown.cooldown : (isRange ? 0.6f : 0.4f));
		damage = LevelToDamage(num, seed, num2);
	}

	public int LevelToDamage(int level, uint seed, float cooldown)
	{
		float num = Unity.Mathematics.Random.CreateFromIndex(seed).NextFloat(0.95f, 1f);
		float num2 = (isRange ? 1.2f : 1.7f);
		float num3 = ((isMagic && isRange) ? 1.3f : 1f);
		float num4 = 1f;
		num4 = ((!isRange) ? (cooldown / 0.4f) : (cooldown / 0.6f));
		return (int)math.round((float)(10 + math.max(1, level) * 10) * damageMultiplier * num4 * num * num2 * num3);
	}

	public float ComputeCooldown()
	{
		if (TryGetComponent<CooldownAuthoring>(out var component) && component.enabled)
		{
			return component.cooldown;
		}
		if (!isRange)
		{
			return 0.4f;
		}
		return 0.6f;
	}
}
