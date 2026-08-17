using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.UI;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Universitas_Weapon : Weapon
{
	private BulletPool _invisibleProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.GlyphAbs;
	}

	public override void OnWeaponAdded()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		bool flag = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).Remove((object)this);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager2 = characterController2._weaponsManager;
		bool flag2 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField.Remove(this);
		GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(((Equipment)this)._003COwner_003Ek__BackingField);
		if ((object)panelForCharacter != null && ((UnityEngine.Object)panelForCharacter).m_CachedPtr != (IntPtr)0)
		{
			panelForCharacter.AddExtra(((Equipment)this)._equipmentType);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Universitas_Weapon>)+350]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Universitas_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			float num3 = base.PInterval();
			object obj = default(object);
			float num4 = (float)obj * 0.95f;
			base._003CTotalTime_003Ek__BackingField = num4;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0068: Invalid comparison between O and F4
		((Equipment)this)._003COwner_003Ek__BackingField.OnAttackAnim(FiringAnimation.GlyphAbs);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0);
		float num = base.PInterval();
		float lastFiringInterval = _lastFiringInterval;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = lastFiringInterval & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num2 = base.PInterval();
			_lastFiringInterval = 0f;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireMeteors()
	{
		//IL_0049: Expected O, but got I
		//IL_0297: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_0108: Expected I, but got O
		//IL_0116: Expected I, but got O
		//IL_0126: Expected O, but got I
		//IL_01a6: Expected O, but got I4
		//IL_0162: Expected O, but got I
		//IL_0198: Expected O, but got I4
		//IL_01f1: Expected I, but got O
		//IL_0282->IL0201: Incompatible stack heights: 1 vs 0
		//IL_0069->IL0201: Incompatible stack heights: 1 vs 0
		//IL_02b7->IL0201: Incompatible stack heights: 1 vs 0
		//IL_034a->IL0201: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform invisibleProjectilePool = (Transform)(object)_invisibleProjectilePool;
				if (_invisibleProjectilePool != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v5 (UnityEngine.Transform)+38]");
					Transform transform2 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v5 (UnityEngine.Transform)+38]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v6 (UnityEngine.Transform)+48]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v6 (UnityEngine.Transform)+48]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v14+20]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v14+28]");
							object obj2 = num - 0;
							if ((nint)obj2 >= 100)
							{
								return;
							}
							int num2 = 0;
							while (_invisibleProjectilePool != null)
							{
								Projectile projectile = _invisibleProjectilePool.SpawnAt((float2)ret, this, num2);
								Transform transform3;
								if ((object)projectile == null)
								{
									transform3 = null;
									goto IL_02e8;
								}
								nint num3 = (nint)projectile;
								nint num4 = (nint)typeof(TP_Universitas_Meteor_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Universitas_Meteor_Projectile>)+130]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Universitas_Meteor_Projectile>)+130]");
								object obj5;
								if (num5 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v40+FFFFFFF8+v440 @ rax_v36*8]");
									if (0 == (nint)typeof(TP_Universitas_Meteor_Projectile))
									{
										obj5 = 1;
										goto IL_02c1;
									}
								}
								obj5 = 0;
								goto IL_02c1;
								IL_02e8:
								if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
								{
									nint num6 = (nint)transform3;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v632 @ rax_v29 (Il2CppClass<UnityEngine.Transform>)+3F8] (should have been resolved before IL gen)");
								}
								num2++;
								if (num2 >= 12)
								{
									return;
								}
								continue;
								IL_02c1:
								bool flag2 = obj5 == null;
								transform3 = null;
								if (!flag2)
								{
									transform3 = (Transform)(object)projectile;
								}
								goto IL_02e8;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
