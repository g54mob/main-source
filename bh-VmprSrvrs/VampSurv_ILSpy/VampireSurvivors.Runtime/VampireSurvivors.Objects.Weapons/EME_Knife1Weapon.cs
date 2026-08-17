using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Knife1Weapon : EME_Weapon
{
	protected Projectile _MoonfallPrefab;

	protected Projectile _KaleidoscopePrefab;

	protected BulletPool _moonfallPool;

	protected BulletPool _kaleidoscopePool;

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 5;

	protected override int _comboIndex2 => 10;

	protected override int _comboIndex3 => 15;

	protected override int ComboIndexFinal => base.ComboIndex1;

	protected virtual bool IsEvolved => false;

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_KNIFE_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_KNIFE_TECH_02;
		}
		return result;
	}

	protected override void OnStart()
	{
		//IL_00bd: Expected I, but got O
		//IL_025f: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_0302: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		Projectile moonfallPrefab = _MoonfallPrefab;
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		if ((object)_MoonfallPrefab == null || ((UnityEngine.Object)moonfallPrefab).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0198;
		}
		BulletPool moonfallPool = new BulletPool(_MoonfallPrefab, 20);
		_moonfallPool = moonfallPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_moonfallPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_moonfallPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0198;
			}
		}
		goto IL_033b;
		IL_0198:
		Projectile kaleidoscopePrefab = _KaleidoscopePrefab;
		if ((object)_KaleidoscopePrefab == null || ((UnityEngine.Object)kaleidoscopePrefab).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BulletPool kaleidoscopePool = new BulletPool(_KaleidoscopePrefab, 20);
		_kaleidoscopePool = kaleidoscopePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_kaleidoscopePool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_kaleidoscopePool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_033b;
		IL_033b:
		throw new NullReferenceException();
	}

	public void DoMoonfall(float2 position)
	{
		float2 pos = default(float2);
		Projectile projectile = _moonfallPool.SpawnAt(pos, this);
	}

	public void DoKaleidoscope(float2 position)
	{
		float2 pos = default(float2);
		Projectile projectile = _kaleidoscopePool.SpawnAt(pos, this);
	}

	protected override float CalcCritMul()
	{
		//IL_0053: Expected O, but got I
		//IL_0134: Invalid comparison between F4 and I
		List<float> critChancesArray = _critChancesArray;
		float num5;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v7+18]");
				if ((nint)num >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					num2 *= currentWeaponData._003CcritChance_003Ek__BackingField;
					float num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v7+20+v55 @ rdx_v5 (System.Int32)*4]");
					if (num4 > 0f)
					{
						WeaponData currentWeaponData2 = _currentWeaponData;
						if (_currentWeaponData == null)
						{
							goto IL_026a;
						}
						num5 = currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
					}
					else
					{
						num5 = 1f;
					}
					if (!IsEvolved || !(num5 > 1f))
					{
						goto IL_02cf;
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						((Equipment)this)._003COwner_003Ek__BackingField.IsInvul = true;
						PlayerModifierStats playerStats = characterController._playerStats;
						if (characterController._playerStats != null)
						{
							float num6 = playerStats._003CInvulTimeBonus_003Ek__BackingField + 500f;
							float num7 = num6 * 0.001f;
							if (num7 > characterController._invincibilityTimer)
							{
								characterController._invincibilityTimer = num7;
							}
							goto IL_02cf;
						}
					}
				}
			}
		}
		goto IL_026a;
		IL_02cf:
		return num5;
		IL_026a:
		throw new NullReferenceException();
	}

	private void ActivateKnifeInvul()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		((Equipment)this)._003COwner_003Ek__BackingField.IsInvul = true;
		PlayerModifierStats playerStats = characterController._playerStats;
		float num = playerStats._003CInvulTimeBonus_003Ek__BackingField + 500f;
		float num2 = num * 0.001f;
		if (num2 > characterController._invincibilityTimer)
		{
			characterController._invincibilityTimer = num2;
		}
	}
}
