using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class AbsetzenInstance
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public AbsetzenInstance _003C_003E4__this;

		public float2 pos;

		public Transform target;
	}

	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0079: Expected I4, but got O
			//IL_0087: Expected I, but got O
			//IL_0097: Expected O, but got I
			//IL_0117: Expected O, but got I4
			//IL_00d3: Expected O, but got I
			//IL_0109: Expected O, but got I4
			_003C_003Ec__DisplayClass13_0 obj = CS_0024_003C_003E8__locals1;
			AbsetzenInstance absetzenInstance = obj._003C_003E4__this;
			int num = localIndex;
			Vector2 pos = default(Vector2);
			Projectile projectile = absetzenInstance._parentWeapon.FireOneProjectile(pos, localIndex, obj.target);
			Projectile projectile2;
			if ((object)projectile == null)
			{
				projectile2 = null;
				goto IL_0215;
			}
			num = (int)projectile;
			nint num2 = (nint)typeof(EME_GreatswordProjectile_Absetzen);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_Absetzen>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v3 (System.Int32)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_Absetzen>)+130]");
			object obj4;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v3 (System.Int32)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v31+FFFFFFF8+v267 @ rax_v27*8]");
				if (0 == (nint)typeof(EME_GreatswordProjectile_Absetzen))
				{
					obj4 = 1;
					goto IL_01ee;
				}
			}
			obj4 = 0;
			goto IL_01ee;
			IL_01ee:
			bool flag = obj4 == null;
			projectile2 = null;
			if (!flag)
			{
				projectile2 = projectile;
			}
			goto IL_0215;
			IL_0215:
			_003C_003Ec__DisplayClass13_0 obj5;
			if ((object)projectile2 != null)
			{
				bool flag2 = ((UnityEngine.Object)projectile2).m_CachedPtr == (IntPtr)0;
				obj5 = CS_0024_003C_003E8__locals1;
				if (!flag2)
				{
					AbsetzenInstance absetzenInstance2 = obj5._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC060");
					return;
				}
			}
			else
			{
				obj5 = CS_0024_003C_003E8__locals1;
			}
			AbsetzenInstance absetzenInstance3 = obj5._003C_003E4__this;
			_003C_003Ec__DisplayClass13_0 obj6 = CS_0024_003C_003E8__locals1;
			AbsetzenInstance absetzenInstance4 = obj6._003C_003E4__this;
			int amount = absetzenInstance4._amount - 1;
			absetzenInstance3._amount = amount;
		}
	}

	private readonly List<EME_GreatswordProjectile_Absetzen> _swordProjectiles;

	private readonly BulletPool _swordBulletPool;

	private readonly BulletPool _beamBulletPool;

	private readonly EME_Weapon _parentWeapon;

	private readonly Transform _targetTransform;

	private Timer _glimmerShotTimer;

	private int _amount;

	private int _amountSpawned;

	private readonly float _repeatInterval;

	private bool _beamFired;

	public bool BeamFired => _beamFired;

	public AbsetzenInstance(EME_Weapon parentWeapon, Transform targetTransform, BulletPool swordBulletPool, BulletPool beamBulletPool, float repeatInterval)
	{
		List<EME_GreatswordProjectile_Absetzen> swordProjectiles = new List<EME_GreatswordProjectile_Absetzen>();
		_swordProjectiles = swordProjectiles;
		_parentWeapon = parentWeapon;
		_targetTransform = targetTransform;
		_swordBulletPool = swordBulletPool;
		BulletPool beamBulletPool2 = default(BulletPool);
		_beamBulletPool = beamBulletPool2;
		float repeatInterval2 = default(float);
		_repeatInterval = repeatInterval2;
	}

	public unsafe void FireProjectiles(int amount, float2 pos, Transform target)
	{
		//IL_00b9: Expected I, but got O
		//IL_00cf: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_0146: Expected I, but got O
		//IL_01be: Expected O, but got I4
		//IL_01d5: Expected I, but got I8
		//IL_012f: Expected I, but got I8
		_003C_003Ec__DisplayClass13_0 obj = new _003C_003Ec__DisplayClass13_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		obj.target = target;
		_amount = amount;
		if (amount <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass13_1 obj2 = new _003C_003Ec__DisplayClass13_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass13_1._003CFireProjectiles_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_01b5;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_01b5;
			IL_01b5:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num3 = (float)(flag ? 1 : 0) * _repeatInterval;
			float duration = num3 * 0.001f;
			Timer glimmerShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_glimmerShotTimer = glimmerShotTimer;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < amount);
	}

	public void InternalUpdate()
	{
		//IL_009e: Expected O, but got I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		if (_beamFired || _swordProjectiles == null)
		{
			return;
		}
		List<EME_GreatswordProjectile_Absetzen> swordProjectiles = _swordProjectiles;
		if (swordProjectiles._size == 0 || swordProjectiles._size < _amount)
		{
			return;
		}
		if (_amount > 0)
		{
			object obj = 0;
			do
			{
				if ((nint)obj < swordProjectiles._size)
				{
					EME_GreatswordProjectile_Absetzen[] items = swordProjectiles._items;
					EME_GreatswordProjectile_Absetzen eME_GreatswordProjectile_Absetzen = items[obj];
					if (((EME_GreatswordProjectile)eME_GreatswordProjectile_Absetzen)._hasLanded)
					{
						obj++;
						continue;
					}
					return;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)obj < _amount);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		float2 position = arcadeSprite.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 199 Invalid \"Jump target not found in method: 0x1874935E0\"");
	}

	private void FireAbsetzenBeam(float2 position, int index)
	{
		//IL_04d0: Expected I, but got O
		//IL_000d: Expected O, but got I
		//IL_0052: Expected I4, but got O
		//IL_0060: Expected I, but got O
		//IL_0070: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		//IL_00ac: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_015b: Expected I, but got O
		//IL_018b: Expected F4, but got I4
		//IL_0597: Expected I, but got O
		//IL_01e7: Expected O, but got I
		//IL_02d0: Expected I, but got O
		//IL_0392: Expected I, but got O
		//IL_03a0: Expected I, but got O
		//IL_021d: Expected I, but got O
		//IL_02f5: Expected I, but got O
		//IL_03ec: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_0291: Expected O, but got F4
		nint num = (nint)_parentWeapon;
		if ((object)_parentWeapon == null)
		{
			goto IL_04ba;
		}
		object obj = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ rax_v5+4D8] (should have been resolved before IL gen)");
		EME_GreatswordProjectile_AbsetzenBeam eME_GreatswordProjectile_AbsetzenBeam = default(EME_GreatswordProjectile_AbsetzenBeam);
		EME_GreatswordProjectile_AbsetzenBeam eME_GreatswordProjectile_AbsetzenBeam2;
		bool flag;
		if ((object)eME_GreatswordProjectile_AbsetzenBeam == null)
		{
			eME_GreatswordProjectile_AbsetzenBeam2 = null;
			flag = false;
			goto IL_0524;
		}
		int num2 = (int)eME_GreatswordProjectile_AbsetzenBeam;
		nint num3 = (nint)typeof(EME_GreatswordProjectile_AbsetzenBeam);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_AbsetzenBeam>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v6 (System.Int32)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_AbsetzenBeam>)+130]");
		object obj4;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v6 (System.Int32)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v61+FFFFFFF8+v315 @ rax_v57*8]");
			if (0 == (nint)typeof(EME_GreatswordProjectile_AbsetzenBeam))
			{
				obj4 = 1;
				goto IL_04f4;
			}
		}
		obj4 = 0;
		goto IL_04f4;
		IL_04ba:
		throw new NullReferenceException();
		IL_04f4:
		bool flag2 = obj4 == null;
		eME_GreatswordProjectile_AbsetzenBeam2 = null;
		flag = false;
		if (!flag2)
		{
			eME_GreatswordProjectile_AbsetzenBeam2 = eME_GreatswordProjectile_AbsetzenBeam;
			flag = false;
		}
		goto IL_0524;
		IL_0524:
		if ((object)eME_GreatswordProjectile_AbsetzenBeam2 == null || ((UnityEngine.Object)eME_GreatswordProjectile_AbsetzenBeam2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag3 = _swordProjectiles == null;
		num = (nint)typeof(UnityEngine.Object);
		if (!flag3)
		{
			List<EME_GreatswordProjectile_Absetzen>.Enumerator enumerator = default(List<EME_GreatswordProjectile_Absetzen>.Enumerator);
			while (enumerator.MoveNext())
			{
				if (eME_GreatswordProjectile_AbsetzenBeam2._targets != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC060");
				}
			}
			float num5 = 0f;
			List<EME_GreatswordProjectile_Absetzen>.Enumerator swordProjectiles = (List<EME_GreatswordProjectile_Absetzen>.Enumerator)_swordProjectiles;
			num = (flag ? 1 : 0);
			bool flag4 = flag;
			EME_GreatswordProjectile_Absetzen eME_GreatswordProjectile_Absetzen = default(EME_GreatswordProjectile_Absetzen);
			EME_GreatswordProjectile_Absetzen eME_GreatswordProjectile_Absetzen2 = default(EME_GreatswordProjectile_Absetzen);
			EME_GreatswordProjectile_Absetzen target = default(EME_GreatswordProjectile_Absetzen);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				nint num6 = (nint)eME_GreatswordProjectile_AbsetzenBeam2._targets;
				if (eME_GreatswordProjectile_AbsetzenBeam2._targets == null)
				{
					break;
				}
				nint intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v22 (Il2CppClass<UnityEngine.Object>)+18]");
				if (intPtr < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v22 (Il2CppClass<UnityEngine.Object>)+18]");
					object obj5 = -1;
					if ((flag4 ? 1 : 0) >= (nint)obj5)
					{
						float finalAngle = eME_GreatswordProjectile_AbsetzenBeam2.GetFinalAngle();
						num = (nint)eME_GreatswordProjectile_AbsetzenBeam2._targets;
						if (eME_GreatswordProjectile_AbsetzenBeam2._targets == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if ((object)eME_GreatswordProjectile_Absetzen == null)
						{
							break;
						}
						eME_GreatswordProjectile_Absetzen.RotateSwordSprite(finalAngle);
						nint num7 = (flag4 ? 1 : 0) + 1;
						num5 = finalAngle;
						swordProjectiles = (List<EME_GreatswordProjectile_Absetzen>.Enumerator)finalAngle;
						num2 = 0;
						num = num7;
						flag4 = (byte)num7 != 0;
						continue;
					}
					bool flag5 = eME_GreatswordProjectile_AbsetzenBeam2._targets == null;
					num = (nint)eME_GreatswordProjectile_AbsetzenBeam2._targets;
					if (flag5)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					num = (nint)eME_GreatswordProjectile_AbsetzenBeam2._targets;
					if (eME_GreatswordProjectile_AbsetzenBeam2._targets == null)
					{
						break;
					}
					object obj6 = (flag4 ? 1 : 0) + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if ((object)eME_GreatswordProjectile_Absetzen2 == null)
					{
						break;
					}
					eME_GreatswordProjectile_Absetzen2.RotateTowardsBeamTarget(target);
					nint num8 = (flag4 ? 1 : 0) + 1;
					num2 = 0;
					num = num8;
					flag4 = (byte)num8 != 0;
					continue;
				}
				Weapon weapon = ((Projectile)eME_GreatswordProjectile_AbsetzenBeam2)._weapon;
				if ((object)((Projectile)eME_GreatswordProjectile_AbsetzenBeam2)._weapon == null)
				{
					break;
				}
				nint num9 = (nint)weapon;
				nint num10 = (nint)typeof(EME_Greatsword2Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
				if (num12 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v26+FFFFFFF8+v175 @ rax_v25 (Il2CppClass<UnityEngine.Object>)*8]");
				if (0 != (nint)typeof(EME_Greatsword2Weapon))
				{
					break;
				}
				if (eME_GreatswordProjectile_AbsetzenBeam2._delayTimer != null)
				{
					eME_GreatswordProjectile_AbsetzenBeam2._delayTimer.Cancel();
				}
				Action onComplete = eME_GreatswordProjectile_AbsetzenBeam2.SetInitialTarget;
				Timer delayTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag);
				eME_GreatswordProjectile_AbsetzenBeam2._delayTimer = delayTimer;
				_beamFired = true;
				return;
			}
		}
		goto IL_04ba;
	}

	public void Cleanup()
	{
		List<EME_GreatswordProjectile_Absetzen> swordProjectiles = _swordProjectiles;
		int version = swordProjectiles._version + 1;
		swordProjectiles._version = version;
		swordProjectiles._size = 0;
		if (swordProjectiles._size > 0)
		{
			Array.Clear(swordProjectiles._items, 0, swordProjectiles._size);
		}
		if (_glimmerShotTimer != null)
		{
			_glimmerShotTimer.Cancel();
		}
	}
}
