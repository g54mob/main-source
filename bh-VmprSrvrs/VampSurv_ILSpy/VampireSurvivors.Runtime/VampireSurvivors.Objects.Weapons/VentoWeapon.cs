using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class VentoWeapon : Weapon
{
	private float _walked;

	private Timer _walkedTimer;

	private float _pBonus;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private const float MUL = 166.66667f;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b2: Expected O, but got I
		//IL_0249: Expected O, but got Ref
		//IL_0263: Expected native int or pointer, but got O
		//IL_027d: Expected O, but got I
		//IL_029d: Expected O, but got Ref
		//IL_02b7: Expected native int or pointer, but got O
		//IL_0485: Expected O, but got I4
		//IL_02cf: Expected O, but got Ref
		//IL_02f6: Expected O, but got I
		//IL_0310: Expected native int or pointer, but got O
		//IL_032a: Expected O, but got I
		//IL_034a: Expected O, but got Ref
		//IL_0364: Expected native int or pointer, but got O
		//IL_04a2: Expected O, but got I4
		//IL_0395: Expected O, but got I
		//IL_039e: Expected native int or pointer, but got O
		//IL_03a8: Expected native int or pointer, but got O
		//IL_03cd: Expected O, but got I4
		//IL_0427: Expected I4, but got I8
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		base.InitWeapon(characterController, weaponType);
		base._003CCanCrit_003Ek__BackingField = true;
		base._003CTotalTime_003Ek__BackingField = 0f;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
			GameObject gameObject = base.gameObject;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v4 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			_ = 0;
			ParticleEmitterManager pfxEmitterManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<ParticleSystem.MinMaxCurve, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref minMaxCurve2, 80))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+50]");
				pfxEmitterManager = (ParticleEmitterManager)0;
			}
			else
			{
				pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_pfxEmitterManager = pfxEmitterManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly2");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-80]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(25f, 50f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 64));
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-40]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-30]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 32));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+50]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
			System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(-500f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)minMaxCurve.m_Mode;
			_ = minMaxCurve.m_CurveMax;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter = pfxEmitter;
			ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(-1);
		}
	}

	public override float PPower()
	{
		float num = base.PPower();
		float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
		return num + num;
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
		if (_walkedTimer != null)
		{
			_walkedTimer.Cancel();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0013: Invalid comparison between I4 and F4
		//IL_0386: Expected O, but got Ref
		//IL_0392: Invalid comparison between F4 and I4
		//IL_0160: Invalid comparison between F4 and I4
		//IL_03fe->IL02c2: Incompatible stack heights: 1 vs 0
		//IL_044d->IL02c2: Incompatible stack heights: 2 vs 0
		//IL_0172->IL0452: Incompatible stack heights: 2 vs 0
		//IL_017c->IL01f5: Incompatible stack heights: 2 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = deltaTime * 1000f;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			if (!(0f < characterController._walked))
			{
				if (_walkedTimer == null)
				{
					Action onComplete = delegate
					{
						//IL_0053: Invalid comparison between I4 and F4
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController2).m_CachedPtr != (IntPtr)0)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if (!(0f < characterController3._walked))
							{
								_walked = 0f;
								_walkedTimer = null;
								_pBonus = 0f;
							}
						}
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer walkedTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_walkedTimer = walkedTimer;
				}
				goto IL_01f5;
			}
			if (_walkedTimer != null)
			{
				_walkedTimer.Cancel();
			}
			_walkedTimer = null;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
				float num2 = frameWalk * 100f;
				float num3 = num2 + _walked;
				float num4 = (float)((Equipment)this)._003CLevel_003Ek__BackingField * 0.5f;
				_walked = num3;
				float num5 = num3 / 200000f;
				if (!(num5 > num4))
				{
					num4 = num5;
				}
				_pBonus = num4;
				if ((object)_pfxEmitter != null)
				{
					float num6 = _pBonus * 40f;
					float num7 = num6 + 100f;
					float constant = num7 * 0.001f;
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
					ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
					object obj = default(object);
					mainModule.startLifetime = (ParticleSystem.MinMaxCurve)(&obj);
					if (!(_pBonus > 0f))
					{
						goto IL_01f5;
					}
					bool flag = false;
					Vector2 pos = default(Vector2);
					while (true)
					{
						Action action = (Action)(object)((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							break;
						}
						bool flag2 = ((Delegate)action).method_ptr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(((Delegate)action).method_ptr);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							break;
						}
						bool flag3 = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
						Transform.get_position_Injected(((Delegate)(object)transform).method_ptr, out Vector3 _);
						if ((object)_pfxEmitterManager == null)
						{
							break;
						}
						_pfxEmitterManager.EmitParticleAt(pos);
						flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
						if (_pBonus > (float)(flag ? 1 : 0))
						{
							continue;
						}
						goto IL_01f5;
					}
				}
			}
		}
		goto IL_02c2;
		IL_02c2:
		throw new NullReferenceException();
		IL_01f5:
		float num8 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float frameWalk2 = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num9 = num / 166.66667f;
			float num10 = frameWalk2 * 100f;
			float num11 = num10 * num9;
			float num12 = (base._003CTotalTime_003Ek__BackingField = num11 + num8);
			float num13 = base.PInterval();
			if (!(num12 < frameWalk2))
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
			return;
		}
		goto IL_02c2;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
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
				base._003CCanCrit_003Ek__BackingField = true;
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
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	private void _003CInternalUpdate_003Eb__11_0()
	{
		//IL_0053: Invalid comparison between I4 and F4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (!(0f < characterController2._walked))
			{
				_walked = 0f;
				_walkedTimer = null;
				_pBonus = 0f;
			}
		}
	}
}
