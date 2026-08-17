using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_WineGlass2_Weapon : Weapon
{
	private BulletPool _invisibleProjectilePool;

	private BulletPool _explosionProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	private Projectile _explosionProjectilePrefab;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override float PPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			EggDouble eggDouble = ((Equipment)this)._003COwner_003Ek__BackingField.PRevivals();
			if (eggDouble != null)
			{
				bool flag = !(1.0 < eggDouble._val);
				float num = 1f;
				if (!flag)
				{
					num = (float)eggDouble._val;
				}
				float num2 = base.PPower();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num3 = num2 + num2;
					return num3 * num;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_019a: Expected I, but got O
		//IL_0254: Expected I, but got O
		//IL_02f7: Expected I, but got O
		base.OnStart();
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				PhysicsManager physicsManager2 = core3._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+5C0]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider3 = physics3.add.overlap(_invisibleProjectilePool, physicsManager2._playerGroup, collideCallback3, processCallback, callbackContext);
				BulletPool explosionProjectilePool = new BulletPool(_explosionProjectilePrefab);
				_explosionProjectilePool = explosionProjectilePool;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+350]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num4 = (nint)this;
					Collider collider4 = physics4.add.overlap(_explosionProjectilePool, core4.Enemies, collideCallback4, processCallback, callbackContext);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						ArcadePhysics physics5 = s_scene5.physics;
						GameManager core5 = GM.Core;
						PhysicsManager physicsManager3 = core5._physicsManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+3A0]");
						ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
						nint num5 = (nint)this;
						Collider collider5 = physics5.add.overlap(_explosionProjectilePool, physicsManager3._destructiblesGroup, collideCallback5, processCallback, callbackContext);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FireProjectiles(Vector2 position)
	{
		float num = base.PAmount();
		int num2 = default(int);
		bool flag = num2 <= 0;
		int num3 = 0;
		if (!flag)
		{
			do
			{
				Projectile projectile = base.FireOneProjectile(position, num3, _targetTransform);
				num3++;
			}
			while (num2 > num3);
		}
	}

	public void FireExplosion(Vector2 position)
	{
		Projectile projectile = base.FireOneProjectile(position, 0, _targetTransform);
	}

	public override void Cleanup()
	{
		_invisibleProjectilePool.Cleanup();
		_explosionProjectilePool.Cleanup();
		base.Cleanup();
	}

	protected virtual bool OnFoodOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02cc: Expected I4, but got O
		//IL_0323: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		//IL_01e5: Expected O, but got I4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				if ((object)component != null)
				{
					if (component._isDead || component.IsDisconnectedFromOnlinePlay)
					{
						goto IL_02b8;
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
								if (component2.HasAlreadyHitObject(component))
								{
									goto IL_02b8;
								}
								component2.Despawn();
								component.RecoverHp(1f, showRecovery: true, mulByRegen: true);
								GameManager core = GM.Core;
								if ((object)GM.Core != null)
								{
									ArcanaManager arcanaManager = core._arcanaManager;
									if (core._arcanaManager != null)
									{
										bool flag = component._deficiencyControl == null;
										bool flag2 = true;
										if (!flag)
										{
											CharacterADControl deficiencyControl = component._deficiencyControl;
											object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
											bool flag3 = obj == null;
											flag2 = !flag3;
										}
										int num = component._PlayerIndex >> 31;
										int num2 = (flag2 ? 1 : 0) & num;
										bool flag4 = num2 == 0;
										object obj2 = !flag4;
										if (obj2 == null && arcanaManager._hasBreadAnathema)
										{
											if (arcanaManager.arcanaManager_Support == null)
											{
												goto IL_02be;
											}
											arcanaManager.arcanaManager_Support.OnFoodPickedUp(component, ItemType.VOID, 1f);
										}
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
										soundConfig.Volume = (float?)(object)1;
										soundConfig.Rate = 1f;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Recovery, soundConfig, 5f, 300, time);
										goto IL_02b8;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_02be;
		IL_02b8:
		return false;
		IL_02be:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
