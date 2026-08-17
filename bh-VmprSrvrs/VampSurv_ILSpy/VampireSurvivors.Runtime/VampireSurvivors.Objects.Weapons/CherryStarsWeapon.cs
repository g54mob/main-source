using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class CherryStarsWeapon : CherryWeapon
{
	private CherryStarProjectile _bulletA;

	private bool _hasBullets;

	private bool _hasImage;

	private bool _hasCharacterImage;

	private PhaserSprite _cow;

	private BulletPool _explosionPool;

	private BulletPool _drawerPool;

	private float _critChance = 0.05f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0032: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_008c: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController2._characterType != CharacterType.CAVALLO)
		{
			return;
		}
		nint num = (nint)characterController2;
		nint num2 = (nint)typeof(CharacterControllerYattaCavallo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerYattaCavallo>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerYattaCavallo>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v9+FFFFFFF8+v66 @ rax_v8*8]");
			if (0 == (nint)typeof(CharacterControllerYattaCavallo))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (VampireSurvivors.Objects.Characters.CharacterController)+428]");
				_hasCharacterImage = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override float SecondaryPPower()
	{
		//IL_0053: Expected O, but got I
		//IL_0108: Invalid comparison between F4 and I
		List<float> critChancesArray = _critChancesArray;
		if (_critChancesArray != null)
		{
			int critIndex = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)critIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			float num2 = default(float);
			if ((nint)num >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return num2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v7+18]");
				if ((nint)num >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					num2 *= _critChance;
					float num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v7+20+v57 @ rdx_v5 (System.Int32)*4]");
					float num6;
					if (num4 > 0f)
					{
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							goto IL_020c;
						}
						float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
						num6 = num2 * ArcanaManager.CritMul;
					}
					else
					{
						num6 = 1f;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						float num7 = base.PAmount();
						float num8 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
								float num9 = num8 * num6;
								float num10 = num9 * num2;
								return num2 + num10;
							}
						}
					}
				}
			}
		}
		goto IL_020c;
		IL_020c:
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		if (!_hasBullets)
		{
			InitBullets();
			_hasBullets = true;
		}
	}

	public void ShootStarAt(float x, float y, int index)
	{
		float2 pos = default(float2);
		Projectile projectile = _explosionPool.SpawnAt(pos, this, index);
	}

	public void InitBullets()
	{
		//IL_037c: Expected I, but got O
		//IL_038a: Expected I, but got O
		//IL_039a: Expected O, but got I
		//IL_041a: Expected O, but got I4
		//IL_03d6: Expected O, but got I
		//IL_040c: Expected O, but got I4
		//IL_009e: Expected I, but got O
		//IL_0235: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02d8: Expected I, but got O
		if (_drawerPool != null)
		{
			goto IL_017a;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.CHERRY_STAR);
		BulletPool drawerPool = new BulletPool(projectilePrefab);
		_drawerPool = drawerPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_drawerPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_drawerPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_017a;
			}
		}
		goto IL_042d;
		IL_048f:
		Projectile bulletA;
		_bulletA = (CherryStarProjectile)bulletA;
		return;
		IL_042d:
		throw new NullReferenceException();
		IL_049e:
		object obj;
		bool flag = obj == null;
		bulletA = null;
		Projectile projectile;
		if (!flag)
		{
			bulletA = projectile;
		}
		goto IL_048f;
		IL_017a:
		if (_explosionPool != null)
		{
			goto IL_0311;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.CHERRY_STAR_EXPLO);
		BulletPool explosionPool = new BulletPool(projectilePrefab2);
		_explosionPool = explosionPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+370]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_explosionPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1000 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_explosionPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_0311;
			}
		}
		goto IL_042d;
		IL_0311:
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		projectile = _drawerPool.SpawnAt(pos, this);
		bool flag2 = (object)projectile == null;
		bulletA = null;
		if (flag2)
		{
			goto IL_048f;
		}
		nint num5 = (nint)projectile;
		nint num6 = (nint)typeof(CherryStarProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryStarProjectile>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryStarProjectile>)+130]");
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rax_v19+FFFFFFF8+v819 @ rax_v15*8]");
			if (0 == (nint)typeof(CherryStarProjectile))
			{
				obj = 1;
				goto IL_049e;
			}
		}
		obj = 0;
		goto IL_049e;
	}

	protected override void OnUpdate()
	{
		if (!_hasImage && !_hasCharacterImage)
		{
			InitImage();
			_hasImage = true;
		}
	}

	private void InitImage()
	{
		//IL_015d: Expected O, but got I4
		PhaserSprite cow = _cow;
		if ((object)_cow == null || ((UnityEngine.Object)cow).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite cow2 = instance.AddPhaserSprite(pos, "anima", "yattaCowi0");
			_cow = cow2;
			bool flag = default(bool);
			List<Sprite> animation = SpriteManager.GetAnimation("yattaCowi0", 1, 4, "anima", flag);
			PhaserSprite cow3 = _cow;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			cow3._spriteAnimation.AddAnimation("Idle", animation, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite cow4 = _cow;
			cow4._spriteAnimation.SetAnimation("Idle");
		}
		PhaserSprite phaserSprite = _cow.setAlpha(0.65f);
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth2 = depth - 2;
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(depth2);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
	}

	private void LateUpdate()
	{
		if (_hasImage)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
			int depth2 = depth - 2;
			PhaserSprite phaserSprite = _cow.setDepth(depth2);
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			PhaserSprite phaserSprite2 = _cow.setFlipX(flipX);
		}
	}

	private void UpdateImage()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth2 = depth - 2;
		PhaserSprite phaserSprite = _cow.setDepth(depth2);
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		PhaserSprite phaserSprite2 = _cow.setFlipX(flipX);
	}

	public override void Cleanup()
	{
		PhaserSprite cow = _cow;
		if ((object)_cow != null && ((UnityEngine.Object)cow).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _cow.setVisible(visible: false);
		}
		CherryStarProjectile bulletA = _bulletA;
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.ForceDespawn();
		}
		if (_drawerPool != null)
		{
			_drawerPool.Cleanup();
		}
		base.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0115: Expected I, but got O
		//IL_0123: Expected I, but got O
		//IL_0133: Expected O, but got I
		//IL_01b3: Expected O, but got I4
		//IL_016f: Expected O, but got I
		//IL_01a5: Expected O, but got I4
		PhaserSprite cow = _cow;
		bool flag = default(bool);
		_isVisible = flag;
		if ((object)_cow != null && ((UnityEngine.Object)cow).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _cow.setVisible(flag);
		}
		CherryStarProjectile bulletA = _bulletA;
		Projectile projectile;
		Projectile bulletA2;
		object obj3;
		if (flag)
		{
			if ((object)_bulletA != null && ((UnityEngine.Object)bulletA).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 pos = default(float2);
			projectile = _drawerPool.SpawnAt(pos, this);
			bool flag2 = (object)projectile == null;
			bulletA2 = null;
			if (flag2)
			{
				goto IL_0274;
			}
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(CherryStarProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryStarProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryStarProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v42+FFFFFFF8+v637 @ rax_v38*8]");
				if (0 == (nint)typeof(CherryStarProjectile))
				{
					obj3 = 1;
					goto IL_0283;
				}
			}
			obj3 = 0;
			goto IL_0283;
		}
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.ForceDespawn();
			_bulletA = null;
		}
		return;
		IL_0274:
		_bulletA = (CherryStarProjectile)bulletA2;
		return;
		IL_0283:
		bool flag3 = obj3 == null;
		bulletA2 = null;
		if (!flag3)
		{
			bulletA2 = projectile;
		}
		goto IL_0274;
	}
}
