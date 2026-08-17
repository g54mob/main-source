using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FlashArrowWeapon : Weapon, IMillionaire
{
	private Timer _rangedAnimEvent;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PAmount();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num;
					return num + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		base._003CCanCrit_003Ek__BackingField = true;
		_bonusBounces = 0;
	}

	protected override void OnStart()
	{
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1873A50E0\"");
	}

	public void PlayNextRangedAnim()
	{
		if (_rangedAnimEvent != null)
		{
			_rangedAnimEvent.Cancel();
		}
		float num = base.PInterval();
		Action onComplete = delegate
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
		};
		object obj = default(object);
		float num2 = (float)obj - 120f;
		float duration = num2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer rangedAnimEvent = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_rangedAnimEvent = rangedAnimEvent;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_005c: Invalid comparison between F4 and O
		//IL_008e: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		PlayNextRangedAnim();
		float num = base.PInterval();
		bool flag = (object)_lastFiringInterval == (object)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873A52D7h\"");
		if (!flag)
		{
			float num2 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void Millionaire(float x, float y, float angle, int times = 4)
	{
	}

	public override void CheckArcanas()
	{
		//IL_008e: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
			List<Collider> wallsColliders = _wallsColliders;
			_bounces = 3;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < wallsColliders._size)
			{
				List<Collider> wallsColliders2 = _wallsColliders;
				if ((nint)obj2 < wallsColliders2._size)
				{
					Collider[] items = wallsColliders2._items;
					World world = ArcadePhysics.s_world.removeCollider(items[obj2]);
					wallsColliders = _wallsColliders;
					obj2++;
					obj3 = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			currentWeaponData2._003ChitsWalls_003Ek__BackingField = false;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		if (base._003CCanCrit_003Ek__BackingField)
		{
			base.StandardCritical(second, first);
			return false;
		}
		return base.OnBulletOverlapsEnemy(context, second, first);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_rangedAnimEvent != null)
		{
			_rangedAnimEvent.Cancel();
		}
	}

	public unsafe void FireVolley(Vector2 pos, int _amount, Transform target = null)
	{
		//IL_0012: Expected F4, but got O
		//IL_0062: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b4: Expected O, but got I4
		//IL_010f: Expected I, but got O
		//IL_011d: Expected I, but got O
		//IL_012d: Expected O, but got I
		//IL_01ad: Expected O, but got I4
		//IL_0169: Expected O, but got I
		//IL_019f: Expected O, but got I4
		//IL_0235: Expected I, but got O
		//IL_02cc: Expected O, but got I
		//IL_04c3: Expected F4, but got O
		//IL_048c->IL041c: Incompatible stack heights: 1 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = (float)characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			float num2 = 0f * 57.29578f;
			if (_amount <= 0)
			{
				return;
			}
			object obj = _amount - 3;
			object obj2 = obj >> 31;
			object obj3 = obj - obj2;
			object obj4 = obj3 >> 1;
			object obj5 = obj4 * 4;
			object obj6 = obj4 + obj5;
			object obj7 = _amount - 1;
			float num3 = (float)obj6 + 25f;
			int num4 = 0;
			BulletPool pool = default(BulletPool);
			object obj11 = default(object);
			Vector3 axis = default(Vector3);
			Quaternion value = default(Quaternion);
			while (true)
			{
				float num5 = ((!(num3 > 45f)) ? num3 : 45f);
				float num6 = num5 / (float)_amount;
				float num7 = (float)num4 * num6;
				float num8 = num6 * 0.5f;
				float num9 = num7 + num2;
				float num10 = num8 * (float)obj7;
				float num11 = num9 - num10;
				Projectile projectile = base.FireOneProjectile(pos, num4, target, pool);
				Component component;
				int num12;
				Vector2 vector;
				if ((object)projectile == null)
				{
					num12 = num4;
					component = null;
					vector = pos;
					goto IL_03ff;
				}
				nint num13 = (nint)projectile;
				nint num14 = (nint)typeof(FlashArrowProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FlashArrowProjectile>)+130]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FlashArrowProjectile>)+130]");
				object obj10;
				if (num15 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v59+FFFFFFF8+v569 @ rax_v55*8]");
					if (0 == (nint)typeof(FlashArrowProjectile))
					{
						obj10 = 1;
						goto IL_03c2;
					}
				}
				obj10 = 0;
				goto IL_03c2;
				IL_03c2:
				bool flag = obj10 == null;
				num12 = (int)num13;
				component = null;
				vector = (Vector2)typeof(FlashArrowProjectile);
				if (!flag)
				{
					num12 = (int)num13;
					component = projectile;
					vector = (Vector2)typeof(FlashArrowProjectile);
				}
				goto IL_03ff;
				IL_03ff:
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
					if (obj11 == null)
					{
						break;
					}
					nint num16 = (nint)component;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v834 @ rdx_v15 (Il2CppClass<UnityEngine.Component>)+2D8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v9 (UnityEngine.Component)+28]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v31+18]");
					if ((nint)0 == 0)
					{
						break;
					}
					num = num11 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v9 (UnityEngine.Component)+28]");
					ref float2 vec = ref *(float2*)((nint)0 + (nint)112);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v31+18]");
					float2 float5 = ((ArcadePhysics)0).velocityFromRotation(num, num10, ref vec);
					_ = 0;
					Transform transform = component.transform;
					Quaternion.AngleAxis_Injected((float)typeof(Vector3), ref axis, out Quaternion _);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					axis = Vector3.forwardVector;
				}
				num4++;
				if (num4 >= _amount)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CPlayNextRangedAnim_003Eb__4_0()
	{
		((Equipment)this)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
	}
}
