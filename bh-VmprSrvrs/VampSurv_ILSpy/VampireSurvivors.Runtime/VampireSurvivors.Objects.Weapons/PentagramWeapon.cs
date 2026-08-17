using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class PentagramWeapon : Weapon
{
	private SpriteRenderer _WhiteDot;

	public float _R = 1f;

	public float _G = 1f;

	public float _B = 1f;

	public float _A;

	private MultiTargetTween _rgbTween;

	private MultiTargetTween _alphaTween;

	private Timer _levelOneFireTimer;

	private bool _restoreInitialFire;

	private bool _canFlash;

	private bool _003CEraseItems_003Ek__BackingField;

	public SpriteRenderer WhiteDot => _WhiteDot;

	protected override bool UseOnlineTimer => false;

	public bool EraseItems
	{
		get
		{
			return _003CEraseItems_003Ek__BackingField;
		}
		private set
		{
			_003CEraseItems_003Ek__BackingField = value;
		}
	}

	public override float PInterval()
	{
		//IL_001a: Invalid comparison between F4 and I
		//IL_0041: Expected F4, but got I
		float num = base.PInterval();
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
		if (num2 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
			num = 0f;
		}
		return num;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		WeaponData currentWeaponData = _currentWeaponData;
		currentWeaponData._003Cchance_003Ek__BackingField = 0.1f;
		_canFlash = true;
		MakeWhiteDot();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a9->IL0038: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		SpriteRenderer whiteDot = _WhiteDot;
		if ((object)_WhiteDot != null)
		{
			bool flag = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, 5000);
			SpriteRenderer whiteDot2 = _WhiteDot;
			if ((object)_WhiteDot != null)
			{
				bool flag2 = ((UnityEngine.Object)whiteDot2).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot2).m_CachedPtr, ref *(Color*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_02c3: Expected O, but got F4
		//IL_010b: Invalid comparison between F4 and I4
		//IL_007d: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0242: Expected O, but got I
		//IL_02d1: Expected O, but got I4
		//IL_022d: Expected O, but got I8
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CoherenceSync coherenceSync = characterController._coherenceSync;
		PentagramWeapon pentagramWeapon = this;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			pentagramWeapon = (PentagramWeapon)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
			bool flag = (byte)(nint)((UnityEngine.Object)pentagramWeapon).m_CachedPtr != 0;
			if (((UnityEngine.Object)pentagramWeapon).m_CachedPtr != (IntPtr)1)
			{
				object obj = (nint)((UnityEngine.Object)pentagramWeapon).m_CachedPtr - 3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		object obj2 = UnityEngine.Random.value;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj3 = default(object);
		float num2 = 1f / (float)obj3;
		float num3 = num2 * (float)obj3;
		bool flag3 = num3 < currentWeaponData._003Cchance_003Ek__BackingField;
		float num4 = num3 - currentWeaponData._003Cchance_003Ek__BackingField;
		bool flag4 = num4 == 0f;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		bool flag7 = flag6 & flag5;
		_003CEraseItems_003Ek__BackingField = flag7;
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformFire(skipTriggers);
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Action<bool, bool> action = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r10_v4 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		_ = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj4 = (nint)0 >> 4;
		object obj5 = obj4 & 1;
		object obj6;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj6 = 6447762832L;
				goto IL_02c8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v23 (System.Action`2<System.Boolean, System.Boolean>)+10]");
		obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v23 (System.Action`2<System.Boolean, System.Boolean>)+20]");
		_ = 0;
		goto IL_02c8;
		IL_02c8:
		object obj7 = 24;
		_ = 6447762720L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F5DED0");
	}

	public void FirePentagram(bool eraseItems, bool skipTriggers)
	{
		_003CEraseItems_003Ek__BackingField = eraseItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 4 Invalid \"Jump target not found in method: 0x187538230\"");
	}

	private unsafe void PerformFire(bool skipTriggers)
	{
		//IL_00af: Expected F4, but got I
		//IL_0828: Expected I, but got O
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected O, but got Unknown
		//IL_067d: Invalid comparison between O and F4
		//IL_0195: Expected I, but got O
		//IL_02e1: Expected I, but got O
		//IL_047c: Expected I, but got O
		//IL_0869->IL075f: Incompatible stack heights: 3 vs 0
		//IL_00db->IL075f: Incompatible stack heights: 3 vs 0
		//IL_06dd->IL075f: Incompatible stack heights: 3 vs 0
		//IL_00fd->IL075f: Incompatible stack heights: 3 vs 0
		//IL_012c->IL075f: Incompatible stack heights: 3 vs 0
		//IL_0749->IL075f: Incompatible stack heights: 3 vs 0
		//IL_0188->IL075f: Incompatible stack heights: 3 vs 0
		//IL_01da->IL075f: Incompatible stack heights: 4 vs 0
		//IL_0222->IL075f: Incompatible stack heights: 4 vs 0
		//IL_02d4->IL075f: Incompatible stack heights: 4 vs 0
		//IL_0326->IL075f: Incompatible stack heights: 5 vs 0
		//IL_036e->IL075f: Incompatible stack heights: 5 vs 0
		//IL_046f->IL075f: Incompatible stack heights: 5 vs 0
		//IL_04c1->IL075f: Incompatible stack heights: 6 vs 0
		//IL_0509->IL075f: Incompatible stack heights: 6 vs 0
		//IL_05e3->IL05e3: Incompatible stack heights: 6 vs 3
		Transform cachedTransform = _cachedTransform;
		float num;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _cachedTransform);
			if (_rgbTween != null)
			{
				_rgbTween.Kill();
			}
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig whiteDot = (TweenConfig)(object)_WhiteDot;
			_B = 1f;
			_G = 1f;
			_R = 1f;
			_A = 0f;
			bool flag2 = (object)_WhiteDot == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11C30]");
			num = 0f;
			bool flag3 = whiteDot.targets == null;
			SpriteRenderer.set_color_Injected((IntPtr)whiteDot.targets, ref *(Color*)(&ret));
			if (!_canFlash)
			{
				goto IL_0644;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
					{
						goto IL_05e3;
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj = default(object);
						bool flag4 = obj == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dictionary != null)
							{
								object value = default(object);
								bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_A", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig.custom = dictionary;
								tweenConfig.duration = 100f;
								tweenConfig.yoyo = true;
								tweenConfig.ease = Ease.Linear;
								MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
								_alphaTween = alphaTween;
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									nint num3 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag6 = obj2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										if (dictionary2 != null)
										{
											object value2 = default(object);
											bool flag7 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_R", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											object value3 = default(object);
											bool flag8 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_G", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											object value4 = default(object);
											bool flag9 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_B", value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											tweenConfig2.custom = dictionary2;
											tweenConfig2.duration = 50f;
											tweenConfig2.yoyo = false;
											tweenConfig2.ease = Ease.Linear;
											MultiTargetTween rgbTween = Tweens.Add(tweenConfig2);
											_rgbTween = rgbTween;
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[1];
											if (array3 != null)
											{
												nint num4 = (nint)array3;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj3 = default(object);
												bool flag10 = obj3 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig3 != null)
												{
													tweenConfig3.targets = array3;
													Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
													if (dictionary3 != null)
													{
														object value5 = default(object);
														bool flag11 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_R", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														object value6 = default(object);
														bool flag12 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_G", value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														object value7 = default(object);
														bool flag13 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_B", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														tweenConfig3.custom = dictionary3;
														tweenConfig3.delay = 100f;
														tweenConfig3.duration = 25f;
														tweenConfig3.yoyo = false;
														tweenConfig3.ease = Ease.Linear;
														MultiTargetTween rgbTween2 = Tweens.Add(tweenConfig3);
														_rgbTween = rgbTween2;
														goto IL_05e3;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_075f;
		IL_05e3:
		_canFlash = false;
		Action onComplete = delegate
		{
			_canFlash = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		num = 0.5f;
		goto IL_0644;
		IL_0644:
		float num5 = PInterval();
		float num6 = _lastFiringInterval - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num6 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num7 = PInterval();
			_lastFiringInterval = num;
			base.ResetFiringTimer();
		}
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			ArcanaManager arcanaManager = core2._arcanaManager;
			if (core2._arcanaManager != null)
			{
				if (arcanaManager._hasAstronomia)
				{
					GameManager core3 = GM.Core;
					core3._arcanaManager.TriggerAstronomia(this);
				}
				if (skipTriggers)
				{
					return;
				}
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
					return;
				}
			}
		}
		goto IL_075f;
		IL_075f:
		throw new NullReferenceException();
	}

	private void MakeWhiteDot()
	{
		Camera main = Camera.main;
		float num = (float)CameraExtensions.OrthographicBounds(main).m_Extents * 2f;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		if (num < num2 || (object)_WhiteDot != null)
		{
			Transform transform = _WhiteDot.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform whiteDot = (Transform)(object)_WhiteDot;
				bool flag2 = (object)_WhiteDot == null;
				bool flag3 = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
				Color value2 = default(Color);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, ref value2);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_WhiteDot, 0f);
				Transform whiteDot2 = (Transform)(object)_WhiteDot;
				bool flag4 = (object)_WhiteDot == null;
				bool flag5 = ((UnityEngine.Object)whiteDot2).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot2).m_CachedPtr, 5000);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			if (_levelOneFireTimer != null)
			{
				_levelOneFireTimer.Cancel();
				_levelOneFireTimer = null;
				_restoreInitialFire = true;
			}
		}
		else if (_restoreInitialFire)
		{
			_restoreInitialFire = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 99 Invalid \"Jump target not found in method: 0x187539240\"");
		}
	}

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x187539240\"");
	}

	private void RunInitialFire()
	{
		//IL_005c: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		Action onComplete = delegate
		{
			_levelOneFireTimer = null;
			base.Fire();
		};
		bool flag = list._size == 0;
		object obj = 1000;
		if (!flag)
		{
			obj = 100;
		}
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer levelOneFireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_levelOneFireTimer = levelOneFireTimer;
	}

	private void _003CPerformFire_003Eb__23_0()
	{
		_canFlash = true;
	}

	private void _003CRunInitialFire_003Eb__27_0()
	{
		_levelOneFireTimer = null;
		base.Fire();
	}
}
