using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Ex_CoinToss1_Weapon : Weapon
{
	protected BulletPool _coin010Pool;

	protected BulletPool _coin025Pool;

	protected BulletPool _coin100Pool;

	protected Projectile _coin010Prefab;

	protected Projectile _coin025Prefab;

	protected Projectile _coin100Prefab;

	public float ProjectileYOffset;

	private bool _003CIsAutoFiring_003Ek__BackingField;

	public bool IsAutoFiring
	{
		get
		{
			return _003CIsAutoFiring_003Ek__BackingField;
		}
		set
		{
			_003CIsAutoFiring_003Ek__BackingField = value;
		}
	}

	public virtual bool HasGreedMult => false;

	public override float PInterval()
	{
		if (_003CIsAutoFiring_003Ek__BackingField)
		{
			return 1000f;
		}
		return base.PInterval();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0132: Expected I, but got O
		//IL_02b9: Expected I, but got O
		//IL_0440: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_coin010Pool != null)
		{
			goto IL_016a;
		}
		BulletPool bulletPool = new BulletPool(_coin010Prefab);
		bulletPool.UpperLimit = 100;
		_coin010Pool = bulletPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy10;
			Collider collider = physics.add.overlap(_coin010Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ r8_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_CoinToss1_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider2 = physics2.add.overlap(_coin010Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_016a;
			}
		}
		goto IL_0479;
		IL_016a:
		if (_coin025Pool != null)
		{
			goto IL_02f1;
		}
		BulletPool bulletPool2 = new BulletPool(_coin025Prefab);
		bulletPool2.UpperLimit = 100;
		_coin025Pool = bulletPool2;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemy25;
			Collider collider3 = physics3.add.overlap(_coin025Pool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_CoinToss1_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider4 = physics4.add.overlap(_coin025Pool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_02f1;
			}
		}
		goto IL_0479;
		IL_0479:
		throw new NullReferenceException();
		IL_02f1:
		if (_coin100Pool != null)
		{
			return;
		}
		BulletPool bulletPool3 = new BulletPool(_coin100Prefab);
		bulletPool3.UpperLimit = 100;
		_coin100Pool = bulletPool3;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			ArcadePhysics physics5 = s_scene5.physics;
			GameManager core5 = GM.Core;
			ArcadePhysicsCallback collideCallback5 = OnBulletOverlapsEnemy100;
			Collider collider5 = physics5.add.overlap(_coin100Pool, core5.Enemies, collideCallback5, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				ArcadePhysics physics6 = s_scene6.physics;
				GameManager core6 = GM.Core;
				PhysicsManager physicsManager3 = core6._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_CoinToss1_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider6 = physics6.add.overlap(_coin100Pool, physicsManager3._destructiblesGroup, collideCallback6, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0479;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00e2: Expected O, but got I4
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0308: Expected I4, but got O
		//IL_030c: Expected O, but got I4
		//IL_0319: Expected O, but got I8
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_0101: Expected O, but got I8
		//IL_00c6: Expected O, but got I4
		//IL_0113: Expected I, but got O
		//IL_0121: Expected I, but got O
		//IL_0131: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_01b1: Expected O, but got I4
		//IL_016d: Expected O, but got I
		//IL_01a3: Expected O, but got I4
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x1874F0870\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 63 Invalid \"Jump target not found in method: 0x1874F0870\"");
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 76 Invalid \"Jump target not found in method: 0x1874F0870\"");
		float num = ((!_003CIsAutoFiring_003Ek__BackingField) ? 1f : 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 104 Invalid \"Jump target not found in method: 0x1874F086C\"");
		float num2 = num * 10000f;
		object obj;
		if (!(num2 > config._003CRunCoins_003Ek__BackingField))
		{
			num2 = num * 25000f;
			if (!(num2 > config._003CRunCoins_003Ek__BackingField))
			{
				num2 = num * 100000f;
				if (!(num2 > config._003CRunCoins_003Ek__BackingField))
				{
					num *= 100000f;
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 167 Invalid \"Jump target not found in method: 0x1874F086C\"");
					float num3 = 100000f;
					obj = 4;
				}
				else
				{
					float num3 = 100000f;
					obj = 3;
				}
			}
			else
			{
				obj = 2;
			}
		}
		else
		{
			obj = 1;
		}
		object obj2 = obj + 4;
		object obj3 = UnityEngine.Random.RandomRangeInt(1, (int)obj2);
		object obj4 = 6442450944L;
		object obj5 = obj3 - 1;
		Projectile projectile = default(Projectile);
		if ((nint)obj5 <= 6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r12_v1+74F0890+v240 @ rcx_v6*4]");
			object obj6 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v256 @ rdx_v7 (should have been resolved before IL gen)");
		}
		else
		{
			BulletPool pool2 = default(BulletPool);
			projectile = base.FireOneProjectile(pos, index, target, pool2);
			if ((object)projectile == null)
			{
				goto IL_02ce;
			}
		}
		nint num4 = (nint)projectile;
		nint num5 = (nint)typeof(EX_CoinToss1_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_CoinToss1_Projectile>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_CoinToss1_Projectile>)+130]");
		object obj9;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v34+FFFFFFF8+v320 @ rax_v30*8]");
			if (0 == (nint)typeof(EX_CoinToss1_Projectile))
			{
				obj9 = 1;
				goto IL_02b1;
			}
		}
		obj9 = 0;
		goto IL_02b1;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 374 Invalid \"Jump target not found in method: 0x1874F0846\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 399 Invalid \"Jump target not found in method: 0x1874F0846\"");
		Projectile result = (Projectile)(obj3 - 1);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 445 Invalid \"Jump target not found in method: 0x1874F07DC\"");
		return result;
		IL_02b1:
		if (obj9 == null)
		{
		}
		goto IL_02ce;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_016c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0189;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if (HasGreedMult)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_015e;
										}
										float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
									}
									base.DealDamage(component, 1f);
								}
								goto IL_0189;
							}
						}
					}
				}
			}
		}
		goto IL_015e;
		IL_0189:
		return false;
		IL_015e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected bool OnBulletOverlapsEnemy10(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_016c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0189;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if (HasGreedMult)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_015e;
										}
										float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
									}
									float damage = 1f * 10f;
									base.DealDamage(component, damage);
								}
								goto IL_0189;
							}
						}
					}
				}
			}
		}
		goto IL_015e;
		IL_0189:
		return false;
		IL_015e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected bool OnBulletOverlapsEnemy25(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_016c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0189;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if (HasGreedMult)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_015e;
										}
										float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
									}
									float damage = 1f * 25f;
									base.DealDamage(component, damage);
								}
								goto IL_0189;
							}
						}
					}
				}
			}
		}
		goto IL_015e;
		IL_0189:
		return false;
		IL_015e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected bool OnBulletOverlapsEnemy100(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_016c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0189;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if (HasGreedMult)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_015e;
										}
										float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
									}
									float damage = 1f * 100f;
									base.DealDamage(component, damage);
								}
								goto IL_0189;
							}
						}
					}
				}
			}
		}
		goto IL_015e;
		IL_0189:
		return false;
		IL_015e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
