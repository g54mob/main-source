using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGamerGoggles : ItemBase
{
	private float maxDamagePerAmount = 1f;

	private float maxDamage;

	private float updateCooldown = 1f;

	private float nextUpdateTime;

	private float lastValue = -1f;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * maxDamagePerAmount;
		maxDamage = num;
	}

	public override void Tick()
	{
		//IL_0076: Invalid comparison between F4 and I4
		//IL_00cb: Expected F4, but got I4
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00ff: Invalid comparison between F4 and O
		if (!(nextUpdateTime > MyTime.time))
		{
			float num = MyTime.time + updateCooldown;
			nextUpdateTime = num;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int combinedHp = inventory.playerHealth.GetCombinedHp();
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int combinedMaxHp = inventory2.playerHealth.GetCombinedMaxHp();
			int num2 = combinedHp / combinedMaxHp;
			float num5;
			if (0.5f > (float)num2)
			{
				float num3 = 0.5f - (float)num2;
				float num4 = num3 + num3;
				num5 = num4 * maxDamage;
			}
			else
			{
				num5 = 0f;
			}
			float num6 = lastValue - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = num6 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.02f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				StatModifier statModifier = new StatModifier();
				statModifier.modification = num5;
				statModifier.stat = EStat.DamageMultiplier;
				SetStat(statModifier);
				lastValue = num5;
			}
		}
	}

	public ItemGamerGoggles(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
