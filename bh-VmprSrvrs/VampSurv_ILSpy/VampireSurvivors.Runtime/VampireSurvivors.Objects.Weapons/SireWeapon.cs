using System;
using System.Collections.Generic;
using System.Threading;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
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

public class SireWeapon : Weapon
{
	private SpriteRenderer _WhiteDot;

	private SpriteRenderer _GroundSeal;

	private GameObject _ExplosionVFXPrefab;

	public float _R = 1f;

	public float _G = 1f;

	public float _B = 1f;

	public float _A;

	private ObjectPool _explosionPool;

	private MultiTargetTween _rgbTween;

	private MultiTargetTween _alphaTween;

	private bool _canFlash;

	private Projectile _activeProjectile;

	public ObjectPool ExplosionPool => _explosionPool;

	public SpriteRenderer WhiteDot => _WhiteDot;

	protected override bool UseOnlineTimer => false;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0054: Expected I4, but got I8
		base.InitWeapon(characterController, weaponType);
		_canFlash = true;
		if ((object)_ExplosionVFXPrefab != null)
		{
			string text = ((UnityEngine.Object)_ExplosionVFXPrefab).GetName();
			ObjectPool explosionPool = ObjectPool.Create(_ExplosionVFXPrefab, text, 10, -1);
			_explosionPool = explosionPool;
			ObjectPool explosionPool2 = _explosionPool;
			if ((object)_explosionPool != null)
			{
				explosionPool2._incrementalInstanceNames = true;
				UnityEngine.Object explosionPool3 = _explosionPool;
				if ((object)_explosionPool != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdi_v6 (UnityEngine.Object)+32]");
					if ((nint)0 == 0)
					{
						_ = 1;
						_explosionPool.AutoFillName();
						ObjectPool explosionPool4 = _explosionPool;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdi_v6 (UnityEngine.Object)+28]");
						explosionPool4.Populate(0);
					}
					if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
					{
						ObjectPool explosionPool5 = _explosionPool;
						if ((object)_explosionPool != null)
						{
							MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(explosionPool5._name, _explosionPool);
							MakeWhiteDot();
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
							Transform transform = _GroundSeal.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PInterval()
	{
		//IL_0069: Invalid comparison between F4 and I
		//IL_0090: Expected F4, but got I
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		float num2 = default(float);
		bool flag = !(0.1f < num2);
		float num3 = 0.1f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cinterval_003Ek__BackingField;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
		if (num5 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
			num4 = 0f;
		}
		return num4;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a9->IL0038: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		SpriteRenderer whiteDot = _WhiteDot;
		if ((object)_WhiteDot != null)
		{
			bool flag = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, 29);
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
		//IL_00fe: Expected I4, but got O
		//IL_0081: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CoherenceSync coherenceSync = characterController._coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			FireSire(skipTriggers);
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Action<bool> action = null;
		((VampireSurvivors.Objects.Characters.CharacterController)(object)action).FireSireWeapon((byte)(int)((Equipment)this)._003COwner_003Ek__BackingField != 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F5C410");
	}

	public void FireSire(bool skipTriggers)
	{
		//IL_0069: Invalid comparison between F4 and O
		//IL_009b: Expected F4, but got O
		//IL_0222->IL0152: Incompatible stack heights: 1 vs 0
		//IL_00d0->IL0152: Incompatible stack heights: 1 vs 0
		//IL_013c->IL0152: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 vector = default(Vector2);
			Projectile activeProjectile = base.FireOneProjectile(vector, 0, _targetTransform);
			_activeProjectile = activeProjectile;
			Transform activeProjectile2 = (Transform)(object)_activeProjectile;
			if ((object)_activeProjectile == null || ((UnityEngine.Object)activeProjectile2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			ShowSeal();
			float num = PInterval();
			bool flag2 = (object)_lastFiringInterval == (object)vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018754D2ABh\"");
			if (!flag2)
			{
				float num2 = PInterval();
				_lastFiringInterval = (float)vector;
				base.ResetFiringTimer();
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core._arcanaManager;
				if (core._arcanaManager != null)
				{
					if (arcanaManager._hasAstronomia)
					{
						GameManager core2 = GM.Core;
						core2._arcanaManager.TriggerAstronomia(this);
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
		}
		throw new NullReferenceException();
	}

	public unsafe void FlashScreen(Projectile projectile)
	{
		//IL_06d1: Expected O, but got I4
		//IL_06eb: Expected O, but got I4
		//IL_028a: Expected I, but got O
		//IL_02f4: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_047d: Expected O, but got I4
		//IL_0543: Expected I, but got O
		//IL_0607: Expected O, but got I4
		//IL_008c->IL06f9: Incompatible stack heights: 0 vs 1
		//IL_006e->IL06f9: Incompatible stack heights: 0 vs 1
		//IL_0712->IL00c3: Incompatible stack heights: 1 vs 0
		//IL_068f->IL068f: Incompatible stack heights: 4 vs 1
		//IL_0637->IL0637: Incompatible stack heights: 16 vs 4
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		bool flag2 = (object)projectile == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		bool num;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if ((object)projectile != null)
				{
					object obj3 = (object)projectile - (object)_activeProjectile;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				bool flag5 = (object)projectile == null;
				num = flag5;
				flag4 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		if (_rgbTween != null)
		{
			_rgbTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		Projectile whiteDot = (Projectile)(object)_WhiteDot;
		_B = 1f;
		_G = 1f;
		_R = 1f;
		_A = 0f;
		bool flag6 = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
		num = flag6;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, ref value);
		if (_canFlash)
		{
			GameManager core = GM.Core;
			bool flag7 = (object)GM.Core == null;
			bool flag8 = core._playerOptions == null;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag9 = config == null;
			if (config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				bool flag10 = array == null;
				void* value2 = ((IntPtr*)(&array))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				bool flag11 = obj4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag12 = tweenConfig == null;
				((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag13 = dictionary == null;
				object value3 = default(object);
				bool flag14 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_A", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
				_ = 1;
				((GameMonoBehaviour)(object)tweenConfig)._onPauseSent = true;
				MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
				_alphaTween = alphaTween;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				bool flag15 = array2 == null;
				void* value4 = ((IntPtr*)(&array2))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				bool flag16 = obj5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag17 = tweenConfig2 == null;
				((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag18 = dictionary2 == null;
				object value5 = default(object);
				bool flag19 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_R", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value6 = default(object);
				bool flag20 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_G", value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value7 = default(object);
				bool flag21 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_B", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1112014848;
				_ = 0;
				((GameMonoBehaviour)(object)tweenConfig2)._onPauseSent = true;
				MultiTargetTween rgbTween = Tweens.Add(tweenConfig2);
				_rgbTween = rgbTween;
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				bool flag22 = array3 == null;
				void* value8 = ((IntPtr*)(&array3))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				bool flag23 = obj6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag24 = tweenConfig3 == null;
				((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag25 = dictionary3 == null;
				object value9 = default(object);
				bool flag26 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_R", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value10 = default(object);
				bool flag27 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_G", value10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value11 = default(object);
				bool flag28 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_B", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				_ = 1120403456;
				((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1103626240;
				_ = 0;
				((GameMonoBehaviour)(object)tweenConfig3)._onPauseSent = true;
				MultiTargetTween rgbTween2 = Tweens.Add(tweenConfig3);
				_rgbTween = rgbTween2;
			}
			_canFlash = false;
			Action onComplete = delegate
			{
				_canFlash = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public unsafe void SpinSeal(float durationMillis, float scale, float alpha, Projectile projectile)
	{
		//IL_0371: Expected O, but got I4
		//IL_038b: Expected O, but got I4
		//IL_0215: Expected O, but got Ref
		//IL_01c5: Expected O, but got I
		//IL_030f: Expected O, but got I
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		object obj = default(object);
		bool flag2 = obj == null;
		object obj2 = flag2 & flag;
		bool flag3 = obj2 == null;
		object obj3 = !flag3;
		if (obj3 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if (obj != null)
				{
					object obj4 = obj - (object)_activeProjectile;
					flag4 = obj4 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ stack_28+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		float duration = durationMillis * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, alpha, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj5 = num + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _GroundSeal.transform;
		float duration2 = durationMillis * 0.001f;
		object obj6 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj6), duration2);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj7 = num2 + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public unsafe void HideSeal(Projectile projectile)
	{
		//IL_0251: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_0175: Expected O, but got Ref
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		bool flag2 = (object)projectile == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if ((object)projectile != null)
				{
					object obj3 = (object)projectile - (object)_activeProjectile;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, 0f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _GroundSeal.transform;
		object obj4 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj4), 0.3f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		Action onComplete = delegate
		{
			base.Fire();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void InitGroundSeal()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
		if ((object)_GroundSeal != null)
		{
			Transform transform = _GroundSeal.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ShowSeal()
	{
		//IL_0122: Expected O, but got Ref
		//IL_0247->IL01bd: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL01bd: Incompatible stack heights: 1 vs 0
		//IL_0264->IL01bd: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
		if ((object)_GroundSeal != null)
		{
			Transform transform = _GroundSeal.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, 0.2f, 3.0000002f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore != null && (object)_GroundSeal != null)
				{
					Transform target = _GroundSeal.transform;
					object obj = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 3.0000002f);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore2 != null)
					{
						return;
					}
				}
			}
		}
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
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot2).m_CachedPtr, 29);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void GeneratePool()
	{
		//IL_003b: Expected I4, but got I8
		string text = ((UnityEngine.Object)_ExplosionVFXPrefab).GetName();
		ObjectPool explosionPool = ObjectPool.Create(_ExplosionVFXPrefab, text, 10, -1);
		_explosionPool = explosionPool;
		ObjectPool explosionPool2 = _explosionPool;
		explosionPool2._incrementalInstanceNames = true;
		ObjectPool explosionPool3 = _explosionPool;
		if (!explosionPool3._003CInitialized_003Ek__BackingField)
		{
			explosionPool3._003CInitialized_003Ek__BackingField = true;
			explosionPool3.AutoFillName();
			explosionPool3.Populate(explosionPool3._defaultSize);
		}
		ObjectPool explosionPool4 = _explosionPool;
		MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(explosionPool4._name, _explosionPool);
	}

	private void _003CFlashScreen_003Eb__23_0()
	{
		_canFlash = true;
	}

	private void _003CMakeLevelOne_003Eb__26_0()
	{
		base.Fire();
	}
}
