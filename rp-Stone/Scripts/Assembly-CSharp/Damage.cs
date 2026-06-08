using System.Collections.Generic;

public class Damage
{
	public enum Type
	{
		Melee = 0,
		Ranged = 1,
		Dot = 2,
		Super = 3
	}

	public Type type = Type.Ranged;

	public int amount;

	public List<string> tags = new List<string>();

	public bool isCritical;

	public float criticalMultiplier = 1f;

	public bool showFloatingText;

	public int targetCountHit = 1;

	public int hitpointsLost;

	public float armorLost;

	public int startHitpoints;

	public int endHitpoints;

	public float startArmor;

	public float endArmor;

	public Character Owner { get; set; }

	public Bullet bullet { get; set; }

	public ItemData.Element GetElement()
	{
		if (Owner != null)
		{
			return Owner.GetElement();
		}
		if (bullet != null)
		{
			return bullet.GetElement();
		}
		return ItemData.Element.Stone;
	}

	public void AddBonusDamageForCharacter(Character character, int bonusDamage, string[] bonusDamageTo)
	{
		if (bonusDamage <= 0)
		{
			return;
		}
		for (int i = 0; i < bonusDamageTo.Length; i++)
		{
			if (character.tags.Contains(bonusDamageTo[i]))
			{
				amount += bonusDamage;
				break;
			}
		}
	}

	public static object SSNew(List<object> parameters, InvocationContext ctx)
	{
		return new SSNativeObject<Damage>(new Damage());
	}

	[StonescriptNativeGetter("amount")]
	public object Property_GetAmount()
	{
		return amount;
	}

	[StonescriptNativeSetter("amount")]
	public void Property_SetAmount(object value)
	{
		amount = (int)value;
	}

	[StonescriptNativeGetter("isCritical")]
	public object Property_GetCritial()
	{
		return isCritical;
	}

	[StonescriptNativeSetter("isCritical")]
	public void Property_SetCritial(object value)
	{
		isCritical = (bool)value;
	}

	[StonescriptNativeGetter("type")]
	public object Property_GetType()
	{
		return type.ToString();
	}

	[StonescriptNativeGetter("startHitpoints")]
	public object Property_GetStartHitpoints()
	{
		return startHitpoints;
	}

	[StonescriptNativeGetter("endHitpoints")]
	public object Property_GetEndHitpoints()
	{
		return endHitpoints;
	}

	[StonescriptNativeGetter("hitpointsLost")]
	public object Property_GetHitpointsLost()
	{
		return hitpointsLost;
	}

	[StonescriptNativeGetter("startArmor")]
	public object Property_GetStartArmor()
	{
		return startArmor;
	}

	[StonescriptNativeGetter("endArmor")]
	public object Property_GetEndArmor()
	{
		return endArmor;
	}

	[StonescriptNativeGetter("armorLost")]
	public object Property_GetArmorLost()
	{
		return armorLost;
	}

	[StonescriptNativeGetter("owner")]
	public object Property_GetOwner()
	{
		return Owner.ssObject;
	}

	[StonescriptNativeGetter("weapon")]
	public object Property_GetWeapon()
	{
		return bullet?.weapon?.ssObject;
	}

	[StonescriptNativeGetter("tags")]
	public object Property_GetTags()
	{
		return string.Join(",", tags);
	}
}
