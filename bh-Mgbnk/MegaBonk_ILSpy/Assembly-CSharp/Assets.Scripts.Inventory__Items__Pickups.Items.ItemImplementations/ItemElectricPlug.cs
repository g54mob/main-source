using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemElectricPlug : ItemBase
{
	public static string damageSource;

	private DamageContainer reuseDc;

	private float radius;

	private float radiusPerAmount;

	private int targets;

	private int targetsPerAmount;

	private int targetsDefault;

	protected override void OnInitOrAmountChanged()
	{
		//IL_002f: Expected O, but got I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected I4, but got Unknown
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float num = stat * radiusPerAmount;
		object obj = amount - 1;
		object obj2 = obj * targetsPerAmount;
		float num2 = num + 12f;
		int num3 = obj2 + targetsDefault;
		targets = num3;
		radius = num2;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		return instance.baseDamage * 0.8f;
	}

	public override void Init()
	{
		//IL_0101: Expected I, but got O
		Action b = OnPlayerHit;
		Delegate obj = Delegate.Combine(PlayerHealth.A_DamagePlayerCalled, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			PlayerHealth.A_DamagePlayerCalled = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0101: Expected I, but got O
		Action value = OnPlayerHit;
		Delegate obj = Delegate.Remove(PlayerHealth.A_DamagePlayerCalled, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			PlayerHealth.A_DamagePlayerCalled = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnPlayerHit()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0047: Expected O, but got Ref
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_00fe: Expected O, but got I
		//IL_0162: Expected O, but got Ref
		//IL_0220: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_024f: Expected I, but got O
		//IL_025d: Expected O, but got Ref
		//IL_02a4: Expected O, but got Ref
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), radius, out var buffer);
		if (enemiesInRadiusSafe > 0)
		{
			float num2 = radius;
			num = position.x;
			string text = null;
			string text2 = null;
			Vector3 vector = default(Vector3);
			Enemy enemy = default(Enemy);
			float num6 = default(float);
			bool useSfx = default(bool);
			string text3;
			do
			{
				if (EnemyManager.Instance.GetEnemy(buffer[(object)text], out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136))))
				{
					float damage = GetDamage();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					Transform transform2 = ((Component)0).transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = MyPlayer.Instance.transform;
					Vector3 position3 = transform3.position;
					float num3 = position2.x - position3.x;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, 0.5f, damageSource, vector, enemy);
					reuseDc = damageContainer;
					DamageContainer damageContainer2 = reuseDc;
					damageContainer2.element = EElement.Lightning;
					DamageContainer damageContainer3 = reuseDc;
					float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
					float knockback = stat * 1.5f;
					damageContainer3.knockback = knockback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					((Enemy)0).DamageFromPlayerOther(reuseDc);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
					nint num4 = (nint)typeof(Vector3);
					Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v48 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v49 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					_ = Vector3.zeroVector;
					EffectManager.Instance.EnemyHitEffect((Vector3)(&num6), moveDir, hitEnemy: true, (string)vector, (GameObject)(object)enemy, useSfx);
					text2++;
					bool flag = (nint)text2 >= targets;
					num2 = 0.5f;
					num = num3;
					if (flag)
					{
						break;
					}
				}
				text++;
				text3 = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
			}
			while ((nint)text3 < 0);
		}
		EffectManager.Instance.ElectricalPlugEffect();
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public unsafe ItemElectricPlug(ItemInventory itemInventoryRef)
	{
		//IL_005f: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		DamageContainer damageContainer = new DamageContainer(0.5f, text);
		reuseDc = damageContainer;
		radius = 13f;
		radiusPerAmount = 4f;
		targets = 15;
		targetsPerAmount = 4;
		targetsDefault = 6;
		base._002Ector(itemInventoryRef);
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

	unsafe static ItemElectricPlug()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
