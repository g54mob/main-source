using UnityEngine;

[DisallowMultipleComponent]
public class DurabilityAuthoring : MonoBehaviour
{
	[Header("Durability properties")]
	public int durability;

	public float durabilityMultiplier = 1f;

	public int maxDurability;

	[Header("Repair/reinforce properties")]
	public float repairMultiplier = 1f;

	public float reinforceCostMultiplier = 1f;

	[HideInInspector]
	public EntityMonoBehaviourData entityMono;

	private const int BaseDurabilityHelmArmor = 90;

	private const int BaseDurabilityBreastArmor = 100;

	private const int BaseDurabilityPantsArmor = 95;

	private const int BaseDurabilityHoe = 250;

	private const int BaseDurabilityShovel = 100;

	private const int BaseDurabilitySledge = 200;

	private const int BaseDurabilityDrillTool = 250;

	private const int BaseDurabilityMeleeWeapon = 350;

	private const int BaseDurabilityRangeWeapon = 250;

	private const int BaseDurabilityShield = 100;

	private const int BaseDurabilitySummoningWeapon = 100;

	private const int BaseDurabilityMiningPick = 800;

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (entityMono == null || entityMono.gameObject != base.gameObject)
		{
			entityMono = GetComponent<EntityMonoBehaviourData>();
		}
		if (entityMono == null)
		{
			ObjectAuthoring component = GetComponent<ObjectAuthoring>();
			if (component == null)
			{
				return;
			}
			durability = CalculateObjectDurability(component.initialAmount, component.objectType);
		}
		else
		{
			durability = CalculateObjectDurability(entityMono.objectInfo.initialAmount, entityMono.objectInfo.objectType);
		}
		maxDurability = durability;
	}

	public int CalculateObjectDurability(int amount, ObjectType objectType)
	{
		int result = amount;
		CooldownAuthoring component;
		bool flag = TryGetComponent<CooldownAuthoring>(out component);
		switch (objectType)
		{
		case ObjectType.Helm:
			result = Mathf.RoundToInt(90f * durabilityMultiplier);
			break;
		case ObjectType.BreastArmor:
			result = Mathf.RoundToInt(100f * durabilityMultiplier);
			break;
		case ObjectType.PantsArmor:
			result = Mathf.RoundToInt(95f * durabilityMultiplier);
			break;
		case ObjectType.Hoe:
			result = Mathf.RoundToInt(250f * durabilityMultiplier);
			break;
		case ObjectType.Shovel:
			result = Mathf.RoundToInt(100f * durabilityMultiplier);
			break;
		case ObjectType.Sledge:
		case ObjectType.RoofingTool:
			result = Mathf.RoundToInt(200f * durabilityMultiplier);
			break;
		case ObjectType.DrillTool:
		case ObjectType.BeamWeapon:
			result = Mathf.RoundToInt(250f * durabilityMultiplier);
			break;
		case ObjectType.MeleeWeapon:
		{
			float num2 = ((flag && component.enabled) ? component.cooldown : 0.4f);
			result = Mathf.RoundToInt(350f * durabilityMultiplier * 0.4f / num2);
			break;
		}
		case ObjectType.RangeWeapon:
		case ObjectType.ThrowingWeapon:
		{
			float num = ((flag && component.enabled) ? component.cooldown : 0.6f);
			result = Mathf.RoundToInt(250f * durabilityMultiplier * 0.6f / num);
			break;
		}
		case ObjectType.Offhand:
			result = Mathf.RoundToInt(100f * durabilityMultiplier);
			break;
		case ObjectType.SummoningWeapon:
			result = Mathf.RoundToInt(100f * durabilityMultiplier);
			break;
		case ObjectType.MiningPick:
			result = Mathf.RoundToInt(800f * durabilityMultiplier);
			break;
		}
		return result;
	}
}
