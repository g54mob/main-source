using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Dominus3_Weapon : Weapon
{
	private SpriteRenderer _Renderer;

	private SpriteRenderer _ZoneRenderer;

	private Tween _angleTween;

	private Sequence _fadeTween;

	private Sequence _fadeTween2;

	private List<bool> _cachedInRange;

	private const float _baseDamageValue = 3f;

	private const float _baseStatBonusValue = 0.08f;

	private int _statBonusMultiplier;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Diabologue05", "ThosePeople");
		_Renderer.sprite = sprite;
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PInterval()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		return currentWeaponData._003Cinterval_003Ek__BackingField;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0071: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_09e3: Expected O, but got Ref
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Expected O, but got Unknown
		//IL_058c: Expected I4, but got I8
		//IL_0894: Expected I4, but got I8
		//IL_010c->IL095e: Incompatible stack heights: 5 vs 1
		base.InitWeapon(characterController, weaponType);
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = null;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = null;
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			bool flag2 = core._characters == null;
			if ((nint)tweenerCore < characters._size)
			{
				List<bool> cachedInRange = _cachedInRange;
				bool flag3 = _cachedInRange == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v100 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v100 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v100 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v100 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r8_v60+18]");
				if (num >= 0)
				{
					_cachedInRange.AddWithResize(false);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v100 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					object obj2 = (nint)0 + (nint)1;
					_ = 0;
				}
				tweenerCore2 = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(tweenerCore2 + 1);
				core = GM.Core;
				bool flag5 = (object)GM.Core == null;
				tweenerCore = tweenerCore2;
				continue;
			}
			break;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Renderer, 0.25f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ZoneRenderer, 0.25f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> renderer = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)_Renderer;
		bool flag6 = (object)_Renderer == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rbx_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
		Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		object obj3 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj3), 12.000001f, RotateMode.FastBeyond360);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
		bool flag8 = tweenerCore3 == null;
		_angleTween = tweenerCore3;
		Sequence fadeTween = DOTween.Sequence();
		_fadeTween = fadeTween;
		Sequence sequence = TweenSettingsExtensions.SetDelay(_fadeTween, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleSprite.DOFade(_Renderer, 0.5f, 2f);
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_fadeTween, (Tween)tweenerCore4, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_fadeTween, (Tween)tweenerCore4, 0f);
		}
		Sequence fadeTween2 = _fadeTween;
		object message;
		if (_fadeTween != null)
		{
			if (((Tween)fadeTween2)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)fadeTween2).creationLocked)
				{
					float duration = ((Tween)fadeTween2).duration + 0.1f;
					fadeTween2.lastTweenInsertTime = ((Tween)fadeTween2).duration;
					((Tween)fadeTween2).duration = duration;
					goto IL_050a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_050a;
		IL_050a:
		Sequence fadeTween3 = _fadeTween;
		if (_fadeTween != null && ((Tween)fadeTween3)._003Cactive_003Ek__BackingField && !((Tween)fadeTween3).creationLocked)
		{
			((Tween)fadeTween3).loops = -1;
			((Tween)fadeTween3).loopType = LoopType.Yoyo;
			if (((ABSSequentiable)fadeTween3).tweenType == TweenType.Tweener)
			{
				((Tween)fadeTween3).fullDuration = 1f / 0f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag9 = _fadeTween == null;
		Sequence fadeTween4 = DOTween.Sequence();
		_fadeTween2 = fadeTween4;
		Sequence sequence3 = TweenSettingsExtensions.SetDelay(_fadeTween2, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleSprite.DOFade(_ZoneRenderer, 0.5f, 2f);
		if (tweenerCore5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_fadeTween2, (Tween)tweenerCore5, false))
		{
			Sequence sequence4 = Sequence.DoInsert(_fadeTween2, (Tween)tweenerCore5, 0f);
		}
		Sequence fadeTween5 = _fadeTween2;
		object message2;
		if (_fadeTween2 != null)
		{
			if (((Tween)fadeTween5)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)fadeTween5).creationLocked)
				{
					float duration2 = ((Tween)fadeTween5).duration + 0.1f;
					fadeTween5.lastTweenInsertTime = ((Tween)fadeTween5).duration;
					((Tween)fadeTween5).duration = duration2;
					goto IL_0812;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_0812;
		IL_0812:
		Sequence fadeTween6 = _fadeTween2;
		if (_fadeTween2 != null && ((Tween)fadeTween6)._003Cactive_003Ek__BackingField && !((Tween)fadeTween6).creationLocked)
		{
			((Tween)fadeTween6).loops = -1;
			((Tween)fadeTween6).loopType = LoopType.Yoyo;
			if (((ABSSequentiable)fadeTween6).tweenType == TweenType.Tweener)
			{
				((Tween)fadeTween6).fullDuration = 1f / 0f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag10 = _fadeTween2 == null;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0072: Expected O, but got Ref
		float num = PInterval();
		float num2 = default(float);
		bool flag = _lastFiringInterval == num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187414861h\"");
		if (!flag)
		{
			float num3 = PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			float num4 = (float)((Equipment)this)._003CLevel_003Ek__BackingField + 3f;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		ClearStatBonuses();
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
		SpriteRenderer zoneRenderer = _ZoneRenderer;
		if ((object)_ZoneRenderer != null && ((UnityEngine.Object)zoneRenderer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject3 = _ZoneRenderer.gameObject;
			if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject4 = _ZoneRenderer.gameObject;
				gameObject4.SetActive(value: false);
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
		if (_fadeTween2 != null)
		{
			TweenExtensions.Kill(_fadeTween2);
		}
	}

	public override void InternalUpdate()
	{
		//IL_0019: Expected I4, but got I8
		//IL_0032: Expected I4, but got I8
		base.InternalUpdate();
		_Renderer.sortingOrder = -1998;
		_ZoneRenderer.sortingOrder = -1998;
		UpdateRendererScaleToArea(_Renderer, 0.85f);
		UpdateRendererScaleToArea(_ZoneRenderer, 0.9f);
		UpdateStatBonuses();
	}

	private bool IsCharacterInRange(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0215: Expected O, but got I4
		//IL_022f: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_0168: Invalid comparison between F4 and O
		float num = base.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = num2 * 50f;
		float num4 = num3 * num3;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)character == null;
		object obj2 = flag2 & flag;
		bool flag3 = obj2 == null;
		object obj3 = !flag3;
		if (obj3 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)character != null)
				{
					object obj4 = (object)character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj4 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				if ((object)character == null)
				{
					goto IL_018c;
				}
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				if ((object)character != null)
				{
					float2 position = character.position;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						object obj5 = position2 - position;
						object obj7 = default(object);
						object obj8 = default(object);
						object obj6 = obj7 - obj8;
						object obj9 = obj5 * obj5;
						object obj10 = obj6 * obj6;
						object obj11 = obj9 + obj10;
						bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11);
						return !flag5;
					}
				}
				goto IL_018c;
			}
		}
		return true;
		IL_018c:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void UpdateStatBonuses()
	{
		//IL_00fb: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_01e0: Expected O, but got I
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		ClearStatBonuses();
		List<bool> cachedInRange = _cachedInRange;
		_statBonusMultiplier = ((Equipment)this)._003CLevel_003Ek__BackingField;
		while (true)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v4 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			if ((nint)0 >= (nint)characters._size)
			{
				break;
			}
			List<bool> cachedInRange2 = _cachedInRange;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v11+18]");
			if (num >= 0)
			{
				cachedInRange2.AddWithResize(false);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 0;
			}
			cachedInRange = _cachedInRange;
		}
		GameManager core2 = GM.Core;
		object obj3 = 0;
		object obj4 = 0;
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
			if ((nint)obj4 < characters2._size)
			{
				GameManager core3 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core3._characters;
				if ((nint)obj3 >= characters3._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
				bool flag = IsCharacterInRange(items[obj3]);
				List<bool> cachedInRange3 = _cachedInRange;
				object obj5 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				if (flag)
				{
					ApplyStatBonuses(items[obj3]);
				}
				obj3++;
				core2 = GM.Core;
				bool flag2 = (object)GM.Core != null;
				obj4 = obj3;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void ApplyStatBonuses(VampireSurvivors.Objects.Characters.CharacterController character, bool addStats = true)
	{
		//IL_0031: Expected O, but got I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		object obj = (addStats ? 1 : 0) * 2;
		object obj2 = obj - 1;
		PlayerModifierStats playerStats = character._playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float num = (float)obj2 * 0.08f;
		float num2 = num * (float)_statBonusMultiplier;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = num2 + eggFloat._val;
		playerStats._003CPower_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = character._playerStats;
		EggFloat eggFloat3 = playerStats2._003CArea_003Ek__BackingField;
		float num3 = (float)obj2 * 0.08f;
		float num4 = num3 * (float)_statBonusMultiplier;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = num4 + eggFloat3._val;
		playerStats2._003CArea_003Ek__BackingField = eggFloat4;
		PlayerModifierStats playerStats3 = character._playerStats;
		EggFloat eggFloat5 = playerStats3._003CSpeed_003Ek__BackingField;
		float num5 = (float)obj2 * 0.08f;
		float num6 = num5 * (float)_statBonusMultiplier;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = num6 + eggFloat5._val;
		playerStats3._003CSpeed_003Ek__BackingField = eggFloat6;
		PlayerModifierStats playerStats4 = character._playerStats;
		EggFloat eggFloat7 = playerStats4._003CDuration_003Ek__BackingField;
		float num7 = (float)obj2 * 0.08f;
		float num8 = num7 * (float)_statBonusMultiplier;
		float value4 = default(float);
		EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
		value4 = num8 + eggFloat7._val;
		playerStats4._003CDuration_003Ek__BackingField = eggFloat8;
	}

	private void ClearStatBonuses()
	{
		//IL_0101: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_01d6: Expected I, but got O
		List<bool> cachedInRange = _cachedInRange;
		while (true)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v5 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			if ((nint)0 >= (nint)characters._size)
			{
				break;
			}
			List<bool> cachedInRange2 = _cachedInRange;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v9+18]");
			if (num >= 0)
			{
				cachedInRange2.AddWithResize(false);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 0;
			}
			cachedInRange = _cachedInRange;
			nint num2 = 0;
		}
		GameManager core2 = GM.Core;
		object obj3 = 0;
		object obj4 = 0;
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
			if ((nint)obj4 < characters2._size)
			{
				List<bool> cachedInRange3 = _cachedInRange;
				object obj5 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v11 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v11 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v3+20+v85 @ rcx_v8]");
				if ((nint)0 != 0)
				{
					GameManager core3 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					ApplyStatBonuses(character, addStats: false);
					nint num2 = unchecked((nint)null);
				}
				obj3++;
				core2 = GM.Core;
				bool flag = (object)GM.Core != null;
				obj4 = obj3;
				if (!flag)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private float GetRadius()
	{
		float num = base.PArea();
		object obj = default(object);
		return (float)obj * 0.01f;
	}

	private void UpdateRendererScaleToArea(SpriteRenderer renderer, float multiplier = 1f)
	{
		Transform transform = renderer.transform;
		float num = base.PArea();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_Renderer.enabled = visible;
		_ZoneRenderer.enabled = visible;
	}

	public TP_Dominus3_Weapon()
	{
		List<bool> cachedInRange = new List<bool>();
		_cachedInRange = cachedInRange;
		_statBonusMultiplier = 1;
		base._002Ector();
	}
}
