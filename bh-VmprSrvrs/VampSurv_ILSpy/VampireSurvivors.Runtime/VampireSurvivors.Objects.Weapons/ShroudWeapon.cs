using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class ShroudWeapon : Weapon
{
	private sealed class _003CDelayAFrame_003Ed__9(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ShroudWeapon _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Fire();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private SpriteRenderer _Renderer;

	private Sequence _fadeTween;

	private Tween _angleTween;

	private int _maxCharges = 3;

	private bool _hasThorns;

	private float _lastReceivedDamage;

	private bool _wasActiveOnMadeInvisible;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCurse();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num3 = _lastReceivedDamage + currentWeaponData._003Cpower_003Ek__BackingField;
					float num4 = num3 * num;
					float num5 = num4 * num;
					return num + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_013a: Expected O, but got Ref
		//IL_0454: Expected I4, but got I8
		//IL_010f->IL053d: Incompatible stack heights: 1 vs 0
		//IL_0635->IL053d: Incompatible stack heights: 1 vs 0
		//IL_0654->IL053d: Incompatible stack heights: 1 vs 0
		//IL_04de->IL053d: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			PlayerModifierStats playerStats = characterController2._playerStats;
			if (characterController2._playerStats != null)
			{
				playerStats._003CShroud_003Ek__BackingField = 10f;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Renderer, 0.3f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_Renderer, 16777215u);
				if ((object)_Renderer != null)
				{
					Transform transform = _Renderer.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v15 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v15 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					_Renderer.enabled = false;
					if (_angleTween != null)
					{
						TweenExtensions.Kill(_angleTween);
					}
					if ((object)_Renderer != null)
					{
						Transform target = _Renderer.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&value), 12.000001f, RotateMode.FastBeyond360);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore != null)
						{
							_angleTween = tweenerCore;
							Sequence fadeTween = DOTween.Sequence();
							_fadeTween = fadeTween;
							Sequence sequence = TweenSettingsExtensions.SetDelay(_fadeTween, 0.1f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_Renderer, 0.6f, 2f);
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v990 @ rax_v36 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							if (TweenSettingsExtensions.ValidateAddToSequence(_fadeTween, (Tween)tweenerCore2, false))
							{
								Sequence sequence2 = Sequence.DoInsert(_fadeTween, (Tween)tweenerCore2, 0f);
							}
							Sequence sequence3 = TweenSettingsExtensions.AppendInterval(_fadeTween, 0.1f);
							Sequence fadeTween2 = _fadeTween;
							if (_fadeTween != null && ((Tween)fadeTween2)._003Cactive_003Ek__BackingField && !((Tween)fadeTween2).creationLocked)
							{
								((Tween)fadeTween2).loops = -1;
								((Tween)fadeTween2).loopType = LoopType.Yoyo;
								if (((ABSSequentiable)fadeTween2).tweenType == TweenType.Tweener)
								{
									((Tween)fadeTween2).fullDuration = 1f / 0f;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (_fadeTween != null)
							{
								Action<GameplaySignals.CharacterLostShieldSignal> action = null;
								((ShroudWeapon)(object)action).OnLostShield((GameplaySignals.CharacterLostShieldSignal)this);
								if (_signalBus != null)
								{
									((ShroudWeapon)(object)_signalBus).OnLostShield((GameplaySignals.CharacterLostShieldSignal)action);
									_003CDelayAFrame_003Ed__9 obj = null;
									obj._003C_003E1__state = 0;
									obj._003C_003E4__this = this;
									Coroutine coroutine = StartCoroutine(obj);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator DelayAFrame()
	{
		_003CDelayAFrame_003Ed__9 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0042: Invalid comparison between I4 and F4
		//IL_0135: Expected O, but got Ref
		//IL_007f: Invalid comparison between I4 and F4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		WeaponData currentWeaponData = _currentWeaponData;
		if ((float)currentWeaponData._003Ccharges_003Ek__BackingField > playerStats._003CShields_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			if ((float)_maxCharges > playerStats2._003CShields_003Ek__BackingField)
			{
				float num = playerStats2._003CShields_003Ek__BackingField + 1f;
				playerStats2._003CShields_003Ek__BackingField = num;
			}
		}
		object obj = default(object);
		CheckColor((GameplaySignals.CharacterLostShieldSignal)(&obj));
		if (!_hasThorns)
		{
			float num2 = base.PInterval();
			float num3 = default(float);
			bool flag = _lastFiringInterval == num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018754663Fh\"");
			if (!flag)
			{
				float num4 = base.PInterval();
				_lastFiringInterval = num3;
				base.ResetFiringTimer();
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
		}
		else
		{
			Fire(false);
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		SpriteRenderer renderer = _Renderer;
		if ((object)_Renderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Renderer.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _Renderer.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((ShroudWeapon)(object)action).OnLostShield((GameplaySignals.CharacterLostShieldSignal)this);
			((ShroudWeapon)(object)_signalBus).OnLostShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
	}

	public override void InternalUpdate()
	{
		//IL_005a: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I4, but got Unknown
		base.InternalUpdate();
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		int sortingOrder = depth - obj2;
		_Renderer.sortingOrder = sortingOrder;
	}

	public override bool LevelUp()
	{
		//IL_020b: Expected I4, but got O
		//IL_0090: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_0111: Expected O, but got I
		if (!LevelUp(skipFire: false))
		{
			goto IL_01cf;
		}
		if (_dataManager != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			if (convertedWeapons != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)((Equipment)this)._equipmentType);
				if (obj != null)
				{
					object obj2 = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v9 (System.Object)+18]");
					if ((nint)obj2 >= 0)
					{
						goto IL_020b;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v9 (System.Object)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v9 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						object obj4 = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v10+20+v236 @ rax_v12*8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v10+20+v236 @ rax_v12*8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v16+158]");
							if ((nint)0 != 0)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
								{
									goto IL_01fd;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v16+158]");
								if ((nint)0 == 0)
								{
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
									goto IL_020b;
								}
								object obj6 = default(object);
								float shieldInvulTime = (float)obj6 + characterController._shieldInvulTime;
								characterController._shieldInvulTime = shieldInvulTime;
							}
							return true;
						}
						goto IL_01cf;
					}
				}
			}
		}
		goto IL_01fd;
		IL_01cf:
		return false;
		IL_01fd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_020b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_01fd;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (visible)
		{
			if (_wasActiveOnMadeInvisible)
			{
				_Renderer.enabled = true;
			}
		}
		else
		{
			bool isVisible = _Renderer.isVisible;
			_wasActiveOnMadeInvisible = isVisible;
			_Renderer.enabled = false;
		}
	}

	protected override void OnStart()
	{
		//IL_006a: Expected I, but got O
		//IL_010d: Expected I, but got O
		base.ResetFiringTimer();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		playerStats._003CShroud_003Ek__BackingField = 10f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShroudWeapon>)+390]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShroudWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_projectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void OnLostShield(GameplaySignals.CharacterLostShieldSignal sig)
	{
		//IL_0117: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_00be: Expected O, but got Ref
		VampireSurvivors.Objects.Characters.CharacterController character = sig.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)sig.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)sig.Character != null)
				{
					object obj3 = (object)sig.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		object obj4 = default(object);
		CheckColor((GameplaySignals.CharacterLostShieldSignal)(&obj4));
	}

	private unsafe void CheckColor(GameplaySignals.CharacterLostShieldSignal sig)
	{
		//IL_0103: Invalid comparison between F4 and I4
		//IL_0191: Invalid comparison between I4 and F4
		//IL_01d6: Expected native int or pointer, but got O
		_Renderer.enabled = true;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		if (1f < playerStats._003CShields_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875470E6h\"");
			if (playerStats._003CShields_003Ek__BackingField == 2f)
			{
				SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_Renderer, 16746496u);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018754715Bh\"");
				if (playerStats._003CShields_003Ek__BackingField != 3f)
				{
					goto IL_016e;
				}
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_Renderer, 16711680u);
			}
			goto IL_0183;
		}
		bool flag = playerStats._003CShields_003Ek__BackingField == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187547126h\"");
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018754715Bh\"");
			if (playerStats._003CShields_003Ek__BackingField == 1f)
			{
				SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(_Renderer, 16776960u);
				goto IL_0183;
			}
		}
		goto IL_016e;
		IL_0183:
		if (0f < sig.DamageAmount)
		{
			if (sig.DamageAmount > 100f)
			{
				((GameplaySignals.CharacterLostShieldSignal*)(nint)sig)->DamageAmount = 100f;
			}
			float lastReceivedDamage = sig.DamageAmount * 0.1f;
			_lastReceivedDamage = lastReceivedDamage;
			base.Fire(false);
		}
		return;
		IL_016e:
		_Renderer.enabled = false;
		goto IL_0183;
	}
}
