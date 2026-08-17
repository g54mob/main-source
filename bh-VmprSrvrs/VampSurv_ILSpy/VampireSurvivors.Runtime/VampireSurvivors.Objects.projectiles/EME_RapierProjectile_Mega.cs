using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_RapierProjectile_Mega : Projectile
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public EME_RapierProjectile_Mega _003C_003E4__this;

		public Vector3 tPosition;
	}

	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal void _003CSetTarget_003Eb__0()
		{
			//IL_01be: Expected O, but got I4
			//IL_00d7->IL0187: Incompatible stack heights: 1 vs 0
			//IL_0106->IL0187: Incompatible stack heights: 1 vs 0
			//IL_0135->IL0187: Incompatible stack heights: 1 vs 0
			//IL_0157->IL0187: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass6_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				EME_RapierProjectile_Mega eME_RapierProjectile_Mega = obj._003C_003E4__this;
				if ((object)obj._003C_003E4__this != null && (object)eME_RapierProjectile_Mega._weapon != null)
				{
					GameObject gameObject = eME_RapierProjectile_Mega._weapon.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj2 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass6_0 obj3 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							EME_RapierProjectile_Mega eME_RapierProjectile_Mega2 = obj3._003C_003E4__this;
							if ((object)obj3._003C_003E4__this != null)
							{
								EME_RapierWeapon trueWeapon = eME_RapierProjectile_Mega2._trueWeapon;
								if ((object)eME_RapierProjectile_Mega2._trueWeapon != null && trueWeapon._megaSinglePool != null)
								{
									float2 pos = default(float2);
									Projectile projectile = trueWeapon._megaSinglePool.SpawnAt(pos, eME_RapierProjectile_Mega2._weapon, localIndex);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private EME_RapierWeapon _trueWeapon;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0072: Expected I, but got O
		//IL_007a: Expected I, but got O
		//IL_008a: Expected O, but got I
		//IL_010a: Expected O, but got I4
		//IL_00c6: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(10f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		Weapon weapon2 = _weapon;
		bool flag = (object)_weapon == null;
		EME_RapierWeapon trueWeapon = null;
		if (flag)
		{
			goto IL_0180;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v19+FFFFFFF8+v163 @ rax_v15*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj3 = 1;
				goto IL_018f;
			}
		}
		obj3 = 0;
		goto IL_018f;
		IL_0180:
		_trueWeapon = trueWeapon;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		return;
		IL_018f:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = (EME_RapierWeapon)_weapon;
		}
		goto IL_0180;
	}

	public override void SetNullTarget()
	{
		base.Despawn();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_0115: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_02b6: Expected I, but got O
		//IL_02cc: Expected O, but got I
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_0348: Expected I, but got O
		//IL_04d3: Expected I, but got I8
		//IL_031b: Expected I, but got I8
		//IL_0171: Expected I4, but got O
		//IL_01bf: Expected I, but got O
		//IL_01d5: Expected O, but got I
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_024c: Expected I, but got O
		//IL_0412: Expected I, but got I8
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0235: Expected I, but got I8
		//IL_03d7->IL034d: Incompatible stack heights: 1 vs 0
		//IL_03f6->IL034d: Incompatible stack heights: 1 vs 0
		//IL_04b7->IL034d: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		bool canPause;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform targetTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				_targetTransform = targetTransform;
				_003C_003Ec__DisplayClass6_1 targetTransform2 = (_003C_003Ec__DisplayClass6_1)(object)_targetTransform;
				if ((object)_targetTransform != null)
				{
					bool flag = targetTransform2.localIndex == 0;
					Transform.get_position_Injected((IntPtr)targetTransform2.localIndex, out Vector3 ret);
					obj.tPosition = ret;
					_ = 0;
					if ((object)_weapon != null)
					{
						float num = _weapon.PDuration();
						float num2 = (float)ret - 1000f;
						float num3 = num2 / 300f;
						if (num3 > 10f || (object)_weapon != null)
						{
							float num4 = _weapon.PAmount();
							object obj2 = 24;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r12d,xmm0\"");
							object obj3 = default(object);
							bool flag2 = (nint)obj3 <= 0;
							canPause = false;
							if (flag2)
							{
								goto IL_025e;
							}
							_003C_003Ec__DisplayClass6_1 obj4 = null;
							while (true)
							{
								_003C_003Ec__DisplayClass6_1 obj5 = new _003C_003Ec__DisplayClass6_1();
								if (obj5 == null)
								{
									break;
								}
								obj5.CS_0024_003C_003E8__locals1 = obj;
								obj5.localIndex = (int)obj4;
								Action action = null;
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r10_v7 (Il2CppMethodInfo)+8]");
								((Delegate)action).method_ptr = (IntPtr)0;
								((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass6_1._003CSetTarget_003Eb__0);
								((Delegate)action).m_target = obj5;
								((Delegate)action).method_code = (IntPtr)action;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r10_v7 (Il2CppMethodInfo)+4C]");
								object obj6 = (nint)0 >> 4;
								object obj7 = obj6 & 1;
								nint num6;
								if (obj7 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r10_v7 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num6 = unchecked((nint)6447293664L);
										goto IL_03fb;
									}
								}
								((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
								num6 = ((Delegate)action).method_ptr;
								goto IL_03fb;
								IL_03fb:
								((Delegate)action).extra_arg = unchecked((nint)6447293568L);
								float num7 = (float)obj4 * 50f;
								float duration = num7 * 0.001f;
								Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								obj4 = (_003C_003Ec__DisplayClass6_1)(obj4 + 1);
								bool flag3 = System.Runtime.CompilerServices.Unsafe.As<_003C_003Ec__DisplayClass6_1, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
								canPause = false;
								if (flag3)
								{
									continue;
								}
								goto IL_025e;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_025e:
		Action action2 = null;
		nint num8 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_RapierProjectile_Mega>)+370]");
		nint method = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ r10_v5 (System.IntPtr)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = method;
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ r10_v5 (System.IntPtr)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		nint num9;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ r10_v5 (System.IntPtr)+52]");
			bool flag4 = (nint)0 == 0;
			num9 = unchecked((nint)6447293664L);
			if (flag4)
			{
				goto IL_04bc;
			}
		}
		num9 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_04bc;
		IL_04bc:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(2f, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}
}
