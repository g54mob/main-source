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

public class LaurelWeapon : Weapon
{
	private sealed class _003CDelayAFrame_003Ed__9(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LaurelWeapon _003C_003E4__this;

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

	private float _worldScreenHeight = 1f;

	private Tween _angleTween;

	private Sequence _fadeTween;

	private int _maxCharges = 3;

	private bool _hasThorns;

	private bool _wasActiveOnMadeInvisible;

	public override float PAmount()
	{
		return 1f;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_012d: Expected O, but got Ref
		//IL_0444: Expected I4, but got I8
		//IL_05b5->IL04f6: Incompatible stack heights: 1 vs 0
		//IL_0102->IL04f6: Incompatible stack heights: 1 vs 0
		//IL_0669->IL04f6: Incompatible stack heights: 1 vs 0
		//IL_0688->IL04f6: Incompatible stack heights: 1 vs 0
		//IL_04ce->IL04f6: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			Camera main2 = Camera.main;
			if ((object)main2 == null)
			{
				goto IL_0545;
			}
			float orthographicSize = main2.orthographicSize;
			float worldScreenHeight = orthographicSize + orthographicSize;
			_worldScreenHeight = worldScreenHeight;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Renderer, 0.3f);
		if ((object)_Renderer != null)
		{
			Transform transform = _Renderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if ((object)_Renderer != null)
				{
					_Renderer.enabled = false;
					if ((object)_Renderer != null)
					{
						Transform target = _Renderer.transform;
						Vector3 vector = default(Vector3);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector), 12.000001f, RotateMode.FastBeyond360);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									if (((UnityEngine.Object)(object)tweenerCore).m_CachedPtr == (IntPtr)0)
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
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
								((LaurelWeapon)(object)action).CheckColorEvent((GameplaySignals.CharacterLostShieldSignal)this);
								if (_signalBus != null)
								{
									((LaurelWeapon)(object)_signalBus).CheckColorEvent((GameplaySignals.CharacterLostShieldSignal)action);
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
			throw new NullReferenceException();
		}
		goto IL_0545;
		IL_0545:
		throw new NullReferenceException();
	}

	private IEnumerator DelayAFrame()
	{
		_003CDelayAFrame_003Ed__9 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0038: Invalid comparison between I4 and F4
		//IL_004e: Expected F4, but got I4
		//IL_0082: Invalid comparison between I4 and F4
		//IL_0095: Expected F4, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = !((float)currentWeaponData._003Ccharges_003Ek__BackingField > playerStats._003CShields_003Ek__BackingField);
		float num = currentWeaponData._003Ccharges_003Ek__BackingField;
		if (!flag)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			bool flag2 = !((float)_maxCharges > playerStats2._003CShields_003Ek__BackingField);
			num = _maxCharges;
			if (!flag2)
			{
				num = ++playerStats2._003CShields_003Ek__BackingField;
			}
		}
		CheckColor();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._hasAstronomia)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerAstronomia(this);
		}
		if (!_hasThorns)
		{
			float num2 = base.PInterval();
			bool flag3 = _lastFiringInterval == num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018752B67Eh\"");
			if (!flag3)
			{
				float num3 = base.PInterval();
				_lastFiringInterval = num;
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
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((LaurelWeapon)(object)action).CheckColorEvent((GameplaySignals.CharacterLostShieldSignal)this);
		((LaurelWeapon)(object)_signalBus).CheckColorEvent((GameplaySignals.CharacterLostShieldSignal)action);
	}

	public override void InternalUpdate()
	{
		//IL_0055: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected I4, but got Unknown
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
		//IL_0257: Expected I4, but got O
		//IL_0090: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_0111: Expected O, but got I
		if (!LevelUp(skipFire: false))
		{
			goto IL_021b;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v9 (System.Object)+18]");
					if ((nint)obj2 >= 0)
					{
						goto IL_0257;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v9 (System.Object)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v9 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						object obj4 = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v10+20+v259 @ rax_v12*8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v10+20+v259 @ rax_v12*8]");
						if ((nint)0 == 0)
						{
							goto IL_021b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v16+158]");
						if ((nint)0 == 0)
						{
							goto IL_0215;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v16+158]");
							if ((nint)0 == 0)
							{
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
								goto IL_0257;
							}
							object obj6 = default(object);
							float shieldInvulTime = (float)obj6 + characterController._shieldInvulTime;
							characterController._shieldInvulTime = shieldInvulTime;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
								object message = default(object);
								Debug.Log(message);
								goto IL_0215;
							}
						}
					}
				}
			}
		}
		goto IL_0249;
		IL_0257:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0249;
		IL_0249:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_021b:
		return false;
		IL_0215:
		return true;
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

	private void CheckColorEvent(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
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
		CheckColor();
	}

	private void CheckColor()
	{
		//IL_00fb: Invalid comparison between F4 and I4
		_Renderer.enabled = true;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		if (1f < playerStats._003CShields_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018752BF12h\"");
			if (playerStats._003CShields_003Ek__BackingField == 2f)
			{
				SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_Renderer, 8978312u);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018752BF90h\"");
			if (playerStats._003CShields_003Ek__BackingField == 3f)
			{
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_Renderer, 16776960u);
				return;
			}
		}
		else
		{
			bool flag = playerStats._003CShields_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018752BF58h\"");
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018752BF90h\"");
				if (playerStats._003CShields_003Ek__BackingField == 1f)
				{
					SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(_Renderer, 8947967u);
					return;
				}
			}
		}
		_Renderer.enabled = false;
	}
}
