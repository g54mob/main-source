using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GarlicWeapon : Weapon
{
	private SpriteRenderer _Renderer;

	private Tween _rotateTweenHandle;

	private Sequence _fadeTween;

	private bool _cooldownAffectedByMovement;

	private const float Mul = 166.66667f;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_004a: Expected O, but got Ref
		//IL_02e1: Expected I4, but got I8
		base.InitWeapon(characterController, weaponType);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Renderer, 0.1f);
		UpdateRendererScaleToArea();
		Transform target = _Renderer.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj), 6.0000005f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
		_rotateTweenHandle = tweenerCore;
		Sequence fadeTween = DOTween.Sequence();
		_fadeTween = fadeTween;
		Sequence sequence = TweenSettingsExtensions.SetDelay(_fadeTween, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_Renderer, 0.3f, 1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
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
		Sequence fadeTween3 = _fadeTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fadeTween3.stringId = "DefaultGameTweenId";
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
		if (_rotateTweenHandle != null)
		{
			TweenExtensions.Kill(_rotateTweenHandle);
		}
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
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
		int sortingOrder = obj2 + depth;
		_Renderer.sortingOrder = sortingOrder;
		UpdateRendererScaleToArea();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num2 = deltaTime * 1000f;
		float num3 = (base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = deltaTime2 * 1000f;
			float num5 = frameWalk * 100f;
			num3 = num4 / 166.66667f;
			float num6 = num5 * num3;
			float num7 = num6 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num7;
		}
		float num8 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num3))
		{
			float num9 = base.PInterval();
			float num10 = base._003CTotalTime_003Ek__BackingField - num3;
			base._003CTotalTime_003Ek__BackingField = num10;
			base.Fire();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		UpdateRendererScaleToArea();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._hasAstronomia)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerAstronomia(this);
		}
		base.Fire(skipTriggers);
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = projectile.transform;
			if ((object)transform == null)
			{
				return (Projectile)(object)new NullReferenceException();
			}
			transform.SetParent(_cachedTransform, worldPositionStays: true);
		}
		return projectile;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		CheckBeginningArcana();
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PPower()
	{
		float num = base.PPower();
		float bloodlineArmorValue = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineArmorValue;
		return num + num;
	}

	private void UpdateRendererScaleToArea()
	{
		Transform transform = _Renderer.transform;
		float num = base.PArea();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_Renderer.enabled = visible;
	}
}
