using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class ProjectileDice : ProjectileBasic
{
	public float explosionRadius;

	public GameObject diceFx;

	public GameObject diceFx6;

	public RotateObjectRandomly rotator;

	private float fxCooldown;

	private float maxScale;

	private int diceRoll;

	public static Action A_RollSix;

	private string explosionFxName;

	private string explosionFxName6;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0246: Expected I4, but got O
		//IL_00a2: Expected O, but got Ref
		//IL_0217: Expected O, but got Ref
		currentTarget = null;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase = base.weaponBase;
			if (base.weaponBase != null)
			{
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					float num = default(float);
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, exceptObject);
					if (!(enemy != null))
					{
						return false;
					}
					if ((object)enemy != null)
					{
						Vector3 centerPosition = enemy.GetCenterPosition();
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							Vector3 position2 = transform2.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							object obj = default(object);
							direction = (Vector3)obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v19+8]");
							_ = 0;
							if ((object)rotator != null)
							{
								rotator.Start();
								if (MyRandom.random != null)
								{
									int num2 = MyRandom.random.Next(1, 7);
									diceRoll = num2;
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										if (transform3.localScale.x > maxScale)
										{
											Transform transform4 = base.transform;
											if ((object)transform4 == null)
											{
												goto IL_0238;
											}
											transform4.localScale = (Vector3)(&num);
										}
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0238;
		IL_0238:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_00c7: Expected I4, but got O
		if ((object)collider != null)
		{
			GameObject gameObject = collider.gameObject;
			if ((object)gameObject != null)
			{
				int layer = gameObject.layer;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,esi\"");
					if ((nint)GameManager.Instance < 0)
					{
						Hitscan(collider);
						ProjectileDone();
						return true;
					}
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Hitscan(Collider collider)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_0513: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Expected O, but got Unknown
		//IL_011c: Expected O, but got I
		//IL_016e: Expected O, but got Ref
		//IL_0313: Expected F4, but got I4
		//IL_01a3: Expected O, but got Ref
		//IL_01a3: Expected O, but got I
		//IL_01d4: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_0220: Expected O, but got Ref
		//IL_0220: Expected O, but got I
		//IL_0255: Expected I4, but got F4
		//IL_0255: Expected O, but got Ref
		//IL_0255: Expected O, but got Ref
		//IL_0278: Expected F4, but got O
		//IL_0430: Expected I, but got O
		//IL_0435: Expected I, but got O
		//IL_048b: Expected O, but got Ref
		//IL_0490: Expected I, but got O
		//IL_0495: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		float value = base.weaponBase.GetValue(EStat.DamageMultiplier);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
		Transform transform = base.transform;
		float num = attackSizeMultiplier * explosionRadius;
		Vector3 position = transform.position;
		ref Collider[] reference = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), num, out reference);
		bool flag = enemiesInRadiusSafe <= 0;
		num2 = position.x;
		DamageContainer damageContainer = null;
		float x2 = default(float);
		if (!flag)
		{
			float num4 = default(float);
			float num5 = default(float);
			float x = default(float);
			Vector3 vector2 = default(Vector3);
			object obj7 = default(object);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
				object obj3 = 0;
				ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r10_v4+20+v236 @ rbx_v7 (Assets.Scripts.Actors.DamageContainer)*8]");
				bool enemy2 = instance.GetEnemy((Collider)0, out enemy);
				bool flag2 = !enemy2;
				reference = ref *(Collider[]*)null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
					Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
					Transform transform2 = MyPlayer.Instance.transform;
					Vector3 position2 = transform2.position;
					float num3 = centerPosition.x - position2.x;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					WeaponBase obj5 = base.weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
					DamageContainer damageContainer2 = WeaponUtility.GetDamageContainer(obj5, null, (Enemy)0, (Vector3)(&num4), num5);
					damageContainer2.element = EElement.Neutral;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
					object obj6 = 0;
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rcx_v23+20+v236 @ rbx_v7 (Assets.Scripts.Actors.DamageContainer)*8]");
					Vector3 vector = ((Collider)0).ClosestPoint((Vector3)(&x));
					attackSizeMultiplier = vector.x;
					weaponAttack.ProjectileHit((Vector3)(&x2), (Vector3)(&vector2), hitEnemy: true, (byte)(int)num5 != 0);
					x2 = vector.x;
					x = position3.x;
					num4 = (float)obj7;
					num2 = num3;
					reference = ref *(Collider[]*)1;
				}
				damageContainer = (DamageContainer)(damageContainer + 1);
			}
			while ((nint)damageContainer < enemiesInRadiusSafe);
		}
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		bool flag3 = FxUtility.weaponCooldowns.ContainsKey(weaponData.eWeapon);
		float num6 = num;
		nint num7 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
		if (!flag3)
		{
			WeaponBase weaponBase2 = base.weaponBase;
			WeaponData weaponData2 = weaponBase2.weaponData;
			((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).Add((System.Int32Enum)weaponData2.eWeapon, 0f);
			num6 = 0f;
			num7 = 0;
		}
		WeaponBase weaponBase3 = base.weaponBase;
		WeaponData weaponData3 = weaponBase3.weaponData;
		float num8 = ((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).get_Item((System.Int32Enum)weaponData3.eWeapon);
		bool flag4 = !(MyTime.time > num8);
		nint num9 = 0;
		if (!flag4)
		{
			WeaponBase weaponBase4 = base.weaponBase;
			WeaponData weaponData4 = weaponBase4.weaponData;
			num6 = MyTime.time + fxCooldown;
			((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).set_Item((System.Int32Enum)weaponData4.eWeapon, num6);
			PoolManager instance2;
			string source;
			GameObject hitPrefab;
			if (diceRoll == 6)
			{
				instance2 = PoolManager.Instance;
				source = explosionFxName;
				hitPrefab = diceFx6;
			}
			else
			{
				instance2 = PoolManager.Instance;
				source = explosionFxName6;
				hitPrefab = diceFx;
			}
			GameObject projectileDoneFx = instance2.GetProjectileDoneFx(source, hitPrefab);
			bool flag5 = projectileDoneFx != null;
			bool flag6 = !flag5;
			num7 = unchecked((nint)null);
			num9 = unchecked((nint)null);
			if (!flag6)
			{
				Transform transform4 = projectileDoneFx.transform;
				Transform transform5 = base.transform;
				num8 = transform5.position.x;
				transform4.position = (Vector3)(&x2);
				num7 = unchecked((nint)null);
				num9 = unchecked((nint)null);
			}
		}
		if (diceRoll == 6)
		{
			Action a_RollSix = A_RollSix;
			if (A_RollSix != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1132.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public ProjectileDice()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172D48]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		explosionRadius = 5f;
		fxCooldown = 0.06f;
		maxScale = 2.5f;
		explosionFxName = "diceFx";
		explosionFxName6 = "diceFx6";
		base._002Ector();
	}
}
