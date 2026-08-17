using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_DragonWater1_Weapon : Weapon
{
	private Projectile _waterDragonHeadPrefab;

	private Projectile _waterDragonTailPrefab;

	protected int _fireCounter;

	protected int _specialCounter = 7;

	protected int _subWeaponCounter = 13;

	private BulletPool _memoryWhipPool;

	private BulletPool _tailPool;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void OnStart()
	{
		//IL_0076: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_01f0: Expected I, but got O
		//IL_0293: Expected I, but got O
		base.OnStart();
		BulletPool memoryWhipPool = new BulletPool(_waterDragonHeadPrefab);
		_memoryWhipPool = memoryWhipPool;
		BulletPool memoryWhipPool2 = _memoryWhipPool;
		memoryWhipPool2.UpperLimit = 200;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+370]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_memoryWhipPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_memoryWhipPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			BulletPool tailPool = new BulletPool(_waterDragonTailPrefab);
			_tailPool = tailPool;
			BulletPool tailPool2 = _tailPool;
			tailPool2.UpperLimit = 200;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+370]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider3 = physics3.add.overlap(_tailPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num4 = (nint)this;
					Collider collider4 = physics4.add.overlap(_tailPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		if (++_fireCounter % _specialCounter == 0)
		{
			OnSpecialCounter(skipTriggers);
		}
		if (_fireCounter % _subWeaponCounter == 0)
		{
			OnSubWeaponCounter(skipTriggers);
		}
	}

	public virtual void OnSpecialCounter(bool skipTriggers = false)
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 size = ((ArcadeSprite)characterController)._spriteRenderer.size;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		Projectile projectile = _memoryWhipPool.SpawnAt(pos, this);
	}

	public virtual void OnSubWeaponCounter(bool skipTriggers = false)
	{
	}

	public Projectile SpawnTailProjectile(float2 pos, int index)
	{
		if (_tailPool != null)
		{
			return _tailPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_memoryWhipPool != null)
		{
			_memoryWhipPool.Cleanup();
		}
		if (_tailPool != null)
		{
			_tailPool.Cleanup();
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.1f;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
	}
}
