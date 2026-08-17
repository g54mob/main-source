using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesCursed : ItemBase
{
	public float procChancePerAmount = 0.05f;

	private float procChance;

	private float difficultyPerAmount = 0.1f;

	private float maxHpMultiplierPerAmount = 0.8f;

	private float baseDamageMultiplier = 0.85f;

	private float baseRadius = 4f;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	public ItemGlovesCursed(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		reuseDc = damageContainer;
		maxProcsPerTick = 250;
		base._002Ector(itemInventoryRef);
	}

	protected override void OnInitOrAmountChanged()
	{
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input, 0.5f, 0.8f);
		procChance = num;
		StatModifier statModifier = new StatModifier();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		statModifier.modification = maxHpMultiplierPerAmount;
		statModifier.stat = EStat.MaxHealth;
		statModifier.modifyType = EStatModifyType.Multiplication;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		float modification = (float)amount * difficultyPerAmount;
		statModifier2.stat = EStat.Difficulty;
		statModifier2.modifyType = EStatModifyType.Flat;
		statModifier2.modification = modification;
		SetStat(statModifier2);
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0093: Expected O, but got Ref
		//IL_0134: Expected O, but got I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_02cd: Expected O, but got Ref
		if (numProcsThisTick >= maxProcsPerTick || !ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		int num = numProcsThisTick + 1;
		numProcsThisTick = num;
		Transform transform = dc.enemy.transform;
		Vector3 position = transform.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), baseRadius, out var buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		float num3 = (float)amount * baseDamageMultiplier;
		float baseDamage = num3 * instance.baseDamage;
		Vector3 direction = default(Vector3);
		Enemy enemy = default(Enemy);
		DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, baseDamage, 0f, damageSource, direction, enemy);
		reuseDc = damageContainer;
		DamageContainer damageContainer2 = reuseDc;
		object obj = 0;
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[obj], out var enemy2))
			{
				DamageContainer damageContainer3 = reuseDc;
				damageContainer3.damage = damageContainer2.damage;
				DamageContainer damageContainer4 = reuseDc;
				damageContainer4.enemy = enemy2;
				enemy2.DamageFromPlayerOther(reuseDc);
			}
			obj++;
		}
		while ((nint)obj < enemiesInRadiusSafe);
		if (fx == null)
		{
			EffectManager instance2 = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance2.gloveCurse);
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			fx = component;
		}
		GameObject gameObject2 = fx.gameObject;
		gameObject2.SetActive(value: true);
		Transform transform2 = fx.transform;
		Transform transform3 = dc.enemy.transform;
		Vector3 position2 = transform3.position;
		Vector3 vector = default(Vector3);
		transform2.position = (Vector3)(&vector);
		fx.Play();
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		float num = (float)amount * baseDamageMultiplier;
		return num * instance.baseDamage;
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = procChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"chance", (object)value);
			string text = EnumUtility.EnumToReadable(EStat.Difficulty);
			if (text == null)
			{
				text = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = difficultyPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"+{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value2);
			string text2 = EnumUtility.EnumToReadable(EStat.MaxHealth);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg3 = default(object);
			string value3 = $"{arg3}x";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value3);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
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

	unsafe static ItemGlovesCursed()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
