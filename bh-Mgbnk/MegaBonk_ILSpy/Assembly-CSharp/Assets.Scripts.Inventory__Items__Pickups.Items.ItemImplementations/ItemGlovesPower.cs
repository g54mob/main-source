using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesPower : ItemBase
{
	private float knockbackForce = 9999f;

	public float procChancePerAmount = 0.08f;

	private float procChance;

	private float baseDamageMultiplier = 1.25f;

	private float radiusPerAmount = 5f;

	private float radius = 9f;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	private float readyAtTime;

	private float cooldown;

	public ItemGlovesPower(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		reuseDc = damageContainer;
		cooldown = 1f;
		base._002Ector(itemInventoryRef);
	}

	protected override void OnInitOrAmountChanged()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		float num = (float)amount * 0.2f;
		float num2 = 3.2f - num;
		bool flag = 0.2f > num2;
		float num3 = 0.2f;
		if (!flag)
		{
			bool flag2 = num2 > 1.5f;
			num3 = 1.5f;
			if (!flag2)
			{
				num3 = num2;
			}
		}
		cooldown = num3;
		object obj = amount * radiusPerAmount;
		float num4 = (float)obj + 10f;
		radius = num4;
		float input = (float)amount * procChancePerAmount;
		float num5 = StatScaling.HyperbolicScaling(input);
		procChance = num5;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		//IL_03a2: Expected O, but got I4
		//IL_04c8: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0139: Expected O, but got I
		//IL_043a: Expected I, but got O
		//IL_033e: Expected O, but got Ref
		//IL_020d: Expected O, but got I
		//IL_03d6: Expected I, but got O
		//IL_02fb: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (readyAtTime > MyTime.time || !ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		Transform transform = dc.enemy.transform;
		Vector3 position = transform.position;
		ref Collider[] buffer = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		_ = position.x;
		_ = position.z;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, radius, out buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		float num = MyTime.time + cooldown;
		readyAtTime = num;
		object obj3 = 0;
		Vector3 direction = default(Vector3);
		Enemy enemy2 = default(Enemy);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
			object obj4 = 0;
			ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			EnemyManager instance = EnemyManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ r10_v6+20+v377 @ rdi_v9*8]");
			if (instance.GetEnemy((Collider)0, out enemy))
			{
				num = GetDamage();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				Transform transform2 = ((Component)0).transform;
				Vector3 position2 = transform2.position;
				Transform transform3 = MyPlayer.Instance.transform;
				Vector3 position3 = transform3.position;
				float num2 = position2.z - position3.z;
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, num, 0f, damageSource, direction, enemy2);
				reuseDc = damageContainer;
				DamageContainer damageContainer2 = reuseDc;
				damageContainer2.knockback = knockbackForce;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				((Enemy)0).DamageFromPlayerOther(reuseDc);
			}
			obj3++;
		}
		while ((nint)obj3 < enemiesInRadiusSafe);
		if (fx == null)
		{
			EffectManager instance2 = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance2.glovePower);
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			fx = component;
			Transform transform4 = fx.transform;
			MyPlayer instance3 = MyPlayer.Instance;
			transform4.parentInternal = instance3.feet;
			Transform transform5 = fx.transform;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			float num5 = (float)Vector3.upVector * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num6 = 0f * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num7 = 0f * 0.01f;
			Vector3 localPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			transform5.localPosition = localPosition;
		}
		Transform transform6 = fx.transform;
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		_ = Vector3.oneVector;
		float num10 = (float)Vector3.oneVector * radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
		float num11 = 0f * radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rdx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num12 = 0f * radius;
		Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		transform6.localScale = localScale;
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

	public override void Tick()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	unsafe static ItemGlovesPower()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
